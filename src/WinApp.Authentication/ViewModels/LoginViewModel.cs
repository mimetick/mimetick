using Prism.Commands;
using System.Windows.Input;

namespace Mimetick.WinApp.Authentication.ViewModels
{
    internal class LoginViewModel
    {
        private readonly AuthenticationService _authenticationService;

        public LoginViewModel(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;

            _loginCommand = new DelegateCommand(() => _authenticationService.Authenticate());
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
