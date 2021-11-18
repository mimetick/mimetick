using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mimetick.WinApp.Authentication.Internals
{
    internal interface IClientApplication
    {
        /// <summary>
        /// Gets already registered accounts
        /// </summary>
        /// <returns>The list of accounts</returns>
        Task<IEnumerable<IAccount>> GetAccountsAsync();

        /// <summary>
        /// Acquire token interactively
        /// </summary>
        /// <param name="scopes">The scopes</param>
        /// <returns></returns>
        Task<AuthenticationResult> AcquireTokenInteractiveAsync(IEnumerable<string> scopes);
    }
}
