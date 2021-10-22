using Mimetick.Module.Git;
using Mimetick.Module.Ssh;
using Mimetick.WinApp.Views;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;

using System.Windows;

namespace Mimetick.WinApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// Create the application shell.
        /// </summary>
        /// <returns>The application main window.</returns>
        protected override Window CreateShell()
        {
            var window = Container.Resolve<ShellView>();

            return window;
        }

        /// <summary>
        /// Register application types.
        /// </summary>
        /// <param name="containerRegistry">The container registry.</param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        /// <summary>
        /// Configure the module catalog.
        /// </summary>
        /// <param name="moduleCatalog">The existing module catalog.</param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<GitModule>();
            moduleCatalog.AddModule<SshModule>();
        }
    }
}
