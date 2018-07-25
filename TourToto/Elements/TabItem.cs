using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TourToto
{
    class TabItem : System.Windows.Controls.TabItem
    {
        public SolidColorBrush BarColour { get; } = Brushes.LightBlue;
        public ScrollViewer scroll_viewer = new ScrollViewer();
        public Grid main_tab_grid = new Grid();
        public TabItem(string header, TotoConfig.UserRole user_role, TotoConfig.GamePhase game_phase)
        {
            // set tab header:
            this.Header = header;
            // set tabitem name:
            this.Name = "tab_" + header;
            // set tab scrollviewer:
            scroll_viewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            scroll_viewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            // add scrollviewer to content tab
            this.Content = scroll_viewer;
            // set grid:
            InitiateGrid();
            // add grid to scrollviewer:
            scroll_viewer.Content = main_tab_grid;
            // create title bar:
            TextBlock txtblck_title = new TextBlock { Name = "txtblck_title", Text="Titel", Background = BarColour, Height = 80 };
            TextDecorationCollection tdc = new TextDecorationCollection();
            tdc.Add(TextDecorations.Underline);
            tdc.Add(TextDecorations.OverLine);
            txtblck_title.TextDecorations = tdc;
            Grid.SetColumnSpan(txtblck_title, 3);
            main_tab_grid.Children.Add(txtblck_title);
            // create a combobox:
            string[][] cb_items = 
            {
                new string[] { "Optie 1", "ID1" },
                new string[] { "Optie 2", "ID2" },
                new string[] { "Optie 3", "ID3" },
                new string[] { "Optie 4", "ID4","hoi" }
            };
            ControlProperties cb_properties = new ControlProperties
            {
                Width = "auto",
                Height = "30",
                Name = "my_combobox",
                ComboBoxPlaceholder = "Kies een optie...",
                ComboboxItems = cb_items,
                Row = 1
            };
            ElementFactory element_factory = new ElementFactory();
            main_tab_grid.Children.Add(element_factory.ComboBoxFactory(cb_properties));
        }
        public void InitiateGrid()
        {
            var converter = new GridLengthConverter();
            // Rows:
            RowDefinition row_def_title = new RowDefinition();
            RowDefinition row_def_main_content = new RowDefinition();
            row_def_title.Height = (GridLength)converter.ConvertFromString("100");
            row_def_main_content.Height = (GridLength)converter.ConvertFromString("*");
            main_tab_grid.RowDefinitions.Add(row_def_title);
            main_tab_grid.RowDefinitions.Add(row_def_main_content);
            // Columns:
            ColumnDefinition col_def_left_margin = new ColumnDefinition();
            ColumnDefinition col_def_center = new ColumnDefinition();
            ColumnDefinition col_def_right_margin = new ColumnDefinition();
            col_def_left_margin.Width = (GridLength)converter.ConvertFromString("120");
            col_def_center.Width = (GridLength)converter.ConvertFromString("*");
            col_def_right_margin.MinWidth = 50;
            col_def_right_margin.MaxWidth = 120;
            col_def_right_margin.Width = (GridLength)converter.ConvertFromString("*");
            main_tab_grid.ColumnDefinitions.Add(col_def_left_margin);
            main_tab_grid.ColumnDefinitions.Add(col_def_center);
            main_tab_grid.ColumnDefinitions.Add(col_def_right_margin);
        }
    }
}
