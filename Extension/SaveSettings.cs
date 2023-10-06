using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace WIndows_Feature_Control_Center_WinUI.Extension
{
    class SaveSettings
    {
        string WFCCSettingRegPatch = @"Software\kisstp2006\WFCC\SETTINGS";
        public object Save(string regname , int value)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(WFCCSettingRegPatch, true))
            {
                if (regkey != null)
                {
                    regkey.SetValue(regname, value, RegistryValueKind.DWord);
                    regkey.Close();
                }
                else
                {
                    regkey.CreateSubKey(regname);
                }
            }
            return value;
        }
        public uint Load(string regname)
        {
            uint value = 0;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(WFCCSettingRegPatch))
            {
                // Check if the key exists and contains the specified value
                if (key != null && key.GetValue(regname) != null)
                {
                    using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(WFCCSettingRegPatch, true))
                    {
                        if (regkey != null)
                        {
                            var avalue = regkey.GetValue(regname);
                            regkey.Close();
                            value = (uint)(int)avalue;
                        }
                        else
                        {
                            regkey.CreateSubKey(regname);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The 'DevMode' value does not exist in the Windows Registry.");
                }
            }
            return value;

        }
        public uint LoadCustom(string regname , string regpath)
        {
            uint value = 0;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(regpath))
            {
                // Check if the key exists and contains the specified value
                if (key != null && key.GetValue(regname) != null)
                {
                    using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(regpath, true))
                    {
                        if (regkey != null)
                        {
                            var avalue = regkey.GetValue(regname);
                            regkey.Close();
                            value = (uint)(int)avalue;
                        }
                        else
                        {
                            regkey.CreateSubKey(regname);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The 'DevMode' value does not exist in the Windows Registry.");
                }
            }
            return value;

        }
        public uint LoadCustomLocalmachine(string regname, string regpath)
        {
            uint value = 0;
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(regpath))
            {
                // Check if the key exists and contains the specified value
                if (key != null && key.GetValue(regname) != null)
                {
                    using (RegistryKey regkey = Registry.LocalMachine.OpenSubKey(regpath, true))
                    {
                        if (regkey != null)
                        {
                            var avalue = regkey.GetValue(regname);
                            regkey.Close();
                            value = (uint)(int)avalue;
                        }
                        else
                        {
                            regkey.CreateSubKey(regname);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The 'DevMode' value does not exist in the Windows Registry.");
                }
            }
            return value;

        }
    }
}
