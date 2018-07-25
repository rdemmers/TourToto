using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TourToto.Connection
{
    public class SqlQueryData : ISqlQueryData
    {
        private CommandType? commandType = CommandType.Text;

        public int NrOfParameters { get; set; } = 0;
        public QueryType? QueryType { get; set; } = null;

        public List<string> SqlParameter { get; set; } = new List<string>();
        public List<SqlDbType> SqlParameterType { get; set; } = new List<SqlDbType>();
        public List<string> SqlParameterValue { get; set; } = new List<string>();

        public string SqlQuery { get; set; }
        public CommandType CommandType => CommandType;

        public SqlQueryData(string sqlQuery, QueryType? queryType = Connection.QueryType.NonQuery)
        {
            QueryType = queryType;
            SqlQuery = sqlQuery;
        }

        public bool HasParameters { get; private set; } = false;

        public bool IsUsable => isUsable();

        public void AddParameter(string sqlParameter, SqlDbType sqlDbType,
            string value)
        {
            if (sqlParameter != string.Empty && value != string.Empty)
            {
                SqlParameter.Add(sqlParameter);
                SqlParameterType.Add(sqlDbType);
                SqlParameterValue.Add(value);
                NrOfParameters++;
                HasParameters = true;
            }
        }

        public bool AddQueryData(string sqlQuery, CommandType commandType, QueryType queryType,
            List<string> sqlParameter = null, List<SqlDbType> sqlParameterType = null,
            List<string> sqlParameterValue = null)
        {
            SqlQuery = sqlQuery;
            QueryType = queryType;
            if (sqlParameter != null && sqlParameterType != null && sqlParameterValue != null)
            {
                SqlParameter = sqlParameter;
                SqlParameterType = sqlParameterType;
                SqlParameterValue = sqlParameterValue;
                HasParameters = true;
                return true;
            }
            else if (sqlParameter == null && sqlParameterType == null && sqlParameterValue == null)
            {
                HasParameters = false;
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

            char paramId = '@';
            int startIndex = -1;
            int hitCount = 0;
            while (true)
            {
                startIndex = SqlQuery.IndexOf(paramId, startIndex + 1, SqlQuery.Length - startIndex - 1);
                if (startIndex < 0) break;
                hitCount++;
            }
            if (hitCount == NrOfParameters)
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