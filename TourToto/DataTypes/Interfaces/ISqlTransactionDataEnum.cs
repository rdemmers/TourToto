using TourToto.Models.DataAccessObject.Connection;

namespace TourToto.DataTypes.Interfaces
{
    public interface ISqlTransactionDataEnum
    {
        SqlQueryData Current { get; }

        bool MoveNext();

        void Reset();
    }
}