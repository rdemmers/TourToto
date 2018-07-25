using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TourToto.Connection
{
    public class SqlTransactionDataEnum : IEnumerator, ISqlTransactionDataEnum
    {
        // Modified from: https://msdn.microsoft.com/en-us/library/system.collections.ienumerable.getenumerator
        public List<SqlQueryData> SqlQueries;

        private int position = -1;

        public SqlTransactionDataEnum(List<SqlQueryData> list)
        {
            SqlQueries = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < SqlQueries.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current => Current;

        public SqlQueryData Current
        {
            get
            {
                try
                {
                    return SqlQueries.ElementAt(position);
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}