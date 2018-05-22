using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tams4a
{
    static class Program
    {
        public static string[] cmdArgs;
        private static bool done = false;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            try
            {
                cmdArgs = Environment.GetCommandLineArgs().Skip(1).ToArray();
            }
            catch (Exception e)
            {
                Classes.Log.Error(e.ToString());
            }
            Environment.CurrentDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            // if new version, bring in the old settings.
            // in future, could also perform other updates.
            if (Properties.Settings.Default.UpdateRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpdateRequired = false;
                Properties.Settings.Default.Save();
            }

            while (!done)
            {
                Application.Run(new MainWindow());
            }
        }
        

        /// <summary>
        /// Return the current version. If running the deployed version, returns that version number,
        /// otherwise returns the assembly version.
        /// </summary>
        /// <returns>Version number</returns>
        public static string GetVersion()
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            else
            {
                return GetBuild() + "dev";
            }
        }

        public static void Close()
        {
            done = true;
        }


        /// <summary>
        /// Return the assembly build number.
        /// if running the deployed application, you can get the version
        /// from the ApplicationDeployment information. If you try
        /// to access this when you are running in Visual Studio, it will not work.
        /// </summary>
        /// <returns>Build number</returns>
        /// 
        public static string GetBuild()
        {
            string ourVersion = string.Empty;

            System.Reflection.Assembly assemblyInfo = System.Reflection.Assembly.GetExecutingAssembly();
            if (assemblyInfo != null)
            {
                ourVersion = assemblyInfo.GetName().Version.ToString();
            }
            else
            {
                ourVersion = "(could not get build)";
            }

            return ourVersion;
        }

    }
}
