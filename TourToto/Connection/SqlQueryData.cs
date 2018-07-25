using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TourToto.Connection
{
    public class SqlQueryData : ISqlQueryData
    {
        private CommandType? commandType = CommandType.Text;

        private bool hasParameters = false;

        private int nrOfParameters = 0;

        public SqlQueryData(string sqlQuery, QueryType? queryType = Connection.QueryType.non_query)
        {
            QueryType = queryType;
            SqlQuery = sqlQuery;
        }

        public CommandType CommandType
        {
            get => CommandType;
        }

        public bool HasParameters
        {
            get => hasParameters;
        }

        public bool IsUsable
        {
            get
            {
                return isUsable();
            }
        }

        public int NrOfParameters
        {
            get => NrOfParameters1;
        }

        public int NrOfParameters1 { get => nrOfParameters; set => nrOfParameters = value; }
        public QueryType? QueryType { get; set; } = null;
        public List<string> SqlParameter { get; set; } = new List<string>();
        public List<SqlDbType> SqlParameterType { get; set; } = new List<SqlDbType>();
        public List<string> SqlParameterValue { get; set; } = new List<string>();
        public string SqlQuery { get; set; } = String.Empty;

        public void AddParameter(string sqlParameter, SqlDbType sqlDbType,
            string value)
        {
            if (sqlParameter != String.Empty && value != String.Empty)
            {
                SqlParameter.Add(sqlParameter);
                SqlParameterType.Add(sqlDbType);
                SqlParameterValue.Add(value);
                NrOfParameters1++;
                hasParameters = true;
            }
        }

        public bool AddQueryData(string sql_query, CommandType command_type, QueryType query_type,
            List<string> sql_parameter = null, List<SqlDbType> sql_parameter_type = null,
            List<string> sql_parameter_value = null)
        {
            SqlQuery = sql_query;
            QueryType = query_type;
            if (sql_parameter != null && sql_parameter_type != null && sql_parameter_value != null)
            {
                SqlParameter = sql_parameter;
                SqlParameterType = sql_parameter_type;
                SqlParameterValue = sql_parameter_value;
                hasParameters = true;
                return true;
            }
            else if (sql_parameter == null && sql_parameter_type == null && sql_parameter_value == null)
            {
                hasParameters = false;
                return true;
            }
            else
                return false;
        }

        public string GetNextParameter()
        {
            string output = SqlParameter.ElementAt(0);
            SqlParameter.RemoveAt(0);
            return output;
        }

        public SqlDbType GetNextParameterType()
        {
            SqlDbType output = SqlParameterType.ElementAt(0);
            SqlParameter.RemoveAt(0);
            return output;
        }

        public string GetNextParameterValue()
        {
            string output = SqlParameterValue.ElementAt(0);
            SqlParameterValue.RemoveAt(0);
            return output;
        }

        private bool AllParametersProvided()
        {
            if (SqlQuery == String.Empty) return true;

            char param_id = '@';
            int start_index = -1;
            int hit_count = 0;
            while (true)
            {
                start_index = SqlQuery.IndexOf(param_id, start_index + 1, SqlQuery.Length - start_index - 1);
                if (start_index < 0) break;
                hit_count++;
            }
            if (hit_count == NrOfParameters1)
                return true;
            else
                return false;
        }

        private bool isUsable()
        {
            return (SqlQuery != String.Empty && QueryType != null &&
                (SqlParameter.Count == SqlParameterType.Count &&
                SqlParameter.Count == SqlParameterValue.Count) && AllParametersProvided());
        }
    }
}