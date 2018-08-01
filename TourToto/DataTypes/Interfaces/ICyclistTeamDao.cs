using TourToto.Models;

namespace TourToto.DataTypes.Interfaces
{
    public interface ICyclistTeamDao
    {
        int Add(CyclistTeam team);

        bool Delete(int cyclistId);

        CyclistTeam Get(int id);

        bool Update(CyclistTeam team);
    }
}