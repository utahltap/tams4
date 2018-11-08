using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tams4a.Controls;
using tams4a.Forms;

namespace tams4a.Classes
{

    internal class RoadSidewalkForm
    {
        private FormCustomMessage dialogBox;
        private int RoadID;
        private ComboBox sidewalks;
        private TextBox textBoxComment;

        public RoadSidewalkForm(int rid)
        {
            RoadID = rid;
            dialogBox = new FormCustomMessage();
            dialogBox.Text = "Sidewalks on this Road";
            dialogBox.labelMessage.Text = "Does this raod have sidewalks?";
            sidewalks = new ComboBox();
            sidewalks.Items.Add("Yes");
            sidewalks.Items.Add("No");
            sidewalks.Items.Add("Partial");
            sidewalks.Location = new Point(240, 16);
            dialogBox.groupBoxUser.Controls.Add(sidewalks);
            Label comment = new Label();
            comment.Text = "Comment:";
            comment.Location = new Point(12, 40);
            comment.Size = new Size(80, 24);
            dialogBox.groupBoxUser.Controls.Add(comment);
            textBoxComment = new TextBox();
            textBoxComment.Size = new Size(240, 24);
            textBoxComment.Location = new Point(100, 40);
            dialogBox.groupBoxUser.Controls.Add(textBoxComment);
        }

        public void setSidewalkData(TamsProject project)
        {
            if (dialogBox.ShowDialog() == DialogResult.OK)
            {
                Database.ReplaceRow(project.conn, new Dictionary<string, string>()
                {
                    { "road_ID", RoadID.ToString()},
                    { "installed", sidewalks.Text },
                    { "comments", textBoxComment.Text }
                }, "road_sidewalks");
            }
        }

        public void prePopField(TamsProject project)
        {
            try
            {
                DataTable data = Database.GetDataByQuery(project.conn, "SELECT * FROM road_sidewalks WHERE road_ID=" + RoadID.ToString() + ";");
                sidewalks.Text = data.Rows[0]["installed"].ToString();
                textBoxComment.Text = data.Rows[0]["comments"].ToString();
            }
            catch (Exception)
            {

            }
        }
        }
    }
