using System.Collections.Generic;
using System.Data;
using TourToto.Models.DataAccessObject.Connection;

namespace TourToto.DataTypes.Interfaces
{
    public interface ISqlQueryData
    {
        bool HasParameters { get; }
        CommandType CommandType { get; }
        bool IsUsable { get; }
        int NrOfParameters { get; }
        QueryType? QueryType { get; set; }
        List<string> SqlParameter { get; set; }
        List<SqlDbType> SqlParameterType { get; set; }
        List<string> SqlParameterValue { get; set; }
        string SqlQuery { get; set; }

        void AddParameter(string sql_parameter, SqlDbType sql_parameter_type, string sql_parameter_value);

        bool AddQueryData(string sql_query, CommandType command_type, QueryType query_type, List<string> sql_parameter = null, List<SqlDbType> sql_parameter_type = null, List<string> sql_parameter_value = null);

        string GetNextParameter();

        SqlDbType GetNextParameterType();

        string GetNextParameterValue();
    }
}