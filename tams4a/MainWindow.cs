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

namespace tams4a
{
    public partial class MainWindow : Form
    {
        private DotSpatial.Controls.FunctionMode CurrentMode;
        public TamsProject Project;
        public ModuleRoads road;

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
                customToolStripMenuItem,
                roadToolStripMenuItem,
                roadTypeToolStripMenuItem,
                roadCategoryToolStripMenuItem,
                governingDistressToolStripMenuItem,
                rSLToolStripMenuItem };
            ToolStripMenuItem[] lcsn = { favoriteSignsToolStripMenuItem, signAlertsToolStripMenuItem, signInventoryToolStripMenuItem, supportAlertsToolStripMenuItem, supportInventoryToolStripMenuItem, signToolStripMenuItem};
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
            ModuleSigns sign = new ModuleSigns(Project, new TabPage("Signs"), lcsn);
            GenericModule other = new GenericModule(Project, new TabPage("Other"), lcso);
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
                //if (theme == "light")
                    uxMap.BackColor = Color.White;
                //if (theme == "dark")
                //{
                //    uxMap.BackColor = Color.Black;
                //}
            }
            else
            {
                toolStrip1.Enabled = false;
                uxMap.Enabled = false;
                uxMap.BackColor = Color.LightGray;
            }
            UpdateZoomButtons(sender, e);
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
                MessageBox.Show("A SHP file is required to do that action.");
                return;
            }
            String id = toolStripTextBoxSearch.Text;
            FeatureLayer selectionLayer = (FeatureLayer)uxMap.Layers.SelectedLayer;
            String tamsidcolumn = Project.settings.GetValue(selectionLayer.Name + "_f_TAMSID");
            selectionLayer.SelectByAttribute(tamsidcolumn + " = " + id);
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
            Project.selectModule(tabControlControls.SelectedTab.Text);
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

            if (openCSV.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openCSV.FileName);
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

                FormOutput report = new FormOutput(Project);
                report.dataGridViewReport.DataSource = importedTable;
                report.Text = "Imported Report";
                report.Show();
                MessageBox.Show("Check to make sure the table was imported correctly.\nSave changes if you want to keep them.");

            }
        }
    }
}
