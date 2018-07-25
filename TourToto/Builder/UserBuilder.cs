using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourToto.Model;

namespace TourToto.Builder
{
    public class UserBuilder
    {
        private int id;
        private int credentials;
        private String name;
        private String email;
        private String password;
        private int userTeamId;
        private int totalScore;
        private int dayScore;
        

        public UserBuilder setId(int id)
        {
            this.id = id;
            return this;
        }

        public UserBuilder setCredentials(int credentials)
        {
            this.credentials = credentials;
            return this;
        }

        public UserBuilder setName(String name)
        {
            this.name = name;
            return this;
        }

        public UserBuilder setEmail(String email)
        {
            this.email = email;
            return this;
        }

        public UserBuilder setPassword(String password)
        {
            this.password = password;
            return this;
        }

        public UserBuilder setUserTeamId(int userTeamId)
        {
            this.userTeamId = userTeamId;
            return this;
        }

        public UserBuilder setTotalScore(int totalScore)
        {
            this.totalScore = totalScore;
            return this;
        }

        public UserBuilder setDayScore(int dayScore)
        {
            this.dayScore = dayScore;
            return this;
        }

        public User build()
        {
            return new User(id, credentials, name, email, password, userTeamId, totalScore, dayScore);
        }
    }
}
