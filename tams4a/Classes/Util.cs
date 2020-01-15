using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;

using System.Windows.Forms;
using System.Diagnostics;

namespace tams4a.Classes
{
    static public class Util
    {
        /// <summary>
        /// Get's a string value of a dictionary of strings. Returns the empty string if the key isn't present.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static String DictionaryItemString(Dictionary<String, String> dictionary, String key)
        {
            try
            {
                string tempString;
                tempString = dictionary[key].ToString();
                return tempString;
            }
            catch
            {
                return "";
            }
        }
        
        // returns in value or -1 if unsuccessful
        public static int DictionaryItemInt(Dictionary<String, String> dictionary, String key)
        {
            try
            {
                return Convert.ToInt16(dictionary[key]);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Strips out some characters that could cause an accidental sql injection and put the tams file in an invalid state.
        /// sourced: https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-strip-invalid-characters-from-a-string
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static string CleanInput(string strIn)
        {
            try
            {
                strIn = strIn.Replace('"', ' ');
                strIn = strIn.Replace('\'', ' ');
                return Regex.Replace(strIn, @"[^\w\.@-]", "",
                                     RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Returns the date in a format that will sort correctly as a string.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string SortableDate (DateTime date)
        {
            return string.Format("{0:yyyy-MM-dd HH:mm:ss}", date);
        }

        /// <summary>
        /// Safe string to int conversion that defaults to 0 when the string is not an integer.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(String s)
        {
            int o = 0;
            try
            {
                int.TryParse(s, out o);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
            return o;
        }

        public static bool TableToCSV(DataTable dt, string prefix = "")
        {
            string filename;

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Comma Separated Value file (*.csv)|*.csv";
            try
            {
                saveDialog.InitialDirectory = Properties.Settings.Default.lastFolder;
            }
            catch
            {
                saveDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            }
            DialogResult dialogResult = saveDialog.ShowDialog();

            if (dialogResult != DialogResult.OK)
            {
                return false;
            }

            filename = saveDialog.FileName;

            System.IO.StreamWriter outFile = new System.IO.StreamWriter(filename);
            string s = prefix;
            foreach (DataColumn col in dt.Columns)
            {
                s = s + col.ColumnName + ",";
            }
            outFile.WriteLine(s);
            foreach (DataRow row in dt.Rows)
            {
                s = "";
                foreach (DataColumn col in dt.Columns)
                {
                    s = s + row[col.ColumnName].ToString() + ",";
                }
                outFile.WriteLine(s);
            }
            outFile.Close();
            Process.Start(filename);
            return true;
        }

        public static bool TableToPNG(DataGridView dgv)
        {
            //Resize DataGridView to full height and width.
            int height = dgv.Height;
            int width = dgv.Width;
            dgv.ClearSelection();
            dgv.Height = (dgv.RowCount + 2) * dgv.RowTemplate.Height;
            dgv.Width = 50; //width of blank column
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Width += dgv.Rows[0].Cells[i].Size.Width;
            }

            //Create a Bitmap and draw the DataGridView on it.
            Bitmap bitmap = new Bitmap(dgv.Width, dgv.Height);
            dgv.DrawToBitmap(bitmap, new Rectangle(0, 0, dgv.Width, dgv.Height));

            //Resize DataGridView back to original height and width.
            dgv.Height = height;
            dgv.Width = width;

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
                Process.Start(save.FileName);
            }

            return true;
        }

        /// <summary>
        /// Safe string to double conversion taht defaults to 0 when the string is not a double.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double ToDouble(string s)
        {
            double o = 0;
            try
            {
                double.TryParse(s, out o);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
            return o;
        }

        public static void ChartToPNG(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {

            string filename;

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Portable Network Graphic (*.png)|*.png";
            try
            {
                saveDialog.InitialDirectory = Properties.Settings.Default.lastFolder;
            }
            catch
            {
                saveDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            }
            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            filename = saveDialog.FileName;
            try
            {
                chart.SaveImage(filename, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
            }
            catch (Exception e)
            {
                Log.Error("Could not save image file: " + e.ToString());
                MessageBox.Show("An error occoured while trying to export chart.");
            }

        }

        public static void AutoChartToPNG(System.Windows.Forms.DataVisualization.Charting.Chart chart, string graphName)
        {
            string filename = Properties.Settings.Default.projectFolder + @"\Reports\" + graphName + ".png";
            try
            {
                chart.SaveImage(filename, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
            }
            catch (Exception e)
            {
                Log.Error("Could not save image file: " + e.ToString());
                MessageBox.Show("An error occoured while trying to export chart.");
            }

        }

        public static DataTable CSVtoDataTable(string csvText)
        {
            DataTable data = new DataTable();
            string[] csvLines = csvText.Split('\n');
            string[] collumnNames = csvLines[0].Split('\r')[0].Split(',');
            for (int i = 0; i < collumnNames.Length; i++)
            {
                data.Columns.Add(collumnNames[i]);
            }
            for (int i = 1; i <csvLines.Length; i++)
            {
                DataRow nr = data.NewRow();
                for (int j = 0; j < collumnNames.Length; j++)
                {
                    nr[collumnNames[j]] = csvLines[i].Split('\r')[0].Split(',')[j];
                }
                data.Rows.Add(nr);
            }
            return data;
        }

        /// <summary>
        /// https://stackoverflow.com/questions/275689/how-to-get-relative-path-from-absolute-path
        /// </summary>
        /// <param name="fromPath"></param>
        /// <param name="toPath"></param>
        /// <returns></returns>
        public static string MakeRelativePath(String fromPath, String toPath)
        {
            if (String.IsNullOrEmpty(fromPath)) throw new ArgumentNullException("fromPath");
            if (String.IsNullOrEmpty(toPath)) throw new ArgumentNullException("toPath");

            Uri fromUri = new Uri(fromPath);
            Uri toUri = new Uri(toPath);

            if (fromUri.Scheme != toUri.Scheme) { return toPath; } // path can't be made relative.

            Uri relativeUri = fromUri.MakeRelativeUri(toUri);
            String relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            if (toUri.Scheme.Equals("file", StringComparison.InvariantCultureIgnoreCase))
            {
                relativePath = relativePath.Replace(System.IO.Path.AltDirectorySeparatorChar, System.IO.Path.DirectorySeparatorChar);
            }

            return relativePath;
        }

        /// <summary>
        /// https://www.dotnetperls.com/uppercase-first-letter
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}
