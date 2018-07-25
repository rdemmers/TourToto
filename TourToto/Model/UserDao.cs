using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TourToto.Builder;
using TourToto.Connection;

namespace TourToto.Model
{
    public class UserDao
    {
        private Crud crud;

        public UserDao()
        {
            crud = Crud.Instance;
        }

        public int add(User user)
        {

            SqlQueryData queryData = new SqlQueryData()
            {
                SqlQuery = "INSERT INTO users " +
                "(name,email,password,credentials) " +
                "VALUES (@name, @email, @password, @credentials); " +
                "SELECT SCOPE_IDENTITY();",
                CommandType = CommandType.Text,
                QueryType = QueryType.non_query
            };
            queryData.addParameter("@name", SqlDbType.VarChar, user.name);
            queryData.addParameter("@email", SqlDbType.VarChar, user.email);
            queryData.addParameter("@password", SqlDbType.VarChar, user.password);
            queryData.addParameter("@credentials", SqlDbType.Int, user.credentials.ToString());

            try
            {
                int lastWrittenId = (int)(decimal)Crud.Instance.ExecuteScalar(queryData);
                return lastWrittenId;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to register new user. " + e.Message, "RegisterNewUser error type: " +
                    e.GetType(), MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(e.StackTrace);
                return 0;
            }
        }

        public bool update(User user)
        {
            Console.WriteLine("Update is triggered");
            SqlQueryData query_data = new SqlQueryData()
            {
                SqlQuery = "UPDATE users " +
                "SET name = @name, email = @email, password = @password, credentials = @credentials " +
                "WHERE id = @userId; ",
                CommandType = CommandType.Text,
                QueryType = QueryType.non_query
            };
            query_data.addParameter("@name", SqlDbType.VarChar, user.name);
            query_data.addParameter("@email", SqlDbType.VarChar, user.email);
            query_data.addParameter("@password", SqlDbType.VarChar, user.password);
            query_data.addParameter("@credentials", SqlDbType.Int, user.credentials.ToString());
            query_data.addParameter("@userId", SqlDbType.Int, user.id.ToString());


            int result = Crud.Instance.ExecuteNonQuery(query_data);
            Console.WriteLine("result update: " + result);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool delete(int userId)
        {
            Console.WriteLine("Update is triggered");
            SqlQueryData query_data = new SqlQueryData()
            {
                SqlQuery = "DELETE FROM users " +
                "WHERE id = @userId; ",
                CommandType = CommandType.Text,
                QueryType = QueryType.non_query
            };

            query_data.addParameter("@userId", SqlDbType.Int, userId.ToString());

            int result = Crud.Instance.ExecuteNonQuery(query_data);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User get(int id)
        {
            SqlQueryData query_data = new SqlQueryData()
            {
                SqlQuery = "SELECT * FROM users WHERE [id] = @id",
                CommandType = CommandType.Text,
                QueryType = QueryType.reader
            };
            query_data.addParameter("@id", SqlDbType.VarChar, Convert.ToString(id));

            UserBuilder userBuilder = new UserBuilder();

            try
            {
                SqlDataReader reader = Crud.Instance.ExecuteReader(query_data);


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int userTeamId = 0;
                        if (reader.IsDBNull(5))
                        {
                            userTeamId = 0;
                        }
                        else
                        {
                            userTeamId = reader.GetInt32(5);
                        }

                        User user = userBuilder
                            .setId(id)
                            .setCredentials(reader.GetInt32(1))
                            .setName(reader.GetString(2))
                            .setEmail(reader.GetString(3))
                            .setPassword(reader.GetString(4))
                            .setUserTeamId(userTeamId)
                            .build();

                        reader.Close();

                        return user;
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                reader.Close();
                return new User();

            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to retrieve user. " + e.Message, "IsUserPassword error type: " +
                    e.GetType(), MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}
