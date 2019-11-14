using DotSpatial.Symbology;
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

            FeatureLayer selectionLayer;
            int numLayers = mainWindow.uxMap.Layers.Count;
            if (numLayers > 0)
            {
                selectionLayer = (FeatureLayer)mainWindow.uxMap.Layers[0];
                checkBoxRoad.Checked = !selectionLayer.UseDynamicVisibility;
            }
            else
            {
                checkBoxRoad.Enabled = false;
                checkBoxRoad.Checked = false;
            }

            if (numLayers > 1)
            {
                selectionLayer = (FeatureLayer)mainWindow.uxMap.Layers[1];
                checkBoxSign.Checked = !selectionLayer.UseDynamicVisibility;
            }
            else
            {
                checkBoxSign.Enabled = false;
                checkBoxSign.Checked = false;
            }

            if (numLayers > 2)
            {
                selectionLayer = (FeatureLayer)mainWindow.uxMap.Layers[2];
                checkBoxOther.Checked = !selectionLayer.UseDynamicVisibility;
            }
            else
            {
                checkBoxOther.Enabled = false;
                checkBoxOther.Checked = false;
            }

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

        public void hideLegend()
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

        public void getLegend()
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
                mainWindow.resetLegend(mainWindow.treatmentLegend);
            }
            if (comboBoxRoadColors.Text == "Treatment")
            {
                mainWindow.treatmentRoutine.Visible = true;
                mainWindow.treatmentPatching.Visible = true;
                mainWindow.treatmentPreventative.Visible = true;
                mainWindow.treatmentPreventativePatching.Visible = true;
                mainWindow.treatmentRehabilitation.Visible = true;
                mainWindow.treatmentReconstruction.Visible = true;
                mainWindow.resetLegend(mainWindow.rslLegend);
            }
        }

        private void comboBoxRoadColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButtonOn.Checked)getLegend();
            mainWindow.road.roadColors = comboBoxRoadColors.Text;
            mainWindow.road.symbols.setSymbolizer();
            mainWindow.Project.map.Refresh();
        }

        private void checkBoxRoad_CheckedChanged(object sender, EventArgs e)
        {
            FeatureLayer selectionLayer = (FeatureLayer)mainWindow.uxMap.Layers[0];
            if (!checkBoxRoad.Checked)
            {
                selectionLayer.UseDynamicVisibility = true;
                selectionLayer.DynamicVisibilityMode = DynamicVisibilityMode.ZoomedIn;
                selectionLayer.DynamicVisibilityWidth = 0;
                selectionLayer.ShowLabels = false;
            }
            else
            {
                selectionLayer.UseDynamicVisibility = false;

                // TODO: Needs to pull from settings
                selectionLayer.ShowLabels = true;
            }
            mainWindow.Project.map.Refresh();
        }

        private void checkBoxSign_CheckedChanged(object sender, EventArgs e)
        {
            FeatureLayer selectionLayer = (FeatureLayer)mainWindow.uxMap.Layers[1];
            if (!checkBoxSign.Checked)
            {
                selectionLayer.UseDynamicVisibility = true;
                selectionLayer.DynamicVisibilityMode = DynamicVisibilityMode.ZoomedIn;
                selectionLayer.DynamicVisibilityWidth = 0;
            }
            else selectionLayer.UseDynamicVisibility = false;
            mainWindow.Project.map.Refresh();
        }

        private void checkBoxOther_CheckedChanged(object sender, EventArgs e)
        {
            FeatureLayer selectionLayer = (FeatureLayer)mainWindow.uxMap.Layers[2];
            if (!checkBoxOther.Checked)
            {
                selectionLayer.UseDynamicVisibility = true;
                selectionLayer.DynamicVisibilityMode = DynamicVisibilityMode.ZoomedIn;
                selectionLayer.DynamicVisibilityWidth = 0;
            }
            else selectionLayer.UseDynamicVisibility = false;
            mainWindow.Project.map.Refresh();
        }
    }
}
