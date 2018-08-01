using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using TourToto.Builder;
using TourToto.Connection;

namespace TourToto.Model.DataAccessObject
{
    public class CyclistTeamDao : ICyclistTeamDao
    {
        private readonly ICrud crud;

        public CyclistTeamDao()
        {
            crud = Crud.Instance;
        }

        public int Add(CyclistTeam team)
        {
            const string query = "INSERT INTO cyclist_team " +
                "(name, country) " +
                "VALUES (@name, @country); " +
                "SELECT SCOPE_IDENTITY();";

            var queryData = new SqlQueryData(query);

            queryData.AddParameter("@name", SqlDbType.VarChar, team.Name);
            queryData.AddParameter("@country", SqlDbType.VarChar, team.Country);

            try
            {
                return crud.Create(queryData);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to register new CyclistRegistration team. " + e.Message, "Register new team error type: " +
                    e.GetType(), MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(e.StackTrace);
                return 0;
            }
        }

        public bool Update(CyclistTeam team)
        {
            const string query = "UPDATE cyclist_team " +
                "SET name = @name, country = @country " +
                "WHERE id = @cyclistId; ";
            var queryData = new SqlQueryData(query);

            queryData.AddParameter("@name", SqlDbType.VarChar, team.Name);
            queryData.AddParameter("@country", SqlDbType.VarChar, team.Country);
            queryData.AddParameter("@cyclistId", SqlDbType.Int, team.Id.ToString());

            return crud.Update(queryData);
        }

        public bool Delete(int cyclistId)
        {
            var queryData = new SqlQueryData("DELETE FROM cyclist_team WHERE id = @cyclistId; ");

            queryData.AddParameter("@cyclistId", SqlDbType.Int, cyclistId.ToString());

            return crud.Delete(queryData);
        }

        public CyclistTeam Get(int id)
        {
            var queryData = new SqlQueryData("SELECT * FROM cyclist_team WHERE [id] = @id", QueryType.Reader);

            queryData.AddParameter("@id", SqlDbType.VarChar, Convert.ToString(id));

            var builder = new CyclistTeamBuilder();
            CyclistTeam team = null;

            try
            {
                SqlDataReader reader = crud.Get(queryData);

                while (reader.Read())
                {
                    team = builder
                        .SetId(id)
                        .SetName(reader.GetString(1))
                        .SetCountry(reader.GetString(2))
                        .Build();
                }

                return team ?? new CyclistTeam();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to retrieve team. " + e.Message, "CyclistRegistration team error type: " +
                    e.GetType(), MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                return new CyclistTeam();
            }
        }

        public List<CyclistTeam> GetAll()
        {
            var queryData = new SqlQueryData("SELECT * FROM cyclist_team", QueryType.Reader);
            var builder = new CyclistTeamBuilder();

            var allTeams = new List<CyclistTeam>();
            try
            {
                SqlDataReader reader = crud.Get(queryData);

                while (reader.Read())
                {
                    CyclistTeam team = builder
                        .SetId(reader.GetInt32(0))
                        .SetName(reader.GetString(1))
                        .SetCountry(reader.GetString(2))
                        .Build();

                    allTeams.Add(team);
                }

                reader.Close();
                return allTeams;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to retrieve team. " + e.Message, "CyclistRegistration team error type: " +
                    e.GetType(), MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                return allTeams;
            }
        }
    }
}