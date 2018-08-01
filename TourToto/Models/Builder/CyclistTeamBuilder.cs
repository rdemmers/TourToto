using System;
using TourToto.DataTypes.Interfaces;

namespace TourToto.Models.Builder
{
    internal class CyclistTeamBuilder : ICyclistTeamBuilder
    {
        private int id;
        private String name;
        private String country;

        public CyclistTeamBuilder SetId(int id)
        {
            this.id = id;
            return this;
        }

        public CyclistTeamBuilder SetName(String name)
        {
            this.name = name;
            return this;
        }

        public CyclistTeamBuilder SetCountry(String country)
        {
            this.country = country;
            return this;
        }

        public CyclistTeam Build()
        {
            return new CyclistTeam(id, name, country);
        }
    }
}