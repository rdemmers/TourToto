using System.Windows;

namespace TourToto.Views.Elements
{
    internal class ControlFactory
    {
        public FrameworkElement GetControl(string control_type)
        {
            switch (control_type)
            {
                case "tabitem":
                    return new System.Windows.Controls.TabItem();

                case "textblock":
                    return new System.Windows.Controls.TextBlock();

                case "textbox":
                    return new System.Windows.Controls.TextBox();

                case "image":
                    return new System.Windows.Controls.Image();

                default:
                    return new FrameworkElement();
            }
        }
    }
}