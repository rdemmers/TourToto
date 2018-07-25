using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourToto.Model
{
    public class Cyclist
    {
        private int id;
        private String name;
        private int cyclistTeamId;

        public Cyclist()
        {
        }

        public Cyclist(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int CyclistTeamId { get => cyclistTeamId; set => cyclistTeamId = value; }
    }
}