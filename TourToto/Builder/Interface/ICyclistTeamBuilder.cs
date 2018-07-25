using System.Collections.Generic;
using TourToto.Model;

namespace TourToto.Builder
{
    internal interface ICyclistTeamBuilder
    {
        CyclistTeam Build();

        CyclistTeamBuilder SetCountry(string country);

        CyclistTeamBuilder SetCyclists(List<CyclistTeamDao> cyclists);

        CyclistTeamBuilder SetId(int id);

        CyclistTeamBuilder SetName(string name);
    }
}