using System;
using System.Data.SqlClient;
using System.Windows;
using TourToto.Connection.Interface;

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

        public int GetSingleValue(ISqlQueryData queryData)
        {
            int result = Int32.Parse(RunQuery.GetInstance.ExecuteScalar(queryData).ToString());

            return result;
        }

        private static ICrud InstantiateCrud()
        {
            crud = new Crud();
            query = RunQuery.GetInstance;
            return crud;
        }
    }
}