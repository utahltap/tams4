using DotSpatial.Symbology;
using DotSpatial.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using tams4a.Controls;
using tams4a.Forms;
using DotSpatial.Data;

namespace tams4a.Classes
{
    class GenericModule : ProjectModule
    {
        static private readonly string itemSelectionSql = @"";
        private string notes;

        public GenericModule(TamsProject theProject, TabPage controlPage, ToolStripMenuItem[] boundButtons, string mn) : base(theProject, controlPage, boundButtons, itemSelectionSql)
        {
            ModuleName = mn;
            notes = "";

            Panel_Module_OpenShp create = new Panel_Module_OpenShp("other");
            create.Name = "MODULEADD";
            create.Controls.Clear();
            Button newFile = new Button();
            newFile.Text = "Create Point SHP File";
            newFile.Size = new Size(196, 54);
            newFile.Location = new Point(10, 74);
            newFile.Click += newSHPFile;
            create.Controls.Add(newFile);
            create.Dock = DockStyle.Fill;
            ControlsPage.Controls.Add(create);

            ModuleSettings.Add(new ProjectSetting(name: ModuleName + "_file", module: ModuleName));
            ModuleSettings.Add(new ProjectSetting(name: ModuleName + "_relative", module: ModuleName));

            FieldSettingToDbColumn = new Dictionary<string, string>()
            {
                { "sign_f_TAMSID", "support_id" }
            };

            Project.map.ResetBuffer();
            Project.map.Update();
        }

        private void newSHPFile(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "GIS ShapeFile (*.SHP)|*.shp";
            if (save.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string filename = save.FileName;
            if (createSHPFile(filename))
            {
                openFile(filename, "point");
                ProjectSetting shpSetting = new ProjectSetting(name: ModuleName + "_file", value: Filepath, module: ModuleName);
                ProjectSetting shpRelative = new ProjectSetting(name: ModuleName + "_relative", value: Util.MakeRelativePath(Properties.Settings.Default.lastProject, Filepath), module: ModuleName);
                Project.settings.SetSetting(shpSetting);
                Project.settings.SetSetting(shpRelative);
            }
        }

        public override bool openFile(string thePath = "", string type = "point")
        {
            if (type == "") { type = "point"; }
            if (type != "point") { throw new Exception("Generic module requires a point-type shp file"); }


            return true;
        }

        private bool createSHPFile(string filename)
        {
            PointShapefile pointLayer = new PointShapefile();
            pointLayer.Projection = DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984;
            pointLayer.DataTable.Columns.Add("FID");
            pointLayer.DataTable.Columns.Add("TAMSID");
            pointLayer.DataTable.Columns.Add("TAMSSIGN");
            pointLayer.DataTable.Columns.Add("address");
            pointLayer.DataTable.Columns.Add("offset");
            try
            {
                pointLayer.SaveAs(filename, true);
            }
            catch (Exception e)
            {
                Log.Error("Could not create ShapeFile" + Environment.NewLine + e.ToString());
                return false;
            }
            return true;
        }
    }
}