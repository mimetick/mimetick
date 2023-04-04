using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Mimetick.WinApp.ViewModels;

namespace Mimetick.WinApp.Views;

public partial class HomeView : ReactiveUserControl<HomeViewModel>
{
    public HomeView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}