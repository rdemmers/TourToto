namespace TourToto.Connection
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