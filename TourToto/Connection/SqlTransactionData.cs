using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourToto.Connection
{
    public enum QueryType
    {
        non_query,
        scalar,
        reader
    }
    public class SqlTransactionData : IEnumerable
    {
        private List<SqlQueryData> sql_queries = new List<SqlQueryData>();
        
        public bool IsUsable()
        {
            foreach (SqlQueryData sql_query_data in sql_queries)
            {
                if (sql_query_data.IsUsable == false)
                    return false;
            }
            return true;
        }
        //====================================================================================================
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        //====================================================================================================
        public SqlTransactionDataEnum GetEnumerator()
        {
            return new SqlTransactionDataEnum(sql_queries);
        }
        //====================================================================================================
        public bool IsEmpty()
        {
            return IsUsable() && sql_queries.Count == 0;
        }
        //====================================================================================================
        public void AddSqlQueryData(SqlQueryData sql_query_data)
        {
            sql_queries.Add(sql_query_data);
        }
        //====================================================================================================
        public SqlQueryData GetNextSqlQueryData()
        {
            SqlQueryData sql_query_data = sql_queries.ElementAt(0);
            sql_queries.RemoveAt(0);
            return sql_query_data;
        }
    }
}
