using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutPicker.Models
{
    class Layout
    {
        public string PageSize { get; set; }
        public string BindingType { get; set; }
        public string Ups { get; set; }
        public string HeadToHead { get; set; }
        public string HeadTrim { get; set; }
        public string SheetSize { get; set; }
        public string Caliper { get; set; }
        public string PageCount { get; set; }
        public string Press { get; set; }
        public List<Signature> Signatures { get; set; }
    }
}
