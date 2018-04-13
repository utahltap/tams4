using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tams4a.Forms
{
    // replaces messageBox
    // messages are centered on parent (instead of screen)
    // TODO:  Set image based on type (error, warning, SHP, Roads, Signs, etc)
    public partial class FormCustomMessage : Form
    {
        public FormCustomMessage()
        {
            InitializeComponent();
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
        }

        public static void ShowDialog(String message, String title=null, Bitmap image=null)
        {
            FormCustomMessage theMessage = new FormCustomMessage();
            theMessage.uiMessage.Text = message;

            if (title != null)
            {
                theMessage.Text = title;
            }

            if (image != null)
            {
                theMessage.pictureBoxIcon.Image = image;
            }
            else
            {
                // hide icon pane
                theMessage.tableLayoutPanel1.ColumnStyles[0].Width = 1;
            }

            theMessage.StartPosition = FormStartPosition.CenterParent;
            theMessage.ShowDialog();
        }
    }
}
