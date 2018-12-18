using System;
using System.Drawing;
using System.Windows.Forms;


namespace tams4a.Forms
{
    public partial class FormDisplaySettings : Form
    {
        private MainWindow mainWindow = null;
        public FormDisplaySettings(Form callingForm, string currentRoadColoring)
        {
            mainWindow = callingForm as MainWindow;
            InitializeComponent();
            if (mainWindow.uxMap.BackColor == Color.White) radioButtonLight.Checked = true;
            else radioButtonDark.Checked = true;
            if (mainWindow.rslBlue.Visible || mainWindow.treatmentRoutine.Visible) radioButtonOn.Checked = true;
            else radioButtonOff.Checked = true;
            if (currentRoadColoring == "RSL") comboBoxRoadColors.SelectedIndex = 0;
            if (currentRoadColoring == "Treatment") comboBoxRoadColors.SelectedIndex = 1;
        }

        private void radioButtonLight_CheckedChanged(object sender, EventArgs e)
        {
            mainWindow.uxMap.BackColor = Color.White;
            mainWindow.road.labelColor = Color.Black;
            mainWindow.road.symbols.setSymbolizer();
            mainWindow.Project.map.Refresh();
        }

        private void radioButtonDark_CheckedChanged(object sender, EventArgs e)
        {
            mainWindow.uxMap.BackColor = Color.Black;
            mainWindow.road.labelColor = Color.LightGray;
            mainWindow.road.symbols.setSymbolizer();
            mainWindow.Project.map.Refresh();
        }

        private void radioButtonOn_CheckedChanged(object sender, EventArgs e)
        {
            getLegend();
        }

        private void radioButtonOff_CheckedChanged(object sender, EventArgs e)
        {
            hideLegend();
        }

        private void hideLegend()
        {
            mainWindow.rslBlue.Visible = false;
            mainWindow.rslDeepSkyBlue.Visible = false;
            mainWindow.rslGreen.Visible = false;
            mainWindow.rslLimeGreen.Visible = false;
            mainWindow.rslYellow.Visible = false;
            mainWindow.rslOrange.Visible = false;
            mainWindow.rslRed.Visible = false;
            mainWindow.rslDarkRed.Visible = false;
            mainWindow.treatmentRoutine.Visible = false;
            mainWindow.treatmentPatching.Visible = false;
            mainWindow.treatmentPreventative.Visible = false;
            mainWindow.treatmentPreventativePatching.Visible = false;
            mainWindow.treatmentRehabilitation.Visible = false;
            mainWindow.treatmentReconstruction.Visible = false;
        }

        private void getLegend()
        {
            hideLegend();
            if (comboBoxRoadColors.Text == "RSL")
            {
                mainWindow.rslBlue.Visible = true;
                mainWindow.rslDeepSkyBlue.Visible = true;
                mainWindow.rslGreen.Visible = true;
                mainWindow.rslLimeGreen.Visible = true;
                mainWindow.rslYellow.Visible = true;
                mainWindow.rslOrange.Visible = true;
                mainWindow.rslRed.Visible = true;
                mainWindow.rslDarkRed.Visible = true;
            }
            if (comboBoxRoadColors.Text == "Treatment")
            {
                mainWindow.treatmentRoutine.Visible = true;
                mainWindow.treatmentPatching.Visible = true;
                mainWindow.treatmentPreventative.Visible = true;
                mainWindow.treatmentPreventativePatching.Visible = true;
                mainWindow.treatmentRehabilitation.Visible = true;
                mainWindow.treatmentReconstruction.Visible = true;
            }
        }

        private void comboBoxRoadColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButtonOn.Checked)getLegend();
            mainWindow.road.roadColors = comboBoxRoadColors.Text;
            mainWindow.road.symbols.setSymbolizer();
            mainWindow.Project.map.Refresh();
        }
    }
}
