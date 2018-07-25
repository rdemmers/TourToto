using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace TourToto
{
    public class TotoConfig
    {
        public Brush BackgroundColor { get; set; } = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        public Brush BarColor { get; set; } = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        public GamePhase CurrentGamePhase { get; set; } = GamePhase.Start;
        public UserRole CurrentUserRole { get; set; } = UserRole.Guest;
        public double FooterHeight = 1D;
        private double _header_height = 1D;
        public double HeaderHeight
        {
            get
            {
                if (_header_height <= 1)
                    _header_height = LogoHeight + LogoMargin.Top + LogoMargin.Bottom;
                return _header_height;
            }
            set { _header_height = value; }
        }
        private double _left_margin = 0D;
        public double LeftMargin
        {
            get
            {
                if (_left_margin <= 0)
                    _left_margin = LogoWidth + LogoMargin.Left + LogoMargin.Right;
                return _left_margin;
            }
            set
            {
                _left_margin = value;
            }
        }
        private double _logo_height = 1D;
        public double LogoHeight
        {
            get
            {
                if (_logo_height <= 1)
                    _logo_height = (double)(((int)LogoMinHeight+(int)LogoMaxHeight)/2);
                return _logo_height;
            }
            set
            {
                _logo_height = value;
            }
        }
        public Thickness LogoMargin { get; set; } = new Thickness(0);
        public double LogoMaxHeight { get; set; } = 0D;
        public double LogoMaxWidth { get; set; } = 0D;
        public double LogoMinHeight { get; set; } = 0D;
        public double LogoMinWidth { get; set; } = 0D;
        public double LogoWidth { get; set; } = 1D;
        private double _main_tab_with = 1D;
        public Style MainTabControlStyle { get; set; }
        public double MainTabWidth
        {
            get
            {
                if (_main_tab_with <= 1)
                    _main_tab_with = LogoWidth + LogoMargin.Left + LogoMargin.Right;
                return _main_tab_with;
            }
            set
            {
                _main_tab_with = value;
            }
        }
        public double RightMargin { get; set; } = 0D;
        public Brush SecundaryBackgroundColor { get; set; } = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        private double _secundary_tab_width = 1D;
        public double SecundaryTabWidth
        {
            get
            {
                if (_secundary_tab_width <= 1)
                    _secundary_tab_width = (double)(((int)MainTabWidth * 10)/8);
                return _secundary_tab_width;
            }
            set
            {
                _secundary_tab_width = value;
            }
        }
        public Thickness TabPadding { get; set; } = new Thickness(0);
        public double WindowHeight { get; set; } = 150D;
        public double WindowWidth { get; set; } = 200D;
        //====================================================================================================
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
        //====================================================================================================
        public TotoConfig() { }
        public TotoConfig(string init)
        {
            if (init == "default" || init == "Default")
            {
                BackgroundColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                BarColor = new SolidColorBrush(Color.FromRgb(216, 226, 243));
                FooterHeight = 50D;
                LogoMargin = new Thickness(10);
                LogoMaxHeight = LogoMaxWidth = 100D;
                LogoMinHeight = LogoMinWidth = 80D;
                LogoMaxWidth = 100D;
                LogoMinWidth = 80D;
                SecundaryBackgroundColor = new SolidColorBrush(Color.FromRgb(242,242,242));
                TabPadding = new Thickness(5, 2, 5, 2);
                WindowHeight = 768D;
                WindowWidth = 1024D;
            }
        }
        public List<string> GetMainMenuItems()
        {
            List<string> menu = new List<string>
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
        /*
        private void SetMainTabControlStyle()
        {
            Style MainTabControlStyle = new Style(typeof(TabControl));
            MainTabControlStyle.Setters.Add(new Setter(TabControl.PaddingProperty, new Thickness(2)));
            MainTabControlStyle.Setters.Add(new Setter(TabControl.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
            MainTabControlStyle.Setters.Add(new Setter(TabControl.VerticalContentAlignmentProperty, VerticalAlignment.Center));
            ContentControl c1 = new ContentControl();
            c1.SetBinding(ContentControl.ContentProperty, new Binding("StaticResource"));
            c1.ContentStringFormat = "TabItem.Selected.Background";
            MainTabControlStyle.Setters.Add(new Setter(TabControl.BackgroundProperty, c1)); // alternative for c1: SecundaryBackgroundColor
            MainTabControlStyle.Setters.Add(new Setter(TabControl.BorderBrushProperty, Color.FromRgb(172, 172, 172)));
            MainTabControlStyle.Setters.Add(new Setter(TabControl.BorderThicknessProperty, new Thickness(1)));
            MainTabControlStyle.Setters.Add(new Setter(TabControl.ForegroundProperty, SystemColors.ControlTextBrushKey));

            // Template:
            ControlTemplate template = new ControlTemplate(typeof(TabControl));
            FrameworkElementFactory root_grid = new FrameworkElementFactory(typeof(Grid));
            root_grid.Name = "Grid";
            root_grid.SetValue(Grid.NameProperty, "templateRoot");
            root_grid.SetValue(Grid.ClipToBoundsProperty, true);
            root_grid.SetValue(Grid.SnapsToDevicePixelsProperty, true);
            // KeyboardNavigation.SetTabNavigation(TabControl, KeyboardNavigationMode.Local);

            // Column definitions:
            FrameworkElementFactory cd0 = new FrameworkElementFactory(typeof(ColumnDefinition));
            cd0.SetValue(ColumnDefinition.NameProperty, "ColumnDefinition0");
            root_grid.AppendChild(cd0);
            FrameworkElementFactory cd1 = new FrameworkElementFactory(typeof(ColumnDefinition));
            cd1.SetValue(ColumnDefinition.NameProperty, "ColumnDefinition1");
            cd1.SetValue(ColumnDefinition.WidthProperty, 0);
            root_grid.AppendChild(cd1);

            // Row definitions:
            FrameworkElementFactory rw0 = new FrameworkElementFactory(typeof(RowDefinition));
            rw0.SetValue(RowDefinition.NameProperty, "RowDefinition0");
            rw0.SetValue(RowDefinition.HeightProperty, new GridLength(Double.NaN, GridUnitType.Auto));
            root_grid.AppendChild(rw0);
            FrameworkElementFactory rw1 = new FrameworkElementFactory(typeof(RowDefinition));
            rw1.SetValue(RowDefinition.NameProperty, "RowDefinition1");
            rw1.SetValue(RowDefinition.HeightProperty, new GridLength(1D, GridUnitType.Star));

            // Tab panel:
            FrameworkElementFactory tbpnl = new FrameworkElementFactory(typeof(TabPanel));
            tbpnl.SetValue(TabPanel.nam = "headerPanel");
            tbpnl.SetValue(TabPanel.BackgroundProperty = Brushes.Transparent);


            template.VisualTree = root_grid;
        }
        */
    }
}
