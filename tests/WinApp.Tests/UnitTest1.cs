using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Mimetick.WinApp.Tests
{
    public class STATestMethodAttribute : TestMethodAttribute
    {
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
                return Invoke(testMethod);

            TestResult[] result = null;
            var thread = new Thread(() => result = Invoke(testMethod));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            return result;
        }

        private TestResult[] Invoke(ITestMethod testMethod)
        {
            return new[] { testMethod.Invoke(null) };
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [STATestMethod]
        public void TestMethod1()
        {
            var mainWindow = new ShellView();

            Assert.IsNotNull(mainWindow);
        }
    }
}
