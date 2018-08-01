using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TourToto.Model;
using TourToto.Model.DataAccessObject;
using TourToto.Service.Interface;
using TourToto.ViewModel;

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

        public bool AddCyclist(Cyclist cyclist)
        {
            cyclist.Id = cyclistDao.Add(cyclist);
            if (cyclist.Id > 0)
            {
                ViewModelManager.GetCollection().AllCyclists.Add(cyclist);
                return true;
            }
            return false;
        }

        public bool AddTeam(string name, string country)
        {
            var team = new CyclistTeam(0, name, country);
            try
            {
                team.Id = cyclistTeamDao.Add(team);

                if (team.Id > 0)
                {
                    ViewModelManager.GetCollection().AllTeams.Add(team);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public ObservableCollection<CyclistTeam> GetAllTeams()
        {
            return ViewModelManager.GetCollection().AllTeams = new ObservableCollection<CyclistTeam>(cyclistTeamDao.GetAll());
        }

        public ObservableCollection<Cyclist> GetAllCyclists()
        {
            return ViewModelManager.GetCollection().AllCyclists = new ObservableCollection<Cyclist>(cyclistDao.GetAll());
        }
    }
}