using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Forms
{
    public partial class FormOutput : Form
    {
        
        public FormOutput()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void csvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.TableToCSV((DataTable)(dataGridViewReport.DataSource), "TAMS");
        }

        private void pngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Resize DataGridView to full height and width.
            int height = dataGridViewReport.Height;
            int width = dataGridViewReport.Width;
            dataGridViewReport.ClearSelection();
            dataGridViewReport.Height = (dataGridViewReport.RowCount + 2) * dataGridViewReport.RowTemplate.Height;
            dataGridViewReport.Width = 50; //width of blank column
            for (int i = 0; i < dataGridViewReport.ColumnCount; i++)
            {
                dataGridViewReport.Width += dataGridViewReport.Rows[0].Cells[i].Size.Width;
            }

            //Create a Bitmap and draw the DataGridView on it.
            Bitmap bitmap = new Bitmap(this.dataGridViewReport.Width, this.dataGridViewReport.Height);
            dataGridViewReport.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridViewReport.Width, this.dataGridViewReport.Height));

            //Resize DataGridView back to original height and width.
            dataGridViewReport.Height = height;
            dataGridViewReport.Width = width;

            //Save the Bitmap to folder.
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "PNG Image | *.png";
            save.Title = "Save Report as PNG";
            save.ShowDialog();

            if (save.FileName != "")
            {
                System.IO.FileStream path = (System.IO.FileStream)save.OpenFile();
                bitmap.Save(path, ImageFormat.Png);
                path.Close();
            }
        }
    }
}
