using FluentAssertions;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mimetick.WinApp.Authentication.Internals;
using Mimetick.WinApp.Authentication.Tests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Mimetick.WinApp.Authentication.Tests
{
    [TestClass]
    public class AuthenticationServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_ThrowException_When_ClientApplicationIsNull()
        {
            var _ = new AuthenticationService(null);
        }

        [TestMethod]
        public async Task Should_BeAuthenticate_When_InitializeWithAccounts()
        {
            var publicClientMock = new Mock<IClientApplication>();
            var accountMock = new Mock<IAccount>();

            publicClientMock.Setup(c => c.GetAccountsAsync()).ReturnsAsync(new List<IAccount> { accountMock.Object });

            var authenticationService = new AuthenticationService(publicClientMock.Object);
            var authenticated = await authenticationService.Initialize();

            authenticated.Should().BeTrue();
        }

        [TestMethod]
        public async Task Should_BeNotAuthenticated_When_InitializeWithNoAccounts()
        {
            var publicClientMock = new Mock<IClientApplication>();
            var accountMock = new Mock<IAccount>();

            publicClientMock.Setup(c => c.GetAccountsAsync()).ReturnsAsync(new List<IAccount>());

            var authenticationService = new AuthenticationService(publicClientMock.Object);
            var authenticated = await authenticationService.Initialize();

            authenticated.Should().BeFalse();
        }

        [TestMethod]
        public async Task Should_AuthenticateUser_When_UserCredentialsValid()
        {
            var scopes = new List<string>() { "user.read" };

            var accountMock = new Mock<IAccount>();
            
            var authenticationResultMock = new Mock<AuthenticationResultMock>();
            authenticationResultMock.SetupGet(r => r.Account).Returns(accountMock.Object);

            var publicClientMock = new Mock<IClientApplication>();
            publicClientMock.Setup(c => c.AcquireTokenInteractiveAsync(It.IsAny<IEnumerable<string>>())).ReturnsAsync(authenticationResultMock.Object);
                        
            var authenticationService = new AuthenticationService(publicClientMock.Object);

            var account = await authenticationService.Authenticate();

            account.Should().NotBeNull();
        }
    }
}
