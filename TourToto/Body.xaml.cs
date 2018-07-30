using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TourToto.Elements;

namespace TourToto
{
    /// <summary>
    /// Interaction logic for Body.xaml
    /// </summary>
    public partial class Body : UserControl
    {
        private TabControl mainTabControl;

        public Body()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(PopulateBody);
        }

        private void PopulateBody(object sender, RoutedEventArgs e)
        {
            var factory = new ElementFactory();
            var properties = new ControlProperties()
            {
                Name = "mainTabControl"
            };
            mainTabControl = factory.TabControlFactory(properties);
            BodyRoot.Children.Add(mainTabControl);
            PopulateMainTabControl();
        }

        private void PopulateMainTabControl()
        {
            var config = new TotoConfig("default");
            var factory = new ElementFactory();
            List<string> mainMenuItems = config.GetMainMenuItems();
            foreach (string menuItem in mainMenuItems)
            {
                var properties = new ControlProperties { Header = menuItem };
                System.Windows.Controls.TabItem tabItem = factory.TabItemFactory(properties);
                mainTabControl.Items.Add(tabItem);
            }
        }
    }
}