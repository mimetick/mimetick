using Microsoft.Extensions.Options;
using Mimetick.Core;
using Mimetick.WinApp.Authentication.Internals;
using Mimetick.WinApp.Authentication.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Runtime.CompilerServices;

#if DEBUG
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
#endif

[assembly: InternalsVisibleTo("Mimetick.WinApp.Authentication.Tests")]

namespace Mimetick.WinApp.Authentication
{
    public class AuthenticationModule : IModule
    {
        public async void OnInitialized(IContainerProvider containerProvider)
        {
            var authenticationService = containerProvider.Resolve<AuthenticationService>();
            var authenticated = await authenticationService.Initialize();

            if (!authenticated)
            {
                var regionManager = containerProvider.Resolve<IRegionManager>();
                regionManager.RegisterViewWithRegion<LoginView>(RegionNames.MainRegion);
            }
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<AuthenticationService>(sp =>
            {
                var appConfiguration = sp.Resolve<IOptionsSnapshot<AppConfiguration>>();

                var clientApplication = new ClientApplicationWrapper(appConfiguration.Value.TenantId, appConfiguration.Value.ClientId);
                return new AuthenticationService(clientApplication);
            });
        }
    }
}
