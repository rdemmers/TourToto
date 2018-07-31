using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;

namespace TourToto.Service.Interface
{
    public interface ICyclistService
    {
        bool AddTeam(string name, string country);
    }
}