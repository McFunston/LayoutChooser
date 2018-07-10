using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutPicker.Domain
{
    class LayoutItem
    {
        public string Name { get; set; }
        public string CurrentValue { get; set; }
        public List<string> PossibleValues { get; set; }

        //public LayoutItem(string name, List<string> possibleValues)
        //{
        //    Name = name;
        //    PossibleValues = possibleValues;
        //}
    }
}
