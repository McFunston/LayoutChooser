using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Waf.Applications;
using System.Windows.Input;
using LayoutPicker.Applications.Views;
using LayoutPicker.Domain;
using LayoutPicker.Models;

namespace LayoutPicker.Applications.ViewModels
{
    [Export]
    internal class ShellViewModel : ViewModel<IShellView>
    {
        private readonly DelegateCommand exitCommand;
        private readonly DelegateCommand getLayoutCommand;
        public readonly SettingsHandler settingsHandler = new SettingsHandler();
        public List<string> ProductParts { get; set; }
        private string productPartName;
        private string layoutString;

        public string LayoutString
        {
            get { return layoutString; }
            set { layoutString = value; RaisePropertyChanged(); }
        }

        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; RaisePropertyChanged(); }
        }


        public string ProductPartName
        {
            get { return productPartName; }
            set { productPartName = value; ObservableLayout.ProductPartName = value; UpdateLayout(); RaisePropertyChanged("ProductPartName"); }
        }

        private string jobNumber;

        public string JobNumber
        {
            get { return jobNumber; }
            set { jobNumber = value; RaisePropertyChanged(); }
        }


        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        private Layout observableLayout;

        public Layout ObservableLayout
            {
            get { return observableLayout; }
            set
            {
                observableLayout = value;
                RaisePropertyChanged();
            }
        }

        public void UpdateLayout()
        {
            ObservableLayout = ObservableLayout.GetUpdatedLayout();
        }

        [ImportingConstructor]
        public ShellViewModel(IShellView view)
            : base(view)
        {
            ObservableLayout = new Layout();
            settingsHandler.GetLayoutOptions();
            ProductParts = settingsHandler.GetProductPartList();
            LayoutFactory layoutFactory = new LayoutFactory();
            ProductPartName = ObservableLayout.ProductPartName;
            exitCommand = new DelegateCommand(Close);
            getLayoutCommand = new DelegateCommand(GetLayout);
        }
        
        public string Title { get { return ApplicationInfo.ProductName; } }
        public ICommand ExitCommand { get { return exitCommand; } }
        public ICommand GetLayoutCommand { get { return getLayoutCommand; } }

        public void GetLayout()
        {
            foreach (var sv in ObservableLayout.LayoutItems)
            {
                LayoutString = LayoutString + sv.CurrentValue;
            }
            FileName = ProductPartName;
            //LayoutString = "Got One";
        }

        public void Show()
        {
            ViewCore.Show();
        }

        private void Close()
        {
            ViewCore.Close();
        }

        //protected void ProductPartChanged(PropertyChangedEventArgs e)
        //{

        //    if (e.PropertyName == "ProductPartName")
        //    {
        //        ObservableLayout.UpdateLayout();
        //        var r = "r";
        //        //RaisePropertyChanged("ProductPartName");
        //    }
        //}

    }
}
