using System.ComponentModel.Composition;
using System.Windows;
using LayoutPicker.Applications.Views;
using MahApps.Metro.Controls;

namespace LayoutPicker.Presentation.Views
{
    [Export(typeof(IShellView))]
    public partial class ShellWindow : MetroWindow, IShellView
    {
        public ShellWindow()
        {
            InitializeComponent();
        }
    }
}
