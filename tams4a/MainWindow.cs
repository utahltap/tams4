using DotSpatial.Symbology;
using System;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using tams4a.Classes;
using tams4a.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace tams4a
{
    public partial class MainWindow : Form
    {
        private DotSpatial.Controls.FunctionMode CurrentMode;
        public TamsProject Project;
        public ModuleRoads road;
        public ModuleSigns sign;
        private GenericModule other;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;


        private int maxWidth;
        //private DotSpatial.Controls.AppManager appManager;
        //private DotSpatial.Plugins.WebMap.ServiceProvider webService;
        //private DotSpatial.Plugins.WebMap.WebMapPlugin webLayer;
        private bool closeForReal = true;

        /// <summary>
        /// Constructor: The main window of TAMS4
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            SetUpLegendControls();
            CenterToScreen();
            setEventHandlers();
            displayChangeLog();
            InitializeProject();
            //createWebLayer();
        }

        private void InitializeProject()
        {
            uxMap.Projection = DotSpatial.Projections.KnownCoordinateSystems.Projected.World.WebMercator;
            Project = new TamsProject(uxMap);
            tabControlControls.TabPages.Clear();

            if (Program.cmdArgs.Length > 0)
            {
                string file = Program.cmdArgs[0];
                if (!Project.open(file))
                {
                    MessageBox.Show("Could not open " + file);
                }
            }
            
            while (!Project.isOpen)
            {
                FormStartup getProject = new FormStartup(Project);
                getProject.ShowDialog();
            }

            Visible = true;
            ToolStripMenuItem[] lcs = { importRoadsToolStripMenuItem,
                generalToolStripMenuItem,
                potholesToolStripMenuItem,
                analysisToolStripMenuItem,
                roadToolStripMenuItem,
                surfaceTypeToolStripMenuItem,
                functionalClassificationToolStripMenuItem,
                governingDistressesToolStripMenuItem,
                rSLDistributionToolStripMenuItem };
            ToolStripMenuItem[] lcsn = { favoriteSignsToolStripMenuItem, signInventoryToolStripMenuItem, signRecommendationsToolStripMenuItem, supportInventoryToolStripMenuItem, supportRecommendationsToolStripMenuItem, signToolStripMenuItem };
            ToolStripMenuItem[] lcso = { otherToolStripMenuItem,
                sidewalkDistressToolStripMenuItem,
                severeRoadDistressToolStripMenuItem,
                aDARampsToolStripMenuItem,
                drainageToolStripMenuItem,
                accidentsToolStripMenuItem,
                allOthersToolStripMenuItem,
                roadsWithSidewalksToolStripMenuItem
            };
            road = new ModuleRoads(Project, new TabPage("Roads"), lcs);
            sign = new ModuleSigns(Project, new TabPage("Signs"), lcsn);
            other = new GenericModule(Project, new TabPage("Other"), lcso);
            Project.addModule(road, "Roads", tabControlControls);
            Project.addModule(sign, "Signs", tabControlControls);
            Project.addModule(other, "Other", tabControlControls);

            Project.selectModule("Roads");

            toolStripStatusLabel1.Text = Project.projectFilePath;
            toolStripStatusLabel2.Visible = false;
            toolStripProgressBar1.Visible = false;

            CurrentMode = uxMap.FunctionMode;
            maxWidth = (int)uxMap.ViewExtents.Width + 10;
        }

        private void SetUpLegendControls()
        {
            //
            // Handles Clicks on Legend for changing map display
            //
            rslBlue.MouseDown += new MouseEventHandler(delegate (object sender, MouseEventArgs e) { highlightKey(sender, e, this.rslBlue); });
            rslDeepSkyBlue.MouseDown += new MouseEventHandler(delegate (object sender, MouseEventArgs e) { highlightKey(sender, e, this.rslDeepSkyBlue); });
            rslGreen.MouseDown += new MouseEventHandler(delegate (object sender, MouseEventArgs e) { highlightKey(sender, e, this.rslGreen); });
            rslLimeGreen.MouseDown += new MouseEventHandler(delegate (object sender, MouseEventArgs e) { highlightKey(sender, e, this.rslLimeGreen); });
            rslYellow.MouseDown += new MouseEventHandler(delegate (object sender, MouseEventArgs e) { highlightKey(sender, e, this.rslYellow); });
            rslOrange.MouseDown += new MouseEventHandler(delegate (object sender, MouseEventArgs e) { highlightKey(sender, e, this.rslOrange); });
            rslRed.MouseDown += new MouseEventHandler(delegate (object sender, MouseEventArgs e) { highlightKey(sender, e, this.rslRed); });
            rslDarkRed.MouseDown += new MouseEventHandler(delegate (object sender, MouseEventArgs e) { highlightKey(sender, e, this.rslDarkRed); });
            treatmentRoutine.MouseDown += new MouseEventHandler(delegate (object sender, MouseEventArgs e) { highlightKey(sender, e, this.treatmentRoutine); });
            treatmentPreventative.MouseDown += new MouseEventHandler(delegate (object sender, MouseEventArgs e) { highlightKey(sender, e, this.treatmentPreventative); });
            treatmentPatching.MouseDown += new MouseEventHandler(delegate (object sender, MouseEventArgs e) { highlightKey(sender, e, this.treatmentPatching); });
            treatmentPreventativePatching.MouseDown += new MouseEventHandler(delegate (object sender, MouseEventArgs e) { highlightKey(sender, e, this.treatmentPreventativePatching); });
            treatmentRehabilitation.MouseDown += new MouseEventHandler(delegate (object sender, MouseEventArgs e) { highlightKey(sender, e, this.treatmentRehabilitation); });
            treatmentReconstruction.MouseDown += new MouseEventHandler(delegate (object sender, MouseEventArgs e) { highlightKey(sender, e, this.treatmentReconstruction); });
            treatmentLegend[treatmentPreventative] = Color.Yellow;
            treatmentLegend[treatmentRehabilitation] = Color.Red;
            treatmentLegend[treatmentPreventativePatching] = Color.Orange;
            treatmentLegend[treatmentReconstruction] = Color.DarkRed;
            treatmentLegend[treatmentPatching] = Color.LimeGreen;
            treatmentLegend[treatmentRoutine] = Color.Blue;
            rslLegend[rslBlue] = Color.Blue;
            rslLegend[rslDeepSkyBlue] = Color.DeepSkyBlue;
            rslLegend[rslGreen] = Color.Green;
            rslLegend[rslLimeGreen] = Color.LimeGreen;
            rslLegend[rslYellow] = Color.Yellow;
            rslLegend[rslDarkRed] = Color.DarkRed;
            rslLegend[rslOrange] = Color.Orange;
            rslLegend[rslRed] = Color.Red;
        }



        /*
        private void createWebLayer()
        {
            appManager = new DotSpatial.Controls.AppManager();
            appManager.HeaderControl = new DotSpatial.Controls.SpatialHeaderControl();
            appManager.DockManager = new DotSpatial.Controls.SpatialDockManager();
            appManager.ProgressHandler = new DotSpatial.Controls.SpatialStatusStrip();
            appManager.Map = uxMap;
            appManager.LoadExtensions();
            webService = DotSpatial.Plugins.WebMap.ServiceProviderFactory.Create("GooleMap");
        }
        */

        private void checkHotKeys(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (tabControlControls.SelectedIndex == 0) road.saveHandler(sender, e);
                if (tabControlControls.SelectedIndex == 1) sign.saveHandler(sender, e);
                //if (tabControlControls.SelectedTab.Name == "Other") //do something
            }
        }

        private void setEventHandlers()
        {
            uxMap.Layers.LayerAdded += LayersChangedEventHandler;
            uxMap.Layers.LayerRemoved += LayersChangedEventHandler;
            uxMap.ViewExtentsChanged += UpdateZoomButtons;
        }

        private void LayersChangedEventHandler(object sender, EventArgs e)
        {
            if (uxMap.Layers.Count() > 0)
            {
                toolStrip1.Enabled = true;
                uxMap.Enabled = true;
                uxMap.BackColor = Color.White;
            }
            else
            {
                toolStrip1.Enabled = false;
                uxMap.Enabled = false;
                uxMap.BackColor = Color.LightGray;
            }
            UpdateZoomButtons(sender, e);
        }

        private void ResetLegend(object sender, EventArgs e)
        {
            FormDisplaySettings display = new FormDisplaySettings(this, road.roadColors);
            if (display.radioButtonOff.Checked) return;
            display.getLegend();
        }

        private void toolStripZoomIn_Click(object sender, EventArgs e)
        {
            uxMap.ZoomIn();
            UpdateZoomButtons(sender, e);
        }


        private void toolStripZoomOut_Click(object sender, EventArgs e)
        {
            uxMap.ZoomOut();
            UpdateZoomButtons(sender, e);
        }


        private void toolStripZoomExt_Click(object sender, EventArgs e)
        {
            uxMap.ZoomToMaxExtent();
            maxWidth = (int)uxMap.ViewExtents.Width + 10;
            UpdateZoomButtons(sender, e);
        }


        /// <summary>
        /// Updates the status of zoom buttons based on zoom level.
        /// </summary>
        /// <param name="sender">Source of the event (unused)</param>
        /// <param name="e">event arguments (unused)</param>
        private void UpdateZoomButtons(object sender, EventArgs e)
        {
            if (uxMap.ViewExtents.Width > maxWidth) {
                toolStripZoomOut.Enabled = false;
            }
            else {
                toolStripZoomOut.Enabled = true;
            }
            if (uxMap.ViewExtents.Width < 200) {
                uxMap.ViewExtents.Width = 199;
                toolStripZoomIn.Enabled = false;
            }
            else {
                toolStripZoomIn.Enabled = true;
            }

        }


        /// <summary>
        /// Sets the cursor mode based on the button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setMode_Click(object sender, EventArgs e)
        {
            String button = sender.ToString();

            buttonModePan.CheckState = CheckState.Unchecked;
            buttonModeSelect.CheckState = CheckState.Unchecked;
            buttonModeTable.CheckState = CheckState.Unchecked;
            buttonModeZoomin.CheckState = CheckState.Unchecked;

            switch (button)
            {
                case "Select":
                    buttonModeSelect.CheckState = CheckState.Checked;
                    CurrentMode = uxMap.FunctionMode = DotSpatial.Controls.FunctionMode.Select;
                    break;
                case "Data Table":
                    buttonModeTable.CheckState = CheckState.Checked;
                    CurrentMode = uxMap.FunctionMode = DotSpatial.Controls.FunctionMode.Info;
                    break;
                case "Zoom To Selection":
                    buttonModeZoomin.CheckState = CheckState.Checked;
                    CurrentMode = uxMap.FunctionMode = DotSpatial.Controls.FunctionMode.ZoomIn;
                    break;
                default:
                    buttonModePan.CheckState = CheckState.Checked;
                    CurrentMode = uxMap.FunctionMode = DotSpatial.Controls.FunctionMode.Pan;
                    break;

            }
        }

        //Trick the UI into thinking the left mouse is clicked so panning works with right click
        public void DoMouseClick()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
        }

        /// <summary>
        /// Used to ensure right mouse button always pans
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                uxMap.FunctionMode = DotSpatial.Controls.FunctionMode.Pan;
                DoMouseClick();
            }
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Sets the mode back to the previous mode if the right mouse button was held.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                uxMap.FunctionMode = CurrentMode;
                uxMap.ZoomIn();  //Refresh() and Update() do not working as expected
                uxMap.ZoomOut(); //but somewhere in these methods the map gets refreshed.
            }
            else
            {
                base.OnMouseUp(e);
                uxMap_SelectionChanged();
            }
        }


        // Calls the right selection change method depending on the active layers
        private void uxMap_SelectionChanged()
        {
            // Shouldn't happen.
            if (uxMap.Layers.SelectedLayer == null) 
            {
                MessageBox.Show("No layer selected");
                return; 
            }

            // Shouldn't happen.
            if (!Project.isOpen)
            {
                MessageBox.Show("No project open");
                return;
            }
            Project.mapSelectionChanged();
        }

        private void uxMap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
            }
        }

        // settings dialog
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = Project.settings.showDialog();
            if (result == DialogResult.OK && Project.isOpen)
            {
                MessageBox.Show("Attempting to reload settings.\nSome settings may not be changed until TAMS is restarted.");
                Project.settings.LoadValues();
            }
        }

        /// <summary>
        /// Opens the folder location of the TAMS4 Logs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\tams";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo() {
                FileName = path,
                UseShellExecute = true,
                Verb = "open"
            });
        }

        /// <summary>
        /// Closes project and and allows the project to bring up the initial start form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.cmdArgs = new string[0];
            Project.close();
            //splitContainerMain.Panel2.Controls.Remove(uxMap);
            //uxMap = new DotSpatial.Controls.Map();
            //uxMap.Dock = DockStyle.Fill;
            //uxMap.Enabled = false;
            //uxMap.TabIndex = 1;
            //splitContainerMain.Panel2.Controls.Add(uxMap);
            closeForReal = false;
            Close();
            //InitializeProject();
        }

        /// <summary>
        /// Shows the form for reporting a problem with TAMS4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportProblemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReport report = new FormReport();
            report.Show(this);
        }

        /// <summary>
        /// called when about clicked from toolbar. Displays information about the project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String message = "";
            message += "File: " + Project.projectFilePath + Environment.NewLine;
            message += "TAMS ver: " + Program.GetVersion() + Environment.NewLine;
            message += "DB ver: " + Project.settings.GetValue("version") + Environment.NewLine;
            MessageBox.Show(message, "About TAMS Project", MessageBoxButtons.OK);
        }

        private void window_Resize(object sender, EventArgs e)
        {
            UpdateZoomButtons(sender, e);
            ResetLegend(sender, e);
        }

        /// <summary>
        /// Called when Quit TAMS is selected from the drop down menu. Exits the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitTAMS4_click(object sender, EventArgs e)
        {
            Program.Close();
            Application.Exit();
            Environment.Exit(0);
        }

        private void importRoadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Project.isOpen)
            {
                ImportAccess.importAccessDBRoads(Project.conn);
            }
            else
            {
                MessageBox.Show("Cannot import data without a project.");
            }
        }

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            searchByID();
        }

        private void toolStripTextBoxSearch_keyDown(object sender, KeyEventArgs e)
        {
            if (toolStripTextBoxSearch.Focused && e.KeyCode == Keys.Enter)
            {
                searchByID();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void searchByID()
        {
            if (uxMap.Layers.Count == 0)
            {
                MessageBox.Show("A SHP file is required to do this action.");
                return;
            }
            string input = toolStripTextBoxSearch.Text;
            if (String.IsNullOrEmpty(input)) return;

            //remove spaces before entry
            int j = 0;
            while (input[j] == ' ') j++;
            input = input.Remove(0, j);

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ',')
                {
                    //remove spaces after comma
                    j = 1;
                    while (input[i + j] == ' ') j++;
                    input = input.Remove(i + 1, j - 1);

                    //remove spaces before comma
                    j = 1;
                    while (input[i - j] == ' ') j++;
                    input = input.Remove(i - j + 1, j - 1); 
                }
            }

            string[] ids = input.Split(',').ToArray();

            FeatureLayer selectionLayer = (FeatureLayer)uxMap.Layers.SelectedLayer;
            string layerName = "";
            if (Project.currentModuleName == "Roads") layerName = "road";
            else if (Project.currentModuleName == "Signs") layerName = "sign";
            else layerName = "other";
            foreach (FeatureLayer layer in uxMap.Layers)
            {
                layer.UnSelectAll();
                if (layer.Name.ToString() == layerName) selectionLayer = layer;
            }
            String tamsidcolumn = Project.settings.GetValue(selectionLayer.Name + "_f_TAMSID");

            string searchBy = toolStripComboBoxFind.Text;
            if (searchBy == "ID")
            {                
                foreach (string id in ids)
                {
                int x;
                    if (!Int32.TryParse(id, out x))
                    {
                        MessageBox.Show("'" + id + "' is not a valid input.\nPlease Enter a Number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        continue;
                    }
                    selectionLayer.SelectByAttribute(tamsidcolumn + " = " + id, ModifySelectionMode.Append);
                }
            }

            if (searchBy == "Street")
            {
                foreach (string name in ids)
                {
                    Console.WriteLine(name);
                    DataTable searchName = Database.GetDataByQuery(Project.conn, "SELECT DISTINCT TAMSID FROM road WHERE name LIKE '%" + name + "%';");
                    foreach (DataRow row in searchName.Rows)
                    {
                        selectionLayer.SelectByAttribute(tamsidcolumn + " = " + row["TAMSID"], ModifySelectionMode.Append);
                    }
                }
            }

            if (selectionLayer.Selection.Count == 0)
            {
                MessageBox.Show(searchBy + " Not Found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (layerName == "road") road.selectionChanged();
            if (layerName == "sign") sign.selectionChanged();
            if (layerName == "other") other.selectionChanged();
        }

        private void toolStripButtonSnapShot_Click(object sender, EventArgs e)
        {
            string filename;

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Portable Network Graphic (*.png)|*.png";
            try
            {
                saveDialog.InitialDirectory = Properties.Settings.Default.lastFolder;
            }
            catch
            {
                saveDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            }
            DialogResult dialogResult = saveDialog.ShowDialog();

            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            filename = saveDialog.FileName;
            Bitmap mapSnap = uxMap.SnapShot(1500);
            mapSnap.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void editTreatmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTreatmentEditor et = new FormTreatmentEditor(Project.conn);
            et.ShowDialog();
        }

        private void manuelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.utahltap.org/software/help/");
        }

        /// <summary>
        /// Pontentially problematic workaround, currently, uxMap.ClearLayers() and uxMap.Layers.Clear() causes a problem where
        /// I cannot access the data lists of newly added layers. Closeing the main window of the application causes Application.Run()
        /// to return, a boolean in the main program flags whether or not to run a new application.
        /// 
        /// Ideally, the application would be able to close and start a new project without errors from this main window without
        /// having to do this awkward, dificult to maintain, and potentially dangerous workaround.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeForReal)
            {
                Program.Close();
            }
        }

        private void tabControlControls_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTab = tabControlControls.SelectedTab.Text;
            Project.selectModule(selectedTab);
            if (selectedTab == "Signs" || selectedTab == "Other")
            {
                toolStripComboBoxFind.SelectedIndex = 0;    
                toolStripComboBoxFind.Enabled = false;
            }
            if (selectedTab == "Roads")
            {
                toolStripComboBoxFind.Enabled = true;
            }

        }

        private void displayChangeLog()
        {
            if (!ApplicationDeployment.IsNetworkDeployed)
                return;

            if (System.Diagnostics.Debugger.IsAttached || !ApplicationDeployment.CurrentDeployment.IsFirstRun)
                return;

            if (MessageBox.Show("This appears to be your first time running this version of TAMS would you like to see the latest changes?", "New Version", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes )
            {
                System.Diagnostics.Process.Start("https://github.com/utahltap/tams4/blob/master/changelog.md");
            }
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDisplaySettings formDisplay = new FormDisplaySettings(this, road.roadColors);
            formDisplay.ShowDialog();
        }

        private void importCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openCSV = new OpenFileDialog();
            openCSV.Filter = "CSV Files|*.csv";
            openCSV.Title = "Select a Comma Separtated Value File";

            if (openCSV.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = null;
                try
                {
                    sr = new System.IO.StreamReader(openCSV.FileName);
                }
                catch
                {
                    MessageBox.Show("Failed to import file. Make sure the file is of type 'CSV' and is not open in any other application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string importedCSV = sr.ReadToEnd();
                sr.Close();

                DataTable importedTable = new DataTable();
                string[] rows = importedCSV.Split('\n');
                string[] cols = rows[0].Split(',');
                foreach (string column in cols)
                {
                    if (column == "TAMSID")
                    {
                        importedTable.Columns.Add("ID", typeof(string));
                        continue;
                    }
                    importedTable.Columns.Add(column, typeof(string));
                }

                int i = -1;
                foreach (string row in rows)
                {
                    i++;
                    if (i == 0) continue;
                    string[] thisRow = row.Split(',');
                    importedTable.Rows.Add(thisRow);
                    
                }

                FormImportReport importReport = new FormImportReport();
                importReport.ShowDialog();
                string reportType = importReport.comboBoxReportType.Text;
                if (importReport.cancel) return;

                string updateList = "";

                if (reportType == "Road")
                {
                    updateList = "\n\t\t ID" +
                        "\n\t\t Name" +
                        "\n\t\t Speed Limit" +
                        "\n\t\t Lanes" +
                        "\n\t\t Width (ft)" +
                        "\n\t\t Length (ft)" +
                        "\n\t\t From Addres" +
                        "\n\t\t To Address" +
                        "\n\t\t Surface" +
                        "\n\t\t Treatment" +
                        "\n\t\t RSL" +
                        "\n\t\t Functional Classification" +
                        "\n\t\t Survey Date" +
                        "\n\t\t Fat/Spa/Pot" +
                        "\n\t\t Edg/Joi/Rut" +
                        "\n\t\t Lon/Cor/X-S" +
                        "\n\t\t Pat/Bro/Dra" +
                        "\n\t\t Pot/Fau/Dus" +
                        "\n\t\t Dra/Lon/Agg" +
                        "\n\t\t Tra/Tra/Cor" +
                        "\n\t\t Block/Crack" +
                        "\n\t\t Rutti/Patch" +
                        "\n\nColumns such as 'Cost' and 'Area' are computed when a table is generated. ";
                }
                else if (reportType == "Sign Inventory")
                {
                    updateList = "\n\t\t ID" +
                        "\n\t\t Support ID" +
                        "\n\t\t Description" +
                        "\n\t\t Sign Text" +
                        "\n\t\t Condition" +
                        "\n\t\t Recommendation" +
                        "\n\t\t Reflectivity" +
                        "\n\t\t Sheeting" +
                        "\n\t\t Backing" +
                        "\n\t\t Height (in)" +
                        "\n\t\t Width (in)" +
                        "\n\t\t Mount Height (ft)" +
                        "\n\t\t Direction" +
                        "\n\t\t Category" +
                        "\n\t\t Favorite" +
                        "\n\t\t MUTCD Code" +
                        "\n\t\t Install Date" +
                        "\n\t\t Survey Date \n\n";
                }
                else if (reportType == "Sign Recommendations")
                {
                    updateList = "\n\t\t ID" +
                        "\n\t\t Support ID" +
                        "\n\t\t Address" +
                        "\n\t\t Recommendation" +
                        "\n\t\t Survey Date \n\n";
                }
                else if (reportType == "Support Inventory")
                {
                    updateList = "\n\t\t Support ID" +
                        "\n\t\t Address" +
                        "\n\t\t Material" +
                        "\n\t\t Condition" +
                        "\n\t\t Obstructions" +
                        "\n\t\t Recommendation" +
                        "\n\t\t Road Offset (ft)" +
                        "\n\t\t Height (ft)" +
                        "\n\t\t Category" +
                        "\n\t\t Survey Date \n\n";
                }
                else if (reportType == "Support Recommendations")
                {
                    updateList = "\n\t\t Support ID" +
                        "\n\t\t Address" +
                        "\n\t\t Recommendation" +
                        "\n\t\t Survey Date \n\n";
                }

                else if (reportType == "Roads with Sidewalks")
                {
                    updateList = "\n\t\t ID" +
                        "\n\t\t Sidewalks" +
                        "\n\t\t Comments \n\n";
                }

                else
                {
                    updateList = "\n\t\t ID" +
                        "\n\t\t Address" +
                        "\n\t\t Description";
                    switch (reportType)
                    {
                        case "Sidewalks":
                            updateList += "\n\t\t Faults" +
                                "\n\t\t Breaks" +
                                "\n\t\t Recommendation";
                            break;
                        case "Severe Road Distresses":
                            updateList += "\n\t\t Distress" +
                                "\n\t\t Recommendation";
                            break;
                        case "ADA Ramps":
                            updateList += "\n\t\t Condition" +
                                "\n\t\t Compliant" +
                                "\n\t\t Has Tiles";
                            break;
                        case "Drainage Problems":
                            updateList += "\n\t\t Type" +
                                "\n\t\t Recommendation";
                            break;
                        case "Accident":
                            updateList += "\n\t\t Date" +
                                "\n\t\t Type" +
                                "\n\t\t Severity";
                            break;
                        case "Objects":
                            updateList += "\n\t\t Property 1" +
                                "\n\t\t Property 2";
                            break;
                    }                        
                    updateList += "\n\n";
                }

                FormOutput report = new FormOutput(Project, road, reportType);
                report.dataGridViewReport.DataSource = importedTable;
                report.Text = "Imported Report";
                report.Show();
                MessageBox.Show("Check to make sure the table was imported correctly. " +
                    "Only columns with following headings will be updated:\n" + updateList +
                    "Notes will not be updated because they would be overwritten by the abbreviated note. Save changes if you want to keep them.",
                    "Importing " + reportType + " CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void highlightKey(object sender, MouseEventArgs e, TextBox key)
        {
            bool noneSelected = true;
            bool allSelected = true;
            if (key.BorderStyle == BorderStyle.FixedSingle)
            {
                key.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                key.BorderStyle = BorderStyle.FixedSingle;
            }

            Dictionary<TextBox, Color> currentLegend = new Dictionary<TextBox, Color>();
            if (road.roadColors == "RSL")
            {
                currentLegend = rslLegend;
            }

            if (road.roadColors == "Treatment")
            {
                currentLegend = treatmentLegend;
            }
            foreach (KeyValuePair<TextBox, Color> box in currentLegend)
            {
                if (box.Key.BorderStyle == BorderStyle.Fixed3D)
                {
                    road.symbols.selectedColors[box.Value] = true;
                    box.Key.BackColor = box.Value;
                    allSelected = false;
                    if (box.Value == Color.Yellow || box.Value == Color.Orange)
                    {
                        box.Key.ForeColor = Color.Black;
                    }
                }
                else
                {
                    road.symbols.selectedColors[box.Value] = false;
                    box.Key.BackColor = Color.LightGray;
                    noneSelected = false;
                    if (box.Value == Color.Yellow || box.Value == Color.Orange)
                    {
                        box.Key.ForeColor = Color.White;
                    }
                }
            }
            if (noneSelected || allSelected)
            {
                resetLegend(currentLegend);
            }
            road.symbols.setSymbolizer();
        }

        public void resetLegend(Dictionary<TextBox, Color> currentLegend)
        {
            foreach (KeyValuePair<TextBox, Color> box in currentLegend)
            {
                road.symbols.selectedColors[box.Value] = true;
                box.Key.BackColor = box.Value;
                box.Key.BorderStyle = BorderStyle.FixedSingle;
                if (box.Value == Color.Yellow || box.Value == Color.Orange)
                {
                    box.Key.ForeColor = Color.Black;
                }
            }
        }

        private void customReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomReport customReport = new CustomReport(Project, road, sign, other, this);
            customReport.newCustomReport();
        }
    }
}
