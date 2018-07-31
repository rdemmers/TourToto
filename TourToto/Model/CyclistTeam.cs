using System;
using System.Collections.Generic;
using TourToto.Model.DataAccessObject;

namespace TourToto.Model
{
    public class CyclistTeam
    {
        private string country;
        private List<CyclistTeamDao> cyclists;
        private int id;
        private string name;

        public CyclistTeam()
        {
        }

        public CyclistTeam(int id, string name, string country)
        {
            this.Id = id;
            this.Name = name;
            this.Country = country;
        }

        public string Country { get => country; set => country = value; }
        public List<CyclistTeamDao> Cyclists { get => cyclists; set => cyclists = value; }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}