using System;

namespace TourToto.Model
{
    public class User : Datastructure
    {
        private int id;
        private int credentials;
        private String name;
        private String email;
        private String password;
        private int totalScore;
        private int dayScore;

        public int Id { get => id; set => id = value; }
        public int Credentials { get => credentials; set => credentials = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public int TotalScore { get => totalScore; set => totalScore = value; }
        public int DayScore { get => dayScore; set => dayScore = value; }

        public User() { }

        public User(int id, int credentials, string name, string email, string password, int totalScore, int dayScore)
        {
            this.Id = id;
            this.Credentials = credentials;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.TotalScore = totalScore;
            this.DayScore = dayScore;
        }

        public override string ToString()
        {
            return "User id: " + Id + "credentials: " + Credentials + "name: " + Name;
        }
    }
}
