﻿using System.Data.SqlClient;

namespace TourToto.Connection
{
    internal interface IRunQuery
    {
        int ExecuteNonQuery(ISqlQueryData queryData);

        SqlDataReader ExecuteReader(ISqlQueryData queryData);

        object ExecuteScalar(ISqlQueryData queryData);

        bool ExecuteTransaction(ISqlTransactionData transactionData);
    }
}