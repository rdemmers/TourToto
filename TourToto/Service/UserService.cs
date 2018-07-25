using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourToto.Model;

namespace TourToto.Service
{

    public class UserService
    {
        UserDao dao;

        public UserService(UserDao dao)
        {
            this.dao = dao;
        }

        public int add(User user)
        {

            int lastWrittenID = dao.add(user);
            return lastWrittenID;
        }

        public User get(int userId)
        {
            return dao.get(userId);
        }

        public bool update(User user)
        {

            return dao.update(user);
        }

        public bool delete(int userId)
        {
            return dao.delete(userId);
        }

        public int getUserScoreTotal(int userId)
        {
            return 0;
        }

        public int getUserScoreDay(int userId, int day)
        {
            return 0;
        }
    }
}
