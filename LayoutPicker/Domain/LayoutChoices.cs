using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutPicker.Domain
{
    public sealed class LayoutChoices
    {
        static readonly LayoutChoices _instance = new LayoutChoices();
        public static LayoutChoices Instance
        {
            get
            {
                return _instance;
            }
        }

        public void GetLayoutChoices(SettingsHandler settingsHandler)
        {            
            Dictionary<string, List<string>> settings = settingsHandler.LayoutOptions;
            if (settings.TryGetValue("Page size", out var pageSizeValues))
            {
                PageSizeValues=pageSizeValues;
            }
            if (settings.TryGetValue("Binding", out var bindingTypeValues))
            {
                BindingTypeValues = bindingTypeValues;
            }
            if (settings.TryGetValue("UPs", out var upsValues))
            {
                UpsValues = upsValues;
            }
            if (settings.TryGetValue("Head to Head", out var headToHeadValues))
            {
                HeadToHeadValues = headToHeadValues;
            }
            if (settings.TryGetValue("Head Trim", out var headTrimValues))
            {
                HeadTrimValues = headTrimValues;
            }
            if (settings.TryGetValue("Sheet Size", out var sheetSizeValues))
            {
                SheetSizeValues = sheetSizeValues;
            }
            if (settings.TryGetValue("Caliper", out var caliperValues))
            {
                CaliperValues = caliperValues;
            }
            if (settings.TryGetValue("Page Count", out var pageCountValues))
            {
                PageCountValues = pageCountValues;
            }
            if (settings.TryGetValue("Press", out var pressValues))
            {
                PressValues = pressValues;
            }
            if (settings.TryGetValue("Multiplier", out var multiplierValues))
            {
                MultiplierValues = multiplierValues;
            }
            if (settings.TryGetValue("Signature", out var signatureValues))
            {
                SignatureValues = signatureValues;
            }

        }
        public List<string> PageSizeValues { get; set; }
        public List<string> BindingTypeValues { get; set; }
        public List<string> UpsValues { get; set; }
        public List<string> HeadToHeadValues { get; set; }
        public List<string> HeadTrimValues { get; set; }
        public List<string> SheetSizeValues { get; set; }
        public List<string> CaliperValues { get; set; }
        public List<string> PageCountValues { get; set; }
        public List<string> PressValues { get; set; }
        public List<string> MultiplierValues { get; set; }
        public List<string> SignatureValues { get; set; }
    }
}
