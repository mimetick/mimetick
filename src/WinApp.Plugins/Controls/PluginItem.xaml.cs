using Mimetick.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mimetick.WinApp.Plugins.Controls
{
    /// <summary>
    /// Interaction logic for PluginItem.xaml
    /// </summary>
    public partial class PluginItem : UserControl
    {
        public PluginItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the plugin
        /// </summary>
        public IMimetickPlugin Plugin
        {
            get { return (IMimetickPlugin)GetValue(PluginProperty); }
            set { SetValue(PluginProperty, value); }
        }

        public static readonly DependencyProperty PluginProperty = DependencyProperty.Register("Plugin", typeof(IMimetickPlugin), typeof(PluginItem));
    }
}
