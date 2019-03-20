using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace tams4a.Classes
{
    public static class Log
    {
        private static String path;

        static Log()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            try
            {
                Directory.CreateDirectory(path + @"\tams\");
                path += @"\tams\";
            }
            catch (Exception e)
            {
#if DEBUG
                MessageBox.Show("Could not create log object.  " + e.ToString());
#endif
                // we'll do nothing here (TODO?) and just log to the appdata folder
            }
        }

        public static void Add(String text, String level="note")
        {
            String logName;
            // ensure we have only value logs
            // could also do different things for different levels if needed.
            switch (level)
            {
                case "error":
                case "warning":
                case "note":
                    logName = "tams_" + level + ".txt";
                    break;
                default:
                    logName = "tams_note.txt";
                    break;
            }


            try
            {
                List<String> lines = new List<String>();
                lines.Add("------------------------");
                lines.Add(DateTime.Now.ToString());
                lines.Add(text);

                String logFullName = path + logName;

                if (File.Exists(logFullName))
                {
                    FileInfo info = new FileInfo(logFullName);

                    // We're going to archive logs monthly to prevent them from growing too large
                    // note that we'll only check when we write to the log.
                    DateTime created = info.CreationTime;
                    int OriginalMonth = created.Month;
                    // DEBUG:
                    // OriginalMonth = 1;
                    // /debug
                    int OriginalYear = created.Year;
                    int NowMonth = DateTime.Now.Month;
                    int NowYear = DateTime.Now.Year;

                    if ((OriginalMonth != NowMonth) || (OriginalYear != NowYear))
                    {
                        String archivePostfix = "-" + OriginalYear.ToString() + "-" + created.ToString("MMM");
                        String archiveFile = path + "tams_" + level + archivePostfix + ".txt";
                        if (File.Exists(archiveFile))  // we'd hope this wouldn't happen, but it could
                        {
                            try
                            {
                                // try to append lines to file.
                                String[] existingFileLines = File.ReadAllLines(logFullName);
                                File.AppendAllLines(archiveFile, existingFileLines);
                            }
                            catch
                            {
                                MessageBox.Show("Could not combine existing archived log file: " + archiveFile);
                            }
                        } else
                        {
                            File.Move(logFullName, archiveFile);
                        }
                    }
                }

                File.AppendAllLines(logFullName, lines);
            }
            catch (Exception e)
            {
                // TODO: System app log
                MessageBox.Show("Could not write to log file.\n\n" + e.ToString());
            }
        }


        // WARNING: log file could be large!
        public static String Get(String level)
        {
            String filename = path + "tams_" + level + ".txt";
            try
            {
                return File.ReadAllText(filename);
            } catch
            {
                return "ERROR READING " + filename;
            }
        }


        // returns the top *lines* lines as a string
        public static String GetTop(String level, int lines=100)
        {
            String filename = path + "tams_" + level + ".txt";
            try
            {
                String[] fileLines = File.ReadAllLines(filename);
                String returnString = "";
                int start = fileLines.Length - lines;
                if (start < 0)
                {
                    start = 0;
                }
                for (int i=start; i<fileLines.Length; i++)
                {
                    returnString += fileLines[i] + "\r\n";
                }
                return returnString;
            }
            catch
            {
                return "ERROR READING " + level + ": " + filename + "\r\n";
            }
        }


        // shortcut
        public static void Error(String text)
        {
            Add(text, "error");
        }

        // shortcut
        public static void Warning(String text)
        {
            Add(text, "warning");
        }

        // shortcut
        public static void Note(String text)
        {
            Add(text, "note");
        }

    }
}
