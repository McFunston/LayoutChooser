using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Waf.Applications;
using System.Windows.Input;
using LayoutPicker.Applications.Views;
using LayoutPicker.Domain;

namespace LayoutPicker.Applications.ViewModels
{
    [Export]
    internal class ShellViewModel : ViewModel<IShellView>
    {
        private readonly DelegateCommand exitCommand;
        public readonly SettingsHandler settingsHandler = new SettingsHandler();
        public LayoutChoices layoutChoices = new LayoutChoices();
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
        public ObservableCollection<LayoutItem> Layout { get; set; }
        [ImportingConstructor]
        public ShellViewModel(IShellView view)
            : base(view)
        {
            //Layout = new List<LayoutItem>();
            settingsHandler.GetLayoutOptions();
            layoutChoices.GetLayoutChoices(settingsHandler);
            PageSizeValues = layoutChoices.PageSizeValues;
            BindingTypeValues = layoutChoices.BindingTypeValues;
            UpsValues = layoutChoices.UpsValues;
            HeadToHeadValues = layoutChoices.HeadToHeadValues;
            HeadTrimValues = layoutChoices.HeadTrimValues;
            SheetSizeValues = layoutChoices.SheetSizeValues;
            CaliperValues = layoutChoices.CaliperValues;
            PageCountValues = layoutChoices.PageCountValues;
            PressValues = layoutChoices.PressValues;
            MultiplierValues = layoutChoices.MultiplierValues;
            SignatureValues = layoutChoices.SignatureValues;
            LayoutFactory layoutFactory = new LayoutFactory();
            Layout = new ObservableCollection<LayoutItem>(layoutFactory.MakeLayout(settingsHandler));
            exitCommand = new DelegateCommand(Close);
            
        }


        public string Title { get { return ApplicationInfo.ProductName; } }

        public ICommand ExitCommand { get { return exitCommand; } }
        

        public void Show()
        {
            ViewCore.Show();
        }

        private void Close()
        {
            ViewCore.Close();
        }
    }
}
