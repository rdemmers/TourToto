using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            //TabControlStyleTemplate mainTabControl = new TabControlStyleTemplate();
            //LayoutRoot.Children.Add(mainTabControl);
            ElementFactory factory = new ElementFactory();
            ControlProperties properties = new ControlProperties()
            {
                Name = "mainTabControl"
            };
            mainTabControl = factory.TabControlFactory(properties);
            BodyRoot.Children.Add(mainTabControl);
            PopulateMainTabControl();
        }

        private void PopulateMainTabControl()
        {
            TotoConfig Config = new TotoConfig("default");
            ElementFactory Factory = new ElementFactory();
            List<string> main_menu_items = Config.GetMainMenuItems();
            foreach (string menu_item in main_menu_items)
            {
                ControlProperties properties = new ControlProperties { Header = menu_item };
                System.Windows.Controls.TabItem tab_item = Factory.TabItemFactory(properties);
                mainTabControl.Items.Add(tab_item);
            }
        }
    }
}