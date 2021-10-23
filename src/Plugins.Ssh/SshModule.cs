using Mimetick.Core;

using Prism.Ioc;
using Prism.Modularity;

namespace Mimetick.Plugins.Ssh
{
    public class SshModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            // TODO : Occurs when initialized
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IMimetickPlugin, SshPlugin>("SSH");
        }
    }
}
