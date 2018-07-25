namespace TourToto.Connection
{
    public interface ISqlTransactionDataEnum
    {
        SqlQueryData Current { get; }

        bool MoveNext();

        void Reset();
    }
}