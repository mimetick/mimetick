using Mimetick.Core;
using Prism.Commands;
using Prism.Regions;
using System.Windows.Input;

namespace Mimetick.WinApp.Authentication.ViewModels
{
    internal class LoginViewModel
    {
        private readonly AuthenticationService _authenticationService;
        private readonly IRegionManager _regionManager;

        public LoginViewModel(AuthenticationService authenticationService, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _authenticationService = authenticationService;

            _loginCommand = new DelegateCommand(async () =>
            {
                await _authenticationService.Authenticate();
                _regionManager.RequestNavigate(RegionNames.MainRegion, "PluginsView");
            });
        }

        private readonly DelegateCommand _loginCommand;
        /// <summary>
        /// Gets the login command
        /// </summary>
        public ICommand LoginCommand
        {
            get { return _loginCommand; }
        }
    }
}
