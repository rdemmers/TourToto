using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;
using TourToto.Model;
using System.Collections.ObjectModel;

namespace TourToto.Service.Interface
{
    public interface ICyclistService
    {
        bool AddTeam(string name, string country);

        List<CyclistTeam> GetAllTeams();
    }
}