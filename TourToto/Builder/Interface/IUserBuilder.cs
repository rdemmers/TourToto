using TourToto.Model;

namespace TourToto.Builder
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