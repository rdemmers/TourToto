using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TourToto
{
    abstract class Control
    {
        public int? GridRow { get; set; } = null;
        public int? GridRowSpan { get; set; } = null;
        public int? GridColumn { get; set; } = null;
        public int? GridColumnSpan { get; set; } = null;
        public Thickness? Margin { get; set; } = null;
        public Thickness? Padding { get; set; } = null;
        public VerticalAlignment? VerticalAlignment { get; set; } = null;
        public HorizontalAlignment? HorizontalAlignment { get; set; } = null;
        public int? Width { get; set; } = null;
        public int? MinWidth { get; set; } = null;
        public int? MaxWidth { get; set; } = null;
        public int? Height { get; set; } = null;
        public int? MinHeight { get; set; } = null;
        public int? MaxHeight { get; set; } = null;
        public bool? IsEnabled { get; set; } = null;
        public Visibility? Visibility { get; set; } = null;
        public int? Uid { get; set; } = null;
        public string Name { get; set; } = String.Empty;
    }
}
