using LayoutPicker.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutPicker.Models
{
    class Layout
    {
        private string productPartName = "Text";
        private List<LayoutItem> layoutItems;
        public string ProductPartName
        {
            get { return productPartName; }
            set { productPartName = value; }
        }

        public List<LayoutItem> LayoutItems
        {
            get { return layoutItems; }
            set { layoutItems = value; }
        }

        public Layout()
        {
            ProductPartName = "Text";
            SettingsHandler settingsHandler = new SettingsHandler();
            LayoutFactory layoutFactory = new LayoutFactory();
            LayoutItems = layoutFactory.GetLayout(settingsHandler, productPartName);
        }

        public Layout GetUpdatedLayout()
        {
            SettingsHandler settingsHandler = new SettingsHandler();
            LayoutFactory layoutFactory = new LayoutFactory();
            LayoutItems = layoutFactory.GetLayout(settingsHandler, productPartName);
            return this;
        }

    }
}
