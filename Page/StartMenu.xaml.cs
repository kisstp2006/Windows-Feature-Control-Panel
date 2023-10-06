using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
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


namespace WIndows_Feature_Control_Center_WinUI.Page
{

    public sealed partial class StartMenu
    {
        public StartMenu()
        {
            this.InitializeComponent();
            LoadOptions();
            CheckWinVer();
            LoadRegSettingsNew();
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
        private void CheckWinVer()
        {
            Version osVersion = Environment.OSVersion.Version;
            if (osVersion.Build < 21000)
            {
                win10warn.IsOpen = true;
            }
        }
        private void LoadOptions()
        {
            SaveSettings Savesettings = new SaveSettings();
            if (Savesettings.Load("NoWarn") == 1)
            {
                infobar.IsOpen = false;
                infobar1.IsOpen = false;
            }
        }
        private void ChechkOptions()
        {
            if (StartStyle.SelectedIndex==0)
            {
                prev.Source = new BitmapImage(new Uri("ms-appx:///Images/design1.png"));
            }
            if (StartStyle.SelectedIndex == 1)
            {
                prev.Source = new BitmapImage(new Uri("ms-appx:///Images/design7.png"));

            }
        }

        private void Roundedwin10start_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\ExplorerPatcher", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("StartUI_EnableRoundedCorners", Roundedwin10start.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        private void Applicationlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("NoStartMenuMorePrograms", Applicationlist.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
            using (RegistryKey regkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("NoStartMenuMorePrograms", Applicationlist.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        private void Fullscreenmenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (RegistryKey regkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("NoStartMenuMorePrograms", Applicationlist.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        private void StartStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChechkOptions();
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("Start_ShowClassicMode", StartStyle.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        private void BingAISearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChechkOptions();
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Search", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("BingSearchEnabled", BingAISearch.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        private void RecomendedSectionSE_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChechkOptions();
            using (RegistryKey regkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Explorer", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("HideRecommendedSection", RecomendedSectionSE.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        private void RecomendedSection2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChechkOptions();
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\ExplorerPatcher", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("StartDocked_DisableRecommendedSection", RecomendedSection.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        private void ImmersiveSearc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChechkOptions();
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Search", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("ImmersiveSearch", ImmersiveSearch.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        private void Immersive_SearchFull_Toggled(object sender, RoutedEventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Search\Flighting\Override", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("ImmersiveSearchFull", Full.IsOn, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }
        private void Immersive_SearchCorner_Changed(object sender, RoutedEventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Search\Flighting\Override", true))
            {
                if (regkey != null)
                {
                    regkey.SetValue("CenterScreenRoundedCornerRadius", RoundedCornerRadius.Value, RegistryValueKind.DWord);
                    regkey.Close();
                }
            }
        }


        private void LoadRegSettingsNew()
        {
            SaveSettings Savesettings = new SaveSettings();
            StartStyle.SelectedIndex = Convert.ToInt32(Savesettings.LoadCustom("Start_ShowClassicMode", @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced"));
            Applicationlist.SelectedIndex = Convert.ToInt32(Savesettings.LoadCustom("NoStartMenuMorePrograms", @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"));
            Roundedwin10start.SelectedIndex = Convert.ToInt32(Savesettings.LoadCustom("StartUI_EnableRoundedCorners", @"Software\ExplorerPatcher"));
            Fullscreenmenu.SelectedIndex = Convert.ToInt32(Savesettings.LoadCustom("NoStartMenuMorePrograms", @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer"));
            RecomendedSectionSE.SelectedIndex = Convert.ToInt32(Savesettings.LoadCustomLocalmachine("NoStartMenuMorePrograms", @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer"));
            RecomendedSection.SelectedIndex = Convert.ToInt32(Savesettings.LoadCustomLocalmachine("StartDocked_DisableRecommendedSection", @"Software\ExplorerPatcher"));
            BingAISearch.SelectedIndex = Convert.ToInt32(Savesettings.LoadCustom("BingSearchEnabled", @"SOFTWARE\Microsoft\Windows\CurrentVersion\Search"));
            ImmersiveSearch.SelectedIndex = Convert.ToInt32(Savesettings.LoadCustom("ImmersiveSearch", @"Software\Microsoft\Windows\CurrentVersion\Search"));
            RoundedCornerRadius.Value = Convert.ToInt32(Savesettings.LoadCustom("CenterScreenRoundedCornerRadius", @"Software\Microsoft\Windows\CurrentVersion\Search\Flighting\Override"));
            if (Savesettings.LoadCustom("ImmersiveSearch", @"Software\Microsoft\Windows\CurrentVersion\Search") == 0)
            {
                Full.IsEnabled = false;
                Full.Visibility = Visibility.Collapsed;
                SearchFullText.Visibility = Visibility.Collapsed;
                SearchRoundedText.Visibility = Visibility.Collapsed;
                RoundedCornerRadius.IsEnabled = false;
                RoundedCornerRadius.Visibility = Visibility.Collapsed;

            }
            if (Savesettings.LoadCustom("ImmersiveSearchFull", @"Software\Microsoft\Windows\CurrentVersion\Search\Flighting\Override") == 1)
            {
                Full.IsOn = true;
            }
        }
    }
}