using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TourToto.Model;
using TourToto.Service;

namespace TourToto.Pages.CyclistRegistration
{
    /// <summary>
    /// Interaction logic for Cyclist.xaml
    /// </summary>
    public partial class Cyclist : UserControl
    {
        public Cyclist()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            TeamsComboBox.ItemsSource = ServiceManager.GetCyclistService().GetAllTeams();
            TeamsComboBox.DisplayMemberPath = "Name";
        }

        private void SubmitCyclist_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CyclistTeam team = (CyclistTeam)TeamsComboBox.SelectedItem;
            string cyclist = CyclistName.Text;
        }
    }
}