using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourToto.Model
{
    public class UserTeam
    {
        private int id;
        private int userId;
        private int cyclistId;
        private int reserveSlot;

        private List<Cyclist> cyclists;

        public int Id { get; set; }
        public int UserId { get; set; }
        public int CyclistId { get; set; }
        public int ReserveSlot { get; set; }

        public UserTeam() { }
        public UserTeam(int id, int userId, int cyclistId, int reserveSlot)
        {
            this.id = id;
            this.userId = userId;
            this.cyclistId = cyclistId;
            this.reserveSlot = reserveSlot;
        }
    }
}
