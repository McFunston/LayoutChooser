using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutPicker.Domain
{

    public sealed class SettingsHandler
    {
        static readonly SettingsHandler _instance = new SettingsHandler();
        public static SettingsHandler Instance
        {
            get
            {
                return _instance;
            }
        }
        public Dictionary<string, List<string>> LayoutOptions { get; set; }
        public void GetLayoutOptions() //Get the potential layout values from LayoutOptions.json
        {
            var layoutOptions = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText("..\\..\\Settings\\LayoutOptions.json"));
            LayoutOptions = layoutOptions;            
        }

    }
}
