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
        private readonly DelegateCommand getOptionalsCommand;

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
            get { return ObservableLayout.ProductPartName; }
            set { productPartName = value; ObservableLayout.ProductPartName = value; UpdateLayout(); RaisePropertyChanged("ProductPartName"); }
        }

        private string jobNumber;

        public string JobNumber
        {
            get { return jobNumber; }
            set { jobNumber = value; RaisePropertyChanged(); }
        }

        private Layout observableLayout;

        public Layout ObservableLayout
            {
            get { return observableLayout; }
            set
            {
                observableLayout = value;
                RaisePropertyChanged("ObservableLayout");
            }
        }

        public void UpdateLayout()
        {
            ObservableLayout = ObservableLayout.GetUpdatedLayout();
        }

        public void GetOptionals()
        {
            Layout tempOl = new Layout();
            tempOl.LayoutItems.Clear();
            tempOl.LayoutItems.AddRange(ObservableLayout.LayoutItems);
            tempOl.ProductPartName = ObservableLayout.ProductPartName;
            var ol = tempOl.AddOptionals(ObservableLayout.LayoutItems);
            ObservableLayout = ol;
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
            getOptionalsCommand = new DelegateCommand(GetOptionals);            
        }
        
        public string Title { get { return ApplicationInfo.ProductName; } }
        public ICommand ExitCommand { get { return exitCommand; } }
        public ICommand GetLayoutCommand { get { return getLayoutCommand; } }
        public ICommand GetOptionalsCommand { get { return getOptionalsCommand; } }
        public void GetLayout()
        {
            LayoutString = "";
            foreach (var sv in ObservableLayout.LayoutItems)
            {
                LayoutString = LayoutString + sv.CurrentValue;
            }
            FileName = JobNumber + "-" + ProductPartName;
            LayoutCopier layoutCopier = new LayoutCopier();
            layoutCopier.CopyLayout(LayoutString, FileName);
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
