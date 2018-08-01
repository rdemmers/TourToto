using TourToto.Models;

namespace TourToto.DataTypes.Interfaces
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