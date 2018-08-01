using System.Collections.ObjectModel;
using System.ComponentModel;
using TourToto.DataTypes.Interfaces;
using TourToto.Models;

namespace TourToto.ViewModels
{
    public class CollectionViewModel : INotifyPropertyChanged, ICollectionViewModel
    {
        private ObservableCollection<Cyclist> allCyclists;
        private ObservableCollection<CyclistTeam> allTeams;

        public ObservableCollection<Cyclist> AllCyclists
        {
            get => allCyclists;
            set
            {
                allCyclists = value;
                RaisePropertyChanged("AllCyclists");
            }
        }

        public ObservableCollection<CyclistTeam> AllTeams
        {
            get => allTeams;
            set
            {
                allTeams = value;
                RaisePropertyChanged("AllTeams");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}