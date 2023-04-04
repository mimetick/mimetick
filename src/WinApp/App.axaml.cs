using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Mimetick.Plugins;
using Mimetick.Plugins.Git;
using Mimetick.WinApp.ViewModels;
using Mimetick.WinApp.Views;
using Splat;

namespace Mimetick.WinApp;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainView
            {
                DataContext = new MainViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    public override void RegisterServices()
    {
        base.RegisterServices();

        Locator.CurrentMutable.Register(() => new GitPlugin(), typeof(IPlugin));
    }
}