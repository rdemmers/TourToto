using TourToto.Model;

namespace TourToto.Service
{
    public interface IUserService
    {
        User LoggedInUser { get; }

        int Add(User user);

        bool Delete(int userId);

        User Get(int userId);

        bool Update(User user);

        bool Login(string email, string password);
    }
}