using System.Windows.Input;
using ReactiveUI;

namespace Mimetick.WinApp.ViewModels;

public class MainViewModel : ViewModelBase, IActivatableViewModel, IScreen
{
    /// <summary>
    /// Initialize a new <see cref="MainViewModel"/>.
    /// </summary>
    public MainViewModel()
    {
        Router = new RoutingState();
        Activator = new ViewModelActivator();

        InitializeCommand = ReactiveCommand.Create(() => Router.Navigate.Execute(new HomeViewModel(this)));
    }
    
    /// <summary>
    /// Gets the router.
    /// </summary>
    public RoutingState Router { get; init; }

    /// <summary>
    /// Gets the view model activator
    /// </summary>
    public ViewModelActivator Activator { get; }

    public ICommand InitializeCommand { get; }
}