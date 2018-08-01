using System.ComponentModel;

namespace TourToto.ViewModels
{
    public class CyclistTeamViewModel : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string country;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Country
        {
            get => this.country;
            set
            {
                this.country = value;

                this.RaisePropertyChanged("Country");
            }
        }

        public int Id
        {
            get => this.id;
            set
            {
                this.id = value;

                this.RaisePropertyChanged("Id");
            }
        }

        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;

                this.RaisePropertyChanged("Name");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}