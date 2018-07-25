using System.Data.SqlClient;

namespace TourToto.Connection
{
    internal interface IRunQuery
    {
        int ExecuteNonQuery(ISqlQueryData input);

        SqlDataReader ExecuteReader(ISqlQueryData input);

        object ExecuteScalar(ISqlQueryData input);

        bool ExecuteTransaction(ISqlTransactionData transactionData);
    }
}