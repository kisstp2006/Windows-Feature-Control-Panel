using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WFCCDesktop.SetUP;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WFCCDesktop.Page
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DevPage 
    {
        public DevPage()
        {
            this.InitializeComponent();
        }

        public object SizeToContent { get; private set; }

        private void OpenFirstSetup(object sender, RoutedEventArgs e)
        {
            // Create a new Window object and set its content to a Frame
            Window setupWindow = new Window();
            Frame frame = new Frame();
            frame.HorizontalAlignment = HorizontalAlignment.Stretch;
            frame.VerticalAlignment = VerticalAlignment.Stretch;
            setupWindow.Content = frame;

            // Add a custom name to the new window
            setupWindow.Title = "Welcome Page";

            // Navigate the Frame to the XAML page you want to show in the new window
            frame.Navigate(typeof(SetupPage1));

            // Activate the Window
            setupWindow.Activate();
        }

    }
}
