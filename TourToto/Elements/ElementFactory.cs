//*******************************
// Title:	ElementFactory Class
// Author:	Thijs Peterkamp
// Version:	0.2
//*******************************
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;

namespace TourToto
{
    class ElementFactory
    {
        /// <summary>
        /// ElementFactory class with methods to create <c>System.Windows.Controls</c> elements.
        /// </summary>
        /// <seealso cref="ControlProperties">
        private dynamic new_item;
        private Type type;
        private ControlProperties properties;
        //====================================================================================================
        public Button ButtonFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.properties = properties;
            // Set type:
            type = typeof(Button);
            // Create new Button:
            new_item = new Button();

            // SET PROPERTIES:
            SetAlignmentProperties();
            SetBackgroundProperty();
            SetClickProperty();
            SetContentProperty();
            SetContentAlignmentProperties();
            SetDimensionProperties();
            SetFontProperties();
            SetGridProperties();
            SetIsEnabledProperty();
            SetMarginProperty();
            SetNameProperty();
            SetPaddingProperty();
            SetUidProperty();
            SetVisibilityProperty();

            return (Button)new_item;
        }
        public CheckBox CheckBoxFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.properties = properties;
            // Set type:
            type = typeof(CheckBox);
            // Create new CheckBox:
            new_item = new CheckBox();

            // SET PROPERTIES:
            SetAlignmentProperties();
            SetBackgroundProperty();
            SetContentAlignmentProperties();
            SetDimensionProperties();
            SetFontProperties();
            SetGridProperties();
            SetIsCheckedProperty();
            SetIsEnabledProperty();
            SetMarginProperty();
            SetNameProperty();
            SetPaddingProperty();
            SetUidProperty();
            SetVisibilityProperty();

            return (CheckBox)new_item;
        }
        public ColumnDefinition ColumnDefinitionFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.properties = properties;
            // Set type:
            type = typeof(ColumnDefinition);
            // Create new ColumnDefinition:
            new_item = new ColumnDefinition();

            // SET PROPERTIES:
            SetIsEnabledProperty();
            SetNameProperty();
            SetWidthProperties();

            return (ColumnDefinition)new_item;
        }
        public ComboBox ComboBoxFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.properties = properties;
            // Set type:
            type = typeof(ComboBox);
            // Create new ComboBox:
            new_item = new ComboBox();

            // SET PROPERTIES:
            SetAlignmentProperties();
            SetBackgroundProperty();
            SetContentAlignmentProperties();
            SetDimensionProperties();
            SetFontProperties();
            SetGridProperties();
            SetIsEnabledProperty();
            SetMarginProperty();
            SetNameProperty();
            SetPaddingProperty();
            SetUidProperty();
            SetVisibilityProperty();

            // create ComboBoxItem as placeholder:
            if (properties.HasComboBoxPlaceholder)
            {
                ComboBoxItem placeholder = new ComboBoxItem
                {
                    Content = properties.ComboBoxPlaceholder,
                    IsEnabled = false,
                    IsSelected = true
                };
                new_item.Items.Add(placeholder);
            }
            // create ComboBoxItems:
            if (properties.HasComboBoxItems)
            {
                foreach (string[] item_properties in properties.ComboboxItems)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    for (int i = 0; i < item_properties.Length; i++)
                    {
                        if (i == 0)
                            item.Content = item_properties[i];
                        if (i == 1)
                            item.Uid = item_properties[i];
                    }
                    ((ComboBox)new_item).Items.Add(item);
                }
            }
            return (ComboBox)new_item;
        }
        public ComboBoxItem ComboBoxItemFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.properties = properties;
            // Set type:
            type = typeof(ComboBoxItem);
            // Create new ComboBoxItem:
            new_item = new ComboBoxItem();

            // SET PROPERTIES:
            SetAlignmentProperties();
            SetBackgroundProperty();
            SetContentProperty();
            SetContentAlignmentProperties();
            SetDimensionProperties();
            SetFontProperties();
            SetIsEnabledProperty();
            SetIsSelectedProperty();
            SetMarginProperty();
            SetNameProperty();
            SetPaddingProperty();
            SetUidProperty();
            SetVisibilityProperty();

            return (ComboBoxItem)new_item;
        }
        public DockPanel DockPanelFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.properties = properties;
            // Set type:
            type = typeof(DockPanel);
            // Create new DockPanel:
            new_item = new DockPanel();

            // SET PROPERTIES:
            SetAlignmentProperties();
            SetBackgroundProperty();
            SetDimensionProperties();
            SetIsEnabledProperty();
            SetMarginProperty();
            SetNameProperty();
            SetUidProperty();
            SetVisibilityProperty();

            return (DockPanel)new_item;
        }
        public Grid GridFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.properties = properties;
            // Set type:
            type = typeof(Grid);
            // Create new Grid:
            new_item = new Grid();

            // SET PROPERTIES:
            SetAlignmentProperties();
            SetBackgroundProperty();
            SetDimensionProperties();
            SetGridProperties();
            SetIsEnabledProperty();
            SetMarginProperty();
            SetNameProperty();
            SetUidProperty();
            SetVisibilityProperty();

            return (Grid)new_item;
        }
        public Image ImageFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.properties = properties;
            // Set type:
            type = typeof(Image);
            // Create new Image:
            new_item = new Image();

            // SET PROPERTIES:
            SetDimensionProperties();
            SetGridProperties();
            SetIsEnabledProperty();
            SetMarginProperty();
            SetNameProperty();
            SetSourceProperty();
            SetUidProperty();
            SetVisibilityProperty();

            return (Image)new_item;
        }
        public PasswordBox PasswordBoxFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.properties = properties;
            // Set type:
            type = typeof(PasswordBox);
            // Create new PasswordBox:
            new_item = new PasswordBox();

            // SET PROPERTIES:
            SetAlignmentProperties();
            SetBackgroundProperty();
            SetContentAlignmentProperties();
            SetDimensionProperties();
            SetFontProperties();
            SetGridProperties();
            SetIsEnabledProperty();
            SetMarginProperty();
            SetNameProperty();
            SetPaddingProperty();
            SetPasswordProperties();
            SetTextWrappingProperty();
            SetUidProperty();
            SetVisibilityProperty();

            return (PasswordBox)new_item;
        }
        public RowDefinition RowDefinitionFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.properties = properties;
            // Set type:
            type = typeof(RowDefinition);
            // Create new RowDefinition:
            new_item = new RowDefinition();

            // SET PROPERTIES:
            SetIsEnabledProperty();
            SetHeightProperties();
            SetNameProperty();

            return (RowDefinition)new_item;
        }
        public ScrollViewer ScrollViewerFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.properties = properties;
            // Set type:
            type = typeof(ScrollViewer);
            // Create new ScrollViewer:
            new_item = new ScrollViewer();

            // SET PROPERTIES:
            SetAlignmentProperties();
            SetBackgroundProperty();
            SetContentAlignmentProperties();
            SetDimensionProperties();
            SetFontProperties();
            SetIsEnabledProperty();
            SetMarginProperty();
            SetNameProperty();
            SetPaddingProperty();
            SetScrollBarVisibilityProperties();
            SetUidProperty();
            SetVisibilityProperty();

            return (ScrollViewer)new_item;
        }
        public TabControl TabControlFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.properties = properties;
            // Set type:
            type = typeof(TabControl);
            // Create new TabControl:
            new_item = new TabControl();

            // SET PROPERTIES:
            SetAlignmentProperties();
            SetBackgroundProperty();
            SetContentAlignmentProperties();
            SetDimensionProperties();
            SetFontProperties();
            SetIsEnabledProperty();
            SetMarginProperty();
            SetNameProperty();
            SetPaddingProperty();
            SetUidProperty();
            SetVisibilityProperty();

            return (TabControl)new_item;
        }
        public TabItem TabItemFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.properties = properties;
            // Set type:
            type = typeof(System.Windows.Controls.TabItem);
            // Create new TabItem:
            new_item = new System.Windows.Controls.TabItem();

            // SET PROPERTIES:
            SetAlignmentProperties();
            SetBackgroundProperty();
            SetContentAlignmentProperties();
            SetDimensionProperties();
            SetFontProperties();
            SetGridProperties();
            SetHeaderProperty();
            SetIsEnabledProperty();
            SetIsSelectedProperty();
            SetMarginProperty();
            SetNameProperty();
            SetPaddingProperty();
            SetUidProperty();
            SetVisibilityProperty();

            return (TabItem)new_item;
        }
        public TextBlock TextBlockFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.properties = properties;
            // Set type:
            type = typeof(TextBlock);
            // Create new TextBlock:
            new_item = new TextBlock();

            // SET PROPERTIES:
            SetAlignmentProperties();
            SetBackgroundProperty();
            SetDimensionProperties();
            SetFontProperties();
            SetGridProperties();
            SetIsEnabledProperty();
            SetMarginProperty();
            SetNameProperty();
            SetPaddingProperty();
            SetTextProperties();
            SetTextWrappingProperty();
            SetUidProperty();
            SetVisibilityProperty();

            return (TextBlock)new_item;
        }
        public TextBox TextBoxFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.properties = properties;
            // Set type:
            type = typeof(TextBox);
            // Create new TextBox:
            new_item = new TextBox();

            // SET PROPERTIES:
            SetAlignmentProperties();
            SetBackgroundProperty();
            SetContentAlignmentProperties();
            SetDimensionProperties();
            SetFontProperties();
            SetGridProperties();
            SetIsEnabledProperty();
            SetMarginProperty();
            SetNameProperty();
            SetPaddingProperty();
            SetTextProperties();
            SetUidProperty();
            SetVisibilityProperty();

            return (TextBox)new_item;
        }
        //====================================================================================================
        private void SetAlignmentProperties()
        {
            SetHorizontalAlignmentProperty();
            SetVerticalAlignmentProperty();
        }
        private void SetBackgroundProperty()
        {
            if (properties.HasBackground)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.Background = properties.Background;
            }
        }
        private void SetClickProperty()
        {
            if(properties.HasClick)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.Click += properties.Click;
            }
        }
        private void SetContentProperty()
        {
            if(properties.HasContent)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.Content = properties.Content;
            }
        }
        private void SetContentAlignmentProperties()
        {
            SetHorizontalContentAlignmentProperty();
            SetVerticalContentAlignmentProperty();
        }
        private void SetDimensionProperties()
        {
            SetHeightProperties();
            SetWidthProperties();
        }
        private void SetFontProperties()
        {
            SetFontSizeProperty();
            SetFontWeightProperty();
        }
        private void SetFontSizeProperty()
        {
            if (properties.HasFontSize)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.FontSize = properties.FontSize;
            }
        }
        private void SetFontWeightProperty()
        {
            if (properties.HasFontWeight)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.FontWeight = properties.FontWeight;
            }
        }
        private void SetGridProperties()
        {
            SetGridColumnProperty();
            SetGridColumnSpanProperty();
            SetGridRowProperty();
            SetGridRowSpanProperty();
        }
        private void SetGridColumnProperty()
        {
            if (properties.HasColumn)
            {
                new_item = Convert.ChangeType(new_item, type);
                Grid.SetColumn(new_item, properties.Column);
            }
        }
        private void SetGridColumnSpanProperty()
        {
            if (properties.HasColumnSpan)
            {
                new_item = Convert.ChangeType(new_item, type);
                Grid.SetColumnSpan(new_item, properties.ColumnSpan);
            }
        }
        private void SetGridRowProperty()
        {
            if (properties.HasRow)
            {
                new_item = Convert.ChangeType(new_item, type);
                Grid.SetRow(new_item, properties.Row);
            }
        }
        private void SetGridRowSpanProperty()
        {
            if (properties.HasRowSpan)
            {
                new_item = Convert.ChangeType(new_item, type);
                Grid.SetRowSpan(new_item, properties.RowSpan);
            }
        }
        private void SetHeaderProperty()
        {
            if (properties.HasHeader)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.Header = properties.Header;
            }
        }
        private void SetHeightProperties()
        {
            SetHeightProperty();
            SetMinHeightProperty();
            SetMaxHeightProperty();
        }
        private void SetHeightProperty()
        {
            if (properties.HasHeight)
            {
                new_item = Convert.ChangeType(new_item, type);
                if (properties.Height == "Auto" || properties.Height == "auto")
                {
                    new_item.Height = Double.NaN;
                }
                else if (int.TryParse(properties.Height, out int height) && height != 0)
                {
                    new_item.Height = (double)height;
                }
            }
        }
        private void SetHorizontalAlignmentProperty()
        {
            if (properties.HasHorizontalAlignment)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.HorizontalAlignment = properties.HorizontalAlignment;
            }
        }
        private void SetHorizontalContentAlignmentProperty()
        {
            if (properties.HasHorizontalContentAlignment)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.HorizontalContentAlignment = properties.HorizontalContentAlignment;
            }
        }
        private void SetHorizontalScrollBarVisibilityProperty()
        {
            if (properties.HasHorizontalScrollBarVisibility)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.HorizontalScrollBarVisibility = properties.HorizontalScrollBarVisibility;
            }
        }
        private void SetIsCheckedProperty()
        {
            if (properties.HasIsChecked)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.IsChecked = properties.IsChecked;
            }
        }
        private void SetIsEnabledProperty()
        {
            if (properties.HasIsEnabled)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.IsEnabled = properties.IsEnabled;
            }
        }
        private void SetIsSelectedProperty()
        {
            if (properties.HasIsSelected)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.IsSelected = properties.IsSelected;
            }
        }
        private void SetMarginProperty()
        {
            if (properties.HasMargin)
            {
                new_item = Convert.ChangeType(new_item, type);
                ThicknessConverter tc = new ThicknessConverter();
                new_item.Margin = (Thickness)tc.ConvertFromString(properties.Margin);
            }
        }
        private void SetMaxHeightProperty()
        {
            if (properties.HasMaxHeight)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.MaxHeight = (double)properties.MaxHeight;
            }
        }
        private void SetMaxWidthProperty()
        {
            if (properties.HasMaxWidth)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.MaxWidth = (double)properties.MaxWidth;
            }
        }
        private void SetMinHeightProperty()
        {
            if (properties.HasMinHeight)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.MinHeight = (double)properties.MinHeight;
            }
        }
        private void SetMinWidthProperty()
        {
            if (properties.HasMinWidth)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.MinWidth = (double)properties.MinWidth;
            }
        }
        private void SetNameProperty()
        {
            if (properties.HasName)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.Name = properties.Name;
            }
        }
        private void SetPaddingProperty()
        {
            if (properties.HasPadding)
            {
                new_item = Convert.ChangeType(new_item, type);
                ThicknessConverter tc = new ThicknessConverter();
                new_item.Padding = (Thickness)tc.ConvertFromString(properties.Padding);
            }
        }
        private void SetPasswordProperties()
        {
            SetPasswordProperty();
            SetPasswordCharProperty();
        }
        private void SetPasswordProperty()
        {
            if (properties.HasPassword)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.Password = properties.Password;
            }
        }
        private void SetPasswordCharProperty()
        {
            if (properties.HasPasswordChar)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.PasswordChar = properties.PasswordChar;
            }
        }
        private void SetScrollBarVisibilityProperties()
        {
            SetHorizontalScrollBarVisibilityProperty();
            SetVerticalScrollBarVisibilityProperty();
        }
        private void SetSourceProperty()
        {
            if (properties.HasSource)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.Source = new BitmapImage(new Uri(properties.Source, UriKind.Relative));
            }
        }
        private void SetTextProperties()
        {
            SetTextProperty();
            SetTextAlignmentProperty();
            SetTextDecorationsProperty();
            SetTextWrappingProperty();
        }
        private void SetTextProperty()
        {
            if (properties.HasText)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.Text = properties.Text;
            }
        }
        private void SetTextAlignmentProperty()
        {
            if (properties.HasTextAlignment)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.TextAlignment = properties.TextAlignment;
            }
        }
        private void SetTextDecorationsProperty()
        {
            if (properties.HasTextDecorations)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.TextDecorations = properties.TextDecorations;
            }
        }
        private void SetTextWrappingProperty()
        {
            if (properties.HasTextWrapping)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.TextWrapping = properties.TextWrapping;
            }
        }
        private void SetUidProperty()
        {
            if (properties.HasUid)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.Uid = properties.Uid;
            }
        }
        private void SetVerticalAlignmentProperty()
        {
            if (properties.HasVerticalAligntment)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.VerticalAlignment = properties.VerticalAlignment;
            }
        }
        private void SetVerticalContentAlignmentProperty()
        {
            if (properties.HasVerticalContentAlignment)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.VerticalContentAlignment = properties.VerticalContentAlignment;
            }
        }
        private void SetVerticalScrollBarVisibilityProperty()
        {
            if (properties.HasVerticalScrollBarVisibility)
            {
                new_item = Convert.ChangeType(new_item, type);
                new_item.VerticalScrollBarVisibility = properties.VerticalScrollBarVisibility;
            }
        }
        private void SetVisibilityProperty()
        {
            if (properties.HasIsVisible)
            {
                new_item = Convert.ChangeType(new_item, type);
                if (properties.IsVisible)
                    new_item.Visibility = Visibility.Visible;
                else
                    new_item.Visibility = Visibility.Hidden;
            }
        }
        private void SetWidthProperties()
        {
            SetWidthProperty();
            SetMinWidthProperty();
            SetMaxWidthProperty();
        }
        private void SetWidthProperty()
        {
            if (properties.HasWidth)
            {
                new_item = Convert.ChangeType(new_item, type);
                if (properties.Width == "Auto" || properties.Width == "auto")
                {
                    new_item.Width = Double.NaN;
                }
                else if (int.TryParse(properties.Width, out int width) && width != 0)
                {
                    new_item.Width = (double)width;
                }
            }
        }
    }
}
