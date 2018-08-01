using System.Collections.ObjectModel;
using TourToto.Model;

namespace TourToto.ViewModel.Interface
{
    public interface ICollectionViewModel
    {
        ObservableCollection<Cyclist> AllCyclists { get; set; }
        ObservableCollection<CyclistTeam> AllTeams { get; set; }
    }
}