using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Management.Deployment;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WFCCDesktop.Page
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DeleteMicrosoftApp 
    {
        public List<string> DeleteInstalledApps;
        List<string> appNames = new List<string>();
        public DeleteMicrosoftApp()
        {
            this.InitializeComponent();
            CreateList();


        }
        public void CreateList()
        {

            PackageManager packageManager = new PackageManager();
            var packages = packageManager.FindPackages().Where(p => p.IsFramework == false);
            foreach (var package in packages)
            {
                appNames.Add(package.Id.FullName);
            }

            // Add each app name to the list box
            foreach (string appName in appNames)
            {
                ListApps.Items.Add(appName);
            }
        }
        public async void RemoveApps(object sender, RoutedEventArgs e)
        {
            PackageManager packageManager = new PackageManager();
            var packages = packageManager.FindPackages().Where(p => p.IsFramework == false);
            foreach (var package in packages)
            {
                if (appNames.Contains(package.Id.FullName) && ListAppsToRemove.Items.Contains(package.Id.FullName))
                {
                    await packageManager.RemovePackageAsync(package.Id.FullName);
                    ListApps.SelectedItems.Clear();
                }
            }
        }

        private void ListApps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListAppsToRemove.Items.Clear();
            List<string> selectedItems = new List<string>();
            foreach (object selectedItem in ListApps.SelectedItems)
            {
                selectedItems.Add(selectedItem.ToString());
                ListAppsToRemove.Items.Add(selectedItem);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListApps.SelectedItems.Clear();
        }

    }
}
