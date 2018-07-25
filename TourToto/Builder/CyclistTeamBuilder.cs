using System;
using System.Collections.Generic;
using TourToto.Builder.Interface;
using TourToto.Model;
using TourToto.Model.DataAccessObject;

namespace TourToto.Builder
{
    internal class CyclistTeamBuilder : ICyclistTeamBuilder
    {
        private int id;
        private String name;
        private String country;
        private List<CyclistTeamDao> cyclists;

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

        public CyclistTeamBuilder SetCyclists(List<CyclistTeamDao> cyclists)
        {
            this.cyclists = cyclists;
            return this;
        }

        public CyclistTeam Build()
        {
            return new CyclistTeam(id, name, country, cyclists);
        }
    }
}