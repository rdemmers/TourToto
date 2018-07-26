//**********************************
// Title:	ControlProperties Class
// Author:	Thijs Peterkamp
// Version:	0.2.6
//**********************************
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TourToto
{
    class ControlProperties
    {
        /// <summary>
        /// Property class for communication with WPF Control Factory
        /// </summary>
        /// <seealso cref="ElementFactory">
        /// <value><c>Background</c> gets and sets a background color of type <c>System.Windows.Media.Brush</c>.</value>
        /// <value><c>HasBackGround</c> gets a value that indicates whether this object's <c>Background</c> property holds an instance of <c>Brush</c>.</value>
		/// <value><c>Click</c> gets and sets a <c>RoutedEventHandler</c> for the Click event.</value>
		/// <value><c>HasClick</c> gets a value that indicates whether this object's <c>Click</c> property holds an instance of <c>RoutedEventHandler</c>.</value>
		/// <value><c>Column</c> gets and sets an integer that refers to a column of the element's parental <c>Grid</c>.</value>
		/// <value><c>HasColumn</c> gets a value that indicates whether this object's <c>Column</c> property holds an integer value.</value>
        //====================================================================================================
        // BACKGROUND:
        // Element background color
        // | Brushes.Red,
        // | SolidColorBrush(Colors.Blue),
        // | SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0, 0)),
        // | System.Windows.SystemColors.MenuHighlightBrush,
        // | etc.
        //====================================================================================================
        private Brush _background;
        public Brush Background
        {
            get => _background;
            set
            {
                _background = value;
                _has_background = true;
            }
        }
        private bool _has_background = false;
        public bool HasBackground
        {
            get => _has_background;
        }
        //====================================================================================================
        // CLICK:
        // Method called on Button Click event
        //====================================================================================================
        private RoutedEventHandler _click;
        public RoutedEventHandler Click
        {
            get => _click;
            set
            {
                _click = value;
                _has_click = true;
            }
        }
        private bool _has_click = false;
        public bool HasClick
        {
            get => _has_click;
        }
        //====================================================================================================
        // COLUMN:
        // Column index of element's parental Grid
        //====================================================================================================
        private int _column;
        public int Column
        {
            get => _column;
            set
            {
                _column = value;
                _has_column = true;
            }
        }
        private bool _has_column = false;
        public bool HasColumn
        {
            get => _has_column;
        }
        //====================================================================================================
        // COLUMN SPAN:
        // Element's column span within parental Grid
        //====================================================================================================
        private int _column_span;
        public int ColumnSpan
        {
            get => _column_span;
            set
            {
                _column_span = value;
                _has_column_span = true;
            }
        }
        private bool _has_column_span = false;
        public bool HasColumnSpan
        {
            get => _has_column_span;
        }
        //====================================================================================================
        // COMBOBOX ITEMS:
        // Array of Content-Uid pairs for creation of multiple instances of ComboBoxItem
        //====================================================================================================
        private string[][] _combobox_items;
        public string[][] ComboboxItems
        {
            get => _combobox_items;
            set
            {
                var input = value;
                // determine number of rows in input:
                int rows = 0;
                foreach (string[] row in input)
                    rows++;
                // initiate _combobox_items rows:
                _combobox_items = new string[rows][];
                // initiate _combobox_items columns for each row:
                for (int i = 0; i < rows; i++)
                {
                    // determine number of columns in each row of input:
                    int columns = 0;
                    foreach (string column in input[i])
                        columns++;
                    // initiate sub-array for current row:
                    _combobox_items[i] = new string[columns];
                }
                // set:
                _combobox_items = input;
                _has_combobox_items = true;
            }
        }
        private bool _has_combobox_items = false;
        public bool HasComboBoxItems
        {
            get => _has_combobox_items;
        }
        //====================================================================================================
        // COMBOBOX PLACEHOLDER:
        // Optional placeholder for ComboBox
        //====================================================================================================
        private string _combobox_placeholder;
        public string ComboBoxPlaceholder
        {
            get => _combobox_placeholder;
            set
            {
                _combobox_placeholder = value;
                _has_combobox_placeholder = true;
            }
        }
        private bool _has_combobox_placeholder = false;
        public bool HasComboBoxPlaceholder
        {
            get => _has_combobox_placeholder;
        }
        //====================================================================================================
        // CONTENT:
        // For elements that accept a string content (e.g. Button, ComboBoxItem, etc.)
        //====================================================================================================
        private string _content;
        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                _has_content = true;
            }
        }
        private bool _has_content = false;
        public bool HasContent
        {
            get => _has_content;
        }
        //====================================================================================================
        // FONT SIZE:
        //====================================================================================================
        private int _font_size;
        public int FontSize
        {
            get => _font_size;
            set
            {
                _font_size = value;
                _has_font_size = true;
            }
        }
        private bool _has_font_size = false;
        public bool HasFontSize
        {
            get => _has_font_size;
        }
        //====================================================================================================
        // FONT WEIGHT:
        //====================================================================================================
        private FontWeight _font_weight;
        public FontWeight FontWeight
        {
            get => _font_weight;
            set
            {
                _font_weight = value;
                _has_font_weight = true;
            }
        }
        private bool _has_font_weight = false;
        public bool HasFontWeight
        {
            get => _has_font_weight;
        }
        //====================================================================================================
        // HEADER:
        // Header for TabItem etc.
        //====================================================================================================
        private string _header;
        public string Header
        {
            get => _header;
            set
            {
                _header = value;
                _has_header = true;
            }
        }
        private bool _has_header = false;
        public bool HasHeader
        {
            get => _has_header;
        }
        //====================================================================================================
        // HEIGHT:
        // Element height
        // | "120",
        // | "15px",
        // | "Auto",
        // | "3*",
        // | etc.
        //====================================================================================================
        private string _height;
        public string Height
        {
            get => _height;
            set
            {
                _height = value;
                _has_height = true;
            }
        }
        private bool _has_height = false;
        public bool HasHeight
        {
            get => _has_height;
        }
        //====================================================================================================
        // HORIZONTAL ALIGNMENT:
        // Horizontal alignment of element
        // | Center,
        // | Left,
        // | Right,
        // | Stretch
        //====================================================================================================
        private HorizontalAlignment _horizontal_alignment;
        public HorizontalAlignment HorizontalAlignment
        {
            get => _horizontal_alignment;
            set
            {
                _horizontal_alignment = value;
                _has_horizontal_alignment = true;
            }
        }
        private bool _has_horizontal_alignment = false;
        public bool HasHorizontalAlignment
        {
            get => _has_horizontal_alignment;
        }
        //====================================================================================================
        // HORIZONTAL CONTENT ALIGNMENT:
        // Horizontal alignment of content for e.g. TabItem, ComboBoxItem, etc.
        // | Center,
        // | Left,
        // | Right,
        // | Stretch
        //====================================================================================================
        private HorizontalAlignment _horizontal_content_alignment;
        public HorizontalAlignment HorizontalContentAlignment
        {
            get => _horizontal_content_alignment;
            set
            {
                _horizontal_content_alignment = value;
                _has_horizontal_content_alignment = true;
            }
        }
        private bool _has_horizontal_content_alignment = false;
        public bool HasHorizontalContentAlignment
        {
            get => _has_horizontal_content_alignment;
        }
        //====================================================================================================
        // HORIZONTAL SCROLLBAR VISIBILITY:
        // ScrollViewer property
        // | Auto,
        // | Disabled,
        // | Hidden,
        // | Visible
        //====================================================================================================
        private ScrollBarVisibility _horizontal_scroll_bar_visibility;  // ScrollViewer property
        public ScrollBarVisibility HorizontalScrollBarVisibility
        {
            get => _horizontal_scroll_bar_visibility;
            set
            {
                _horizontal_scroll_bar_visibility = value;
                _has_horizontal_scroll_bar_visibility = true;
            }
        }
        private bool _has_horizontal_scroll_bar_visibility = false;
        public bool HasHorizontalScrollBarVisibility
        {
            get => _has_horizontal_scroll_bar_visibility;
        }
        //====================================================================================================
        // IS CHECKED:
        // CheckBox boolean
        //====================================================================================================
        private bool _is_checked;
        public bool IsChecked
        {
            get => _is_checked;
            set
            {
                _is_checked = value;
                _has_is_checked = true;
            }
        }
        private bool _has_is_checked = false;
        public bool HasIsChecked
        {
            get => _has_is_checked;
        }
        //====================================================================================================
        // IS ENABLED:
        //====================================================================================================
        private bool _is_enabled;
        public bool IsEnabled
        {
            get => _is_enabled;
            set
            {
                _is_enabled = value;
                _has_is_enabled = true;
            }
        }
        private bool _has_is_enabled = false;
        public bool HasIsEnabled
        {
            get => _has_is_enabled;
        }
        //====================================================================================================
        // IS SELECTED:
        // For TabItem, ComboBoxItem, etc.
        //====================================================================================================
        private bool _is_selected;
        public bool IsSelected
        {
            get => _is_selected;
            set
            {
                _is_selected = value;
                _has_is_selected = true;
            }
        }
        private bool _has_is_selected = false;
        public bool HasIsSelected
        {
            get => _has_is_selected;
        }
        //====================================================================================================
        // IS VISIBLE:
        //====================================================================================================
        private bool _is_visible;
        public bool IsVisible
        {
            get => _is_visible;
            set
            {
                _is_visible = value;
                _has_is_visible = true;
            }
        }
        private bool _has_is_visible = false;
        public bool HasIsVisible
        {
            get => _has_is_visible;
        }
        //====================================================================================================
        // MARGIN:
        // String in XML format
        // | "12",
        // | "15,15",
        // | "7,5,7,5",
        // | etc.
        //====================================================================================================
        private string _margin;
        public string Margin
        {
            get => _margin;
            set
            {
                _margin = value;
                _has_margin = true;
            }
        }
        private bool _has_margin = false;
        public bool HasMargin
        {
            get => _has_margin;
        }
        //====================================================================================================
        // MAX HEIGHT:
        // Element maximum height
        //====================================================================================================
        private int _max_height;
        public int MaxHeight
        {
            get => _max_height;
            set
            {
                _max_height = value;
                _has_max_height = true;
            }
        }
        private bool _has_max_height = false;
        public bool HasMaxHeight
        {
            get => _has_max_height;
        }
        //====================================================================================================
        // MAX WIDTH:
        // Element maximum width
        //====================================================================================================
        private int _max_width;
        public int MaxWidth
        {
            get => _max_width;
            set
            {
                _max_width = value;
                _has_max_width = true;
            }
        }
        private bool _has_max_width = false;
        public bool HasMaxWidth
        {
            get => _has_max_width;
        }
        //====================================================================================================
        // MIN HEIGHT:
        // Element minimal height
        //====================================================================================================
        private int _min_height;
        public int MinHeight
        {
            get => _min_height;
            set
            {
                _min_height = value;
                _has_min_height = true;
            }
        }
        private bool _has_min_height = false;
        public bool HasMinHeight
        {
            get => _has_min_height;
        }
        //====================================================================================================
        // MIN WIDTH:
        // Element minimal width
        //====================================================================================================
        private int _min_width;
        public int MinWidth
        {
            get => _min_width;
            set
            {
                _min_width = value;
                _has_min_width = true;
            }
        }
        private bool _has_min_width = false;
        public bool HasMinWidth
        {
            get => _has_min_width;
        }
        //====================================================================================================
        // NAME:
        //====================================================================================================
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                _has_name = true;
            }
        }
        private bool _has_name = false;
        public bool HasName
        {
            get => _has_name;
        }
        //====================================================================================================
        // PADDING:
        // String in XML format
        // | "12",
        // | "15,15",
        // | "7,5,7,5"
        // | etc.
        //====================================================================================================
        private string _padding;
        public string Padding
        {
            get => _padding;
            set
            {
                _padding = value;
                _has_padding = true;
            }
        }
        private bool _has_padding = false;
        public bool HasPadding
        {
            get => _has_padding;
        }
        //====================================================================================================
        // PASSWORD:
        // Property for PasswordBase64 element
        //====================================================================================================
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                _has_password = true;
            }
        }
        private bool _has_password = false;
        public bool HasPassword
        {
            get => _has_password;
        }
        //====================================================================================================
        // PASSWORD CHAR
        //====================================================================================================
        private char _password_char;
        public char PasswordChar
        {
            get => _password_char;
            set
            {
                _password_char = value;
                _has_password_char = true;
            }
        }
        private bool _has_password_char = false;
        public bool HasPasswordChar
        {
            get => _has_password_char;
        }
        //====================================================================================================
        // ROW:
        // Row index of element's parental Grid
        //====================================================================================================
        private int _row;
        public int Row
        {
            get => _row;
            set
            {
                _row = value;
                _has_row = true;
            }
        }
        private bool _has_row = false;
        public bool HasRow
        {
            get => _has_row;
        }
        //====================================================================================================
        // ROW SPAN:
        // Element's row span within parental Grid
        //====================================================================================================
        private int _row_span;
        public int RowSpan
        {
            get => _row_span;
            set
            {
                _row_span = value;
                _has_row_span = true;
            }
        }
        private bool _has_row_span = false;
        public bool HasRowSpan
        {
            get => _has_row_span;
        }
        //====================================================================================================
        // SOURCE:
        // Image source, relative path
        // Resources supported: e.g. "/AppName;component/image.png"
        //====================================================================================================
        private string _source;
        public string Source
        {
            get => _source;
            set
            {
                _source = value;
                _has_source = true;
            }
        }
        private bool _has_source = false;
        public bool HasSource
        {
            get => _has_source;
        }
        //====================================================================================================
        // TEXT
        //====================================================================================================
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                _has_text = true;
            }
        }
        private bool _has_text = false;
        public bool HasText
        {
            get => _has_text;
        }
        //====================================================================================================
        // TEXT ALIGNMENT:
        // Text alignment for text elements
        // | Center,
        // | Justify,
        // | Left,
        // | Right
        //====================================================================================================
        private TextAlignment _text_alignment;
        public TextAlignment TextAlignment
        {
            get => _text_alignment;
            set
            {
                _text_alignment = value;
                _has_text_alignment = true;
            }
        }
        private bool _has_text_alignment = false;
        public bool HasTextAlignment
        {
            get => _has_text_alignment;
        }
        //====================================================================================================
        // TEXT DECORATIONS:
        // Text decorations for text element
        // | Baseline,
        // | OverLine,
        // | Strikethrough, 
        // | Underline
        //====================================================================================================
        private TextDecorationCollection _text_decorations;
        public TextDecorationCollection TextDecorations
        {
            get => _text_decorations;
            set
            {
                _text_decorations = value;
                _has_text_decorations = true;
            }
        }
        private bool _has_text_decorations = false;
        public bool HasTextDecorations
        {
            get => _has_text_decorations;
        }
        //====================================================================================================
        // TEXT WRAPPING:
        // Text wrapping for text elements
        // | NoWrap,
        // | Wrap,
        // | WrapWithOverflow
        //====================================================================================================
        private TextWrapping _text_wrapping;
        public TextWrapping TextWrapping
        {
            get => _text_wrapping;
            set
            {
                _text_wrapping = value;
                _has_text_wrapping = true;
            }
        }
        private bool _has_text_wrapping = false;
        public bool HasTextWrapping
        {
            get => _has_text_wrapping;
        }
        //====================================================================================================
        // UID:
        //====================================================================================================
        private string _uid;
        public string Uid
        {
            get => _uid;
            set
            {
                _uid = value;
                _has_uid = true;
            }
        }
        private bool _has_uid = false;
        public bool HasUid
        {
            get => _has_uid;
        }
        //====================================================================================================
        // VERTICAL ALIGNMENT:
        // Vertical alignment of element
        // | Bottom,
        // | Center,
        // | Stretch,
        // | Top
        //====================================================================================================
        private VerticalAlignment _vertical_alignment;
        public VerticalAlignment VerticalAlignment
        {
            get => _vertical_alignment;
            set
            {
                _vertical_alignment = value;
                _has_vertical_alignment = true;
            }
        }
        private bool _has_vertical_alignment = false;
        public bool HasVerticalAligntment
        {
            get => _has_vertical_alignment;
        }
        //====================================================================================================
        // VERTICAL CONTENT ALIGNMENT:
        // Vertical alignment of content for e.g. TabItem, ComboBoxItem, etc.
        // | Bottom,
        // | Center,
        // | Stretch,
        // | Top
        //====================================================================================================
        private VerticalAlignment _vertical_content_alignment;
        public VerticalAlignment VerticalContentAlignment
        {
            get => _vertical_content_alignment;
            set
            {
                _vertical_content_alignment = value;
                _has_vertical_content_alignment = true;
            }
        }
        private bool _has_vertical_content_alignment = false;
        public bool HasVerticalContentAlignment
        {
            get => _has_vertical_content_alignment;
        }
        //====================================================================================================
        // VERTICAL SCROLLBAR VISIBILITY:
        // ScrollViewer property
        // | Auto,
        // | Disabled,
        // | Hidden,
        // | Visible
        //====================================================================================================
        private ScrollBarVisibility _vertical_scroll_bar_visibility;
        public ScrollBarVisibility VerticalScrollBarVisibility
        {
            get => _vertical_scroll_bar_visibility;
            set
            {
                _vertical_scroll_bar_visibility = value;
                _has_vertical_scroll_bar_visibility = true;
            }
        }
        private bool _has_vertical_scroll_bar_visibility = false;
        public bool HasVerticalScrollBarVisibility
        {
            get => _has_vertical_scroll_bar_visibility;
        }
        //====================================================================================================
        // WIDTH:
        // Element width
        // | "120",
        // | "15px",
        // | "Auto",
        // | "3*",
        // | etc.
        //====================================================================================================
        private string _width;
        public string Width
        {
            get => _width;
            set
            {
                _width = value;
                _has_width = true;
            }
        }
        private bool _has_width = false;
        public bool HasWidth
        {
            get => _has_width;
        }
    }
}