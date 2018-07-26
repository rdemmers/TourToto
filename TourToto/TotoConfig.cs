using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace TourToto
{
    public class TotoConfig
    {
        public double FooterHeight = 1D;
        private double headerHeight = 1D;
        private double leftMargin = 0D;
        private double logoHeight = 1D;
        private double mainTabWidth = 1D;
        private double secondaryTabWidth = 1D;

        public TotoConfig()
        {
        }

        public TotoConfig(string init)
        {
            if (init.ToLower() != "default") return;

            BackgroundColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            BarColor = new SolidColorBrush(Color.FromRgb(216, 226, 243));
            FooterHeight = 50D;
            LogoMargin = new Thickness(10);
            LogoMaxHeight = LogoMaxWidth = 100D;
            LogoMinHeight = LogoMinWidth = 80D;
            LogoMaxWidth = 100D;
            LogoMinWidth = 80D;
            SecundaryBackgroundColor = new SolidColorBrush(Color.FromRgb(242, 242, 242));
            TabPadding = new Thickness(5, 2, 5, 2);
            WindowHeight = 768D;
            WindowWidth = 1024D;
        }

        public enum GamePhase
        {
            Start,
            TeamComposition,
            Race
        }

        public enum UserRole
        {
            Guest,
            Player,
            Admin
        }

        public Brush BackgroundColor { get; set; } = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        public Brush BarColor { get; set; } = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        public GamePhase CurrentGamePhase { get; set; } = GamePhase.Start;
        public UserRole CurrentUserRole { get; set; } = UserRole.Guest;

        public double HeaderHight
        {
            get
            {
                if (headerHeight <= 1)
                    headerHeight = LogoHeight + LogoMargin.Top + LogoMargin.Bottom;
                return headerHeight;
            }
            set => headerHeight = value;
        }

        public double LeftMargin
        {
            get
            {
                if (leftMargin <= 0)
                    leftMargin = LogoWidth + LogoMargin.Left + LogoMargin.Right;
                return leftMargin;
            }
            set => leftMargin = value;
        }

        public double LogoHeight
        {
            get
            {
                if (logoHeight <= 1)
                    logoHeight = (double)(((int)LogoMinHeight + (int)LogoMaxHeight) / 2);
                return logoHeight;
            }
            set => logoHeight = value;
        }

        public Thickness LogoMargin { get; set; } = new Thickness(0);
        public double LogoMaxHeight { get; set; } = 0D;
        public double LogoMaxWidth { get; set; } = 0D;
        public double LogoMinHeight { get; set; } = 0D;
        public double LogoMinWidth { get; set; } = 0D;
        public double LogoWidth { get; set; } = 1D;
        public Style MainTabControlStyle { get; set; }

        public double MainTabWidth
        {
            get
            {
                if (mainTabWidth <= 1)
                    mainTabWidth = LogoWidth + LogoMargin.Left + LogoMargin.Right;
                return mainTabWidth;
            }
            set => mainTabWidth = value;
        }

        public double RightMargin { get; set; } = 0D;

        public double SecondaryTabWidth
        {
            get
            {
                if (secondaryTabWidth <= 1)
                    secondaryTabWidth = (double)(((int)MainTabWidth * 10) / 8);
                return secondaryTabWidth;
            }
            set => secondaryTabWidth = value;
        }

        public Brush SecundaryBackgroundColor { get; set; } = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        public Thickness TabPadding { get; set; } = new Thickness(0);
        public double WindowHeight { get; set; } = 150D;
        public double WindowWidth { get; set; } = 200D;

        public List<string> GetMainMenuItems()
        {
            var menu = new List<string>
            {
                "Thuis"
            };
            if ((CurrentGamePhase == GamePhase.Start || CurrentGamePhase == GamePhase.TeamComposition) && CurrentUserRole == UserRole.Guest)
                menu.Add("Registreer");
            if (CurrentUserRole == UserRole.Admin)
                menu.Add("Wielrenners");
            if ((CurrentGamePhase == GamePhase.TeamComposition || CurrentGamePhase == GamePhase.Race) && CurrentUserRole == UserRole.Player)
                menu.Add("Mijn Team");
            if ((CurrentUserRole == UserRole.Player || CurrentUserRole == UserRole.Admin) && CurrentGamePhase == GamePhase.Race)
                menu.Add("Resultaten");
            if (CurrentUserRole == UserRole.Guest)
                menu.Add("Inloggen");
            if (CurrentUserRole != UserRole.Guest)
                menu.Add("Uitloggen");
            return menu;
        }
    }
}