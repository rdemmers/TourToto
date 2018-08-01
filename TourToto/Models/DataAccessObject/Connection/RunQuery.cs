using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using TourToto.DataTypes.Interfaces;

namespace TourToto.Models.DataAccessObject.Connection
{
    internal class RunQuery : IRunQuery
    {
        private static readonly IRunQuery Instance = null;
        private readonly SqlConnection conn;

        public static IRunQuery GetInstance => Instance ?? new RunQuery();

        public RunQuery()
        {
            conn = SqlConnector.Conn;
        }

        public bool ExecuteTransaction(ISqlTransactionData transactionData)
        {
            ResetConnection();
            conn.Open();

            SqlCommand sqlCommand = conn.CreateCommand();
            SqlTransaction sqlTransaction = conn.BeginTransaction();

            sqlCommand.Connection = conn;
            sqlCommand.Transaction = sqlTransaction;

            try
            {
                foreach (ISqlQueryData queryData in transactionData)
                {
                    // Add query string to command:
                    sqlCommand.CommandText = queryData.SqlQuery;
                    // Add parameter definitions to command:
                    if (queryData.HasParameters)
                    {
                        for (int i = 0; i < queryData.NrOfParameters; i++)
                        {
                            sqlCommand.Parameters.Add(queryData.SqlParameter.ElementAt(0), queryData.GetNextParameterType());
                            sqlCommand.Parameters[i].Value = queryData.GetNextParameterValue();
                        }
                    }
                    // Set command type:
                    sqlCommand.CommandType = queryData.CommandType;
                    // Execute correct query
                    switch (queryData.QueryType)
                    {
                        case QueryType.NonQuery:
                            sqlCommand.ExecuteNonQuery();
                            break;

                        case QueryType.Reader:
                            sqlCommand.ExecuteReader();
                            break;

                        case QueryType.Scalar:
                            sqlCommand.ExecuteScalar();
                            break;
                    }
                }
                // Commit queries:
                sqlTransaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Commit Exception Type " + e.GetType(),
                    MessageBoxButton.OK, MessageBoxImage.Error);
                try
                {
                    sqlTransaction.Rollback();
                }
                catch (Exception e2)
                {
                    MessageBox.Show(e.Message, "Rollback Exception Type " + e2.GetType(),
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return false;
            }
        }

        //====================================================================================================
        // Function for executing queries that do not return data (e.g. UPDATE, INSERT, DELETE, etc.)
        // returns number of affected rows
        public int ExecuteNonQuery(ISqlQueryData queryData)
        {
            ResetConnection();
            using (var command = new SqlCommand(queryData.SqlQuery, conn))
            {
                command.CommandType = queryData.CommandType;
                if (queryData.HasParameters)
                {
                    for (int i = 0; i < queryData.NrOfParameters; i++)
                    {
                        command.Parameters.Add(queryData.SqlParameter.ElementAt(0), queryData.GetNextParameterType());
                        command.Parameters[i].Value = queryData.GetNextParameterValue();
                    }
                }
                var idParameter = new SqlParameter("@ID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idParameter);
                conn.Open();
                int result = command.ExecuteNonQuery();
                conn.Close();
                return result;
            }
        }

        //====================================================================================================
        // Function for executing queries that return data of a single field
        public object ExecuteScalar(ISqlQueryData queryData)
        {
            ResetConnection();
            if (!queryData.IsUsable) return false;

            using (var command = new SqlCommand(queryData.SqlQuery, conn))
            {
                command.CommandType = queryData.CommandType;
                if (queryData.HasParameters)
                {
                    for (int i = 0; i < queryData.NrOfParameters; i++)
                    {
                        command.Parameters.Add(queryData.SqlParameter.ElementAt(0), queryData.GetNextParameterType());
                        command.Parameters[i].Value = queryData.GetNextParameterValue();
                    }
                }
                conn.Open();
                var result = command.ExecuteScalar();
                conn.Close();
                return result;
            }
        }

        //====================================================================================================
        // Function for execution regular SELECT queries that return multiple fields
        public SqlDataReader ExecuteReader(ISqlQueryData queryData)
        {
            ResetConnection();
            using (var command = new SqlCommand(queryData.SqlQuery, conn))
            {
                command.CommandType = queryData.CommandType;
                if (queryData.HasParameters)
                {
                    for (int i = 0; i < queryData.NrOfParameters; i++)
                    {
                        command.Parameters.Add(queryData.SqlParameter.ElementAt(0), queryData.GetNextParameterType());
                        command.Parameters[i].Value = queryData.GetNextParameterValue();
                    }
                }

                conn.Open();

                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }

        private void ResetConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}