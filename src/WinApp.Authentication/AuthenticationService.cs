using Microsoft.Identity.Client;
using Mimetick.WinApp.Authentication.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mimetick.WinApp.Authentication
{

    internal class AuthenticationService
    {
        private readonly IClientApplication _clientApplication;

        /// <summary>
        /// Initialize a new <see cref="AuthenticationService"/>
        /// </summary>
        /// <param name="clientApplication">The client application used to connect.</param>
        /// <exception cref="ArgumentNullException">If the parameters are null</exception>
        public AuthenticationService(IClientApplication clientApplication)
        {
            _clientApplication = clientApplication ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Initialize the authentication
        /// </summary>
        /// <returns></returns>
        internal async Task<bool> Initialize()
        {
            var accounts = await _clientApplication.GetAccountsAsync();

            if (accounts.Any())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Authenticate the user against the service
        /// </summary>
        /// <returns></returns>
        public async Task<IAccount> Authenticate()
        {
            var scopes = new List<string>() { "user.read" };

            var authenticationResult = await _clientApplication.AcquireTokenInteractiveAsync(scopes);

            return authenticationResult.Account;
        }
    }
}
