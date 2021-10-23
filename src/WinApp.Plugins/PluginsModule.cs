using Mimetick.Core;
using Mimetick.WinApp.Plugins.Views;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Mimetick.WinApp.Plugins
{
    public class PluginsModule : IModule
    {
        /// <summary>
        /// Occurs when the plugin is initialized.
        /// </summary>
        /// <param name="containerProvider">The container provider.</param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();

            regionManager.RegisterViewWithRegion<PluginsView>(RegionNames.MainRegion);
        }

        /// <summary>
        /// Register module types.
        /// </summary>
        /// <param name="containerRegistry">The container registry.</param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
