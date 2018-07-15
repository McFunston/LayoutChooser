using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public List<LayoutItem> GetLayout(SettingsHandler settingsHandler, string productPart)
        {
            List<LayoutItem> layoutItems = new List<LayoutItem>();
            Dictionary<string, Dictionary<string, List<string>>> layoutProducts;
            Dictionary<string, List<string>> layoutProduct = new Dictionary<string, List<string>>();
            List<string> layoutElements = new List<string>();
            settingsHandler.GetLayoutOptions();
            layoutProducts = settingsHandler.LayoutOptions2;
            if (layoutProducts.TryGetValue(productPart, out var lo))
            {
                layoutProduct = lo;
            }

            if (layoutProduct.TryGetValue("Keys", out var le))
            {
                layoutElements = le;
            }
            foreach (var element in layoutElements)
            {
                LayoutItem layoutItem = new LayoutItem();
                layoutItem.Name = element;
                if (layoutProduct.TryGetValue(element, out var items))
                {
                    layoutItem.PossibleValues = items;
                }
                layoutItems.Add(layoutItem);
            }

            return layoutItems;
        }
    }
}
