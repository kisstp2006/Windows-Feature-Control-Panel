using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIndows_Feature_Control_Center_WinUI.Extension
{
    internal class SystemInfo
    {
        public int WindowsBuildNumber()
        {
            Version osVersion = Environment.OSVersion.Version;
            return  osVersion.Build;
        }
        public string CurrentUserName()
        {
            string currentuser = "Current User: " + Environment.UserName;
            return currentuser;
        }

    }
}
