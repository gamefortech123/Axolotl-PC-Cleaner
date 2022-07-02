using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;

namespace AXOLOTL_PC_CLEANER.Helper
{
    internal class Utils
    {
        public static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            return false;
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string path = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Axolotl_Software";

        public static void Logger(string lines)
        {
            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(path + "delete" + "_logs.txt", true);

                file.WriteLine(lines);
                file.Close();
            }
            catch (Exception) { }
        }

        public static void RemoveDeleteLogs()
        {
            foreach (string file in Directory.GetFiles(path, "*.txt").Where(item => item.EndsWith(".txt")))
            {
                File.Delete(file);
            }
        }

        public static void KillProcess(string Proc)
        {
            Process[] workers = Process.GetProcessesByName(Proc);

            foreach (Process worker in workers)
            {
                try { worker.Kill(); } catch { }
            }
        }

        public static void UsernameSid()
        {
            Properties.Settings.Default.Sid = UserPrincipal.Current.Sid.ToString();
            Properties.Settings.Default.Save();
        }

        public static void ReturnSystem()
        {
            if (Properties.Settings.Default.Windows == "")
            {
                var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                            select x.GetPropertyValue("Caption")).FirstOrDefault();

                Properties.Settings.Default.Windows = name.ToString();

                Properties.Settings.Default.Save();
            }

            if (Properties.Settings.Default.Cpu == "")
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                foreach (ManagementObject mo in mos.Get())
                {
                    Properties.Settings.Default.Cpu = mo["Name"].ToString();

                    Properties.Settings.Default.Save();
                }
            }

            if (Properties.Settings.Default.Ram == "")
            {
                string Query = "SELECT MaxCapacity FROM Win32_PhysicalMemoryArray";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(Query);
                foreach (ManagementObject WniPART in searcher.Get())
                {
                    UInt32 SizeinKB = Convert.ToUInt32(WniPART.Properties["MaxCapacity"].Value);
                    UInt32 SizeinMB = SizeinKB / 1024;
                    UInt32 SizeinGB = SizeinMB / 1024;

                    Properties.Settings.Default.Ram = SizeinGB.ToString();

                    Properties.Settings.Default.Save();
                }
            }

            if (Properties.Settings.Default.Gpu == "")
            {
                using (var searcher1 = new ManagementObjectSearcher("select * from Win32_VideoController"))
                {
                    foreach (ManagementObject obj in searcher1.Get())
                    {
                        Properties.Settings.Default.Gpu = obj["Name"].ToString();
                    }
                }

                Properties.Settings.Default.Save();
            }
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string moduleName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetCurrentProcess();

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string methodName);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool IsWow64Process([In] IntPtr hSourceProcessHandle, [MarshalAs(UnmanagedType.Bool)] out bool isWow64);

        [SecurityCritical]
        internal static bool DoesWin32MethodExist(string moduleName, string methodName)
        {
            IntPtr moduleHandle = GetModuleHandle(moduleName);
            if (moduleHandle == IntPtr.Zero)
            {
                return false;
            }
            return (GetProcAddress(moduleHandle, methodName) != IntPtr.Zero);
        }

        [SecuritySafeCritical]
        public static bool get_Is64BitOperatingSystem()
        {
            bool flag;
            return (IntPtr.Size == 8) ||
                ((DoesWin32MethodExist("kernel32.dll", "IsWow64Process") &&
                IsWow64Process(GetCurrentProcess(), out flag)) && flag);
        }

        public static void SetStartup(bool enable)
        {
            RegistryKey key;

            if (enable)
            {
                if (get_Is64BitOperatingSystem())
                {
                    try
                    {
                        key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                        key.SetValue("Axolotl", "\"" + Application.ExecutablePath + "\"");
                        key.Close();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                        key.SetValue("Axolotl", "\"" + Application.ExecutablePath + "\"");
                        key.Close();
                    }
                    catch { }
                }
            }
            else if (!enable)
            {
                if (get_Is64BitOperatingSystem())
                {
                    try
                    {
                        key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                        key.DeleteValue("Axolotl", false);
                        key.Close();
                    }
                    catch { }
                }
                else
                {
                    key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    key.DeleteValue("Axolotl", false);
                    key.Close();
                }
            }
        }
    }
}
