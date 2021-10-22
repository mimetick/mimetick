using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mimetick.Module.Git;
using Mimetick.Module.Ssh;
using Mimetick.WinApp.Tests.Utils;

namespace Mimetick.WinApp.Tests
{
    [TestClass]
    public class AppTests
    {
        [STATestMethod]
        public void Should_HaveSshModuleRegister_When_BootstrapApplication()
        {
            var app = ApplicationTest.Instance;

            var provider = app.Container.CreateScope();
            var module = provider.Resolve(typeof(SshModule));

            module.Should().NotBeNull();
        }

        [STATestMethod]
        public void Should_HaveGitModuleRegister_When_BootstrapApplication()
        {
            var app = ApplicationTest.Instance;

            var provider = app.Container.CreateScope();
            var module = provider.Resolve(typeof(GitModule));

            module.Should().NotBeNull();
        }
    }
}
