using MySql.Data.MySqlClient;
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
using TourToto.Connection;

namespace TourToto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TotoConfig Config { get; set; } = new TotoConfig("Default");
        public MainWindow()
        {
            InitializeComponent();
            

            //this.Loaded += new RoutedEventHandler(WindowLoaded);
        }
        public void WindowLoaded(object sender, RoutedEventArgs e)
        {/*
            // create header:
            UserControl header = new Header();
            DockPanel.SetDock(header, Dock.Top);
            header.Height = Config.HeaderHeight;
            LayoutRoot.Children.Add(header);
            // create footer:
            UserControl footer = new Footer();
            DockPanel.SetDock(footer, Dock.Bottom);
            footer.Height = Config.FooterHeight;
            footer.Background = Config.BarColor;
            LayoutRoot.Children.Add(footer);
            // create body:
            UserControl body = new Body();
            LayoutRoot.Children.Add(body);
            */
        }
    }
}
