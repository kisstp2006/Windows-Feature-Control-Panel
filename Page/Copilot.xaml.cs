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
using Microsoft.Win32;
using WIndows_Feature_Control_Center_WinUI.Extension;
using System.Diagnostics;
using Windows.ApplicationModel.DataTransfer;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WFCCDesktop.Page
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Copilot 
    {
        public Copilot()
        {
            this.InitializeComponent();
            LoadRegSettingsNew();
        }
        private void CopilotOnTaskbar_SelectionChanged(object sender, RoutedEventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Copilot\BingChat", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("IsUserEligible", CopilotOnTaskbar.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        private void LoadRegSettingsNew()
        {
            SaveSettings Savesettings = new SaveSettings();
            CopilotOnTaskbar.SelectedIndex = Convert.ToInt32(Savesettings.LoadCustom("IsUserEligible", @"Software\Microsoft\Windows\Shell\Copilot\BingChat"));
        }

        private void CopilotLauncher_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("cmd.exe");
        }

        private void CopilotLauncherTextCopy_Click(object sender, RoutedEventArgs e)
        {
            var copilotruntext = new DataPackage();
            copilotruntext.SetText("start microsoft-edge:?ux=copilot^&tcp=1^&source=taskbar\"");
            Clipboard.SetContent(copilotruntext);
        }
    }

}
