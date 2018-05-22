using DotSpatial.Symbology;
using DotSpatial.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using tams4a.Controls;
using tams4a.Forms;
using DotSpatial.Data;

namespace tams4a.Classes
{
    class GenericModule : ProjectModule
    {
        static private readonly string itemSelectionSql = @"SELECT * from miscellaneous WHERE TAMSID IN ([[IDLIST]]);";
        private string notes;
        int maxTAMSID = 0;

        public GenericModule(TamsProject theProject, TabPage controlPage, ToolStripMenuItem[] boundButtons, string mn = "miscellaneous") : base(theProject, controlPage, boundButtons, itemSelectionSql)
        {
            ModuleName = mn;
            notes = "";

            setControlPanel();

            ModuleSettings.Add(new ProjectSetting(name: ModuleName + "_file", module: ModuleName));
            ModuleSettings.Add(new ProjectSetting(name: ModuleName + "_relative", module: ModuleName));

            FieldSettingToDbColumn = new Dictionary<string, string>()
            {
                { ModuleName + "_f_TAMSID", "TAMSID" }
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
            Panel_Other panel = new Panel_Other();
            panel.Name = "OTHERCONTROLS";
            panel.Dock = DockStyle.Fill;
            ControlsPage.Controls.Add(panel);

            #region eventhandlers
            panel.setChangedHandler(controlChanged);
            panel.toolStripButtonSave.Click += saveHandler;
            panel.toolStripButtonCancel.Click += cancelChanges;
            panel.clickMapToolStripMenuItem.Click += clickMap;
            panel.enterCoordinatesToolStripMenuItem.Click += enterCoordinates;
            #endregion

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

        private void setSymbolizer()
        {
            int baseWidth = 48;

            PointScheme ftrScheme = new PointScheme();

            PointCategory catDef = new PointCategory(Properties.Resources.feature, baseWidth);
            catDef.LegendText = "No Info";
            catDef.SelectionSymbolizer.ScaleMode = ScaleMode.Geographic;
            catDef.SelectionSymbolizer.SetOutline(Color.Cyan, baseWidth / 4);
            catDef.Symbolizer.ScaleMode = ScaleMode.Geographic;
            ftrScheme.AddCategory(catDef);

            Image[] images = { Properties.Resources.feature, Properties.Resources.important, Properties.Resources.question, Properties.Resources.problem};
            string[] iconNames = { "feature", "important", "question", "problem"};

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

        protected override void clearControlPanel()
        {
            ControlsPage.Controls.Remove(ControlsPage.Controls["OTHERCONTROLS"]);
            setControlPanel();
        }

        override public void selectionChanged(object sender, EventArgs e)
        {

            if (!isOpen()) { return; }

            if (UnsavedChanges)
            {


            }

            resetDisplay();
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            ISelection shpSelection = selectionLayer.Selection;

            if (shpSelection.Count <= 0)
            {
                disableDisplay();
                return;
            }

            enableControls();
            Dictionary<string, string> values = setSegmentValues(selectionLayer.Selection.ToFeatureSet().DataTable);
            getOtherControls().updateDisplay(values);
            resetSaveCondition();

            string tamsidcolumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");
            tamsids = new List<string>();
            foreach (DataRow row in selectionLayer.Selection.ToFeatureSet().DataTable.Rows)
            {
                tamsids.Add(row[tamsidcolumn].ToString());
            }
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

        private void updatePhotoPreview()
        {
            Panel_Other controls = getOtherControls();
            if (!string.IsNullOrWhiteSpace(controls.textBoxPhotoFile.Text))
            {
                try
                {
                    string imageLocation = Project.projectFolderPath + @"\Photos\" + controls.textBoxPhotoFile.Text;
                    if (File.Exists(imageLocation))
                    {
                        controls.pictureBoxPhoto.ImageLocation = imageLocation;
                    }
                    else
                    {
                        Log.Warning("Missing image file: " + imageLocation);
                        controls.toolTip.SetToolTip(controls.pictureBoxPhoto, "Missing: " + imageLocation);
                        throw new Exception("Missing image file");
                    }
                }
                catch
                {
                    controls.pictureBoxPhoto.Image = Properties.Resources.error;
                }
            }
            else
            {
                controls.pictureBoxPhoto.Image = Properties.Resources.nophoto;
            }
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
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            ISelection shpSelection = selectionLayer.Selection;
            string tamsidcolumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");

            Panel_Other controls = getOtherControls();
            Dictionary<string, string> values = new Dictionary<string, string>();
            values["type"] = controls.comboBoxObject.Text;
            values["icon"] = controls.comboBoxIcon.Text;
            values["address"] = controls.textBoxAddress.Text;
            values["description"] = controls.textBoxDescription.Text;
            values["photo"] = controls.textBoxPhotoFile.Text;
            values["property1"] = controls.getProperty(values["type"], 0);
            values["property2"] = controls.getProperty(values["type"], 1);
            values["notes"] = controls.getProperty(values["type"], 2);

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

            resetSaveCondition();

            updatePhotoPreview();
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
            selectionChanged(sender, e);
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
            if (!np.DataRow.Table.Columns.Contains("FID"))
            {
                np.DataRow.Table.Columns.Add("FID");
            }
            if (!np.DataRow.Table.Columns.Contains(Project.settings.GetValue(ModuleName + "_f_TAMSID")))
            {
                np.DataRow.Table.Columns.Add(Project.settings.GetValue(ModuleName + "_f_TAMSID"));
            }
            if (!np.DataRow.Table.Columns.Contains("TAMSICON"))
            {
                np.DataRow.Table.Columns.Add("TAMSICON");
            }
            np.DataRow["FID"] = maxTAMSID;
            np.DataRow[Project.settings.GetValue(ModuleName + "_f_TAMSID")] = maxTAMSID;
            np.DataRow["TAMSICON"] = "feature";
            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                {"support_id", maxTAMSID.ToString() },
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
            bool hasStreetMap = false;
            bool hasSignMap = false;
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
            Project.map.Click += addFeatureByClick;
        }

        private void addFeatureByClick(object sender, EventArgs e)
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
            addFeature(xy[1], xy[0]);
            Project.map.Click -= addFeatureByClick;
        }
    }
}