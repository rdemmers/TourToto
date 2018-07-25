using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourToto.Connection
{
    public class SqlQueryData
    {
        private CommandType? commandType = null;
        public CommandType CommandType
        {
            get
            {
                return (CommandType)commandType;
            }
            set
            {
                commandType = value;
            }
        }
        private bool hasParameters = false;
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
        private int nrOfParameters = 0;
        public int NrOfParameters
        {
            get => nrOfParameters;
        }
        public QueryType? QueryType { get; set; } = null;
        public List<string> SqlParameter { get; set; } = new List<string>();
        public List<SqlDbType> SqlParameterType { get; set; } = new List<SqlDbType>();
        public List<string> SqlParameterValue { get; set; } = new List<string>();
        public string SqlQuery { get; set; } = String.Empty;


        private bool isUsable()
        {
            return (SqlQuery != String.Empty && QueryType != null &&
                (SqlParameter.Count == SqlParameterType.Count &&
                SqlParameter.Count == SqlParameterValue.Count) && AllParametersProvided());
        }

        public bool addQueryData(string sql_query, CommandType command_type, QueryType query_type,
            List<string> sql_parameter = null, List<SqlDbType> sql_parameter_type = null,
            List<string> sql_parameter_value = null)
        {
            SqlQuery = sql_query;
            CommandType = command_type;
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
        =
        public void addParameter(string sql_parameter, SqlDbType sql_parameter_type,
            string sql_parameter_value)
        {
            if (sql_parameter != String.Empty && sql_parameter_value != String.Empty)
            {
                SqlParameter.Add(sql_parameter);
                SqlParameterType.Add(sql_parameter_type);
                SqlParameterValue.Add(sql_parameter_value);
                nrOfParameters++;
                hasParameters = true;
            }
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
            if (hit_count == nrOfParameters)
                return true;
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
    }
}
