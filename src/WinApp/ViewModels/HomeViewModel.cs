using System.Collections.ObjectModel;
using Mimetick.Plugins;
using ReactiveUI;
using Splat;

namespace Mimetick.WinApp.ViewModels;

public class HomeViewModel : ViewModelBase, IRoutableViewModel
{
    public IScreen HostScreen { get; }

    // Unique identifier for the routable view model.
    public string UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];

    public HomeViewModel(IScreen screen)
    {
        HostScreen = screen;
        
        var plugins = Locator.Current.GetServices<IPlugin>() ?? new List<IPlugin>();
        _plugins = new ObservableCollection<IPlugin>(plugins);

    }

    private readonly ObservableCollection<IPlugin> _plugins;
    /// <summary>
    /// Gets the plugin list
    /// </summary>
    public IEnumerable<IPlugin> Plugins => _plugins.AsEnumerable();
}