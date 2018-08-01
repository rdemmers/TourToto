using System.Data.SqlClient;

namespace TourToto.Models.DataAccessObject.Connection
{
    internal class SqlConnector
    {
        private static SqlConnector instance = null;
        private static SqlConnection conn = null;

        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\RDemmers\source\repos\TourToto\TourToto\Database.mdf;Integrated Security=True;Connect Timeout=30";

        public static SqlConnection Conn => conn ?? InstantiateConnection();

        private SqlConnector()
        {
        }

        private static SqlConnection InstantiateConnection()
        {
            instance = new SqlConnector();
            conn = new SqlConnection(ConnectionString);
            return conn;
        }
    }
}