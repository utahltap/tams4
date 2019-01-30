using System;
using System.IO;
using System.Windows.Forms;

namespace tams4a.Forms
{
    public partial class FormStartup : Form
    {
        private Classes.TamsProject Project;                    // need reference to the project
        String lastProjectFile;

        /// <summary>
        /// Brings up a window asking user which project to open or start a new project
        /// </summary>
        /// <param name="project">Reference to the current project</param>
        public FormStartup(Classes.TamsProject project)
        {
            InitializeComponent();
            CenterToScreen();
            Project = project;

            labelBuild.Text = "version " + Program.GetBuild();

            if (String.IsNullOrEmpty(Properties.Settings.Default.lastProject))
            {
                labelRecent.Text = "(no recent project)";
                buttonContinue.Enabled = false;
                lastProjectFile = "";
            } else {
                labelRecent.Text = "(" + Properties.Settings.Default.lastProject + ")";
                buttonContinue.Enabled = true;
                lastProjectFile = Properties.Settings.Default.lastProject;
            }
        }

        /// <summary>
        /// Prompts user to create a new .tams project
        /// </summary>
        /// <param name="sender">source of the event</param>
        /// <param name="e">.net event arguments</param>
        private void button_StartNew_click(object sender, EventArgs e)
        {
            String filename;

            Properties.Settings.Default.newProject = true;

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "TAMS Project Files (*.tams)|*.tams";

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
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            filename = saveDialog.FileName;
            // save the directory for future use.
            Properties.Settings.Default.lastFolder = Path.GetDirectoryName(filename);
            Properties.Settings.Default.Save();

            if (!Project.startNew(filename))
            {
                MessageBox.Show("Could not create " + filename);
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Opens an .net OpenFileDialog to allow the user to select an existing .tams project to open.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_openExisting_Click(object sender, EventArgs e)
        {
            String filename;

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "TAMS Project Files (*.tams)|*.tams";
            openDialog.Multiselect = false;

            try
            {
                openDialog.InitialDirectory = Properties.Settings.Default.lastFolder;
            }
            catch
            {
                openDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            }
            DialogResult clickedOk = openDialog.ShowDialog();

            if (clickedOk != DialogResult.OK)
            {
                return;
            }

            filename = openDialog.FileName;
            openProjectFile(filename);
        }

        /// <summary>
        /// Opens the last .tams project file that was in use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonContinue_Click(object sender, EventArgs e)
        {
            openProjectFile(lastProjectFile);
        }

        /// <summary>
        /// Attempts to open .tams project file.
        /// </summary>
        /// <param name="filename">The name of the file to be opened</param>
        /// <returns>Whether or not the operation was successful</returns>
        private bool openProjectFile(String filename)
        {
            if (String.IsNullOrEmpty(filename))
            {
                return false;
            }

            // save the directory for future use.  (Even in failure as they may want to continue from there.)
            Properties.Settings.Default.lastFolder = Path.GetDirectoryName(filename);
            Properties.Settings.Default.Save();

            if (!Project.open(filename))
            {
                MessageBox.Show("Could not open " + filename);
                return false;
            } 
            else
            {
                this.DialogResult = DialogResult.OK;
            }

            return true;
        }

        /// <summary>
        /// Quits the application, from this form there is most likely nothing to save.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            // Application.Exit returns to main thread before quitting; and that pops up another of this same form.
            // Don't think I have to save anything anyway, so it's OK to just quit.
            Environment.Exit(0);
        }
    }
}
