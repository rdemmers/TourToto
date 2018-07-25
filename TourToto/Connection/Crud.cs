using System.Data.SqlClient;

namespace TourToto.Connection
{
    internal class Crud : ICrud
    {
        private static IRunQuery query;
        private static ICrud crud = null;

        public static ICrud Instance
        {
            get
            {
                if (crud == null)
                {
                    crud = new Crud();
                    query = RunQuery.GetInstance;
                    return crud;
                }
                else
                {
                    return crud;
                }
            }
        }

        public SqlDataReader Get(ISqlQueryData queryData)
        {
            SqlDataReader reader = query.ExecuteReader(queryData);

            if (reader.HasRows)
            {
                return reader;
            }
            else
            {
                return null;
            }
        }

        public bool Update(ISqlQueryData queryData)
        {
            int result = RunQuery.GetInstance.ExecuteNonQuery(queryData);

            if (result > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(ISqlQueryData queryData)
        {
            int result = RunQuery.GetInstance.ExecuteNonQuery(queryData);
            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Create(ISqlQueryData queryData)
        {
            int lastWrittenId = (int)(decimal)RunQuery.GetInstance.ExecuteScalar(queryData);
            return lastWrittenId;
        }
    }
}