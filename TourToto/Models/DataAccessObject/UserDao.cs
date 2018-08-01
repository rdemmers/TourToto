using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using TourToto.DataTypes.Interfaces;
using TourToto.Models.Builder;
using TourToto.Models.DataAccessObject.Connection;

namespace TourToto.Models.DataAccessObject
{
    public class UserDao : IUserDao
    {
        private readonly ICrud crud;

        public UserDao()
        {
            crud = Crud.Instance;
        }

        public int Add(User user)
        {
            if (DoesUserExist(user))
            {
                MessageBox.Show("Gebruiker bestaat al, gebruik a.u.b een ander e-mail adres");
                return 0;
            }

            const string query = "INSERT INTO users " +
                                 "(name,email,password,credentials) " +
                                 "VALUES (@name, @email, @password, @credentials); " +
                                 "SELECT SCOPE_IDENTITY();";

            var queryData = new SqlQueryData(query);

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
            const string query = "UPDATE users " +
                           "SET name = @name, email = @email, password = @password, credentials = @credentials " +
                           "WHERE id = @userId; ";

            var queryData = new SqlQueryData(query);

            queryData.AddParameter("@name", SqlDbType.VarChar, user.Name);
            queryData.AddParameter("@email", SqlDbType.VarChar, user.Email);
            queryData.AddParameter("@password", SqlDbType.VarChar, user.Password);
            queryData.AddParameter("@credentials", SqlDbType.Int, user.Credentials.ToString());
            queryData.AddParameter("@userId", SqlDbType.Int, user.Id.ToString());

            return crud.Update(queryData);
        }

        public bool Delete(int userId)
        {
            var queryData = new SqlQueryData("DELETE FROM users WHERE id = @userId;");

            queryData.AddParameter("@userId", SqlDbType.Int, userId.ToString());

            return crud.Delete(queryData);
        }

        public User Get(int id)
        {
            var queryData = new SqlQueryData("SELECT * FROM users WHERE [id] = @id", QueryType.Reader);

            queryData.AddParameter("@id", SqlDbType.VarChar, Convert.ToString(id));

            var userBuilder = new UserBuilder();

            try
            {
                SqlDataReader reader = crud.Get(queryData);

                while (reader.Read())
                {
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

        private bool DoesUserExist(User user)
        {
            try
            {
                var queryData = new SqlQueryData("SELECT COUNT(*) FROM users WHERE [email] = @email", QueryType.Scalar);

                queryData.AddParameter("@email", SqlDbType.VarChar, Convert.ToString(user.Email));

                int foundUsers = crud.GetSingleValue(queryData);

                return (foundUsers > 0) ? true : false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to register user. " + e.Message, " error type: " +
                                                                         e.GetType(), MessageBoxButton.OK,
                MessageBoxImage.Error);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                return true;
            }
        }

        public User ValidateCredentials(string email, string password)
        {
            var queryData = new SqlQueryData("SELECT * FROM users WHERE [email] = @email AND [password] = @password", QueryType.Reader);

            queryData.AddParameter("@email", SqlDbType.VarChar, email);
            queryData.AddParameter("@password", SqlDbType.VarChar, password);

            var userBuilder = new UserBuilder();

            SqlDataReader reader = crud.Get(queryData);
            try
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        User user = userBuilder
                            .SetId(reader.GetInt32(0))
                            .SetCredentials(reader.GetInt32(1))
                            .SetName(reader.GetString(2))
                            .SetEmail(reader.GetString(3))
                            .Build();

                        reader.Close();

                        return user;
                    }

                    reader.Close();
                }

                throw new UnauthorizedAccessException("Username or password incorrect");
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to login. " + e.Message, "IsUserPassword error type: " +
                                                                         e.GetType(), MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                return new User();
            }
        }
    }
}