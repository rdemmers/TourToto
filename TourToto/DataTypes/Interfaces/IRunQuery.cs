using System.Data.SqlClient;

namespace TourToto.DataTypes.Interfaces
{
    internal interface IRunQuery
    {
        int ExecuteNonQuery(ISqlQueryData queryData);

        SqlDataReader ExecuteReader(ISqlQueryData queryData);

        object ExecuteScalar(ISqlQueryData queryData);

        bool ExecuteTransaction(ISqlTransactionData transactionData);
    }
}