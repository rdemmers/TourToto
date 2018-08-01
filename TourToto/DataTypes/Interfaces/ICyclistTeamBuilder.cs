using TourToto.Models;
using TourToto.Models.Builder;

namespace TourToto.DataTypes.Interfaces
{
    internal interface ICyclistTeamBuilder
    {
        CyclistTeam Build();

        CyclistTeamBuilder SetCountry(string country);

        CyclistTeamBuilder SetId(int id);

        CyclistTeamBuilder SetName(string name);
    }
}