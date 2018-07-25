using System.Data.SqlClient;

namespace TourToto.Connection
{
    internal class SqlConnector
    {
        private static SqlConnector instance = null;
        private static SqlConnection conn = null;

        public static SqlConnection Conn
        {
            get
            {
                if (conn == null)
                {
                    instance = new SqlConnector();
                    string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\RDemmers\Dropbox\Amerika\Tourtoto\project\TourToto\Database.mdf;Integrated Security=True;Connect Timeout=30";
                    conn = new SqlConnection(connStr);
                    return conn;
                }
                else
                {
                    return conn;
                }
            }
        }

        private SqlConnector()
        {
        }
    }
}