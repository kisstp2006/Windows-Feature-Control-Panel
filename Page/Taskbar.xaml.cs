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
    public sealed partial class Taskbar
    {
        public Taskbar()
        {
            this.InitializeComponent();
            LoadOptions();
            LoadRegistrySettings();
            CheckWinVer();
        }
        private void RestartE(object sender, RoutedEventArgs e)
        {
            Process[] Processes = Process.GetProcessesByName("explorer");
            foreach (Process explorerProcess in Processes)
            {
                explorerProcess.Kill();
            }
            //Process.Start("C:\\Windows\\explorer.exe"); (Use this if the explorer doesn't  start automaticly)

        }
        private void LoadOptions()
        {
            SaveSettings Savesettings = new SaveSettings();
            if (Savesettings.Load("NoWarn") == 1)
            {
                infobar.IsOpen = false;
            }
        }
        private void Search_SelectionChange(object sender, RoutedEventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Search", true))
            {
                if (regkey != null )
                {
                    regkey.SetValue("SearchboxTaskbarMode", search.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        private void comninedtaskbar_SelectionChange(object sender, RoutedEventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("TaskbarGlomLevel", comninedtaskbar.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\ExplorerPatcher", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("TaskbarGlomLevel", comninedtaskbar.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        private void taskbartype_SelectionChange(object sender, RoutedEventArgs e)
        {
            using (RegistryKey regkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell\Update\Packages", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("UndockingDisabled", taskbartype.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\ExplorerPatcher", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("OldTaskbar", taskbartype.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        private void MMTtaskbar_SelectionChange(object sender, RoutedEventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("MMTaskbarEnabled", MMTtaskbar.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        private void Win10TaskSize_SelectionChange(object sender, RoutedEventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("TaskbarSmallIcons", Win10TaskSize.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        private void Win11TaskSize_SelectionChange(object sender, RoutedEventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("TaskbarSi", Win11TaskSize.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        private void taskviev_Toggled(object sender, RoutedEventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("ShowTaskViewButton", taskviev.IsOn, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        private void Taskbaralign_SelectionChanged(object sender, RoutedEventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("TaskbarAl", Taskbaralign.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        //Disable unavailable settings on windows10
        private void CheckWinVer()
        {
            Version osVersion = Environment.OSVersion.Version;
            if (osVersion.Build< 21000)
            {
                taskbartype.IsEnabled = false;
                Taskbaralign.IsEnabled = false;
                Win11TaskSize.IsEnabled = false;
                win10warn.IsOpen = true;
            }
        }
        //Load back options
        private void LoadRegistrySettings()
        {
            SaveSettings Savesettings = new SaveSettings();
            //Load search reg
            if (Savesettings.LoadCustom("SearchboxTaskbarMode" , @"Software\Microsoft\Windows\CurrentVersion\Search") == 0)
            {
                search.SelectedIndex=0;
            }
            if (Savesettings.LoadCustom("SearchboxTaskbarMode", @"Software\Microsoft\Windows\CurrentVersion\Search") == 1)
            {
                search.SelectedIndex = 1;
            }
            if (Savesettings.LoadCustom("SearchboxTaskbarMode", @"Software\Microsoft\Windows\CurrentVersion\Search") == 2)
            {
                search.SelectedIndex = 2;
            }
            if (Savesettings.LoadCustom("SearchboxTaskbarMode", @"Software\Microsoft\Windows\CurrentVersion\Search") == 3)
            {
                search.SelectedIndex = 3;
            }
            //Load search reg
            if (Savesettings.LoadCustom("TaskbarGlomLevel", @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced") == 0)
            {
                comninedtaskbar.SelectedIndex = 0;
            }
            if (Savesettings.LoadCustom("TaskbarGlomLevel", @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced") == 1)
            {
                comninedtaskbar.SelectedIndex = 1;
            }
            if (Savesettings.LoadCustom("TaskbarGlomLevel", @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced") == 2)
            {
                comninedtaskbar.SelectedIndex = 2;
            }
            //Load TaskView reg
            if (Savesettings.LoadCustom("ShowTaskViewButton", @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced") == 0)
            {
                taskviev.IsOn = false;
            }
            if (Savesettings.LoadCustom("ShowTaskViewButton", @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced") == 1)
            {
                taskviev.IsOn = true;

            }
            //Load Taskbartype reg
            Version osVersion = Environment.OSVersion.Version;
            if (osVersion.Build < 22621)
            {
                if (Savesettings.LoadCustomLocalmachine("UndockingDisabled", @"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell\Update\Packages") == 0)
                {
                    taskbartype.SelectedIndex = 0;
                }
                if (Savesettings.LoadCustomLocalmachine("UndockingDisabled", @"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell\Update\Packages") == 1)
                {
                    taskbartype.SelectedIndex = 1;

                }
            }
            else
            {
                if (Savesettings.LoadCustomLocalmachine("OldTaskbar", @"Software\ExplorerPatcher") == 0)
                {
                    taskbartype.SelectedIndex = 0;
                }
                if (Savesettings.LoadCustomLocalmachine("OldTaskbar", @"Software\ExplorerPatcher") == 1)
                {
                    taskbartype.SelectedIndex = 1;

                }
            }
            //Load LoadWin10 11 Taskbar size reg
            if (Savesettings.LoadCustom("TaskbarSmallIcons", @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced") == 0)
            {
                Win10TaskSize.SelectedIndex = 0;
            }
            if (Savesettings.LoadCustom("TaskbarSmallIcons", @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced") == 1)
            {
                Win10TaskSize.SelectedIndex = 1;

            }
            if (Savesettings.LoadCustom("TaskbarSi", @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced") == 0)
            {
                Win11TaskSize.SelectedIndex = 0;
            }
            if (Savesettings.LoadCustom("TaskbarSi", @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced") == 1)
            {
                Win11TaskSize.SelectedIndex = 1;
            }
            if (Savesettings.LoadCustom("TaskbarSi", @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced") == 2)
            {
                Win11TaskSize.SelectedIndex = 2;
            }
        }
    }
}
