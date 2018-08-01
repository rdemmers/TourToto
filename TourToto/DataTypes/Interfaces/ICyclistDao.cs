using TourToto.Models;

namespace TourToto.DataTypes.Interfaces
{
    public interface ICyclistDao
    {
        int Add(Cyclist cyclist);

        bool Delete(int cyclistId);

        Cyclist Get(int id);

        bool Update(Cyclist cyclist);
    }
}