using Microsoft.Identity.Client;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Mimetick.WinApp.Authentication.Tests.Mocks
{
    internal class AuthenticationResultMock : AuthenticationResult
    {
        public AuthenticationResultMock(): this("E4B8D18B-4DE5-4E48-A293-85BD9903F982", true, "749DE4DC-3D9B-4B77-A463-5209A0651E4E", DateTime.Now, DateTime.Now, "749DE4DC-3D9B-4B77-A463-5209A0651E4E", new Mock<IAccount>().Object, "16475098-9298-42C2-88F4-BBE8D6B65394", null, Guid.NewGuid())
        {
        }

        public AuthenticationResultMock(string accessToken, bool isExtendedLifeTimeToken, string uniqueId, DateTimeOffset expiresOn, DateTimeOffset extendedExpiresOn, string tenantId, IAccount account, string idToken, IEnumerable<string> scopes, Guid correlationId, AuthenticationResultMetadata authenticationResultMetadata, string tokenType = "Bearer") : base(accessToken, isExtendedLifeTimeToken, uniqueId, expiresOn, extendedExpiresOn, tenantId, account, idToken, scopes, correlationId, authenticationResultMetadata, tokenType)
        {
        }

        public AuthenticationResultMock(string accessToken, bool isExtendedLifeTimeToken, string uniqueId, DateTimeOffset expiresOn, DateTimeOffset extendedExpiresOn, string tenantId, IAccount account, string idToken, IEnumerable<string> scopes, Guid correlationId, string tokenType = "Bearer", AuthenticationResultMetadata authenticationResultMetadata = null, ClaimsPrincipal claimsPrincipal = null) : base(accessToken, isExtendedLifeTimeToken, uniqueId, expiresOn, extendedExpiresOn, tenantId, account, idToken, scopes, correlationId, tokenType, authenticationResultMetadata, claimsPrincipal)
        {
        }

        public new virtual IAccount Account {
            get { return Account; }
            set { Account = value; }
        }
    }
}
