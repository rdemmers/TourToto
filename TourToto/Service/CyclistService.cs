using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TourToto.Model;
using TourToto.Model.DataAccessObject;
using TourToto.Service.Interface;

namespace TourToto.Service
{
    internal class CyclistService : ICyclistService
    {
        private readonly CyclistDao cyclistDao;
        private readonly CyclistTeamDao cyclistTeamDao;

        public CyclistService(CyclistDao cyclistDao, CyclistTeamDao cyclistTeamDao)
        {
            this.cyclistTeamDao = cyclistTeamDao;
            this.cyclistDao = cyclistDao;
        }

        public bool AddTeam(string name, string country)
        {
            var team = new CyclistTeam(0, name, country);
            try
            {
                MessageBox.Show("service: " + team.Name + team.Country);
                var id = cyclistTeamDao.Add(team);

                if (id > 0) return true;

                return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}