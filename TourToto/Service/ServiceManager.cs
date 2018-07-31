using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourToto.Model;
using TourToto.Model.DataAccessObject;
using TourToto.Service.Interface;

namespace TourToto.Service
{
    public static class ServiceManager
    {
        private static IUserService userService = null;
        private static ICyclistService cyclistService = null;

        public static IUserService GetUserService()
        {
            return userService ?? InstantiateUserService();
        }

        public static ICyclistService GetCyclistService()
        {
            return cyclistService ?? InstantiateCyclistService();
        }

        private static IUserService InstantiateUserService()
        {
            IUserDao dao = new UserDao();
            userService = new UserService(dao);
            return userService;
        }

        private static ICyclistService InstantiateCyclistService()
        {
            var cyclistDao = new CyclistDao();
            var cyclistTeamDao = new CyclistTeamDao();
            cyclistService = new CyclistService(cyclistDao, cyclistTeamDao);
            return cyclistService;
        }
    }
}