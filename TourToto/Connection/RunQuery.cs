using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

namespace TourToto.Connection
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
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            SqlTransaction transaction = conn.BeginTransaction();

            command.Connection = conn;
            command.Transaction = transaction;

            try
            {
                foreach (ISqlQueryData queryData in transactionData)
                {
                    // Add query string to command:
                    command.CommandText = queryData.SqlQuery;
                    // Add parameter definitions to command:
                    if (queryData.HasParameters)
                    {
                        for (int i = 0; i < queryData.NrOfParameters; i++)
                        {
                            command.Parameters.Add(queryData.SqlParameter.ElementAt(0), queryData.GetNextParameterType());
                            command.Parameters[i].Value = queryData.GetNextParameterValue();
                        }
                    }
                    // Set command type:
                    command.CommandType = queryData.CommandType;
                    // Execute correct query
                    switch (queryData.QueryType)
                    {
                        case QueryType.non_query:
                            command.ExecuteNonQuery();
                            break;

                        case QueryType.reader:
                            command.ExecuteReader();
                            break;

                        case QueryType.scalar:
                            command.ExecuteScalar();
                            break;
                    }
                }
                // Commit queries:
                transaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Commit Exception Type " + e.GetType(),
                    MessageBoxButton.OK, MessageBoxImage.Error);
                try
                {
                    transaction.Rollback();
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
        public int ExecuteNonQuery(ISqlQueryData input)
        {
            using (SqlCommand cmd = new SqlCommand(input.SqlQuery, conn))
            {
                cmd.CommandType = input.CommandType;
                if (input.HasParameters)
                {
                    for (int i = 0; i < input.NrOfParameters; i++)
                    {
                        cmd.Parameters.Add(input.SqlParameter.ElementAt(0), input.GetNextParameterType());
                        cmd.Parameters[i].Value = input.GetNextParameterValue();
                    }
                }
                SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(idParameter);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                return result;
            }
        }

        //====================================================================================================
        // Function for executing queries that return data of a single field
        public Object ExecuteScalar(ISqlQueryData input)
        {
            if (!input.IsUsable) return false;

            using (SqlCommand cmd = new SqlCommand(input.SqlQuery, conn))
            {
                cmd.CommandType = input.CommandType;
                if (input.HasParameters)
                {
                    for (int i = 0; i < input.NrOfParameters; i++)
                    {
                        cmd.Parameters.Add(input.SqlParameter.ElementAt(0), input.GetNextParameterType());
                        cmd.Parameters[i].Value = input.GetNextParameterValue();
                    }
                }
                conn.Open();
                Object result = cmd.ExecuteScalar();
                conn.Close();
                return result;
            }
        }

        //====================================================================================================
        // Function for execution regular SELECT queries that return multiple fields
        public SqlDataReader ExecuteReader(ISqlQueryData input)
        {
            using (SqlCommand cmd = new SqlCommand(input.SqlQuery, conn))
            {
                cmd.CommandType = input.CommandType;
                if (input.HasParameters)
                {
                    for (int i = 0; i < input.NrOfParameters; i++)
                    {
                        cmd.Parameters.Add(input.SqlParameter.ElementAt(0), input.GetNextParameterType());
                        cmd.Parameters[i].Value = input.GetNextParameterValue();
                    }
                }
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }
    }
}