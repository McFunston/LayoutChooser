using System.ComponentModel.Composition;
using System.Windows;
using LayoutPicker.Applications.Views;

namespace LayoutPicker.Presentation.Views
{
    [Export(typeof(IShellView))]
    public partial class ShellWindow : Window, IShellView
    {
        public ShellWindow()
        {
            InitializeComponent();
        }
    }
}
