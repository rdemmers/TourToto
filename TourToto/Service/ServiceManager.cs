using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourToto.Model;
using TourToto.Model.DataAccessObject;

namespace TourToto.Service
{
    public static class ServiceManager
    {
        private static IUserService userService = null;

        public static IUserService GetUserService()
        {
            return userService ?? InstantiateUserService();
        }

        private static IUserService InstantiateUserService()
        {
            IUserDao dao = new UserDao();
            userService = new UserService(dao);
            return userService;
        }
    }
}