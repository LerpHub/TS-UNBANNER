using System;
using Microsoft.Win32;

namespace ProductIdService
{
    public class ProductIdChanger
    {
        public static bool ChangeProductID(string ProductID)
        {
            try
            {
                RegistryKey localKey;
                if (Environment.Is64BitOperatingSystem)
                {
                    localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                    localKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
                    localKey.SetValue("ProductId", ProductID, RegistryValueKind.String);
                    return true;
                }
                else
                {
                    localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                    localKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
                    localKey.SetValue("ProductId", ProductID, RegistryValueKind.String);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static string SeeProductID()
        {
            try
            {
                RegistryKey localKey;
                if (Environment.Is64BitOperatingSystem)
                {
                    localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                    return localKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion")
                        .GetValue("ProductId").ToString();
                }
                else
                {
                    localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                    return localKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion")
                        .GetValue("ProductId").ToString();
                }
            }
            catch
            {
                return "Error Try Running App as Administrator";
            }
        }
    }
}
