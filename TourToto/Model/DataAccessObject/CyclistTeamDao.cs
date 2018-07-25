using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using TourToto.Builder;
using TourToto.Connection;

namespace TourToto.Model
{
    public class CyclistTeamDao : ICyclistTeamDao
    {
        private ICrud crud;

        public CyclistTeamDao()
        {
            crud = Crud.Instance;
        }

        public int Add(CyclistTeam team)
        {
            String query = "INSERT INTO cyclist_team " +
                "(name, country) " +
                "VALUES (@name, @country); " +
                "SELECT SCOPE_IDENTITY();";

            SqlQueryData queryData = new SqlQueryData(query);

            queryData.AddParameter("@name", SqlDbType.VarChar, team.Name);
            queryData.AddParameter("@country", SqlDbType.VarChar, team.Country);

            try
            {
                return crud.Create(queryData);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to register new Cyclist team. " + e.Message, "Register new team error type: " +
                    e.GetType(), MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(e.StackTrace);
                return 0;
            }
        }

        public bool Update(CyclistTeam team)
        {
            String query = "UPDATE cyclist_team " +
                "SET name = @name, country = @country " +
                "WHERE id = @cyclistId; ";
            SqlQueryData queryData = new SqlQueryData(query);

            queryData.AddParameter("@name", SqlDbType.VarChar, team.Name);
            queryData.AddParameter("@country", SqlDbType.VarChar, team.Country);
            queryData.AddParameter("@cyclistId", SqlDbType.Int, team.Id.ToString());

            return crud.Update(queryData);
        }

        public bool Delete(int cyclistId)
        {
            SqlQueryData queryData = new SqlQueryData("DELETE FROM cyclist_team WHERE id = @cyclistId; ");

            queryData.AddParameter("@cyclistId", SqlDbType.Int, cyclistId.ToString());

            return crud.Delete(queryData);
        }

        public CyclistTeam Get(int id)
        {
            SqlQueryData queryData = new SqlQueryData("SELECT * FROM cyclist_team WHERE [id] = @id", QueryType.Reader);

            queryData.AddParameter("@id", SqlDbType.VarChar, Convert.ToString(id));

            CyclistTeamBuilder builder = new CyclistTeamBuilder();

            try
            {
                SqlDataReader reader = crud.Get(queryData);

                while (reader.Read())
                {
                    CyclistTeam team = builder
                        .SetId(id)
                        .SetName(reader.GetString(1))
                        .SetCountry(reader.GetString(2))
                        .Build();

                    reader.Close();

                    return team;
                }

                reader.Close();
                return new CyclistTeam();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to retrieve team. " + e.Message, "Cyclist team error type: " +
                    e.GetType(), MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                return new CyclistTeam();
            }
        }
    }
}