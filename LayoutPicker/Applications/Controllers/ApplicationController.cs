using System.ComponentModel.Composition;
using LayoutPicker.Applications.ViewModels;
using LayoutPicker.Domain;

namespace LayoutPicker.Applications.Controllers
{
    [Export]
    internal class ApplicationController
    {
        private readonly ShellViewModel shellViewModel;

        [ImportingConstructor]
        public ApplicationController(ShellViewModel shellViewModel)
        {
            this.shellViewModel = shellViewModel;
        }

        public void Initialize()
        {
        }

        public void Run()
        {            
            shellViewModel.Show();            
        }

        public void Shutdown()
        {
        }
    }
}
