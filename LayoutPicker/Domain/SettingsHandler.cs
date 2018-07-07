using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutPicker.Domain
{

    class SettingsHandler
    {
        public Dictionary<string, List<string>> LayoutOptions { get; set; }
        public void GetLayoutOptions()
        {
            var layoutOptions = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText("..\\..\\Settings\\LayoutOptions.json"));
            LayoutOptions = layoutOptions;            
        }

    }
}
