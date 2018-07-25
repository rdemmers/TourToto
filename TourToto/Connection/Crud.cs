using System.Data.SqlClient;

namespace TourToto.Connection
{
    internal class Crud : ICrud
    {
        private static IRunQuery query;
        private static ICrud crud = null;

        public static ICrud Instance => crud ?? InstantiateCrud();

        public SqlDataReader Get(ISqlQueryData queryData)
        {
            SqlDataReader reader = query.ExecuteReader(queryData);

            return (reader.HasRows) ? reader : null;
        }

        public bool Update(ISqlQueryData queryData)
        {
            int result = RunQuery.GetInstance.ExecuteNonQuery(queryData);

            return (result > 1) ? true : false;
        }

        public bool Delete(ISqlQueryData queryData)
        {
            int result = RunQuery.GetInstance.ExecuteNonQuery(queryData);

            return (result >= 1) ? true : false;
        }

        public int Create(ISqlQueryData queryData)
        {
            int lastWrittenId = (int)(decimal)RunQuery.GetInstance.ExecuteScalar(queryData);
            return lastWrittenId;
        }

        private static ICrud InstantiateCrud()
        {
            crud = new Crud();
            query = RunQuery.GetInstance;
            return crud;
        }
    }
}