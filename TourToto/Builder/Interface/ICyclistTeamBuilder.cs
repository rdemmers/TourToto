using System.Collections.Generic;
using TourToto.Model;
using TourToto.Model.DataAccessObject;

namespace TourToto.Builder.Interface
{
    internal interface ICyclistTeamBuilder
    {
        CyclistTeam Build();

        CyclistTeamBuilder SetCountry(string country);

        CyclistTeamBuilder SetId(int id);

        CyclistTeamBuilder SetName(string name);
    }
}