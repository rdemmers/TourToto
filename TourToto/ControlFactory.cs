using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TourToto
{
    class ControlFactory
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
