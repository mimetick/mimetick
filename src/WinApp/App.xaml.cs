using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mimetick.Core;
using Mimetick.Plugins.Git;
using Mimetick.Plugins.Ssh;
using Mimetick.WinApp.Authentication;
using Mimetick.WinApp.Plugins;
using Mimetick.WinApp.Views;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;

using Serilog;
using System.IO;
using System.Windows;

using Unity;
using Unity.Microsoft.DependencyInjection;

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
            // We don't actually have anything to register.
        }

        /// <summary>
        /// Create container extensions.
        /// </summary>
        /// <returns>The container extension.</returns>
        protected override IContainerExtension CreateContainerExtension()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets(typeof(App).Assembly, true, true);

            var configuration = configurationBuilder.Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
            serviceCollection.Configure<AppConfiguration>(c => configuration.GetSection("app").Bind(c, o => o.BindNonPublicProperties = true));

            var container = new UnityContainer();
            container.BuildServiceProvider(serviceCollection);

            return new UnityContainerExtension(container);
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

            moduleCatalog.AddModule<AuthenticationModule>();
            moduleCatalog.AddModule<PluginsModule>(InitializationMode.WhenAvailable, typeof(GitModule).Name, typeof(SshModule).Name);
        }
    }
}
