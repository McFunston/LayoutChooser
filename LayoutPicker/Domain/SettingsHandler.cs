using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutPicker.Domain
{

    public class SettingsHandler
    {
        //static readonly SettingsHandler _instance = new SettingsHandler();
        //public static SettingsHandler Instance
        //{
        //    get
        //    {
        //        return _instance;
        //    }
        //}
        //public Dictionary<string, List<string>> LayoutOptions { get; set; }
        public Dictionary<string, Dictionary<string, List<string>>> LayoutOptions { get; set; }

        public List<String> GetProductPartList()
        {
            List<string> productPartList = new List<string>();
            productPartList = LayoutOptions.Keys.ToList<string>();
            return productPartList;
        }
        public void GetLayoutOptions() //Get the potential layout values from LayoutOptions.json
        {

            if (LayoutOptions == null)
            {
                LayoutOptions = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<string>>>>(File.ReadAllText("..\\..\\Settings\\LayoutOptions.json"));
            }
            
        }

    }
}
