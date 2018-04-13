using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace tams4a.Classes
{
    public static class ProjectDatabase
    {
        private static SqlConnection Conn;

        public static SqlConnection Get()
        {
            if (IsConnected())
            {
                return Conn;
            } else
            {
                throw new Exception("No project database open");
            }
        }


        public static Boolean IsConnected()
        {
            if (    (Conn != null) &&
                    (Conn.State == System.Data.ConnectionState.Open)
                )
            {
                return true;
            }
            return false;
        }

        public static void Connect(String filename)
        {
            String connectionString = String.Format("Data Source=(localdb)\v11.0;Integrated Security=true;AttachDbFileName=" + filename);

            Conn = new SqlConnection(connectionString);
            try
            {
                Conn.Open();
            } catch (Exception)
            {
                // Show message box and/or throw exception
                throw new Exception("Could not connect to database " + filename);
            }
        }
    }
}
