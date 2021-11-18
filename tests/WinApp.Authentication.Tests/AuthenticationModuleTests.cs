using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mimetick.Core;
using Moq;
using Prism.Unity;
using Unity;

namespace Mimetick.WinApp.Authentication.Tests
{
    [TestClass]
    public class AuthenticationModuleTests
    {
        [TestMethod]
        public void Should_RegisterAuthenticationService_When_Initialize()
        {
            var module = new AuthenticationModule();
            var options = new Mock<IOptionsSnapshot<AppConfiguration>>();
            options.SetupGet(o => o.Value).Returns(new AppConfiguration("A8EA5A0C-77DC-4BAE-963D-2F86B90D207B", "D3E18C20-4E3D-4F59-A1B8-3DCF1140C70D"));

            var containerRegistry = new UnityContainerExtension();
            containerRegistry.RegisterInstance(typeof(IOptionsSnapshot<AppConfiguration>), options.Object);

            module.RegisterTypes(containerRegistry);

            var provider = containerRegistry.CreateScope();
            var authenticationService = provider.Resolve(typeof(AuthenticationService));
        }
    }
}
