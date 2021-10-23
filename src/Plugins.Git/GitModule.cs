using Mimetick.Core;

using Prism.Ioc;
using Prism.Modularity;

namespace Mimetick.Plugins.Git
{
    public class GitModule : IModule
    {
        /// <summary>
        /// Occurs when the module is initialized.
        /// </summary>
        /// <param name="containerProvider">The container provider.</param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            // We don't actually have anything to initialize
        }

        /// <summary>
        /// Register module types.
        /// </summary>
        /// <param name="containerRegistry">The container registry.</param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IMimetickPlugin, GitPlugin>("Git");
        }
    }
}
