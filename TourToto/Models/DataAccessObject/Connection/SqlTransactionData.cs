using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TourToto.DataTypes.Interfaces;

namespace TourToto.Models.DataAccessObject.Connection
{
    public enum QueryType
    {
        NonQuery,
        Scalar,
        Reader
    }

    public class SqlTransactionData : IEnumerable, ISqlTransactionData
    {
        private List<SqlQueryData> sqlQueries = new List<SqlQueryData>();

        public bool IsUsable()
        {
            foreach (SqlQueryData sqlQueryData in sqlQueries)
            {
                if (sqlQueryData.IsUsable == false)
                    return false;
            }
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public SqlTransactionDataEnum GetEnumerator()
        {
            return new SqlTransactionDataEnum(sqlQueries);
        }

        public bool IsEmpty()
        {
            return IsUsable() && sqlQueries.Count == 0;
        }

        public void AddSqlQueryData(SqlQueryData sqlQueryData)
        {
            sqlQueries.Add(sqlQueryData);
        }

        public SqlQueryData GetNextSqlQueryData()
        {
            SqlQueryData sqlQueryData = sqlQueries.ElementAt(0);
            sqlQueries.RemoveAt(0);
            return sqlQueryData;
        }
    }
}