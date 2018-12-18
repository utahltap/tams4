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
    public partial class FormLoading : Form
    {
        public int frame = 0;

        public FormLoading(string message = "Loading...")
        {
            InitializeComponent();
            this.Text = message;
            Timer fps = new Timer();
            fps.Interval = 150;
            fps.Tick += new EventHandler(ChangeFrame);
            fps.Start();
        }

        private void ChangeFrame(object sender, EventArgs e)
        {
            if (frame == 4) frame = 0;
            List<Bitmap> loadingGif = new List<Bitmap>();
            loadingGif.Add(Properties.Resources.tams_logo4);
            loadingGif.Add(Properties.Resources.tams_logo3);
            loadingGif.Add(Properties.Resources.tams_logo2);
            loadingGif.Add(Properties.Resources.tams_logo1);
            this.BackgroundImage = loadingGif[frame++];
        }

    }
}
