using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace _219996
{
    public partial class Windows11Control : Form
    {
        bool Win10startenabled = false;
        bool Win10taskbarenabled = false;
        int Win11taskbarsize = 2; //1=small taskbar 2=medium(Default) taskbar 3=Large taskbar
        string InWindows10taskbar = ""; //0=false 1=true
        bool MMTTaskbarEnabled = false;
        public Windows11Control()
        {
            InitializeComponent();
            OperatingSystem os = Environment.OSVersion;
            Version version = os.Version;
            label1.Text = "Windows version:" + version.ToString();

            if (version.ToString() != "10.0.21996.0")
            {
                doesntsupport.Visible = true;
            }
            else
            {
                doesntsupport.Visible = false;
            }
            object value = Registry.LocalMachine.GetValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell\Update\Packages", "UndockingDisabled2");
            if (value != null)
            {

                if (value.ToString() == "0")
                {
                    label3.Text = "Set Windows11 taskbar size:";
                    label2.Text = value.ToString();
                }
                else
                {
                    label3.Text = "Set Windows10 taskbar size:";
                    label2.Text = value.ToString();
                }
            }
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell\Update\Packages", true))
            {
                if (value != null)
                {
                    //label2.Text = key.GetValue("UndockingDisabled", 0).ToString(); (For debugging)
                    string InWindows10taskbar = key.GetValue("UndockingDisabled", 0).ToString();
                    if (key.GetValue("UndockingDisabled", 0).ToString() == "0")
                    {
                        label3.Text = "Set Windows11 taskbar size:";
                    }
                    else
                    {
                        label3.Text = "Set Windows10 taskbar size:";
                        comboBox1.Items.Clear();
                        comboBox1.Items.Add("Default");
                        comboBox1.Items.Add("Small");

                    }

                }
                else
                {
                    label2.Text = "Registry key not found.";
                    MessageBox.Show("An error occurred ");
                }

            }


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true))
            {
                if (key != null)
                {
                    Win10startenabled = !Win10startenabled;
                    if (Win10startenabled == false)
                    {
                        button2.Text = "[Enable] Windows10 Start Menu (only works with Windows11 Taskbar)";
                        key.SetValue("Start_ShowClassicMode", 0, RegistryValueKind.DWord);
                        key.Close();

                    }
                    else
                    {
                        button2.Text = "[Disable] Windows10 Start Menu (only works with Windows11 Taskbar)";
                        key.SetValue("Start_ShowClassicMode", 1, RegistryValueKind.DWord);
                        key.Close();
                    }
                }
                else
                {
                    label2.Text = "Registry key not found.";
                    MessageBox.Show("An error occurred ");
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Process[] Processes = Process.GetProcessesByName("explorer");
            foreach (Process explorerProcess in Processes)
            {
                explorerProcess.Kill();
            }
            //Process.Start("C:\\Windows\\explorer.exe"); (Use this if the explorer doesn't  start automaticli)
        }
        private void win10taskbar_Click(object sender, EventArgs e)
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell\Update\Packages", true))
            {
                if (key != null)
                {
                    Win10taskbarenabled = !Win10taskbarenabled;
                    if (Win10taskbarenabled == false)
                    {
                        win10taskbar.Text = "[Enable] Windows10 Taskbar";
                        key.SetValue("UndockingDisabled", 0, RegistryValueKind.DWord);
                        key.Close();

                    }
                    else
                    {
                        win10taskbar.Text = "[Disable] Windows10 Taskbar";
                        key.SetValue("UndockingDisabled", 1, RegistryValueKind.DWord);
                        key.Close();
                    }
                }
                else
                {
                    label2.Text = "Registry key not found.";
                    MessageBox.Show("An error occurred ");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true))
            {
                if (key != null)
                {
                    if (InWindows10taskbar == "0") //If windows 10 taskbar enabled this changes the second vlue 
                    {
                        key.SetValue("TaskbarSi", comboBox1.SelectedIndex, RegistryValueKind.DWord);
                        key.Close();
                    }
                    else
                    {
                        key.SetValue("TaskbarSmallIcons", comboBox1.SelectedIndex, RegistryValueKind.DWord);
                        key.Close();
                    }
                }
                else
                {
                    label2.Text = "Registry key not found.";
                    MessageBox.Show("An error occurred ");
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true))
            {
                if (key != null)
                {
                    MMTTaskbarEnabled =! MMTTaskbarEnabled;
                    if (MMTTaskbarEnabled == false)
                    {
                        key.SetValue("MMTaskbarEnabled", 0, RegistryValueKind.DWord);
                        key.Close();
                        button3.Text = "[Enable] Taskbar on other monitors(Experimental)";
                    }
                    else
                    {
                        key.SetValue("MMTaskbarEnabled", 1, RegistryValueKind.DWord);
                        key.Close();
                        button3.Text = "[Disable] Taskbar on other monitors(Experimental)";
                    }
                }
                else
                {
                    label2.Text = "Registry key not found.";
                    MessageBox.Show("An error occurred ");
                }
            }
        }
    }
}