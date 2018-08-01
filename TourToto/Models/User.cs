namespace TourToto.Models
{
    public class User
    {
        public int Id { get; set; }
        public int Credentials { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int TotalScore { get; set; }
        public int DayScore { get; set; }

        public User()
        {
        }

        public User(int id, int credentials, string name, string email, string password, int totalScore, int dayScore)
        {
            Id = id;
            Credentials = credentials;
            Name = name;
            Email = email;
            Password = password;
            TotalScore = totalScore;
            DayScore = dayScore;
        }

        public override string ToString()
        {
            return "User id: " + Id + "credentials: " + Credentials + "name: " + Name;
        }
    }
}