using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TourToto.Model;
using TourToto.Tools;
using TourToto.Tools.Interfaces;

namespace TourToto.Service
{
    public class UserService : IUserService
    {
        private IUserDao dao;

        public User LoggedInUser { get; private set; } = null;

        public UserService(IUserDao dao)
        {
            this.dao = dao;
        }

        public int Add(User user)
        {
            IPassword password = new PasswordBase64();
            user.Password = password.EncodePassword(user.Password);

            int lastWrittenId = dao.Add(user);
            return lastWrittenId;
        }

        public User Get(int userId)
        {
            return dao.Get(userId);
        }

        public bool Update(User user)
        {
            return dao.Update(user);
        }

        public bool Delete(int userId)
        {
            return dao.Delete(userId);
        }

        public bool Login(string email, string password)
        {
            IPassword passwordEncrypt = new PasswordBase64();
            password = passwordEncrypt.EncodePassword(password);

            try
            {
                User user = dao.ValidateCredentials(email, password);
                if (user.Email.Equals(email))
                {
                    LoggedInUser = user;
                    return true;
                }

                return false;
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
    }
}