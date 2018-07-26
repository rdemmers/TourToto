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

namespace TourToto.Pages
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

            MessageBox.Show("ingelogd als: " + service.LoggedInUser.Name);
        }
    }
}