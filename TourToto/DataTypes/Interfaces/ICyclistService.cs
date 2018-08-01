using System.Collections.ObjectModel;
using TourToto.Models;

namespace TourToto.DataTypes.Interfaces
{
    public interface ICyclistService
    {
        bool AddTeam(string name, string country);

        ObservableCollection<CyclistTeam> GetAllTeams();

        ObservableCollection<Cyclist> GetAllCyclists();

        bool AddCyclist(Cyclist cyclist);
    }
}