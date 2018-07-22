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
        public Dictionary<string, List<string>> GetLayoutProduct(SettingsHandler settingsHandler, string productPart)
        {
            Dictionary<string, Dictionary<string, List<string>>> layoutProducts;
            Dictionary<string, List<string>> layoutProduct = new Dictionary<string, List<string>>();
            settingsHandler.GetLayoutOptions();
            layoutProducts = settingsHandler.LayoutOptions;
            if (layoutProducts.TryGetValue(productPart, out var lo))
            {
                layoutProduct = lo;
            }
            return layoutProduct;
        }

        public List<string> GetLayoutElements(Dictionary<string, List<string>> layoutProduct, string key)
        {
            List<string> layoutElements = new List<string>();
            if (layoutProduct.TryGetValue(key, out var le))
            {
                layoutElements = le;
            }
            return layoutElements;
        }

        public List<LayoutItem> GetLayout(SettingsHandler settingsHandler, string productPart)
        {
            List<LayoutItem> layoutItems = new List<LayoutItem>();
            Dictionary<string, List<string>> layoutProduct;
            List<string> layoutElements;
            layoutProduct = GetLayoutProduct(settingsHandler, productPart);
            layoutElements = GetLayoutElements(layoutProduct, "Keys");
                        
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
        public List<LayoutItem> GetOptionalItems(SettingsHandler settingsHandler, string productPart)
        {
            Dictionary<string, List<string>> layoutProduct;
            List<LayoutItem> layoutItems = new List<LayoutItem>();
            List<string> layoutElements;
            layoutProduct = GetLayoutProduct(settingsHandler, productPart);
            layoutElements = GetLayoutElements(layoutProduct, "Optional Keys");

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
