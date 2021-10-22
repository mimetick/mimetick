namespace Mimetick.WinApp.Tests.Utils
{
    public static class ApplicationTest
    {
        private static App _instance;

        public static App Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new App();
                    _instance.Startup += (s, e) => { _instance.Shutdown(); };
                    _instance.Run();
                }

                return _instance;
            }
        }
    }
}
