using System.Collections.ObjectModel;
using TourToto.Models;

namespace TourToto.DataTypes.Interfaces
{
    public interface ICollectionViewModel
    {
        ObservableCollection<Cyclist> AllCyclists { get; set; }
        ObservableCollection<CyclistTeam> AllTeams { get; set; }
    }
}