using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using TourToto.Connection;

namespace TourToto.Model
{
    public class CyclistDao : ICyclistDao
    {
        private ICrud crud;

        public CyclistDao()
        {
            crud = Crud.Instance;
        }

        public int Add(Cyclist cyclist)
        {
            SqlQueryData queryData = new SqlQueryData()
            {
                SqlQuery = "INSERT INTO cyclists " +
                "(name) " +
                "VALUES (@name); " +
                "SELECT SCOPE_IDENTITY();",
                CommandType = CommandType.Text,
                QueryType = QueryType.non_query
            };
            queryData.AddParameter("@name", SqlDbType.VarChar, cyclist.Name);

            try
            {
                return crud.Create(queryData);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to register new Cyclist. " + e.Message, "Register new Cyclist error type: " +
                    e.GetType(), MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(e.StackTrace);
                return 0;
            }
        }

        public bool Update(Cyclist cyclist)
        {
            SqlQueryData queryData = new SqlQueryData()
            {
                SqlQuery = "UPDATE cyclists " +
                "SET name = @name " +
                "WHERE id = @cyclistId; ",
                CommandType = CommandType.Text,
                QueryType = QueryType.non_query
            };
            queryData.AddParameter("@name", SqlDbType.VarChar, cyclist.Name);
            queryData.AddParameter("@cyclistId", SqlDbType.Int, cyclist.Id.ToString());

            return crud.Update(queryData);
        }

        public bool Delete(int cyclistId)
        {
            Console.WriteLine("Update is triggered");
            SqlQueryData queryData = new SqlQueryData()
            {
                SqlQuery = "DELETE FROM cyclists " +
                "WHERE id = @cyclistId; ",
                CommandType = CommandType.Text,
                QueryType = QueryType.non_query
            };

            queryData.AddParameter("@cyclistId", SqlDbType.Int, cyclistId.ToString());

            return crud.Delete(queryData);
        }

        public Cyclist Get(int id)
        {
            SqlQueryData queryData = new SqlQueryData()
            {
                SqlQuery = "SELECT * FROM cyclists WHERE [id] = @id",
                CommandType = CommandType.Text,
                QueryType = QueryType.reader
            };
            queryData.AddParameter("@id", SqlDbType.VarChar, Convert.ToString(id));

            try
            {
                SqlDataReader reader = crud.Get(queryData);

                while (reader.Read())
                {
                    Cyclist cyclist = new Cyclist(reader.GetInt32(0), reader.GetString(1));

                    return cyclist;
                }

                reader.Close();
                return new Cyclist();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to retrieve team. " + e.Message, "Cyclist team error type: " +
                    e.GetType(), MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                return new Cyclist();
            }
        }
    }
}