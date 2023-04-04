using Mimetick.WinApp.ViewModels;
using ReactiveUI;

namespace Mimetick.WinApp.Views;

internal class AppViewLocator : IViewLocator
{
    public IViewFor ResolveView<T>(T viewModel, string? contract = null) => viewModel switch
    {
        HomeViewModel context => new HomeView { DataContext = context },
        _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
    };
}