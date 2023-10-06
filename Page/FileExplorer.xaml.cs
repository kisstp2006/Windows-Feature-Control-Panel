using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WIndows_Feature_Control_Center_WinUI.Extension;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WIndows_Feature_Control_Center_WinUI.Page
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FileExplorer
    {
        public string ExplorerRegPath= @"Software\kisstp2006\WFCC\SETTINGS";
        public FileExplorer()
        {
            this.InitializeComponent();
            LoadRegSettingsNew();
        }
        private void CheckWinVer()
        {
            Version osVersion = Environment.OSVersion.Version;
            if (osVersion.Build < 21000)
            {
                win10warn.IsOpen = true;
            }
        }

        private void XAML_File_Explorer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(ExplorerRegPath, true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("WASDK_Explorer_enabled", XAML_File_Explorer.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
                else
                {
                    regkey.CreateSubKey("WASDK_Explorer_enabled");
                }
            }
            if (XAML_File_Explorer.SelectedIndex ==0)
            {
                Process.Start("cmd.exe" , "vivetool /enable /id:38664959,40729001,41076133");

            }
            else
            {
                Process.Start("cmd.exe", "vivetool /disable /id:38664959,40729001,41076133");
            }

        }

        private void File_Explorer_New_Detail_Panel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(ExplorerRegPath, true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("WASDK_Explorer_Detail_Panel", File_Explorer_New_Detail_Panel.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
                else
                {
                    regkey.CreateSubKey("WASDK_Explorer_Detail_Panel");
                }
            }
            if (File_Explorer_New_Detail_Panel.SelectedIndex == 0)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "vivetool /enable /id:38613007";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.CreateNoWindow = true;

                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();

            }
            else
            {
                Process.Start("cmd.exe", "vivetool /disable /id:38613007");
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "vivetool /disable /id:38613007";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.CreateNoWindow = true;

                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
            }

        }
        private void LoadRegSettingsNew()
        {
            SaveSettings Savesettings = new SaveSettings();
            XAML_File_Explorer.SelectedIndex = Convert.ToInt32(Savesettings.LoadCustom("WASDK_Explorer_enabled", ExplorerRegPath));
            File_Explorer_New_Detail_Panel.SelectedIndex = Convert.ToInt32(Savesettings.LoadCustom("WASDK_Explorer_Detail_Panel", ExplorerRegPath));
        }

    }
}
