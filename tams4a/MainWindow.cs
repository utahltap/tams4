using DotSpatial.Symbology;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tams4a.Classes;
using tams4a.Forms;

namespace tams4a
{
    public partial class MainWindow : Form
    {
        private DotSpatial.Controls.FunctionMode CurrentMode;
        private TamsProject Project;
        private int maxWidth;
        private DotSpatial.Controls.AppManager appManager;
        private DotSpatial.Plugins.WebMap.ServiceProvider webService;
        private DotSpatial.Plugins.WebMap.WebMapPlugin webLayer;
        private Boolean closeForReal = true;

        /// <summary>
        /// Constructor: The main window of TAMS4
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            setEventHandlers();
            InitializeProject();
            //createWebLayer();
        }

        private void InitializeProject()
        {
            Project = new TamsProject(uxMap);
            tabControlControls.TabPages.Clear();

            if (Program.cmdArgs.Length > 0)
            {
                //open project
                String file = Program.cmdArgs[0];
                if (!Project.open(file))
                {
                    MessageBox.Show("Could not open " + file);
                } 
            }

            // Before we can start, we must open a project.
            while (!Project.isOpen)
            {
                FormStartup getProject = new FormStartup(Project);
                getProject.ShowDialog();
            }

            Visible = true;
            ToolStripMenuItem[] lcs = { importRoadsToolStripMenuItem, generalReportToolStripMenuItem, roadsWithPotholesToolStripMenuItem, budgetToolStripMenuItem };
            ToolStripMenuItem[] lcsn = { };
            ModuleRoads road = new ModuleRoads(Project, new TabPage("Roads"), lcs);
            ModuleSigns sign = new ModuleSigns(Project, new TabPage("Signs"), lcsn);
            Project.addModule(road, "Roads", tabControlControls);
            Project.addModule(sign, "Signs", tabControlControls);

            Project.selectModule("Roads");

            toolStripStatusLabel1.Text = Project.projectFilePath;
            toolStripStatusLabel2.Visible = false;
            toolStripProgressBar1.Visible = false;

            CurrentMode = uxMap.FunctionMode;
            maxWidth = (int)uxMap.ViewExtents.Width + 10;
        }

        private void createWebLayer()
        {
            appManager = new DotSpatial.Controls.AppManager();
            appManager.HeaderControl = new DotSpatial.Controls.SpatialHeaderControl();
            appManager.DockManager = new DotSpatial.Controls.SpatialDockManager();
            appManager.ProgressHandler = new DotSpatial.Controls.SpatialStatusStrip();
            appManager.Map = uxMap;
            appManager.LoadExtensions();
            uxMap.Projection = DotSpatial.Projections.KnownCoordinateSystems.Projected.World.WebMercator;
            webService = DotSpatial.Plugins.WebMap.ServiceProviderFactory.Create("GooleMap");
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
            }
            base.OnMouseUp(e);
        }


        // calls the right selection change method depending on the active layers
        private void uxMap_SelectionChanged(object sender, EventArgs e)
        {
            // Shouldn't happen.
            if (uxMap.Layers.SelectedLayer == null) 
            {
                MessageBox.Show("No layer selected");
                return; 
            }

            // shouldn't happen.
            if (!Project.isOpen)
            {
                MessageBox.Show("No project open");
                return;
            }
            Project.mapSelectionChanged(sender, e);
        }

        // settings dialog
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = Project.settings.showDialog();
            if (result == DialogResult.OK && Project.isOpen)
            {
                MessageBox.Show("Attempting to reload settings");
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
    }
}
