using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;

namespace Mimetick.WinApp.Behaviors;

internal abstract class LoadedBehavior : AvaloniaObject
{
    static LoadedBehavior()
    {
        CommandProperty.Changed.Subscribe(x =>
            HandleCommandChanged(x.Sender, x.NewValue.GetValueOrDefault<ICommand>()));
    }
    
    /// <summary>
    /// Identifies the <seealso cref="CommandProperty"/> avalonia attached property.
    /// </summary>
    /// <value>Provide an <see cref="ICommand"/> derived object or binding.</value>
    public static readonly AttachedProperty<ICommand> CommandProperty = AvaloniaProperty.RegisterAttached<LoadedBehavior, Interactive, ICommand>(
        "Command", default!, false, BindingMode.OneTime);

    /// <summary>
    /// <see cref="CommandProperty"/> changed event handler.
    /// </summary>
    private static void HandleCommandChanged(IAvaloniaObject element, ICommand? commandValue)
    {
        if (element is WindowBase window)
        {
            if (commandValue != null)
            {
                // Add non-null value
                window.Activated += Handler;
            }
            else
            {
                // remove prev value
                window.Activated -= Handler;
            }
        }

        // local handler fcn
        static void Handler(object? s, EventArgs e)
        {
            if (s is not Interactive interactElem) return;
            
            var commandValue = interactElem.GetValue(CommandProperty);
            commandValue.Execute(null);
        }
    }


    /// <summary>
    /// Accessor for Attached property <see cref="CommandProperty"/>.
    /// </summary>
    public static void SetCommand(AvaloniaObject element, ICommand commandValue)
    {
        element.SetValue(CommandProperty, commandValue);
    }

    /// <summary>
    /// Accessor for Attached property <see cref="CommandProperty"/>.
    /// </summary>
    public static ICommand GetCommand(AvaloniaObject element)
    {
        return element.GetValue(CommandProperty);
    }
}