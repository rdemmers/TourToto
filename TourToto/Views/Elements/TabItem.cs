using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TourToto.Views.Elements
{
    internal class TabItem : System.Windows.Controls.TabItem
    {
        public Grid MainTabGrid = new Grid();
        public ScrollViewer ScrollViewer = new ScrollViewer();

        public TabItem(string header, TotoConfig.UserRole userRole, TotoConfig.GamePhase gamePhase)
        {
            this.Header = header;

            this.Name = "tab_" + header;

            ScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            ScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;

            this.Content = ScrollViewer;

            InitiateGrid();

            // add grid to scrollviewer:
            ScrollViewer.Content = MainTabGrid;

            // create title bar:
            var textBlockTitle = new TextBlock { Name = "txtblck_title", Text = "Titel", Background = BarColour, Height = 80 };
            var textDecorations = new TextDecorationCollection();
            textDecorations.Add(TextDecorations.Underline);
            textDecorations.Add(TextDecorations.OverLine);
            textBlockTitle.TextDecorations = textDecorations;
            Grid.SetColumnSpan(textBlockTitle, 3);
            MainTabGrid.Children.Add(textBlockTitle);

            // create a combobox:
            string[][] cbItems =
            {
                new string[] { "Optie 1", "ID1" },
                new string[] { "Optie 2", "ID2" },
                new string[] { "Optie 3", "ID3" },
                new string[] { "Optie 4", "ID4","hoi" }
            };
            var controlProperties = new ControlProperties
            {
                Width = "auto",
                Height = "30",
                Name = "my_combobox",
                ComboBoxPlaceholder = "Kies een optie...",
                ComboboxItems = cbItems,
                Row = 1
            };
            var elementFactory = new ElementFactory();
            MainTabGrid.Children.Add(elementFactory.ComboBoxFactory(controlProperties));
        }

        public SolidColorBrush BarColour { get; } = Brushes.LightBlue;

        public void InitiateGrid()
        {
            var converter = new GridLengthConverter();
            // Rows:

            var titleRowDefinition = new RowDefinition();
            var mainContentRowDefinition = new RowDefinition();
            titleRowDefinition.Height = (GridLength)converter.ConvertFromString("100");
            mainContentRowDefinition.Height = (GridLength)converter.ConvertFromString("*");
            MainTabGrid.RowDefinitions.Add(titleRowDefinition);
            MainTabGrid.RowDefinitions.Add(mainContentRowDefinition);

            // Columns:
            var columnLeftMargin = new ColumnDefinition();
            var columnCenter = new ColumnDefinition();
            var columnRightMargin = new ColumnDefinition();
            columnLeftMargin.Width = (GridLength)converter.ConvertFromString("120");
            columnCenter.Width = (GridLength)converter.ConvertFromString("*");
            columnRightMargin.MinWidth = 50;
            columnRightMargin.MaxWidth = 120;
            columnRightMargin.Width = (GridLength)converter.ConvertFromString("*");
            MainTabGrid.ColumnDefinitions.Add(columnLeftMargin);
            MainTabGrid.ColumnDefinitions.Add(columnCenter);
            MainTabGrid.ColumnDefinitions.Add(columnRightMargin);
        }
    }
}