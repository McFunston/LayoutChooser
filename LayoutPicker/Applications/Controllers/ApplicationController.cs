using System.ComponentModel.Composition;
using LayoutPicker.Applications.ViewModels;
using LayoutPicker.Domain;

namespace LayoutPicker.Applications.Controllers
{
    [Export]
    internal class ApplicationController
    {
        private readonly ShellViewModel shellViewModel;
        public readonly SettingsHandler settingsHandler = new SettingsHandler();

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
            settingsHandler.GetLayoutOptions();
            shellViewModel.Show();
        }

        public void Shutdown()
        {
        }
    }
}
