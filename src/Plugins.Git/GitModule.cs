using Mimetick.Core;

using Prism.Ioc;
using Prism.Modularity;

namespace Mimetick.Plugins.Git
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
