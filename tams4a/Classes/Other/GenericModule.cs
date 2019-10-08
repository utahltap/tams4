using DotSpatial.Symbology;
using DotSpatial.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using tams4a.Controls;
using tams4a.Forms;
using tams4a.Classes.Other;
using DotSpatial.Data;
using DotSpatial.Plugins.ShapeEditor;

namespace tams4a.Classes
{
    class GenericModule : ProjectModule
    {
        static private readonly string itemSelectionSql = @"SELECT * from miscellaneous WHERE TAMSID IN ([[IDLIST]]);";
        private bool inClick = false;
        int maxTAMSID = 0;
        private Dictionary<string, string> icons;
        private bool movingLandmark = false;
        private bool addLandmark = false;
        private Color originalColor;
        private OtherReports reports;

        public GenericModule(TamsProject theProject, TabPage controlPage, ToolStripMenuItem[] boundButtons, string mn = "miscellaneous") : base(theProject, controlPage, boundButtons, itemSelectionSql)
        {
            ModuleName = mn;
            reports = new OtherReports(theProject, this);

            boundButtons[1].Click += new EventHandler(delegate (object sender, EventArgs e) { reports.SidewalkReport(sender, e); });
            boundButtons[2].Click += new EventHandler(delegate (object sender, EventArgs e) { reports.RoadReport(sender, e); });
            boundButtons[3].Click += new EventHandler(delegate (object sender, EventArgs e) { reports.RampReport(sender, e); });
            boundButtons[4].Click += new EventHandler(delegate (object sender, EventArgs e) { reports.DrainageReport(sender, e); }); ;
            boundButtons[5].Click += new EventHandler(delegate (object sender, EventArgs e) { reports.AccidentReport(sender, e); });
            boundButtons[6].Click += new EventHandler(delegate (object sender, EventArgs e) { reports.OtherReport(sender, e); });
            boundButtons[7].Click += new EventHandler(delegate (object sender, EventArgs e) { reports.RoadsWithSidewalks(sender, e); });

            setControlPanel();

            ModuleSettings.Add(new ProjectSetting(name: ModuleName + "_file", module: ModuleName));
            ModuleSettings.Add(new ProjectSetting(name: ModuleName + "_relative", module: ModuleName));

            FieldSettingToDbColumn = new Dictionary<string, string>()
            {
                { ModuleName + "_f_TAMSID", "TAMSID" }
            };

            icons = new Dictionary<string, string>()
            {
                { "Severe Road Distress", "road" },
                { "Other", "other" },
                { "ADA Ramp", "ramp" },
                { "Sidewalk", "sidewalk" },
                { "Drainage", "drainage" },
                { "Accident", "accident" }
            };

            Project.map.ResetBuffer();
            Project.map.Update();
        }

        private void enableControls()
        {
            Panel_Other controls = getOtherControls();

            controls.groupBoxType.Enabled = true;
            controls.toolStrip.Enabled = true;
            controls.groupBoxProperties.Enabled = true;
            controls.toolStripButtonRemove.Enabled = tamsids.Count == 1;
        }

        private void newSHPFile(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "GIS ShapeFile (*.SHP)|*.shp";
            if (save.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string filename = save.FileName;
            if (createSHPFile(filename))
            {
                openFile(filename, "point");
                ProjectSetting shpSetting = new ProjectSetting(name: ModuleName + "_file", value: Filepath, module: ModuleName);
                ProjectSetting shpRelative = new ProjectSetting(name: ModuleName + "_relative", value: Util.MakeRelativePath(Properties.Settings.Default.lastProject, Filepath), module: ModuleName);
                Project.settings.SetSetting(shpSetting);
                Project.settings.SetSetting(shpRelative);
            }
        }

        public override bool openFile(string thePath = "", string type = "point")
        {
            if (type == "") { type = "point"; }
            if (type != "point") { throw new Exception("Generic module requires a point-type shp file"); }

            ModuleSettings.Add(new ProjectSetting(name: ModuleName + "_f_TAMSID", module: ModuleName, value: "",
                    display_text: "SHP field with a unique identifier (TAMSID).", display_type: "field",
                    description: "The unique identify for objects in this layer.", required: true));

            injectSettings();

            if (!base.openFile(thePath, type)) { return false; }

            ControlsPage.Controls.Remove(ControlsPage.Controls["MODULEADD"]);
            Panel_Other panel = new Panel_Other(Project);
            panel.Name = "OTHERCONTROLS";
            panel.Dock = DockStyle.Fill;
            ControlsPage.Controls.Add(panel);

            #region eventhandlers
            panel.toolStripMoveLandmark.Click += moveLandmark;
            panel.setChangedHandler(controlChanged);
            panel.toolStripButtonSave.Click += saveHandler;
            panel.toolStripButtonCancel.Click += cancelChanges;
            panel.toolStripDropDownAddObject.Click += toggleAddFeature;
            panel.clickMapToolStripMenuItem.Click += clickMap;
            panel.enterCoordinatesToolStripMenuItem.Click += enterCoordinates;
            panel.toolStripButtonRemove.Click += deleteFeature;

            panel.setOtherDateToolStripMenuItem.Click += selectRecordDate;
            panel.setTodayToolStripMenuItem.Click += resetRecordDate;
            panel.pictureBoxPhoto.Click += clickPhotoBox;
            Project.map.MouseUp += moveLandmarkMouseUp;
            #endregion

            setMaxID();
            setSymbolizer();
            disableDisplay();
            resetDisplay();
            resetSaveCondition();

            return true;
        }

        private void resetDisplay()
        {
            getOtherControls().clearValues();
            resetSaveCondition();
        }

        private void disableDisplay()
        {
            Panel_Other controls = getOtherControls();
            resetSaveCondition();
            controls.groupBoxProperties.Enabled = false;
            controls.groupBoxType.Enabled = false;
            controls.toolStripButtonSave.Enabled = false;
            controls.toolStripButtonCancel.Enabled = false;
            controls.toolStripButtonRemove.Enabled = false;
        }

        private bool createSHPFile(string filename)
        {
            PointShapefile pointLayer = new PointShapefile();
            pointLayer.Projection = DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984;
            pointLayer.DataTable.Columns.Add("FID");
            pointLayer.DataTable.Columns.Add("TAMSID");
            try
            {
                pointLayer.SaveAs(filename, true);
            }
            catch (Exception e)
            {
                Log.Error("Could not create ShapeFile" + Environment.NewLine + e.ToString());
                return false;
            }
            return true;
        }

        private void setMaxID()
        {
            DataTable tmp = Database.GetDataByQuery(Project.conn, "SELECT MAX(TAMSID) FROM miscellaneous");
            maxTAMSID = tmp.Rows.Count > 0 ? Util.ToInt(tmp.Rows[0]["MAX(TAMSID)"].ToString()) : 0;
        }

        override protected void setSymbolizer()
        {
            int baseWidth = 48;

            PointScheme ftrScheme = new PointScheme();

            PointCategory catDef = new PointCategory(Properties.Resources.feature, baseWidth);
            catDef.LegendText = "No Info";
            catDef.SelectionSymbolizer.ScaleMode = ScaleMode.Geographic;
            catDef.SelectionSymbolizer.SetOutline(Color.Cyan, baseWidth / 4);
            catDef.Symbolizer.ScaleMode = ScaleMode.Geographic;
            ftrScheme.AddCategory(catDef);

            Image[] images = {
                Properties.Resources.feature,
                Properties.Resources.important,
                Properties.Resources.question,
                Properties.Resources.problem,
                Properties.Resources.ramp,
                Properties.Resources.sidewalk,
                Properties.Resources.feature,
                Properties.Resources.problem,
                Properties.Resources.pooling,
                Properties.Resources.crash
            };
            string[] iconNames = { "feature", "important", "question", "problem", "ramp", "sidewalk", "other", "road", "drainage", "accident"};

            for (int i = 0; i < images.Length; i++)
            {
                PointCategory cat = new PointCategory(images[i], baseWidth);
                cat.FilterExpression = "[TAMSICON] = '" + iconNames[i] + "'";
                cat.SelectionSymbolizer.ScaleMode = ScaleMode.Geographic;
                cat.SelectionSymbolizer.SetOutline(Color.Cyan, baseWidth / 4);
                cat.Symbolizer.ScaleMode = ScaleMode.Geographic;
                ftrScheme.AddCategory(cat);
            }

            ((MapPointLayer)Layer).Symbology = ftrScheme;
            ((MapPointLayer)Layer).ApplyScheme(ftrScheme);
        }

        private void moveLandmark(object sender, EventArgs e)
        {
            Panel_Other otherControls = getOtherControls();
            if (otherControls.toolStripMoveLandmark.BackColor == Color.LightSkyBlue)
            {
                movingLandmark = false;
                Project.map.FunctionMode = FunctionMode.Select;
                otherControls.toolStripMoveLandmark.BackColor = originalColor;
                return;
            }
            toggleAddFeature(sender, e);
            originalColor = otherControls.toolStripMoveLandmark.BackColor;
            otherControls.toolStripMoveLandmark.BackColor = Color.LightSkyBlue;
            IFeatureLayer selectionLayer = (IFeatureLayer)Layer;
            MoveVertexFunction moveLandmark = new MoveVertexFunction(Project.map);
            moveLandmark.Map = Project.map;
            moveLandmark.YieldStyle = YieldStyles.LeftButton | YieldStyles.RightButton;
            if (Project.map.MapFunctions.Contains(moveLandmark) == false)
            {
                Project.map.MapFunctions.Add(moveLandmark);
            }
            Project.map.FunctionMode = FunctionMode.None;
            Project.map.Cursor = Cursors.Cross;
            moveLandmark.DeselectFeature();
            moveLandmark.Layer = selectionLayer;
            SetSnapLayers(moveLandmark);
            moveLandmark.Activate();
            movingLandmark = true;
        }

        private void moveLandmarkMouseUp(object sender, MouseEventArgs e)
        {
            Panel_Other otherControls = getOtherControls();
            if (e.Button == MouseButtons.Right && otherControls.toolStripMoveLandmark.BackColor == Color.LightSkyBlue)
            {
                otherControls.toolStripMoveLandmark.BackColor = originalColor;
                moveLandmark(sender, e);
                return;
            }
            if (!movingLandmark) return;
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            Properties.Settings.Default.Save();
            selectionLayer.ClearSelection();
            selectionLayer.DataSet.Save();
            setSymbolizer();
            Project.map.Invalidate();
            Project.map.Refresh();
            Project.map.ResetBuffer();
            Project.map.Update();
            if (otherControls.toolStripMoveLandmark.BackColor != originalColor) return;
            movingLandmark = false;
            Project.map.FunctionMode = FunctionMode.Select;
            otherControls.toolStripMoveLandmark.BackColor = originalColor;
        }

        private void SetSnapLayers(SnappableMapFunction func)
        {
            func.DoSnapping = true;
            IFeatureLayer selectionLayer = (IFeatureLayer)Layer;
            foreach (var layer in Project.map.Layers)
            {
                IFeatureLayer fl = layer as IFeatureLayer;
                if (fl != null && fl != selectionLayer && fl.DataSet.FeatureType != selectionLayer.DataSet.FeatureType)
                    func.AddLayerToSnap(fl);
            }
        }

        protected override void clearControlPanel()
        {
            ControlsPage.Controls.Remove(ControlsPage.Controls["OTHERCONTROLS"]);
            setControlPanel();
        }

        override public void selectionChanged()
        {
            if (!isOpen()) { return; }

            if (UnsavedChanges)
            {
                DialogResult rslt = MessageBox.Show("Unsaved changes detected! Would you like to save the changes? Otherwise, they will be discared",
                    "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (rslt == DialogResult.Yes) saveHandler(null, null);
                if (rslt == DialogResult.Cancel) return;
            }

            resetDisplay();
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            ISelection shpSelection = selectionLayer.Selection;

            if (shpSelection.Count <= 0)
            {
                disableDisplay();
                return;
            }

            selectionLayer.ZoomToSelectedFeatures();
            Project.map.ZoomOut();
            Project.map.ZoomOut();

            tamsids = new List<string>();
            string tamsidcolumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");

            foreach (DataRow row in selectionLayer.Selection.ToFeatureSet().DataTable.Rows)
            {
                tamsids.Add(row[tamsidcolumn].ToString());
            }
            enableControls();
            Dictionary<string, string> values = setSegmentValues(selectionLayer.Selection.ToFeatureSet().DataTable);
            getOtherControls().updateDisplay(values);
            updatePhotoPreview(getOtherControls().pictureBoxPhoto, getOtherControls().textBoxPhotoFile.Text);
            resetSaveCondition();
        }

        private void setControlPanel()
        {
            Panel_Module_OpenShp create = new Panel_Module_OpenShp(ModuleName);
            create.Name = "MODULEADD";
            create.Controls.Clear();
            Button newFile = new Button();
            newFile.Text = "Create Point SHP File";
            newFile.Size = new Size(196, 54);
            newFile.Location = new Point(10, 10);
            newFile.Click += newSHPFile;
            create.Controls.Add(newFile);
            create.Dock = DockStyle.Fill;
            ControlsPage.Controls.Add(create);
        }

        private Panel_Other getOtherControls()
        {
            Panel_Other controls;

            try
            {
                controls = (Panel_Other)ControlsPage.Controls["OTHERCONTROLS"];
            }
            catch (Exception e)
            {
                Log.Error("Could not retrieve controls page.\n" + e.ToString());
                throw new Exception("Could not retrieve controls page.\n" + e.ToString());
            }
            return controls;
        }

        protected override void controlChanged(object sender, EventArgs e)
        {
            Panel_Other controls = getOtherControls();

            controls.toolStripButtonSave.Enabled = true;
            controls.toolStripButtonSave.BackColor = Color.Red;
            UnsavedChanges = true;
            
            controls.toolStripButtonCancel.Enabled = true;
        }

        public void saveHandler(object sender, EventArgs e)
        {
            Panel_Other controls = getOtherControls();
            if (!controls.toolStripButtonSave.Enabled) return;
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            ISelection shpSelection = selectionLayer.Selection;
            string tamsidcolumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");

            Dictionary<string, string> values = new Dictionary<string, string>();
            values["type"] = controls.comboBoxObject.Text;
            values["icon"] = Util.DictionaryItemString(icons, controls.comboBoxObject.Text);
            values["address"] = controls.textBoxAddress.Text;
            values["description"] = controls.textBoxDescription.Text;
            values["photo"] = controls.textBoxPhotoFile.Text;
            values["property1"] = controls.getProperty(values["type"], 0);
            values["property2"] = controls.getProperty(values["type"], 1);
            values["property3"] = controls.getProperty(values["type"], 2);
            values["property4"] = controls.getProperty(values["type"], 3);
            values["notes"] = controls.getProperty(values["type"], 4);

            if (!string.IsNullOrWhiteSpace(controls.textBoxPhotoFile.Text))
            {
                Properties.Settings.Default.lastPhoto = controls.textBoxPhotoFile.Text;
            }

            for (int i = 0; i < tamsids.Count; i++)
            {
                values["TAMSID"] = tamsids[i];
                Dictionary<string, string> v = new Dictionary<string, string>();

                foreach (string key in values.Keys)
                {
                    v[key] = values[key];
                    if ((string.IsNullOrWhiteSpace(values[key]) || values[key].Equals("multi") || values[key].Equals("-1") || key.Equals("category")) && selectionValues.Count > 1)
                    {
                        if (i < selectionValues.Count && selectionValues[i].ContainsKey(key))
                        {
                            v[key] = selectionValues[i][key];
                        }
                    }
                }

                if (!Database.ReplaceRow(Project.conn, v, ModuleName))
                {
                    MessageBox.Show("Could not save data!");
                }
            }

            string tamsidsCSV = string.Join(",", tamsids.ToArray());
            foreach (DataRow row in selectionLayer.DataSet.DataTable.Select(tamsidcolumn + " IN (" + tamsidsCSV + ")"))
            {
                row["TAMSICON"] = values["icon"];
            }

            resetDisplay();
            disableDisplay();
            Properties.Settings.Default.Save();
            selectionLayer.ClearSelection();
            selectionLayer.DataSet.Save();
            setSymbolizer();
            Project.map.Invalidate();
            Project.map.Refresh();
            Project.map.ResetBuffer();
            Project.map.Update();

        }

        private void cancelChanges(object sender, EventArgs e)
        {
            resetSaveCondition();
            selectionChanged();
        }

        private void resetSaveCondition()
        {
            UnsavedChanges = false;
            Panel_Other controls = getOtherControls();
            
            controls.toolStripButtonSave.Enabled = false;
            controls.toolStripButtonSave.BackColor = default(Color);
        }

        private void addFeature(double lat, double lon)
        {
            MapPointLayer mpl = (MapPointLayer)Layer;
            double[] xy = { lon, lat };
            double[] z = { 0 };
            DotSpatial.Projections.Reproject.ReprojectPoints(xy, z, DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984, mpl.Projection, 0, 1);
            DotSpatial.Topology.Point newPost = new DotSpatial.Topology.Point(xy[0], xy[1]);
            IFeature np = mpl.DataSet.AddFeature(newPost);
            maxTAMSID++;
            string[] cols = { "FID", ModuleName + "_f_TAMSID", "TAMSICON"};
            PrepareDatatable(np.DataRow.Table, cols);
            np.DataRow["FID"] = maxTAMSID;
            np.DataRow[Project.settings.GetValue(ModuleName + "_f_TAMSID")] = maxTAMSID;
            np.DataRow["TAMSICON"] = "feature";
            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                {"TAMSID", maxTAMSID.ToString() },
                {"icon", "feature" }
            };
            Database.ReplaceRow(Project.conn, values, "miscellaneous");
            mpl.DataSet.Save();
            mpl.ClearSelection();
            setSymbolizer();
            Project.map.Invalidate();
            Project.map.Refresh();
            Project.map.ResetBuffer();
            Project.map.Update();
            if (mpl.DataSet.NumRows() == 1)
            {
                mpl.Extent.SetValues(xy[0] - 100, xy[1] - 100, xy[0] + 100, xy[1] + 100);
                Project.map.ViewExtents = mpl.Extent;
            }
        }

        private void enterCoordinates(object sender, EventArgs e)
        {
            FormLatLon dlg = new FormLatLon();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                double lat, lon;
                if (dlg.tabControlDegree.SelectedTab == dlg.tabPageDecimal)
                {
                    lat = Util.ToDouble(dlg.textBoxLatitude.Text) * (dlg.radioButtonNorth1.Checked ? 1 : -1);
                    lon = Util.ToDouble(dlg.textBoxLongitude.Text) * (dlg.radioButtonEast1.Checked ? 1 : -1);
                }
                else
                {
                    lat = (Util.ToDouble(dlg.textBoxLatDeg.Text) + Util.ToDouble(dlg.textBoxLatMin.Text) / 60 + Util.ToDouble(dlg.textBoxLatSec.Text) / 3600) * (dlg.radioButtonNorth2.Checked ? 1 : -1);
                    lon = (Util.ToDouble(dlg.textBoxLonDeg.Text) + Util.ToDouble(dlg.textBoxLonMin.Text) / 60 + Util.ToDouble(dlg.textBoxLonSec.Text) / 3600) * (dlg.radioButtonEast2.Checked ? 1 : -1);
                }
                addFeature(lat, lon);
            }
            dlg.Close();
        }

        private void clickMap(object sender, EventArgs e)
        {
            Panel_Other otherControls = getOtherControls();

            bool hasStreetMap = false;
            bool hasSignMap = false;
            addLandmark = !addLandmark;

            if (!addLandmark)
            {
                Project.map.MouseUp -= mapMouseUp;
                otherControls.toolStripDropDownAddObject.BackColor = originalColor;
                return;
            }
            otherControls.toolStripDropDownAddObject.BackColor = Color.LightSkyBlue;

            for (int i = 0; i < Project.map.Layers.Count; i++)
            {
                if (((FeatureLayer)Project.map.Layers[i]).Name.Contains("road"))
                {
                    hasStreetMap = true;
                }
                if (((FeatureLayer)Project.map.Layers[i]).Name.Contains("sign"))
                {
                    if (((FeatureLayer)Project.map.Layers[i]).FeatureSet.DataTable.Rows.Count > 0)
                    {
                        hasSignMap = true;
                    }
                }
            }

            if (Project.map.GetMaxExtent().IsEmpty() || (Layer.Extent.IsEmpty() && !hasStreetMap && !hasSignMap))
            {
                MessageBox.Show("Map has no view extent, please open a road SHP file or add feature support by coordinates.", "No view extent", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Project.map.MouseClick += new MouseEventHandler(delegate(object _sender, MouseEventArgs _e) { determineLeftClick(_sender, _e); });
            Project.map.MouseUp += mapMouseUp;
        }

        private void toggleAddFeature(object sender, EventArgs e)
        {
            Panel_Other otherControls = getOtherControls();

            if (otherControls.toolStripMoveLandmark.BackColor == Color.LightSkyBlue)
            {
                movingLandmark = false;
                Project.map.FunctionMode = FunctionMode.Select;
                otherControls.toolStripMoveLandmark.BackColor = originalColor;
            }

            if (otherControls.toolStripDropDownAddObject.BackColor == Color.LightSkyBlue)
            {
                addLandmark = true;
                clickMap(sender, e);
            }
        }

        private void mapMouseUp(object sender, MouseEventArgs e)
        {
            inClick = false;
        }

        private void determineLeftClick(object sender, MouseEventArgs e)
        {
            if (!addLandmark || inClick) return;
            if (e.Button == MouseButtons.Right) return;
            inClick = true;
            addFeatureByClick();
        }

        private void addFeatureByClick()
        {
            var clickCoords = Project.map.PixelToProj(Project.map.PointToClient(Cursor.Position));
            double[] xy = { clickCoords.X, clickCoords.Y };
            double[] z = { clickCoords.Z };
            DotSpatial.Projections.Reproject.ReprojectPoints(xy, z, Project.map.Projection, DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984, 0, 1);
            if (double.IsInfinity(xy[0]) || double.IsInfinity(xy[1]))
            {
                MessageBox.Show("There appears to be a problem with the projection of your shapefile. Consider reprojecting your shapefiles using ArcMap or MapWindow.");
                Log.Error("Coordinate is Infinity or NaN " + Environment.NewLine + Environment.StackTrace);
            }
            try
            {
                addFeature(xy[1], xy[0]);
            }
            catch (Exception err)
            {
                Log.Error("something went terribly wrong: " + err.ToString());
            }
        }

        protected void selectRecordDate(object sender, EventArgs e)
        {
            dateForm.Show();
            Panel_Other controls = getOtherControls();
            controls.setTodayToolStripMenuItem.Checked = false;
            controls.setOtherDateToolStripMenuItem.Checked = true;
        }


        protected void resetRecordDate(object sender, EventArgs e)
        {
            surveyDate = DateTime.Now;
            Panel_Other controls = getOtherControls();
            controls.setTodayToolStripMenuItem.Checked = true;
            controls.setOtherDateToolStripMenuItem.Checked = false;
        }

        private void deleteFeature(object sender, EventArgs e)
        {
            toggleAddFeature(sender, e);
            string[] tables = { ModuleName };
            deleteShape(tamsids[0], tables);
        }

        private void clickPhotoBox(object sender, EventArgs e)
        {
            Panel_Other controls = getOtherControls();
            string photo_column = "";
            if (controls.comboBoxObject.Text == "Sidewalk") photo_column = "sidewalk_photos";
            else if (controls.comboBoxObject.Text == "ADA Ramp") photo_column = "ada_photos";
            else if (controls.comboBoxObject.Text == "Severe Road Distress") photo_column = "severe_distress_photos";
            else if (controls.comboBoxObject.Text == "Accident") photo_column = "accident_photos";
            else if (controls.comboBoxObject.Text == "Drainage") photo_column = "drainage_photos";
            else if (controls.comboBoxObject.Text == "Other") photo_column = "other_photos";

            string subPath = Database.GetDataByQuery(Project.conn, "SELECT " + photo_column + " FROM photo_paths;").Rows[0][0].ToString();
            enlargePicture(controls.textBoxPhotoFile.Text, subPath);
        }
    }
}