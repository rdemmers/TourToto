using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TourToto.DataTypes.Interfaces;
using TourToto.Services;

namespace TourToto.Views
{
    /// <summary>
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : UserControl
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void UIElement_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            string email = EmailBox.Text;
            string password = PasswordBox.Text;
            IUserService service = ServiceManager.GetUserService();

            if (!service.Login(email, password))
            {
                MessageBox.Show("Incorrecte login gegevens! Helaas pindakaas");
            }

            if (service.LoggedInUser != null)
            {
                MessageBox.Show("ingelogd als: " + service.LoggedInUser.Name);
            }
        }
    }
}