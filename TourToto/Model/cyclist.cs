using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourToto.Model
{
    public class Cyclist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CyclistTeamId { get; set; }

        public Cyclist()
        {
        }

        public Cyclist(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}