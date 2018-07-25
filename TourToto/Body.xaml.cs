using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TourToto
{
    /// <summary>
    /// Interaction logic for Body.xaml
    /// </summary>
    public partial class Body : UserControl
    {
        private TabControl main_tab_ctrl;
        public Body()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(PopulateBody);
        }
        private void PopulateBody(object sender, RoutedEventArgs e)
        {
            //TabControlStyleTemplate main_tab_ctrl = new TabControlStyleTemplate();
            //LayoutRoot.Children.Add(main_tab_ctrl);
            ElementFactory factory = new ElementFactory();
            ControlProperties properties = new ControlProperties()
            {
                Name = "main_tab_ctrl"
            };
            main_tab_ctrl = factory.TabControlFactory(properties);
            BodyRoot.Children.Add(main_tab_ctrl);
            PopulateMainTabControl();
        }
        private void PopulateMainTabControl()
        {
            TotoConfig Config = new TotoConfig("default");
            ElementFactory Factory = new ElementFactory();
            List<string> main_menu_items = Config.GetMainMenuItems();
            foreach(string menu_item in main_menu_items)
            {
                ControlProperties properties = new ControlProperties { Header = menu_item };
                TabItem tab_item = Factory.TabItemFactory(properties);
                main_tab_ctrl.Items.Add(tab_item);
            }
        }
    }
}
