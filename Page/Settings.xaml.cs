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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using WIndows_Feature_Control_Center_WinUI.Extension;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WIndows_Feature_Control_Center_WinUI.Page
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings
    {
        public Settings()
        {
            this.InitializeComponent();
            LoadSettings();
            SetWallpaper();
            SystemInfo systemInfo = new SystemInfo();
            GetUsername();
            version.Text = "Windows Version:" + systemInfo.WindowsBuildNumber();
        }
        private void SetWallpaper()
        {
            const string wallpaperRegistryPath = @"Control Panel\Desktop";
            const string wallpaperRegistryKey = "Wallpaper";
            using (var key = Registry.CurrentUser.OpenSubKey(wallpaperRegistryPath))
            {
                wallpaper.Source = new BitmapImage(new Uri(key.GetValue(wallpaperRegistryKey) as string));
            }
        }
        private void GetUsername()
        {
            SystemInfo systemInfo = new SystemInfo();
            user.Text =  systemInfo.CurrentUserName();
                }
        private void user_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        //Create registry keys if they arent existing
        private void devmodesw_Toggled(object sender, RoutedEventArgs e)
        {
            SaveSettings Savesetting =new SaveSettings();
            if (devmodesw.IsOn)
            {
                Savesetting.Save("DevMode",1);
            }
            else
            {
                Savesetting.Save("DevMode", 0);
            }
        }
        private void nowarning_Toggled(object sender, RoutedEventArgs e)
        {
            SaveSettings Savesetting =new SaveSettings();
            if (nowarning.IsOn)
            {
                Savesetting.Save("NoWarn",1);
            }
            else
            {
                Savesetting.Save("NoWarn", 0);
            }
        }
        private void enablecustomcommand_Toggled(object sender, RoutedEventArgs e)
        {
            SaveSettings Savesetting = new SaveSettings();
            if (enablecustomcommand.IsOn)
            {
                Savesetting.Save("CustomCMD", 1);
            }
            else
            {
                Savesetting.Save("CustomCMD", 0);
            }
        }
        private void LoadSettings()
        {
            SaveSettings Savesettings = new SaveSettings();
            //Set DevMode Swith according to the save
                if (Savesettings.Load("DevMode")==0)
                {
                    devmodesw.IsOn = false;
                }
                else
                {
                    devmodesw.IsOn = true;
                }

            //Set no warning/info switch according to the save 
                if (Savesettings.Load("NoWarn") == 0)
                {
                    nowarning.IsOn = false;
                }
                else
                {
                    nowarning.IsOn = true;
                }

            //Set Custom command switch according to the save
                if (Savesettings.Load("CustomCMD") == 0)
                {
                    enablecustomcommand.IsOn = false;
                }
                else
                {
                    enablecustomcommand.IsOn = true;
                }
        }
    }
}
