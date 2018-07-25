using TourToto.Model;

namespace TourToto.Service
{
    public interface IUserService
    {
        int Add(User user);

        bool Delete(int userId);

        User Get(int userId);

        int GetUserScoreDay(int userId, int day);

        int GetUserScoreTotal(int userId);

        bool Update(User user);
    }
}