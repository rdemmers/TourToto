//*******************************
// Title:	ElementFactory Class
// Author:	Thijs Peterkamp
// Version:	0.2
//*******************************

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TourToto.Elements
{
    internal class ElementFactory
    {
        /// <summary>
        /// ElementFactory class with methods to create <c>System.Windows.Controls</c> elements.
        /// </summary>
        /// <seealso cref="ControlProperties" />
        private dynamic newItem;

        private Type type;
        private ControlProperties controlProperties;

        //====================================================================================================
        public Button ButtonFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.controlProperties = properties;
            // Set type:
            type = typeof(Button);
            // Create new Button:
            newItem = new Button();

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

            return (Button)newItem;
        }

        public CheckBox CheckBoxFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.controlProperties = properties;
            // Set type:
            type = typeof(CheckBox);
            // Create new CheckBox:
            newItem = new CheckBox();

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

            return (CheckBox)newItem;
        }

        public ColumnDefinition ColumnDefinitionFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.controlProperties = properties;
            // Set type:
            type = typeof(ColumnDefinition);
            // Create new ColumnDefinition:
            newItem = new ColumnDefinition();

            // SET PROPERTIES:
            SetIsEnabledProperty();
            SetNameProperty();
            SetWidthProperties();

            return (ColumnDefinition)newItem;
        }

        public ComboBox ComboBoxFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.controlProperties = properties;
            // Set type:
            type = typeof(ComboBox);
            // Create new ComboBox:
            newItem = new ComboBox();

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
                var placeholder = new ComboBoxItem
                {
                    Content = properties.ComboBoxPlaceholder,
                    IsEnabled = false,
                    IsSelected = true
                };
                newItem.Items.Add(placeholder);
            }
            // create ComboBoxItems:
            if (!properties.HasComboBoxItems) return (ComboBox)newItem;

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
                ((ComboBox)newItem).Items.Add(item);
            }
            return (ComboBox)newItem;
        }

        public ComboBoxItem ComboBoxItemFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.controlProperties = properties;
            // Set type:
            type = typeof(ComboBoxItem);
            // Create new ComboBoxItem:
            newItem = new ComboBoxItem();

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

            return (ComboBoxItem)newItem;
        }

        public DockPanel DockPanelFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.controlProperties = properties;
            // Set type:
            type = typeof(DockPanel);
            // Create new DockPanel:
            newItem = new DockPanel();

            // SET PROPERTIES:
            SetAlignmentProperties();
            SetBackgroundProperty();
            SetDimensionProperties();
            SetIsEnabledProperty();
            SetMarginProperty();
            SetNameProperty();
            SetUidProperty();
            SetVisibilityProperty();

            return (DockPanel)newItem;
        }

        public Grid GridFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.controlProperties = properties;
            // Set type:
            type = typeof(Grid);
            // Create new Grid:
            newItem = new Grid();

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

            return (Grid)newItem;
        }

        public Image ImageFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.controlProperties = properties;
            // Set type:
            type = typeof(Image);
            // Create new Image:
            newItem = new Image();

            // SET PROPERTIES:
            SetDimensionProperties();
            SetGridProperties();
            SetIsEnabledProperty();
            SetMarginProperty();
            SetNameProperty();
            SetSourceProperty();
            SetUidProperty();
            SetVisibilityProperty();

            return (Image)newItem;
        }

        public PasswordBox PasswordBoxFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.controlProperties = properties;
            // Set type:
            type = typeof(PasswordBox);
            // Create new PasswordBox:
            newItem = new PasswordBox();

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

            return (PasswordBox)newItem;
        }

        public RowDefinition RowDefinitionFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.controlProperties = properties;
            // Set type:
            type = typeof(RowDefinition);
            // Create new RowDefinition:
            newItem = new RowDefinition();

            // SET PROPERTIES:
            SetIsEnabledProperty();
            SetHeightProperties();
            SetNameProperty();

            return (RowDefinition)newItem;
        }

        public ScrollViewer ScrollViewerFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.controlProperties = properties;
            // Set type:
            type = typeof(ScrollViewer);
            // Create new ScrollViewer:
            newItem = new ScrollViewer();

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

            return (ScrollViewer)newItem;
        }

        public TabControl TabControlFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.controlProperties = properties;
            // Set type:
            type = typeof(TabControl);
            // Create new TabControl:
            newItem = new TabControl();

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

            return (TabControl)newItem;
        }

        public TabItem TabItemFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.controlProperties = properties;
            // Set type:
            type = typeof(System.Windows.Controls.TabItem);
            // Create new TabItem:
            newItem = new System.Windows.Controls.TabItem();

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

            return (TabItem)newItem;
        }

        public TextBlock TextBlockFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.controlProperties = properties;
            // Set type:
            type = typeof(TextBlock);
            // Create new TextBlock:
            newItem = new TextBlock();

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

            return (TextBlock)newItem;
        }

        public TextBox TextBoxFactory(ControlProperties properties)
        {
            // Store properties in field:
            this.controlProperties = properties;
            // Set type:
            type = typeof(TextBox);
            // Create new TextBox:
            newItem = new TextBox();

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

            return (TextBox)newItem;
        }

        //====================================================================================================
        private void SetAlignmentProperties()
        {
            SetHorizontalAlignmentProperty();
            SetVerticalAlignmentProperty();
        }

        private void SetBackgroundProperty()
        {
            if (!controlProperties.HasBackground) return;

            newItem = Convert.ChangeType(newItem, type);
            newItem.Background = controlProperties.Background;
        }

        private void SetClickProperty()
        {
            if (!controlProperties.HasClick) return;

            newItem = Convert.ChangeType(newItem, type);
            newItem.Click += controlProperties.Click;
        }

        private void SetContentProperty()
        {
            if (!controlProperties.HasContent) return;

            newItem = Convert.ChangeType(newItem, type);
            newItem.Content = controlProperties.Content;
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
            if (!controlProperties.HasFontSize) return;

            newItem = Convert.ChangeType(newItem, type);
            newItem.FontSize = controlProperties.FontSize;
        }

        private void SetFontWeightProperty()
        {
            if (!controlProperties.HasFontWeight) return;

            newItem = Convert.ChangeType(newItem, type);
            newItem.FontWeight = controlProperties.FontWeight;
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
            if (!controlProperties.HasColumn) return;

            newItem = Convert.ChangeType(newItem, type);
            Grid.SetColumn(newItem, controlProperties.Column);
        }

        private void SetGridColumnSpanProperty()
        {
            if (!controlProperties.HasColumnSpan) return;

            newItem = Convert.ChangeType(newItem, type);
            Grid.SetColumnSpan(newItem, controlProperties.ColumnSpan);
        }

        private void SetGridRowProperty()
        {
            if (!controlProperties.HasRow) return;

            newItem = Convert.ChangeType(newItem, type);
            Grid.SetRow(newItem, controlProperties.Row);
        }

        private void SetGridRowSpanProperty()
        {
            if (controlProperties.HasRowSpan)
            {
                newItem = Convert.ChangeType(newItem, type);
                Grid.SetRowSpan(newItem, controlProperties.RowSpan);
            }
        }

        private void SetHeaderProperty()
        {
            if (!controlProperties.HasHeader) return;

            newItem = Convert.ChangeType(newItem, type);
            newItem.Header = controlProperties.Header;
        }

        private void SetHeightProperties()
        {
            SetHeightProperty();
            SetMinHeightProperty();
            SetMaxHeightProperty();
        }

        private void SetHeightProperty()
        {
            if (!controlProperties.HasHeight) return;

            newItem = Convert.ChangeType(newItem, type);
            if (controlProperties.Height == "Auto" || controlProperties.Height == "auto")
            {
                newItem.Height = Double.NaN;
            }
            else if (int.TryParse(controlProperties.Height, out int height) && height != 0)
            {
                newItem.Height = (double)height;
            }
        }

        private void SetHorizontalAlignmentProperty()
        {
            if (!controlProperties.HasHorizontalAlignment) return;

            newItem = Convert.ChangeType(newItem, type);
            newItem.HorizontalAlignment = controlProperties.HorizontalAlignment;
        }

        private void SetHorizontalContentAlignmentProperty()
        {
            if (!controlProperties.HasHorizontalContentAlignment) return;

            newItem = Convert.ChangeType(newItem, type);
            newItem.HorizontalContentAlignment = controlProperties.HorizontalContentAlignment;
        }

        private void SetHorizontalScrollBarVisibilityProperty()
        {
            if (!controlProperties.HasHorizontalScrollBarVisibility) return;

            newItem = Convert.ChangeType(newItem, type);
            newItem.HorizontalScrollBarVisibility = controlProperties.HorizontalScrollBarVisibility;
        }

        private void SetIsCheckedProperty()
        {
            if (!controlProperties.HasIsChecked) return;

            newItem = Convert.ChangeType(newItem, type);
            newItem.IsChecked = controlProperties.IsChecked;
        }

        private void SetIsEnabledProperty()
        {
            if (!controlProperties.HasIsEnabled) return;

            newItem = Convert.ChangeType(newItem, type);
            newItem.IsEnabled = controlProperties.IsEnabled;
        }

        private void SetIsSelectedProperty()
        {
            if (!controlProperties.HasIsSelected) return;

            newItem = Convert.ChangeType(newItem, type);
            newItem.IsSelected = controlProperties.IsSelected;
        }

        private void SetMarginProperty()
        {
            if (!controlProperties.HasMargin) return;

            newItem = Convert.ChangeType(newItem, type);
            ThicknessConverter tc = new ThicknessConverter();
            newItem.Margin = (Thickness)tc.ConvertFromString(controlProperties.Margin);
        }

        private void SetMaxHeightProperty()
        {
            if (controlProperties.HasMaxHeight)
            {
                newItem = Convert.ChangeType(newItem, type);
                newItem.MaxHeight = (double)controlProperties.MaxHeight;
            }
        }

        private void SetMaxWidthProperty()
        {
            if (controlProperties.HasMaxWidth)
            {
                newItem = Convert.ChangeType(newItem, type);
                newItem.MaxWidth = (double)controlProperties.MaxWidth;
            }
        }

        private void SetMinHeightProperty()
        {
            if (controlProperties.HasMinHeight)
            {
                newItem = Convert.ChangeType(newItem, type);
                newItem.MinHeight = (double)controlProperties.MinHeight;
            }
        }

        private void SetMinWidthProperty()
        {
            if (controlProperties.HasMinWidth)
            {
                newItem = Convert.ChangeType(newItem, type);
                newItem.MinWidth = (double)controlProperties.MinWidth;
            }
        }

        private void SetNameProperty()
        {
            if (controlProperties.HasName)
            {
                newItem = Convert.ChangeType(newItem, type);
                newItem.Name = controlProperties.Name;
            }
        }

        private void SetPaddingProperty()
        {
            if (controlProperties.HasPadding)
            {
                newItem = Convert.ChangeType(newItem, type);
                ThicknessConverter tc = new ThicknessConverter();
                newItem.Padding = (Thickness)tc.ConvertFromString(controlProperties.Padding);
            }
        }

        private void SetPasswordProperties()
        {
            SetPasswordProperty();
            SetPasswordCharProperty();
        }

        private void SetPasswordProperty()
        {
            if (controlProperties.HasPassword)
            {
                newItem = Convert.ChangeType(newItem, type);
                newItem.Password = controlProperties.Password;
            }
        }

        private void SetPasswordCharProperty()
        {
            if (controlProperties.HasPasswordChar)
            {
                newItem = Convert.ChangeType(newItem, type);
                newItem.PasswordChar = controlProperties.PasswordChar;
            }
        }

        private void SetScrollBarVisibilityProperties()
        {
            SetHorizontalScrollBarVisibilityProperty();
            SetVerticalScrollBarVisibilityProperty();
        }

        private void SetSourceProperty()
        {
            if (controlProperties.HasSource)
            {
                newItem = Convert.ChangeType(newItem, type);
                newItem.Source = new BitmapImage(new Uri(controlProperties.Source, UriKind.Relative));
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
            if (controlProperties.HasText)
            {
                newItem = Convert.ChangeType(newItem, type);
                newItem.Text = controlProperties.Text;
            }
        }

        private void SetTextAlignmentProperty()
        {
            if (controlProperties.HasTextAlignment)
            {
                newItem = Convert.ChangeType(newItem, type);
                newItem.TextAlignment = controlProperties.TextAlignment;
            }
        }

        private void SetTextDecorationsProperty()
        {
            if (controlProperties.HasTextDecorations)
            {
                newItem = Convert.ChangeType(newItem, type);
                newItem.TextDecorations = controlProperties.TextDecorations;
            }
        }

        private void SetTextWrappingProperty()
        {
            if (controlProperties.HasTextWrapping)
            {
                newItem = Convert.ChangeType(newItem, type);
                newItem.TextWrapping = controlProperties.TextWrapping;
            }
        }

        private void SetUidProperty()
        {
            if (controlProperties.HasUid)
            {
                newItem = Convert.ChangeType(newItem, type);
                newItem.Uid = controlProperties.Uid;
            }
        }

        private void SetVerticalAlignmentProperty()
        {
            if (controlProperties.HasVerticalAligntment)
            {
                newItem = Convert.ChangeType(newItem, type);
                newItem.VerticalAlignment = controlProperties.VerticalAlignment;
            }
        }

        private void SetVerticalContentAlignmentProperty()
        {
            if (controlProperties.HasVerticalContentAlignment)
            {
                newItem = Convert.ChangeType(newItem, type);
                newItem.VerticalContentAlignment = controlProperties.VerticalContentAlignment;
            }
        }

        private void SetVerticalScrollBarVisibilityProperty()
        {
            if (controlProperties.HasVerticalScrollBarVisibility)
            {
                newItem = Convert.ChangeType(newItem, type);
                newItem.VerticalScrollBarVisibility = controlProperties.VerticalScrollBarVisibility;
            }
        }

        private void SetVisibilityProperty()
        {
            if (controlProperties.HasIsVisible)
            {
                newItem = Convert.ChangeType(newItem, type);
                if (controlProperties.IsVisible)
                    newItem.Visibility = Visibility.Visible;
                else
                    newItem.Visibility = Visibility.Hidden;
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
            if (controlProperties.HasWidth)
            {
                newItem = Convert.ChangeType(newItem, type);
                if (controlProperties.Width == "Auto" || controlProperties.Width == "auto")
                {
                    newItem.Width = Double.NaN;
                }
                else if (int.TryParse(controlProperties.Width, out int width) && width != 0)
                {
                    newItem.Width = (double)width;
                }
            }
        }
    }
}