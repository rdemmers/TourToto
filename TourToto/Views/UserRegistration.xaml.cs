﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TourToto.Models.Builder;
using TourToto.Services;

namespace TourToto.Views
{
    /// <summary>
    /// Interaction logic for UserRegistration.xaml
    /// </summary>
    public partial class UserRegistration : UserControl
    {
        public UserRegistration()
        {
            InitializeComponent();
        }

        private void Register_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            string validPassword = (Password.Text.Equals(RepeatPassword.Text)) ? Password.Text : null;

            if (validPassword == null)
            {
                return;
            }

            var user = new UserBuilder()
                .SetName(Name.Text)
                .SetPassword(validPassword)
                .SetEmail(Email.Text)
                .SetCredentials(0)
                .Build();

            var userservice = ServiceManager.GetUserService();

            int id = userservice.Add(user);

            if (id == 0)
            {
                MessageBox.Show("foutje, ergens, user; " + user.ToString());
                return;
            }

            MessageBox.Show("Gefeliciteerd! De registratie is gelukt, u kunt nu inloggen! ID: " + id);
        }
    }
}