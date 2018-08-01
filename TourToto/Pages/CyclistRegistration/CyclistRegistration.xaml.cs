using System.Windows.Controls;
using System.Windows.Input;
using TourToto.Model;
using TourToto.Service;
using TourToto.Service.Interface;

namespace TourToto.Pages.CyclistRegistration
{
    /// <summary>
    /// Interaction logic for CyclistRegistration.xaml
    /// </summary>
    public partial class CyclistRegistration : UserControl
    {
        public CyclistRegistration()
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeListBox();
        }

        private void InitializeComboBox()
        {
            TeamsComboBox.ItemsSource = ServiceManager.GetCyclistService().GetAllTeams();
            TeamsComboBox.DisplayMemberPath = "Name";
        }

        private void InitializeListBox()
        {
            CyclistListBox.ItemsSource = ServiceManager.GetCyclistService().GetAllCyclists();
            CyclistListBox.DisplayMemberPath = "Name";
        }

        private void SubmitCyclist_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CyclistTeam team = (CyclistTeam)TeamsComboBox.SelectedItem;
            string cyclistName = CyclistName.Text;

            ICyclistService service = ServiceManager.GetCyclistService();
            Cyclist cyclist = new Cyclist(0, cyclistName, team.Id);
            service.AddCyclist(cyclist);
        }
    }
}