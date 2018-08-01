namespace TourToto.ViewModel
{
    public static class ViewModelManager
    {
        private static CollectionViewModel collection = null;
        private static CyclistTeamViewModel cyclistTeam = null;
        private static CyclistViewModel cyclist = null;

        public static CollectionViewModel GetCollection()
        {
            return collection ?? InstantiateCollection();
        }

        public static CyclistTeamViewModel GetCyclistTeam()
        {
            return cyclistTeam ?? InstantiateCyclistTeam();
        }

        public static CyclistViewModel GetCyclist()
        {
            return cyclist ?? InstantiateCyclist();
        }

        private static CollectionViewModel InstantiateCollection()
        {
            collection = new CollectionViewModel();
            return collection;
        }

        private static CyclistTeamViewModel InstantiateCyclistTeam()
        {
            cyclistTeam = new CyclistTeamViewModel();
            return cyclistTeam;
        }

        private static CyclistViewModel InstantiateCyclist()
        {
            cyclist = new CyclistViewModel();
            return cyclist;
        }
    }
}