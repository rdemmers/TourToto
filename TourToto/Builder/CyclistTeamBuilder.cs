using System;
using System.Collections.Generic;
using TourToto.Model;

namespace TourToto.Builder
{
    class CyclistTeamBuilder
    {
        private int id;
        private String name;
        private String country;
        private List<Cyclist> cyclist;

        public CyclistTeamBuilder setId(int id)
        {
            this.id = id;
            return this;
        }

        public CyclistTeamBuilder setName(String name)
        {
            this.name = name;
            return this;
        }

        public CyclistTeamBuilder setCountry(String country)
        {
            this.country = country;
            return this;
        }

        public CyclistTeamBuilder setCyclist(List<Cyclist> cyclist)
        {
            this.cyclist = cyclist;
            return this;
        }

        public Cyclist build()
        {
            return new Cyclist();
        }
    }
}