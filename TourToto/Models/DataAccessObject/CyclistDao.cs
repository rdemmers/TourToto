using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using TourToto.DataTypes.Interfaces;
using TourToto.Models.DataAccessObject.Connection;

namespace TourToto.Models.DataAccessObject
{
    public class CyclistDao : ICyclistDao
    {
        private readonly ICrud crud;

        public CyclistDao()
        {
            crud = Crud.Instance;
        }

        public int Add(Cyclist cyclist)
        {
            var queryData = new SqlQueryData("INSERT INTO cyclists (name, cyclist_team_id) VALUES (@name, @teamId); SELECT SCOPE_IDENTITY();");

            queryData.AddParameter("@name", SqlDbType.VarChar, cyclist.Name);
            queryData.AddParameter("@teamId", SqlDbType.Int, cyclist.CyclistTeamId.ToString());

            try
            {
                return crud.Create(queryData);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to register new CyclistRegistration. " + e.Message, "Register new CyclistRegistration error type: " +
                    e.GetType(), MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(e.StackTrace);
                return 0;
            }
        }

        public bool Update(Cyclist cyclist)
        {
            var queryData = new SqlQueryData("UPDATE cyclists SET name = @name WHERE id = @cyclistId; ");

            queryData.AddParameter("@name", SqlDbType.VarChar, cyclist.Name);
            queryData.AddParameter("@cyclistId", SqlDbType.Int, cyclist.Id.ToString());

            return crud.Update(queryData);
        }

        public bool Delete(int cyclistId)
        {
            var queryData = new SqlQueryData("DELETE FROM cyclists WHERE id = @cyclistId; ");

            queryData.AddParameter("@cyclistId", SqlDbType.Int, cyclistId.ToString());

            return crud.Delete(queryData);
        }

        public Cyclist Get(int id)
        {
            var queryData = new SqlQueryData("SELECT * FROM cyclists WHERE [id] = @id", QueryType.Reader);

            queryData.AddParameter("@id", SqlDbType.VarChar, Convert.ToString(id));

            try
            {
                SqlDataReader reader = crud.Get(queryData);

                while (reader.Read())
                {
                    var cyclist = new Cyclist(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));

                    return cyclist;
                }

                reader.Close();
                return new Cyclist();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to retrieve team. " + e.Message, "CyclistRegistration team error type: " +
                    e.GetType(), MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                return new Cyclist();
            }
        }

        public List<Cyclist> GetAll()
        {
            var queryData = new SqlQueryData("SELECT * FROM cyclists", QueryType.Reader);

            var allCyclists = new List<Cyclist>();

            try
            {
                SqlDataReader reader = crud.Get(queryData);

                while (reader.Read())
                {
                    var cyclist = new Cyclist(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));

                    allCyclists.Add(cyclist);
                }

                reader.Close();
                return allCyclists;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to retrieve team. " + e.Message, "CyclistRegistration team error type: " +
                    e.GetType(), MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                return allCyclists;
            }
        }
    }
}