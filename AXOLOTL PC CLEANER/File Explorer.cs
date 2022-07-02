using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AXOLOTL_PC_CLEANER
{
    public partial class File_Explorer : Form
    {
        #region File Loading
        public static string Viewing;

        private void Load_Files(string Location, string Name, bool folders)
        {
            Lbl1.Text = "Currently explorering: " + Name;

            try
            {
                string[] files = Directory.GetFiles(Location);
                Viewer.SmallImageList = this.images;

                foreach (string file in files)
                {
                    string fileName = Path.GetFullPath(file);
                    string fileSize = Calculations.Size.ConvertToString(file.Length);

                    string[] row = { fileName, fileSize };
                    var listViewItem = new ListViewItem(row);
                    listViewItem.ImageIndex = 0;
                    Viewer.Items.Add(listViewItem);
                }
            }
            catch { }

            if (folders)
            {
                try
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(Location);

                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        string[] row = { dir.FullName, Calculations.Size.ConvertToString(Calculations.Size.DirectorySize(dir, true)) };

                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 1;
                        Viewer.Items.Add(listViewItem);
                    }
                }
                catch { }
            }
        }

        private void Load_Single(string Location, string Name)
        {
            Lbl1.Text = "Currently explorering: " + Name;

            if (File.Exists(Location))
            {
                string file = Location;

                string[] row = { Location, Calculations.Size.ConvertToString(file.Length) };

                var listViewItem = new ListViewItem(row);
                listViewItem.ImageIndex = 0;
                Viewer.Items.Add(listViewItem);
            }
        }

        private void Load_Other(string Location, string Name, string Exetension)
        {
            Lbl1.Text = "Currently explorering: " + Name;

            Viewer.SmallImageList = this.images;

            try
            {
                foreach (string file in Directory.GetFiles(Location, "*." + Exetension).Where(item => item.EndsWith("." + Exetension)))
                {
                    string fileName = Path.GetFullPath(file);
                    string fileSize = Calculations.Size.ConvertToString(file.Length);

                    string[] row = { fileName, fileSize };
                    var listViewItem = new ListViewItem(row);
                    listViewItem.ImageIndex = 0;
                    Viewer.Items.Add(listViewItem);
                }
            }
            catch { }
        }
        #endregion

        public File_Explorer()
        {
            InitializeComponent();

            this.ActiveControl = Lbl1;
        }

        private void File_Explorer_Load(object sender, EventArgs e)
        {
            #region Windows Explorer
            if (Viewing == "Recent Documents")
            {
                Viewer.Items.Clear();
                Load_Files(Helper.Locations.Recent_Documents, "Recent Documents", true);
            }
            else if (Viewing == "Thumnail Cache")
            {
                Viewer.Items.Clear();
                Load_Files(Helper.Locations.Thumnail_Cache, "Thumbnail Cache", false);
            }
            else if (Viewing == "Mini Dumps")
            {
                Viewer.Items.Clear();
                Load_Files(Helper.Locations.Mini_Dumps, "Mini Dumps", false);
            }
            else if (Viewing == "WTemporary Files")
            {
                Viewer.Items.Clear();
                Load_Files(Helper.Locations.Win_Temp_Files, " Windows Temporary Files", true);
            }
            #endregion
            #region System
            else if (Viewing == "Recycle Bin")
            {
                Viewer.Items.Clear();
                Load_Files(Helper.Locations.Recyle_Bin, "Recycle Bin", true);
            }
            else if (Viewing == "Temporary Files")
            {
                Viewer.Items.Clear();
                Load_Files(Helper.Locations.Temp_Files, "Temporary Files", true);
            }
            else if (Viewing == "Memory Dumps")
            {
                Viewer.Items.Clear();
                Load_Files(Helper.Locations.Memory_Dumps, "Memory Dumps", true);
            }
            #region Windows Log Files
            else if (Viewing == "Windows Log Files")
            {
                Viewer.Items.Clear();
                Load_Other(Helper.Locations.WinLogs, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs1, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs2, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs3, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs4, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs5, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs6, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs7, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs8, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs9, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs10, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs11, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs12, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs13, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs14, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs15, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs16, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs17, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs18, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs19, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs20, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs21, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs22, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs23, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs24, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs25, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs26, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs27, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs28, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs29, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs30, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs31, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs32, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs33, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs34, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs35, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs36, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs37, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs38, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs39, "Windows Log Files", "log");
                Load_Other(Helper.Locations.WinLogs40, "Windows Log Files", "log");
            }
            #endregion
            else if (Viewing == "Event Trace Logs")
            {
                Viewer.Items.Clear();
                Load_Other(Helper.Locations.WinLogs1, "Event Trace Logs", "etl");
                Load_Other(Helper.Locations.WinLogs2, "Event Trace Logs", "etl");
                Load_Other(Helper.Locations.WinLogs3, "Event Trace Logs", "etl");
                Load_Other(Helper.Locations.WinLogs4, "Event Trace Logs", "etl");
                Load_Other(Helper.Locations.WinLogs5, "Event Trace Logs", "etl");
                Load_Other(Helper.Locations.WinLogs6, "Event Trace Logs", "etl");
                Load_Other(Helper.Locations.WinLogs7, "Event Trace Logs", "etl");
                Load_Other(Helper.Locations.WinLogs8, "Event Trace Logs", "etl");
                Load_Other(Helper.Locations.WinLogs9, "Event Trace Logs", "etl");
                Load_Other(Helper.Locations.WinLogs10, "Event Trace Logs", "etl");
                Load_Other(Helper.Locations.WinLogs11, "Event Trace Logs", "etl");
            }
            else if (Viewing == "Error Reporting")
            {
                Viewer.Items.Clear();
                Load_Files(Helper.Locations.Error_Reports, "Error Reportings", false);
                Load_Files(Helper.Locations.Error_Reports + @"\ReportArchive", "Error Reportings", false);
                Load_Files(Helper.Locations.Error_Reports + @"\ReportQueue", "Error Reportings", false);
                Load_Files(Helper.Locations.Error_Reports + @"\Temp", "Error Reportings", false);
            }
            else if (Viewing == "Driver Installation Log Files")
            {
                Viewer.Items.Clear();
                Load_Single(Helper.Locations.Error_Reports + @"\setupapi.dev.log", "Driver Installation Log Files");
            }
            else if (Viewing == "Windows Delivery Optimization Files")
            {
                Viewer.Items.Clear();
                Load_Files(Helper.Locations.Delivery_Optimization + @"\Cache", "Windows Delivery Optimization Files", false);
                Load_Other(Helper.Locations.Delivery_Optimization + @"\Logs", "Windows Delivery Optimization Files", "log");
            }
            else if (Viewing == "Network Data Usage")
            {
                Viewer.Items.Clear();
                Load_Files(Helper.Locations.Network_Data, "Windows Delivery Optimization Files", false);
            }
            #endregion
            #region Advanced
            else if (Viewing == "Prefetch Data")
            {
                Viewer.Items.Clear();
                Load_Files(Helper.Locations.Prefetch, "Prefetch Data", true);
            }
            else if (Viewing == "Store Install Service Cache")
            {
                Viewer.Items.Clear();
                Load_Other(Helper.Locations.Store_Install_Service, "Store Install Service Cache", "catalogItem");
            }
            else if (Viewing == "QT Framework")
            {
                Viewer.Items.Clear();
                Load_Files(Helper.Locations.QtFramework, "QT Framework", true);
            }
            else if (Viewing == "Power Efficiency Diagnostics")
            {
                Viewer.Items.Clear();
                Load_Other(Helper.Locations.Power_Efficiency, "Power Efficiency Diagnostics", "xml");
            }
            else if (Viewing == "Notifications")
            {
                Viewer.Items.Clear();
                Load_Files(Helper.Locations.Notifications, "Notifications", true);
            }
            else if (Viewing == "MS Search")
            {
                Viewer.Items.Clear();
                Load_Other(Helper.Locations.MS_Search, "MS Search", "edb");
                Load_Other(Helper.Locations.MS_Search2, "MS Search", "crwl");
                Load_Files(Helper.Locations.MS_Search3, "MS Search", false);
                Load_Files(Helper.Locations.MS_Search4, "MS Search", true);
                Load_Files(Helper.Locations.MS_Search5, "MS Search", true);
            }
            else if (Viewing == "Jump List")
            {
                Viewer.Items.Clear();
                Load_Other(Helper.Locations.Jump_List, "Jump List", "dat");
            }
            #endregion
            #region Applications
            else if (Viewing == "Windows Defender")
            {
                Viewer.Items.Clear();
                Load_Files(Helper.Locations.Win_Defender, "Windows Defender", false);
                Load_Other(Helper.Locations.Win_Defender2, "Windows Defender", "log");
                Load_Files(Helper.Locations.Win_Defender3, "Windows Defender", true);
                Load_Files(Helper.Locations.Win_Defender4, "Windows Defender", false);
                Load_Files(Helper.Locations.Win_Defender5, "Windows Defender", false);
                Load_Files(Helper.Locations.Win_Defender6, "Windows Defender", false);
            }
            else if (Viewing == "Origin Installers")
            {
                Load_Files(Helper.Locations.Origin_Installers, "Origin Installers", true);
            }
            else if (Viewing == "Visual Studio Installation")
            {
                Load_Files(Helper.Locations.Visual_Studio, "Visual Studio Installation", true);
            }
            else if (Viewing == "One Drive")
            {
                Load_Files(Helper.Locations.One_Drive, "One Drive", false);
                Load_Other(Helper.Locations.One_Drive2, "One Drive", "log");
                Load_Files(Helper.Locations.One_Drive3, "One Drive", true);
            }
            else if (Viewing == "Easy Anti-Cheat")
            {
                Load_Other(Helper.Locations.Easy_AntiCheat, "Easy Anti-Cheat", "log");
            }
            else if (Viewing == "Battlenet")
            {
                Load_Files(Helper.Locations.Battlenet, "Battlenet", true);
                Load_Files(Helper.Locations.Battlenet2, "Battlenet", false);
                Load_Files(Helper.Locations.Battlenet3, "Battlenet", false);
                Load_Files(Helper.Locations.Battlenet4, "Battlenet", false);
                Load_Files(Helper.Locations.Battlenet5, "Battlenet", true);
            }
            else if (Viewing == "Ccleaner")
            {
                Load_Other(Helper.Locations.Ccleaner, "Ccleaner", "log");
            }
            else if (Viewing == "Steam")
            {
                Load_Other(Helper.Locations.Steam, "Steam", "log");
                Load_Files(Helper.Locations.Steam2, "Steam", false);
                Load_Files(Helper.Locations.Steam3, "Steam", false);
            }
            #endregion
            #region Windows
            else if (Viewing == "DirectX Shader Cache")
            {
                Load_Files(Helper.Locations.DirectX, "DirectX Shader Cache", true);
                Load_Files(Helper.Locations.DirectX2, "DirectX Shader Cache", true);
            }
            else if (Viewing == "Update Files")
            {
                Load_Files(Helper.Locations.Windows_Update, "Update Files", true);
            }
            else if (Viewing == "Font Cache")
            {
                Load_Single(Helper.Locations.Font_Cache, "Font Cache");
            }
            else if (Viewing == "Debug Files")
            {
                Load_Other(Helper.Locations.Windows_Debug, "Debug Files", "log");
            }
            else if (Viewing == "Cache Files")
            {
                Load_Files(Helper.Locations.Windows_Cache, "Update Files", true);
                Load_Files(Helper.Locations.Windows_Cache2, "Update Files", true);
                Load_Files(Helper.Locations.Windows_Cache3, "Update Files", true);
                Load_Files(Helper.Locations.Windows_Cache4, "Update Files", true);
                Load_Files(Helper.Locations.Windows_Cache5, "Update Files", true);
            }
            else if (Viewing == "Installers")
            {
                Load_Files(Helper.Locations.Windows_Installer, "Installers", true);
            }
            else if (Viewing == "Experience Index")
            {
                Load_Other(Helper.Locations.Windows_Experience, "Experience Index", "log");
                Load_Files(Helper.Locations.Windows_Experience2, "Experience Index", true);
            }
            else if (Viewing == "Auto/Video Quality Experience")
            {
                Load_Other(Helper.Locations.Windows_Auto_Video_Experience, "Experience Index", "dat");
            }
            else if (Viewing == "Internet Explorer")
            {
                Load_Files(Helper.Locations.Windows_Internet_Cache, "Internet Explorer Cache", true);
            }
            #endregion
            #region Edge Chromium
            else if (Viewing == "Edge Cache")
            {
                Load_Files(Helper.Locations.Edge_Cache, "Chromium Edge Cache", false);
                Load_Files(Helper.Locations.Edge_Cache2, "Chromium Edge Cache", false);
                Load_Files(Helper.Locations.Edge_Cache3, "Chromium Edge Cache", false);
                Load_Files(Helper.Locations.Edge_Cache4, "Chromium Edge Cache", false);
                Load_Files(Helper.Locations.Edge_Cache5, "Chromium Edge Cache", true);
                Load_Files(Helper.Locations.Edge_Cache6, "Chromium Edge Cache", false);
                Load_Files(Helper.Locations.Edge_Cache7, "Chromium Edge Cache", false);
                Load_Files(Helper.Locations.Edge_Cache8, "Chromium Edge Cache", false);
                Load_Files(Helper.Locations.Edge_Cache9, "Chromium Edge Cache", false);
                Load_Files(Helper.Locations.Edge_Cache10, "Chromium Edge Cache", false);

                Load_Single(Helper.Locations.Edge_Cache11, "Chromium Edge Cache");
                Load_Single(Helper.Locations.Edge_Cache12, "Chromium Edge Cache");
                Load_Single(Helper.Locations.Edge_Cache13, "Chromium Edge Cache");
                Load_Single(Helper.Locations.Edge_Cache14, "Chromium Edge Cache");
                Load_Single(Helper.Locations.Edge_Cache15, "Chromium Edge Cache");
                Load_Single(Helper.Locations.Edge_Cache16, "Chromium Edge Cache");
                Load_Single(Helper.Locations.Edge_Cache17, "Chromium Edge Cache");
                Load_Single(Helper.Locations.Edge_Cache18, "Chromium Edge Cache");
                Load_Single(Helper.Locations.Edge_Cache19, "Chromium Edge Cache");
                Load_Single(Helper.Locations.Edge_Cache20, "Chromium Edge Cache");
                Load_Single(Helper.Locations.Edge_Cache21, "Chromium Edge Cache");
            }
            else if (Viewing == "Edge Cookies")
            {
                Load_Files(Helper.Locations.Edge_Cookies, "Chromium Edge History", true);
                Load_Single(Helper.Locations.Edge_Cookies, "Chromium Edge History");
            }
            else if (Viewing == "Edge History")
            {
                Load_Single(Helper.Locations.Edge_History, "Chromium Edge Cookies");
                Load_Single(Helper.Locations.Edge_History2, "Chromium Edge Cookies");
                Load_Single(Helper.Locations.Edge_History3, "Chromium Edge Cookies");
                Load_Single(Helper.Locations.Edge_History4, "Chromium Edge Cookies");
                Load_Single(Helper.Locations.Edge_History5, "Chromium Edge Cookies");
                Load_Single(Helper.Locations.Edge_History6, "Chromium Edge Cookies");
                Load_Single(Helper.Locations.Edge_History7, "Chromium Edge Cookies");
                Load_Single(Helper.Locations.Edge_History8, "Chromium Edge Cookies");
                Load_Single(Helper.Locations.Edge_History9, "Chromium Edge Cookies");
                Load_Single(Helper.Locations.Edge_History10, "Chromium Edge Cookies");
                Load_Single(Helper.Locations.Edge_History11, "Chromium Edge Cookies");
                Load_Single(Helper.Locations.Edge_History12, "Chromium Edge Cookies");
                Load_Single(Helper.Locations.Edge_History13, "Chromium Edge Cookies");
                Load_Single(Helper.Locations.Edge_History14, "Chromium Edge Cookies");
            }
            else if (Viewing == "Edge Session")
            {
                Load_Files(Helper.Locations.Edge_Session, "Chromium Edge Session Data", false);
                Load_Files(Helper.Locations.Edge_Session2, "Chromium Edge Session Data", false);
                Load_Files(Helper.Locations.Edge_Session3, "Chromium Edge Session Data", false);
            }
            else if (Viewing == "Edge Passwords")
            {
                Load_Single(Helper.Locations.Edge_Passwords, "Chromium Edge Passwords");
            }
            else if (Viewing == "Edge Metrics")
            {
                Load_Other(Helper.Locations.Edge_Metrics, "Chromium Edge Passwords", "pma");
                Load_Other(Helper.Locations.Edge_Metrics2, "Chromium Edge Passwords", "pma");
            }
            #endregion
            #region Google Chrome
            else if (Viewing == "Chrome Cache")
            {
                Load_Files(Helper.Locations.Chrome_Cache, "Google Chrome Cache", false);
                Load_Files(Helper.Locations.Chrome_Cache2, "Google Chrome Cache", false);
                Load_Files(Helper.Locations.Chrome_Cache3, "Google Chrome Cache", false);
                Load_Files(Helper.Locations.Chrome_Cache4, "Google Chrome Cache", false);
                Load_Files(Helper.Locations.Chrome_Cache5, "Google Chrome Cache", true);
                Load_Files(Helper.Locations.Chrome_Cache6, "Google Chrome Cache", false);
                Load_Files(Helper.Locations.Chrome_Cache7, "Google Chrome Cache", false);
                Load_Files(Helper.Locations.Chrome_Cache8, "Google Chrome Cache", true);
                Load_Files(Helper.Locations.Chrome_Cache9, "Google Chrome Cache", false);
                Load_Files(Helper.Locations.Chrome_Cache10, "Google Chrome Cache", false);
                Load_Files(Helper.Locations.Chrome_Cache11, "Google Chrome Cache", false);
                Load_Files(Helper.Locations.Chrome_Cache12, "Google Chrome Cache", false);

                Load_Single(Helper.Locations.Chrome_Cache13, "Google Chrome Cache");
                Load_Single(Helper.Locations.Chrome_Cache14, "Google Chrome Cache");
                Load_Single(Helper.Locations.Chrome_Cache15, "Google Chrome Cache");
                Load_Single(Helper.Locations.Chrome_Cache16, "Google Chrome Cache");
                Load_Single(Helper.Locations.Chrome_Cache17, "Google Chrome Cache");
                Load_Single(Helper.Locations.Chrome_Cache18, "Google Chrome Cache");
                Load_Single(Helper.Locations.Chrome_Cache19, "Google Chrome Cache");
                Load_Single(Helper.Locations.Chrome_Cache20, "Google Chrome Cache");
                Load_Single(Helper.Locations.Chrome_Cache21, "Google Chrome Cache");
                Load_Single(Helper.Locations.Chrome_Cache22, "Google Chrome Cache");
            }
            else if (Viewing == "Chrome History")
            {
                Load_Single(Helper.Locations.Chrome_History, "Google Chrome History");
                Load_Single(Helper.Locations.Chrome_History2, "Google Chrome History");
                Load_Single(Helper.Locations.Chrome_History3, "Google Chrome History");
                Load_Single(Helper.Locations.Chrome_History4, "Google Chrome History");
                Load_Single(Helper.Locations.Chrome_History5, "Google Chrome History");
                Load_Single(Helper.Locations.Chrome_History6, "Google Chrome History");
                Load_Single(Helper.Locations.Chrome_History7, "Google Chrome History");
                Load_Single(Helper.Locations.Chrome_History8, "Google Chrome History");
                Load_Files(Helper.Locations.Chrome_History9, "Google Chrome History", false);
            }
            else if (Viewing == "Chrome Cookies")
            {
                Load_Files(Helper.Locations.Chrome_Cookies, "Google Chrome Cookies", false);
                Load_Single(Helper.Locations.Chrome_Cookies2, "Google Chrome Cookies");
            }
            else if (Viewing == "Chrome Download History")
            {
                Load_Single(Helper.Locations.Chrome_Download, "Google Chrome Download History");
            }
            else if (Viewing == "Chrome Metrics")
            {
                Load_Other(Helper.Locations.Chrome_Metrics, "Google Chrome Metrics Temp Files", "pma");
            }
            else if (Viewing == "Chrome Session")
            {
                Load_Files(Helper.Locations.Chrome_Session, "Google Chrome Session Data", false);
                Load_Files(Helper.Locations.Chrome_Session2, "Google Chrome Session Data", false);
                Load_Files(Helper.Locations.Chrome_Session3, "Google Chrome Session Data", false);
            }
            else if (Viewing == "Chrome Passwords")
            {
                Load_Single(Helper.Locations.Chrome_Passwords, "Google Chrome Passwords");
            }
            #endregion
            #region Firefox
            else if (Viewing == "Firefox Cache")
            {
                Load_Files(Helper.Locations.Firefox_Cache, "Mozilla Firefox Cache", false);
                Load_Files(Helper.Locations.Firefox_Cache2, "Mozilla Firefox Cache", false);
                Load_Files(Helper.Locations.Firefox_Cache3, "Mozilla Firefox Cache", false);
                Load_Files(Helper.Locations.Firefox_Cache4, "Mozilla Firefox Cache", false);
                Load_Files(Helper.Locations.Firefox_Cache5, "Mozilla Firefox Cache", false);
            }
            else if (Viewing == "Firefox History")
            {
                Load_Files(Helper.Locations.Firefox_History, "Mozilla Firefox History", false);
            }
            else if (Viewing == "Firefox Cookies")
            {
                Load_Files(Helper.Locations.Firefox_Cookies, "Mozilla Firefox Cookies", true);
            }
            else if (Viewing == "Firefox Session")
            {
                Load_Files(Helper.Locations.Firefox_Session, "Mozilla Firefox Session Data", false);
                Load_Single(Helper.Locations.Firefox_Session2, "Mozilla Firefox Session Data");
            }
            else if (Viewing == "Firefox Preferences")
            {
                Load_Single(Helper.Locations.Firefox_Site_Pref, "Mozilla Firefox Site Preferences");
            }
            else if (Viewing == "Firefox Form")
            {
                Load_Single(Helper.Locations.Firefox_Saved_Form, "Mozilla Firefox Saved Form Information");
            }
            else if (Viewing == "Firefox Passwords")
            {
                Load_Single(Helper.Locations.Firefox_Login, "Mozilla Firefox Saved Passwords");
                Load_Single(Helper.Locations.Firefox_Login2, "Mozilla Firefox Saved Passwords");
            }
            #endregion
        }

        private void Viewer_DoubleClick(object sender, EventArgs e)
        {
            if (Viewer.SelectedIndices.Count <= 0)
            {
                return;
            }

            int intselectedindex = Viewer.SelectedIndices[0];

            if (intselectedindex >= 0)
            {
                String text = Viewer.Items[intselectedindex].Text;

                try { Process.Start(text); } catch (Exception ex) { MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Viewer.SelectedIndices.Count <= 0)
            {
                return;
            }

            int intselectedindex = Viewer.SelectedIndices[0];

            if (intselectedindex >= 0)
            {
                String text = Viewer.Items[intselectedindex].Text;

                try {File.Delete(text); } catch (Exception ex) { MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        public string selected;

        private void Viewer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Viewer.SelectedIndices.Count <= 0)
            {
                return;
            }

            int intselectedindex = Viewer.SelectedIndices[0];

            if (intselectedindex >= 0)
            {
                selected = Viewer.Items[intselectedindex].Text;
            }
        }
    }
}
