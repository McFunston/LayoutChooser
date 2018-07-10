using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutPicker.Domain
{
    class LayoutFactory
    {
        public List<LayoutItem> MakeLayout(SettingsHandler settingsHandler)
        {
            List<string> layoutElements = new List<string>();
            List<LayoutItem> layoutItems = new List<LayoutItem>();
            Dictionary<string, List<string>> _layoutOptions;
            _layoutOptions = settingsHandler.LayoutOptions;

            if (_layoutOptions.TryGetValue("Values", out var lo))
            {
                layoutElements = lo;
            }

            foreach(var element in layoutElements)
            {
                LayoutItem layoutItem = new LayoutItem();
                layoutItem.Name = element;
                if (_layoutOptions.TryGetValue(element, out var items))
                {
                    layoutItem.PossibleValues = items;
                }
                layoutItems.Add(layoutItem);
            }
            return layoutItems;
        }
    }
}
