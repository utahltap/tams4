using System;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Forms
{
    public partial class FormLTAPAnalysis : Form
    {
        private TamsProject Project;
        private ModuleRoads moduleRoads;

        public FormLTAPAnalysis(TamsProject theProject, ModuleRoads modRoads)
        {
            Project = theProject;
            moduleRoads = modRoads;
            InitializeComponent();
        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            LTAPAnalysis analysis = new LTAPAnalysis(Project, moduleRoads);
            object template = "C:\\Users\\A02064884\\Desktop\\Report_Template.docx";
            object file = "C:\\Users\\A02064884\\Desktop\\Test_Report.docx";
            analysis.CreateWordDocument(template, file, this);
            Close();
        }
    }
}
