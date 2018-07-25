using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourToto.Connection
{
    public class SqlTransactionDataEnum : IEnumerator
    {
        // Modified from: https://msdn.microsoft.com/en-us/library/system.collections.ienumerable.getenumerator
        public List<SqlQueryData> sql_queries;
        int position = -1;
        public SqlTransactionDataEnum(List<SqlQueryData> list)
        {
            sql_queries = list;
        }
        public bool MoveNext()
        {
            position++;
            return (position < sql_queries.Count);
        }
        public void Reset()
        {
            position = -1;
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public SqlQueryData Current
        {
            get
            {
                try
                {
                    return sql_queries.ElementAt(position);
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
