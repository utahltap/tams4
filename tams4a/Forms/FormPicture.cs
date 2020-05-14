using System;
using System.Windows.Forms;

namespace tams4a.Forms
{
    public partial class FormPicture : Form
    {
        private string[] listOfPhotos;
        private string sourcePhoto;
        private string folderPath;
        private int index;
        public FormPicture(string[] theListOfPhotos, string source, string theFolderPath)
        {
            listOfPhotos = theListOfPhotos;
            sourcePhoto = source;
            folderPath = theFolderPath;
            index = getIndexFromPhotoList(sourcePhoto);


            InitializeComponent();

            CenterToScreen();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int getIndexFromPhotoList(string item)
        {
            for(int i = 0; i < listOfPhotos.Length; i++)
            {
                if(listOfPhotos[i] == item)
                {
                    return i;
                }
            }
            return 0;
        }

        private void buttonNextPhoto_Click(object sender, EventArgs e)
        {
            if(index + 1== listOfPhotos.Length)
            {
                index = 0;
            }
            else
            {
                index++;
            }
            // change the photo
            pictureBox.ImageLocation = folderPath +  listOfPhotos[index];

            Console.WriteLine("Selected Image: " + listOfPhotos[index]);

        }

        private void buttonPreviousPhoto_Click(object sender, EventArgs e)
        {
            if (index - 1 < 0)
            {
                index = listOfPhotos.Length - 1;
            }
            else
            {
                index--;
            }
            // change the photo
            pictureBox.ImageLocation = folderPath + listOfPhotos[index];
            Console.WriteLine("Selected Image: " + listOfPhotos[index]);
        }
    }
}
