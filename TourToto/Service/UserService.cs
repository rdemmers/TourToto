using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourToto.Model;

namespace TourToto.Service
{
    public class UserService : IUserService
    {
        private IUserDao dao;

        public UserService(IUserDao dao)
        {
            this.dao = dao;
        }

        public int Add(User user)
        {
            int lastWrittenID = dao.Add(user);
            return lastWrittenID;
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

        public int GetUserScoreTotal(int userId)
        {
            return 0;
        }

        public int GetUserScoreDay(int userId, int day)
        {
            return 0;
        }
    }
}