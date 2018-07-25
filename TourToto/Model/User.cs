using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourToto.Model
{
    public class User
    {
        public int id { get; set; }
        public int credentials { get; set; }
        public String name { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public int userTeamId { get; set; }
        public int totalScore { get; set; }
        public int dayScore { get; set; }

        public User() { }

        public User(int id, int credentials, string name, string email, string password, int userTeamId, int totalScore, int dayScore)
        {
            this.id = id;
            this.credentials = credentials;
            this.name = name;
            this.email = email;
            this.password = password;
            this.userTeamId = userTeamId;
            this.totalScore = totalScore;
            this.dayScore = dayScore;
        }

        public override string ToString()
        {
            return "User id: " + id + "credentials: " + credentials + "name: " + name;
        }
    }
}
