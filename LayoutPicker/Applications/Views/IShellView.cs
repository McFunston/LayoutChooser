using System.Waf.Applications;

namespace LayoutPicker.Applications.Views
{
    internal interface IShellView : IView
    {
        void Show();

        void Close();
    }
}
