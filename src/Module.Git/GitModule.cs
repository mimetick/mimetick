using Mimetick.Core;
using Mimetick.Module.Git.Views;
using Mimetick.Modules.Git;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Mimetick.Module.Git
{
    public class GitModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IMimetickPlugin, GitPlugin>("Git");
        }
    }
}
