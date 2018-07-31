using System;
using System.Collections.Generic;
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
using TourToto.Service;
using TourToto.Service.Interface;

namespace TourToto.Pages.CyclistRegistration
{
    /// <summary>
    /// Interaction logic for Team.xaml
    /// </summary>
    public partial class Team : UserControl
    {
        public Team()
        {
            InitializeComponent();
        }

        private void Button_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var country = CountryBox.Text;
            var name = NameBox.Text;
            MessageBox.Show(country + name);
            try
            {
                ICyclistService cyclistService = ServiceManager.GetCyclistService();
                cyclistService.AddTeam(name, country);
                MessageBox.Show("Team toegevoegd!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}