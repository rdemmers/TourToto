using System;
using System.Collections.Generic;
using TourToto.Model.DataAccessObject;

namespace TourToto.Model
{
    public class CyclistTeam
    {
        private int id;
        private String name;
        private String country;
        private List<CyclistTeamDao> cyclists;

        public int Id { get; }
        public String Name { get; set; }
        public String Country { get; set; }
        public List<CyclistTeamDao> Cyclists { get; set; }

        public CyclistTeam()
        {
        }

        public CyclistTeam(int id, string name, string country, List<CyclistTeamDao> cyclists)
        {
            this.id = id;
            this.name = name;
            this.country = country;
            this.cyclists = cyclists;
        }
    }
}