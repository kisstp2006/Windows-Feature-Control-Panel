using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Hosting;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Win32;
using System.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WFCCDesktop.SetUP;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WIndows_Feature_Control_Center_WinUI.Extension;
using WIndows_Feature_Control_Center_WinUI.Page;
using WFCCDesktop.Page;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WFCCDesktop
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        string WFCCSettingRegPatch = @"Software\kisstp2006\WFCC\SETTINGS";
        int WindowsVer = 0;

        public MainWindow()
        {
            this.InitializeComponent();
            loadRegistry();
            SystemBackdrop BackDrop = new DesktopAcrylicBackdrop();
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(Taskbar));
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            //check setting page opened
            if (args.IsSettingsSelected)
            {
                Content.Navigate(typeof(WIndows_Feature_Control_Center_WinUI.Page.Settings));
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag.ToString())
                {
                    case "Taskbar":
                        Content.Navigate(typeof(Taskbar));
                        break;
                    case "StartMenu":
                        Content.Navigate(typeof(StartMenu));
                        break;
                    case "Explorer":
                        Content.Navigate(typeof(FileExplorer));
                        break;
                    case "Remove_Microsoft_App":
                        Content.Navigate(typeof(DeleteMicrosoftApp));
                        break;
                    case "Dev":
                        Content.Navigate(typeof(DevPage));
                        break;
                    case "CoPilot":
                        Content.Navigate(typeof(Copilot));
                        break;
                }
            }

        }

        private void Content_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void loadRegistry()
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(WFCCSettingRegPatch, true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("Version", "1.0", RegistryValueKind.String);
                    regkey.Close();
                }
                else
                {
                    OpenNewWindow();
                    RegistryKey newRegkey = Registry.CurrentUser.CreateSubKey(WFCCSettingRegPatch);
                    newRegkey.SetValue("Version", "1.0", RegistryValueKind.String);
                }

                SaveSettings Savesettings = new SaveSettings();
                int devModeValue = (int)Savesettings.Load("DevMode");

                if (devModeValue == 1)
                {
                    devmode.Visibility = Visibility.Visible;
                }
                else
                {
                    devmode.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void OpenNewWindow()
        {// Create a new Window object and set its content to a Frame
            Window SetupWindow = new Window();
            SetupWindow.Content = new Frame();

            //Add custom name to the new window
            SetupWindow.Title = "Welcome Page";

            // Navigate the Frame to the XAML page you want to show in the new window
            (SetupWindow.Content as Frame).Navigate(typeof(SetupPage1));

            // Activate the Window
            SetupWindow.Activate();


        }
    }
}
