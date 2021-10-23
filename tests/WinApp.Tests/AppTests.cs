using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mimetick.Core;
using Mimetick.Plugins.Git;
using Mimetick.Plugins.Ssh;
using Mimetick.WinApp.Tests.Utils;

using System;

namespace Mimetick.WinApp.Tests
{
    [TestClass]
    public class AppTests
    {
        [STATestMethod]
        public void Should_HaveSshModuleRegister_When_BootstrapApplication()
        {
            ValidateAppModule(typeof(SshModule), "SSH");
        }

        [STATestMethod]
        public void Should_HaveGitModuleRegister_When_BootstrapApplication()
        {
            ValidateAppModule(typeof(GitModule), "Git");
        }

        private void ValidateAppModule(Type moduleToValidate, string name)
        {
            var app = ApplicationTest.Instance;

            var provider = app.Container.CreateScope();

            var module = provider.Resolve(moduleToValidate);
            var plugin = provider.Resolve(typeof(IMimetickPlugin), name) as IMimetickPlugin;

            module.Should().NotBeNull();

            plugin.Should().NotBeNull();
            plugin.Name.Should().NotBeEmpty();
        }
    }
}
