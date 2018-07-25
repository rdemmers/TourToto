using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace TourToto.Connection
{
    class SqlConnector
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
                    string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dirk\Dropbox\Amerika\Amerika\project\TourToto\Database.mdf;Integrated Security=True;Connect Timeout=30";
                    conn = new SqlConnection(connStr);
                    return conn;
                }
                else
                {
                    return conn;
                }

            }
        }

        private SqlConnector() { }



        

    }
}
