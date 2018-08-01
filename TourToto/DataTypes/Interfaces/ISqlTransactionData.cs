using TourToto.Models.DataAccessObject.Connection;

namespace TourToto.DataTypes.Interfaces
{
    public interface ISqlTransactionData
    {
        void AddSqlQueryData(SqlQueryData sql_query_data);

        SqlTransactionDataEnum GetEnumerator();

        SqlQueryData GetNextSqlQueryData();

        bool IsEmpty();

        bool IsUsable();
    }
}