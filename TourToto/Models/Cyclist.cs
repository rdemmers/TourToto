namespace TourToto.Models
{
    public class Cyclist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CyclistTeamId { get; set; }

        public Cyclist()
        {
        }

        public Cyclist(int id, string name, int cyclistTeamId)
        {
            Id = id;
            Name = name;
            CyclistTeamId = cyclistTeamId;
        }
    }
}