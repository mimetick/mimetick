using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mimetick.WinApp.ViewModels;

namespace Mimetick.WinApp.Tests.ViewModels
{
    [TestClass]
    public class ShellViewModelTests
    {
        [TestMethod]
        public void Should_CreateVM_When_ConstructorValid()
        {
            var vm = new ShellViewModel();

            vm.Should().NotBeNull();
        }
    }
}
