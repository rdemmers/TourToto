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
    public class UserDao : IUserDao
    {
        private ICrud crud;

        public UserDao()
        {
            crud = Crud.Instance;
        }

        public int Add(User user)
        {
            String query = "INSERT INTO users " +
                           "(name,email,password,credentials) " +
                           "VALUES (@name, @email, @password, @credentials); " +
                           "SELECT SCOPE_IDENTITY();";

            SqlQueryData queryData = new SqlQueryData(query);

            queryData.AddParameter("@name", SqlDbType.VarChar, user.Name);
            queryData.AddParameter("@email", SqlDbType.VarChar, user.Email);
            queryData.AddParameter("@password", SqlDbType.VarChar, user.Password);
            queryData.AddParameter("@credentials", SqlDbType.Int, user.Credentials.ToString());

            try
            {
                return crud.Create(queryData);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to register new user. " + e.Message, "RegisterNewUser error type: " +
                                                                             e.GetType(), MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Console.WriteLine(e.StackTrace);
                return 0;
            }
        }

        public bool Update(User user)
        {
            String query = "UPDATE users " +
                           "SET name = @name, email = @email, password = @password, credentials = @credentials " +
                           "WHERE id = @userId; ";

            SqlQueryData queryData = new SqlQueryData(query);

            queryData.AddParameter("@name", SqlDbType.VarChar, user.Name);
            queryData.AddParameter("@email", SqlDbType.VarChar, user.Email);
            queryData.AddParameter("@password", SqlDbType.VarChar, user.Password);
            queryData.AddParameter("@credentials", SqlDbType.Int, user.Credentials.ToString());
            queryData.AddParameter("@userId", SqlDbType.Int, user.Id.ToString());

            return crud.Update(queryData);
        }

        public bool Delete(int userId)
        {
            SqlQueryData queryData = new SqlQueryData("DELETE FROM users WHERE id = @userId;");

            queryData.AddParameter("@userId", SqlDbType.Int, userId.ToString());

            return crud.Delete(queryData);
        }

        public User Get(int id)
        {
            SqlQueryData queryData = new SqlQueryData("SELECT * FROM users WHERE [id] = @id", QueryType.Reader);

            queryData.AddParameter("@id", SqlDbType.VarChar, Convert.ToString(id));

            UserBuilder userBuilder = new UserBuilder();

            try
            {
                SqlDataReader reader = crud.Get(queryData);

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
                        .SetId(id)
                        .SetCredentials(reader.GetInt32(1))
                        .SetName(reader.GetString(2))
                        .SetEmail(reader.GetString(3))
                        .SetPassword(reader.GetString(4))
                        .Build();

                    reader.Close();

                    return user;
                }

                reader.Close();
                return new User();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to retrieve user. " + e.Message, "IsUserPassword error type: " +
                                                                         e.GetType(), MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                return new User();
            }
        }
    }
}