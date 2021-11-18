using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mimetick.WinApp.Authentication.Internals
{
    internal class ClientApplicationWrapper : IClientApplication
    {
        private readonly IPublicClientApplication _clientApplication;

        public ClientApplicationWrapper(string tenantId, string clientId)
        {
            _clientApplication = PublicClientApplicationBuilder.Create(clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, tenantId)
                .WithDefaultRedirectUri()
                .Build();
        }

        public async Task<AuthenticationResult> AcquireTokenInteractiveAsync(IEnumerable<string> scopes)
        {
            var builder = _clientApplication.AcquireTokenInteractive(scopes);
            var result = await builder.ExecuteAsync();

            return result;
        }

        /// <summary>
        /// Gets already registered accounts
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<IAccount>> GetAccountsAsync()
        {
            return _clientApplication.GetAccountsAsync();
        }
    }
}
