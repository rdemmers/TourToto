using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TourToto.DataTypes.Interfaces;
using TourToto.Services;

namespace TourToto.Views.CyclistRegistration
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
            try
            {
                ICyclistService cyclistService = ServiceManager.GetCyclistService();
                cyclistService.AddTeam(name, country);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}