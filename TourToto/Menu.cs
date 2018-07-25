using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourToto
{
    class Menu
    {
        public enum Guest
        {
            Thuis,
            Registreer,
            Inloggen
        }
        public enum AdminPre
        {
            Thuis,
            Wielrenners,
            Uitloggen
        }
        public enum AdminPost
        {
            Thuis,
            Wielrenners,
            Resultaten,
            Uitloggen
        }
        public enum PlayerPre
        {
            Thuis,
            Uitloggen
        }
        public enum PlayerPost
        {
            Thuis,
            MijnTeam,
            Uitloggen
        }
        public enum PlayerRace
        {
            Thuis,
            MijnTeam,
            Resutlaten,
            Uitloggen
        }
    }
}
