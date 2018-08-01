using TourToto.Models;
using TourToto.Models.Builder;

namespace TourToto.DataTypes.Interfaces
{
    public interface IUserBuilder
    {
        User Build();

        UserBuilder SetCredentials(int credentials);

        UserBuilder SetDayScore(int dayScore);

        UserBuilder SetEmail(string email);

        UserBuilder SetId(int id);

        UserBuilder SetName(string name);

        UserBuilder SetPassword(string password);

        UserBuilder SetTotalScore(int totalScore);
    }
}