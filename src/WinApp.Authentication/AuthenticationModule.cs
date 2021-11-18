using Mimetick.Core;
using Mimetick.WinApp.Authentication.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

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
            containerRegistry.Register<AuthenticationService>();
        }
    }
}
