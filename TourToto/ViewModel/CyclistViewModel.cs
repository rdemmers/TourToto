using System.ComponentModel;

namespace TourToto.ViewModel
{
    public class CyclistViewModel : INotifyPropertyChanged
    {
        private int cyclistTeamId;
        private int id;
        private string name;

        public event PropertyChangedEventHandler PropertyChanged;

        public int CyclistTeamId
        {
            get => this.cyclistTeamId;
            set
            {
                this.cyclistTeamId = value;

                this.RaisePropertyChanged("CyclistTeamId");
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