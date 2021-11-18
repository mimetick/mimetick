using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Mimetick.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mimetick.WinApp.Authentication
{
    internal class AuthenticationService
    {
        private readonly IPublicClientApplication _clientApplication;

        public AuthenticationService(IOptionsSnapshot<AppConfiguration> options)
        {
            _clientApplication = PublicClientApplicationBuilder.Create(options.Value.ClientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, options.Value.TenantId)
                .WithDefaultRedirectUri()
                .Build();
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

        public async Task Authenticate()
        {
            var scopes = new List<string>() { "user.read" };

            try
            {
                var builder = _clientApplication.AcquireTokenInteractive(scopes);
                var result = await builder.ExecuteAsync();

                if (result == null)
                {
                }
            }
            catch (System.Exception e)
            {   

            }
            
        }
    }
}
