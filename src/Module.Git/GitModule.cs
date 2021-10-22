using Mimetick.Core;
using Mimetick.Module.Git.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Mimetick.Module.Git
{
    public class GitModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();

            regionManager.RegisterViewWithRegion<GitModuleItemView>(RegionNames.ModuleRegion);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
