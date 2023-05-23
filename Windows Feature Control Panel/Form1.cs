using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Windows_Feature_Control_Panel
{
    public partial class Form1 : Form
    {
        //Variables 
        string TaskbarPackagespath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell\Update\Packages";
        string Windows1011Taskbarswitchervalue = "UndockingDisabled";
        string ExplorerAdvancedPath = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        string MMTTAskbarvalue = "MMTaskbarEnabled";
        string Windows11TaskbarSize = "TaskbarSi";
        string Windows10TaskbarSize = "TaskbarSmallIcons";
        string ExplorerSearchPath = @"Software\Microsoft\Windows\CurrentVersion\Search";
        string WhichSearchLookSelected = "SearchboxTaskbarMode";
        string TaskbarTaskView = "ShowTaskViewButton";
        string ExplorerPatcherRegistrys = "S-1-5-21-396046952-3905077869-1184723764-1000\\Software\\ExplorerPatcher";
        bool TaskViewEnabled = false; // false = disabled true = enabled
        string TaskbarCombined = "TaskbarGlomLevel";
        string Win10TaskbarExplorerPatcher = "OldTaskbar";

        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(ExplorerAdvancedPath, true))
            {
                if (regkey != null)
                {
                    regkey.SetValue(MMTTAskbarvalue, comboBox2.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
                else
                {
                    MessageBox.Show("Cant Find the registry value!");
                }
            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(ExplorerAdvancedPath, true))
            {
                if (regkey != null)
                {
                    regkey.SetValue(Windows10TaskbarSize, comboBox4.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
                else
                {
                    MessageBox.Show("Cant Find the registry value!");
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (RegistryKey regkey = Registry.LocalMachine.OpenSubKey(TaskbarPackagespath, true))
            {
                if (regkey != null)
                {
                    regkey.SetValue(Windows1011Taskbarswitchervalue, comboBox1.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
                else
                {
                    MessageBox.Show("Cant Find the registry value!");
                }
            }
            using (RegistryKey regkey = Registry.Users.OpenSubKey(ExplorerPatcherRegistrys, true))
            {
                if (regkey != null)
                {
                    regkey.SetValue(Win10TaskbarExplorerPatcher, comboBox1.SelectedIndex, RegistryValueKind.DWord);
                }
                else
                {
                    MessageBox.Show("Cant Find the registry value!");
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Process[] Processes = Process.GetProcessesByName("explorer");
            foreach (Process explorerProcess in Processes)
            {
                explorerProcess.Kill();
            }
            //Process.Start("C:\\Windows\\explorer.exe"); (Use this if the explorer doesn't  start automaticli)
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(ExplorerAdvancedPath, true))
            {
                if (regkey != null)
                {
                    regkey.SetValue(Windows11TaskbarSize, comboBox3.SelectedIndex, RegistryValueKind.DWord);
                    regkey.Close();
                }
                else
                {
                    MessageBox.Show("Cant Find the registry value!");
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(ExplorerAdvancedPath, true))
            {
                if (regkey != null)
                {
                    TaskViewEnabled = !TaskViewEnabled;
                    if (TaskViewEnabled == false)
                    {
                        regkey.SetValue(TaskbarTaskView, 0, RegistryValueKind.DWord);
                        label5.Text = "Show Task Wiev Icon: X";
                    }
                    if (TaskViewEnabled == true)
                    {
                        regkey.SetValue(TaskbarTaskView, 1, RegistryValueKind.DWord);
                        label5.Text = "Show Task Wiev Icon: 🗸";

                    }

                }
                else
                {
                    MessageBox.Show("Cant Find the registry value!");
                }
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(ExplorerSearchPath, true))
            {
                if (regkey != null)
                {
                    regkey.SetValue(WhichSearchLookSelected, comboBox6.SelectedIndex, RegistryValueKind.DWord);
                }
                else
                {
                    MessageBox.Show("Cant Find the registry value!");
                }
            }

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(ExplorerAdvancedPath, true))
            {
                if (regkey != null)
                {
                    regkey.SetValue(TaskbarCombined, comboBox5.SelectedIndex, RegistryValueKind.DWord);
                }
                else
                {
                    MessageBox.Show("Cant Find the registry value!");
                }
            }
            using (RegistryKey regkey = Registry.Users.OpenSubKey(ExplorerPatcherRegistrys, true))
            {
                if (regkey != null)
                {
                    regkey.SetValue(TaskbarCombined, comboBox5.SelectedIndex, RegistryValueKind.DWord);
                }
                else
                {
                    MessageBox.Show("Cant Find the registry value!");
                }
            }
        }
    }
}