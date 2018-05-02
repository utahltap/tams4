using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tams4a.Controls
{
    public partial class Panel_Sign : Panel_Module
    {
        public Panel_Sign()
        {
            InitializeComponent();

            textBoxAddress.TextChanged += moduleValueChanged;
            comboBoxCondition.SelectionChangeCommitted += moduleValueChanged;
            comboBoxMaterial.SelectionChangeCommitted += moduleValueChanged;
            numericUpDownOffset.ValueChanged += moduleValueChanged;
            numericUpDownHeight.ValueChanged += moduleValueChanged;
            textBoxType.TextChanged += moduleValueChanged;
            textBoxDescription.TextChanged += moduleValueChanged;
            comboBoxSheeting.SelectedValueChanged += moduleValueChanged;
            comboBoxBacking.SelectedValueChanged += moduleValueChanged;
            numericUpDownHeigthSign.ValueChanged += moduleValueChanged;
            numericUpDownWidth.ValueChanged += moduleValueChanged;
            numericUpDownMountHeight.ValueChanged += moduleValueChanged;
            textBoxInstall.TextChanged += moduleValueChanged;
            textBoxText.TextChanged += moduleValueChanged;
            comboBoxReflectivity.SelectionChangeCommitted += moduleValueChanged;
            comboBoxConditionSign.SelectedValueChanged += moduleValueChanged;
            comboBoxObstruction.SelectedValueChanged += moduleValueChanged;
            comboBoxDirection.SelectedValueChanged += moduleValueChanged;
            textBoxPhotoFile.TextChanged += moduleValueChanged;

            new ToolTip().SetToolTip(buttonAdd, "Add New Sign to Post");
            new ToolTip().SetToolTip(buttonRemove, "Remove Sign from Post");
            new ToolTip().SetToolTip(buttonInstallDate, "Set Install Date of Sign");
            new ToolTip().SetToolTip(buttonFavorite, "Add Sign to Favorites");
            new ToolTip().SetToolTip(buttonSignNote, "Add Note to Sign");

            AutoScroll = true;
        }
    }
}
