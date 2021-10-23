using Mimetick.Core;

using System.Collections.Generic;

namespace Mimetick.WinApp.Plugins.ViewModels
{
    internal class PluginsViewModel
    {
        /// <summary>
        /// Initialize a new <see cref="PluginsViewModel"/>
        /// </summary>
        /// <param name="plugins">The application plugins.</param>
        public PluginsViewModel(IEnumerable<IMimetickPlugin> plugins)
        {
            _plugins = plugins;
        }

        private readonly IEnumerable<IMimetickPlugin> _plugins;
        /// <summary>
        /// Gets the plugins list
        /// </summary>
        public IEnumerable<IMimetickPlugin> Plugins
        {
            get { return _plugins; }
        }
    }
}
