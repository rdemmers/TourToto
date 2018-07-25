using System;
using TourToto.Model;

namespace TourToto.Builder
{
    public class UserBuilder : IUserBuilder
    {
        private int id;
        private int credentials;
        private String name;
        private String email;
        private String password;
        private int userTeamId;
        private int totalScore;
        private int dayScore;

        public UserBuilder SetId(int id)
        {
            this.id = id;
            return this;
        }

        public UserBuilder SetCredentials(int credentials)
        {
            this.credentials = credentials;
            return this;
        }

        public UserBuilder SetName(String name)
        {
            this.name = name;
            return this;
        }

        public UserBuilder SetEmail(String email)
        {
            this.email = email;
            return this;
        }

        public UserBuilder SetPassword(String password)
        {
            this.password = password;
            return this;
        }

        public UserBuilder SetTotalScore(int totalScore)
        {
            this.totalScore = totalScore;
            return this;
        }

        public UserBuilder SetDayScore(int dayScore)
        {
            this.dayScore = dayScore;
            return this;
        }

        public UserBuilder SetUserTeamId(int userTeamId)
        {
            this.userTeamId = userTeamId;
            return this;
        }

        public User Build()
        {
            return new User(id, credentials, name, email, password, totalScore, dayScore);
        }
    }
}