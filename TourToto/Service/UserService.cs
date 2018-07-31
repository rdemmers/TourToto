using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TourToto.Model;
using TourToto.Tools;
using TourToto.Service;
using TourToto.Tools.Interfaces;

namespace TourToto.Service
{
    public class UserService : IUserService
    {
        private IUserDao dao;

        private User loggedInUser = null;

        public UserService(IUserDao dao)
        {
            this.dao = dao;
        }

        public User LoggedInUser
        {
            get => loggedInUser;
            set
            {
                var window = PageManager.MainWindow;
                if (value.Credentials == 0)
                {
                    window.VisibilityAdmin = Visibility.Hidden;
                    window.VisibilityLoggedIn = Visibility.Visible;
                    window.VisibilityLoginRegister = Visibility.Hidden;
                }
                else
                {
                    window.VisibilityAdmin = Visibility.Visible;
                    window.VisibilityLoggedIn = Visibility.Visible;
                    window.VisibilityLoginRegister = Visibility.Visible;
                }

                loggedInUser = value;
            }
        }

        public int Add(User user)
        {
            IPassword password = new PasswordBase64();
            user.Password = password.EncodePassword(user.Password);

            int lastWrittenId = dao.Add(user);
            return lastWrittenId;
        }

        public bool Delete(int userId)
        {
            return dao.Delete(userId);
        }

        public User Get(int userId)
        {
            return dao.Get(userId);
        }

        public bool Login(string email, string password)
        {
            IPassword passwordEncrypt = new PasswordBase64();
            password = passwordEncrypt.EncodePassword(password);

            try
            {
                User user = dao.ValidateCredentials(email, password);

                if (!user.Email.Equals(email)) return false;

                LoggedInUser = user;
                return true;
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show((e.Message));
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool Update(User user)
        {
            return dao.Update(user);
        }
    }
}