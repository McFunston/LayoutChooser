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
        public ObservableCollection<LayoutItem> Layout { get; set; }
        [ImportingConstructor]
        public ShellViewModel(IShellView view)
            : base(view)
        {
            settingsHandler.GetLayoutOptions();            
            LayoutFactory layoutFactory = new LayoutFactory();
            Layout = new ObservableCollection<LayoutItem>(layoutFactory.MakeLayout(settingsHandler));
            exitCommand = new DelegateCommand(Close);            
        }


        public string Title { get { return ApplicationInfo.ProductName; } }

        public ICommand ExitCommand { get { return exitCommand; } }
        
        public void AddSig()
        {            
            Layout.Add(Layout[Layout.Count - 2]);
            Layout.Add(Layout[Layout.Count - 2]);
        }
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
