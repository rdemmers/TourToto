using TourToto.Models;

namespace TourToto.DataTypes.Interfaces
{
    public interface IUserDao
    {
        int Add(User user);

        bool Delete(int userId);

        User Get(int id);

        bool Update(User user);

        User ValidateCredentials(string email, string password);
    }
}