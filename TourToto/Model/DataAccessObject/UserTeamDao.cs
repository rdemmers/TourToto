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
    public class UserTeamDao
    {
        //private Crud crud;

        //public UserTeamDao()
        //{
        //    crud = Crud.GetInstance;
        //}

        //public int Add(UserTeam team)
        //{
        //    SqlQueryData queryData = new SqlQueryData()
        //    {
        //        SqlQuery = "INSERT INTO cyclist_team " +
        //        "(name, country) " +
        //        "VALUES (@name, @country); " +
        //        "SELECT SCOPE_IDENTITY();",
        //        CommandType = CommandType.Text,
        //        QueryType = QueryType.NonQuery
        //    };
        //    queryData.addParameter("@name", SqlDbType.VarChar, team.Name);
        //    queryData.addParameter("@country", SqlDbType.VarChar, team.Country);

        //    try
        //    {
        //        return crud.create(queryData);
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Unable to register new Cyclist team. " + e.Message, "Register new team error type: " +
        //            e.GetType(), MessageBoxButton.OK, MessageBoxImage.Error);
        //        Console.WriteLine(e.StackTrace);
        //        return 0;
        //    }
        //}

        //public bool Update(CyclistTeam team)
        //{
        //    SqlQueryData queryData = new SqlQueryData()
        //    {
        //        SqlQuery = "UPDATE cyclist_team " +
        //        "SET name = @name, country = @country " +
        //        "WHERE id = @cyclistId; ",
        //        CommandType = CommandType.Text,
        //        QueryType = QueryType.NonQuery
        //    };
        //    queryData.addParameter("@name", SqlDbType.VarChar, team.Name);
        //    queryData.addParameter("@country", SqlDbType.VarChar, team.Country);
        //    queryData.addParameter("@cyclistId", SqlDbType.Int, team.Id.ToString());

        //    return crud.update(queryData);
        //}

        //public bool Delete(int cyclistId)
        //{
        //    Console.WriteLine("Update is triggered");
        //    SqlQueryData queryData = new SqlQueryData()
        //    {
        //        SqlQuery = "DELETE FROM cyclist_team " +
        //        "WHERE id = @cyclistId; ",
        //        CommandType = CommandType.Text,
        //        QueryType = QueryType.NonQuery
        //    };

        //    queryData.addParameter("@cyclistId", SqlDbType.Int, cyclistId.ToString());

        //    return crud.delete(queryData);

        //}

        //public UserTeam Get(int id)
        //{
        //    SqlQueryData queryData = new SqlQueryData()
        //    {
        //        SqlQuery = "SELECT * FROM cyclist_team WHERE [id] = @id",
        //        CommandType = CommandType.Text,
        //        QueryType = QueryType.reader
        //    };
        //    queryData.addParameter("@id", SqlDbType.VarChar, Convert.ToString(id));

        //    CyclistTeamBuilder builder = new CyclistTeamBuilder();

        //    try
        //    {
        //        SqlDataReader reader = crud.get(queryData);

        //        while (reader.Read())
        //        {
        //            CyclistTeam team = builder
        //                .SetId(id)
        //                .SetName(reader.GetString(1))
        //                .SetCountry(reader.GetString(2))
        //                .Build();

        //            reader.Close();

        //            return team;
        //        }

        //        reader.Close();
        //        return new CyclistTeam();

        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Unable to retrieve team. " + e.Message, "Cyclist team error type: " +
        //            e.GetType(), MessageBoxButton.OK, MessageBoxImage.Error);
        //        Console.WriteLine(e.StackTrace);
        //        Console.WriteLine(e.Message);
        //        return new CyclistTeam();
        //    }
        //}
    }
}