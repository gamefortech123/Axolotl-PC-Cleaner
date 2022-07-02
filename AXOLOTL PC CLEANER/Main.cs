using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using AXOLOTL_PC_CLEANER.Helper;
using AXOLOTL_PC_CLEANER.Remover;
using AXOLOTL_PC_CLEANER.Calculations;
using static AXOLOTL_PC_CLEANER.Calculations.Size;
using System.IO;

namespace AXOLOTL_PC_CLEANER
{
    public partial class Main : Form
    {
        #region Main
        public Main()
        {
            InitializeComponent();

            Load_Settings();

            Utils.ReturnSystem();

            if (Properties.Settings.Default.Startup == true)
            {
                Helper.Utils.SetStartup(true);
            }

            if (Properties.Settings.Default.Minimized == true)
            {
                Visible = false;
                ShowInTaskbar = false; 
                Opacity = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Line1.Text = Properties.Settings.Default.Windows.ToUpper() + " (" + Environment.UserName.ToUpper() + ")";

            Line2.Text = Properties.Settings.Default.Cpu.ToUpper() + ", " + Properties.Settings.Default.Ram + "GB RAM, " + Properties.Settings.Default.Gpu.ToUpper();

            this.ActiveControl = TitleLogo;

            if (Properties.Settings.Default.ExpandAll)
                Options.ExpandAll();
            else
                Options.CollapseAll();

            if (!Properties.Settings.Default.ShowAdvanced)
            {
                node16.Visible = false;
                node17.Visible = false;
                node18.Visible = false;
                node19.Visible = false;
                node20.Visible = false;
                node21.Visible = false;
                node22.Visible = false;
                node23.Visible = false;
                node24.Visible = false;

                node16.Checked = false;
                node17.Checked = false;
                node18.Checked = false;
                node19.Checked = false;
                node20.Checked = false;
                node21.Checked = false;
                node22.Checked = false;
                node23.Checked = false;
                node24.Checked = false;
            }

            if (!Properties.Settings.Default.ShowApps)
            {
                node25.Visible = false;
                node26.Visible = false;
                node27.Visible = false;
                node28.Visible = false;
                node29.Visible = false;
                node30.Visible = false;
                node31.Visible = false;
                node32.Visible = false;
                node33.Visible = false;

                node25.Checked = false;
                node26.Checked = false;
                node27.Checked = false;
                node28.Checked = false;
                node29.Checked = false;
                node30.Checked = false;
                node31.Checked = false;
                node32.Checked = false;
                node33.Checked = false;
            }

            if (!Properties.Settings.Default.ShowWindows)
            {
                node34.Visible = false;
                node35.Visible = false;
                node36.Visible = false;
                node37.Visible = false;
                node38.Visible = false;
                node39.Visible = false;
                node40.Visible = false;
                node41.Visible = false;
                node42.Visible = false;
                node66.Visible = false;

                node34.Checked = false;
                node35.Checked = false;
                node36.Checked = false;
                node37.Checked = false;
                node38.Checked = false;
                node39.Checked = false;
                node40.Checked = false;
                node41.Checked = false;
                node42.Checked = false;
                node66.Checked = false;
            }

            if (!Properties.Settings.Default.ShowEdge)
            {
                node43.Visible = false;
                node44.Visible = false;
                node45.Visible = false;
                node46.Visible = false;
                node47.Visible = false;
                node48.Visible = false;
                node49.Visible = false;

                node43.Checked = false;
                node44.Checked = false;
                node45.Checked = false;
                node46.Checked = false;
                node47.Checked = false;
                node48.Checked = false;
                node49.Checked = false;
            }

            if (!Properties.Settings.Default.ShowChrome)
            {
                node50.Visible = false;
                node51.Visible = false;
                node52.Visible = false;
                node53.Visible = false;
                node54.Visible = false;
                node55.Visible = false;
                node56.Visible = false;
                node57.Visible = false;

                node50.Checked = false;
                node51.Checked = false;
                node52.Checked = false;
                node53.Checked = false;
                node54.Checked = false;
                node55.Checked = false;
                node56.Checked = false;
                node57.Checked = false;
            }

            if (!Properties.Settings.Default.ShowFirefox)
            {
                node58.Visible = false;
                node59.Visible = false;
                node60.Visible = false;
                node61.Visible = false;
                node62.Visible = false;
                node63.Visible = false;
                node64.Visible = false;
                node65.Visible = false;

                node58.Checked = false;
                node59.Checked = false;
                node60.Checked = false;
                node61.Checked = false;
                node62.Checked = false;
                node63.Checked = false;
                node64.Checked = false;
                node65.Checked = false;
            }

            if (Properties.Settings.Default.Sid == "")
            {
                Utils.UsernameSid();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save_Settings();
        }
        #endregion

        #region Settings
        private void Load_Settings()
        {
            node59.Checked = Properties.Settings.Default.FirefoxCache;
            node60.Checked = Properties.Settings.Default.FirefoxHistory;
            node61.Checked = Properties.Settings.Default.FirefoxCookies;
            node62.Checked = Properties.Settings.Default.FirefoxSession;
            node63.Checked = Properties.Settings.Default.FirefoxSite;
            node64.Checked = Properties.Settings.Default.FirefoxForm;
            node65.Checked = Properties.Settings.Default.FirefoxPasswords;

            node51.Checked = Properties.Settings.Default.ChromeCache;
            node52.Checked = Properties.Settings.Default.ChromeHistroy;
            node53.Checked = Properties.Settings.Default.ChromeCookies;
            node54.Checked = Properties.Settings.Default.ChromeDownloadHistory;
            node55.Checked = Properties.Settings.Default.ChromeMetrics;
            node56.Checked = Properties.Settings.Default.ChromeSession;
            node57.Checked = Properties.Settings.Default.ChromePasswords;

            node44.Checked = Properties.Settings.Default.EdgeCache;
            node45.Checked = Properties.Settings.Default.EdgeCookies;
            node46.Checked = Properties.Settings.Default.EdgeHistory;
            node47.Checked = Properties.Settings.Default.EdgeSession;
            node48.Checked = Properties.Settings.Default.EdgePasswords;
            node49.Checked = Properties.Settings.Default.EdgeMetrics;

            node2.Checked = Properties.Settings.Default.RecentDocuments;
            node3.Checked = Properties.Settings.Default.ThumbnailCache;
            node4.Checked = Properties.Settings.Default.MiniDumps;
            node15.Checked = Properties.Settings.Default.TemporaryFiles;

            node6.Checked = Properties.Settings.Default.RecycleBin;
            node7.Checked = Properties.Settings.Default.TempFiles;
            node8.Checked = Properties.Settings.Default.MemoryDumps;
            node9.Checked = Properties.Settings.Default.WindowsLogs;
            node10.Checked = Properties.Settings.Default.EventTraceLogs;
            node11.Checked = Properties.Settings.Default.ErrorReporting;
            node12.Checked = Properties.Settings.Default.DriverInstallation;
            node13.Checked = Properties.Settings.Default.DeliveryOpti;
            node14.Checked = Properties.Settings.Default.NetworkData;

            node17.Checked = Properties.Settings.Default.Prefetch;
            node18.Checked = Properties.Settings.Default.StoreInstallServiceCache;
            node19.Checked = Properties.Settings.Default.QtFramework;
            node20.Checked = Properties.Settings.Default.PowerEfficencyDiagnostics;
            node21.Checked = Properties.Settings.Default.Notfications;
            node22.Checked = Properties.Settings.Default.MsSearch;
            node23.Checked = Properties.Settings.Default.JumpList;
            node24.Checked = Properties.Settings.Default.FontCache;

            node26.Checked = Properties.Settings.Default.WinDefender;
            node27.Checked = Properties.Settings.Default.OriginInstaller;
            node28.Checked = Properties.Settings.Default.VisualStudio;
            node29.Checked = Properties.Settings.Default.OneDrive;
            node30.Checked = Properties.Settings.Default.EasyAntiCheat;
            node31.Checked = Properties.Settings.Default.Battlenet;
            node32.Checked = Properties.Settings.Default.Ccleaner;
            node33.Checked = Properties.Settings.Default.Steam;

            node35.Checked = Properties.Settings.Default.DirectX;
            node36.Checked = Properties.Settings.Default.WinUpdateFiles;
            node37.Checked = Properties.Settings.Default.WinFontCache;
            node38.Checked = Properties.Settings.Default.WinDebug;
            node39.Checked = Properties.Settings.Default.WinCache;
            node40.Checked = Properties.Settings.Default.WinInstaller;
            node41.Checked = Properties.Settings.Default.WinExpIndex;
            node42.Checked = Properties.Settings.Default.WinAutoVideo;

            node66.Checked = Properties.Settings.Default.InternetExplorer;
        }

        private void Save_Settings()
        {
            Properties.Settings.Default.FirefoxCache = node59.Checked;
            Properties.Settings.Default.FirefoxHistory = node60.Checked;
            Properties.Settings.Default.FirefoxCookies = node61.Checked;
            Properties.Settings.Default.FirefoxSession = node62.Checked;
            Properties.Settings.Default.FirefoxSite = node63.Checked;
            Properties.Settings.Default.FirefoxForm = node64.Checked;
            Properties.Settings.Default.FirefoxPasswords = node65.Checked;

            Properties.Settings.Default.ChromeCache = node51.Checked;
            Properties.Settings.Default.ChromeHistroy = node52.Checked;
            Properties.Settings.Default.ChromeCookies = node53.Checked;
            Properties.Settings.Default.ChromeDownloadHistory = node54.Checked;
            Properties.Settings.Default.ChromeMetrics = node55.Checked;
            Properties.Settings.Default.ChromeSession = node56.Checked;
            Properties.Settings.Default.ChromePasswords = node57.Checked;

            Properties.Settings.Default.EdgeCache = node44.Checked;
            Properties.Settings.Default.EdgeCookies = node45.Checked;
            Properties.Settings.Default.EdgeHistory = node46.Checked;
            Properties.Settings.Default.EdgeSession = node47.Checked;
            Properties.Settings.Default.EdgePasswords = node48.Checked;
            Properties.Settings.Default.EdgeMetrics = node49.Checked;

            Properties.Settings.Default.RecentDocuments = node2.Checked;
            Properties.Settings.Default.ThumbnailCache = node3.Checked;
            Properties.Settings.Default.MiniDumps = node4.Checked;
            Properties.Settings.Default.TemporaryFiles = node15.Checked;

            Properties.Settings.Default.RecycleBin = node6.Checked;
            Properties.Settings.Default.TempFiles = node7.Checked;
            Properties.Settings.Default.MemoryDumps = node8.Checked;
            Properties.Settings.Default.WindowsLogs = node9.Checked;
            Properties.Settings.Default.EventTraceLogs = node10.Checked;
            Properties.Settings.Default.ErrorReporting = node11.Checked;
            Properties.Settings.Default.DriverInstallation = node12.Checked;
            Properties.Settings.Default.DeliveryOpti = node13.Checked;
            Properties.Settings.Default.NetworkData = node14.Checked;

            Properties.Settings.Default.Prefetch = node17.Checked;
            Properties.Settings.Default.StoreInstallServiceCache = node18.Checked;
            Properties.Settings.Default.QtFramework = node19.Checked;
            Properties.Settings.Default.PowerEfficencyDiagnostics = node20.Checked;
            Properties.Settings.Default.Notfications = node21.Checked;
            Properties.Settings.Default.MsSearch = node22.Checked;
            Properties.Settings.Default.JumpList = node23.Checked;
            Properties.Settings.Default.FontCache = node24.Checked;

            Properties.Settings.Default.WinDefender = node26.Checked;
            Properties.Settings.Default.OriginInstaller = node27.Checked;
            Properties.Settings.Default.VisualStudio = node28.Checked;
            Properties.Settings.Default.OneDrive = node29.Checked;
            Properties.Settings.Default.EasyAntiCheat = node30.Checked;
            Properties.Settings.Default.Battlenet = node31.Checked;
            Properties.Settings.Default.Ccleaner = node32.Checked;
            Properties.Settings.Default.Steam = node33.Checked;

            Properties.Settings.Default.DirectX = node35.Checked;
            Properties.Settings.Default.WinUpdateFiles = node36.Checked;
            Properties.Settings.Default.WinFontCache = node37.Checked;
            Properties.Settings.Default.WinDebug = node38.Checked;
            Properties.Settings.Default.WinCache = node39.Checked;
            Properties.Settings.Default.WinInstaller = node40.Checked;
            Properties.Settings.Default.WinExpIndex = node41.Checked;
            Properties.Settings.Default.WinAutoVideo = node42.Checked;

            Properties.Settings.Default.InternetExplorer = node66.Checked;

            Properties.Settings.Default.Save();
        }
        #endregion

        #region Listview
        private void List_DoubleClick(object sender, EventArgs e)
        {
            if (List.SelectedIndices.Count <= 0)
            {
                return;
            }

            int intselectedindex = List.SelectedIndices[0];

            if (intselectedindex >= 0)
            {
                String text = List.Items[intselectedindex].Text;

                #region Windows Explorer
                if (text == " Windows Explorer - Recent Documents")
                {
                    File_Explorer.Viewing = "Recent Documents";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Windows Explorer - Thumnail Cache")
                {
                    File_Explorer.Viewing = "Thumnail Cache";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Windows Explorer - Mini Dumps")
                {
                    File_Explorer.Viewing = "Mini Dumps";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Windows Explorer - Temporary Files")
                {
                    File_Explorer.Viewing = "WTemporary Files";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                #endregion
                #region System
                else if (text == " System - Recycle Bin")
                {
                    File_Explorer.Viewing = "Recycle Bin";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " System - Temporary Files")
                {
                    File_Explorer.Viewing = "Temporary Files";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " System - Memory Dumps")
                {
                    File_Explorer.Viewing = "Memory Dumps";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " System - Windows Log Files")
                {
                    File_Explorer.Viewing = "Windows Log Files";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " System - Event Trace Logs")
                {
                    File_Explorer.Viewing = "Event Trace Logs";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " System - Error Reporting")
                {
                    File_Explorer.Viewing = "Error Reporting";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " System - Driver Installation Log Files")
                {
                    File_Explorer.Viewing = "Driver Installation Log Files";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " System - Windows Delivery Optimization Files")
                {
                    File_Explorer.Viewing = "Windows Delivery Optimization Files";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " System - Network Data Usage")
                {
                    File_Explorer.Viewing = "Network Data Usage";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                #endregion
                #region Advanced
                else if (text == " Advanced - Prefetch Data")
                {
                    File_Explorer.Viewing = "Prefetch Data";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Advanced - Store Install Service Cache")
                {
                    File_Explorer.Viewing = "Store Install Service Cache";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Advanced - QT Framework")
                {
                    File_Explorer.Viewing = "QT Framework";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Advanced - Power Efficiency Diagnostics")
                {
                    File_Explorer.Viewing = "Power Efficiency Diagnostics";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Advanced - Notifications")
                {
                    File_Explorer.Viewing = "Notifications";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Advanced - MS Search")
                {
                    File_Explorer.Viewing = "MS Search";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Advanced - Jump List")
                {
                    File_Explorer.Viewing = "Jump List";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Advanced - Font Cache")
                {
                    File_Explorer.Viewing = "Font Cache";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                #endregion
                #region Applications
                else if (text == " Applications - Windows Defender")
                {
                    File_Explorer.Viewing = "Windows Defender";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Applications - Origin Installers")
                {
                    File_Explorer.Viewing = "Origin Installers";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Applications - Visual Studio Installation")
                {
                    File_Explorer.Viewing = "Visual Studio Installation";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Applications - One Drive")
                {
                    File_Explorer.Viewing = "One Drive";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Applications - Easy Anti-Cheat")
                {
                    File_Explorer.Viewing = "Easy Anti-Cheat";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Applications - Battlenet")
                {
                    File_Explorer.Viewing = "Battlenet";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Applications - Ccleaner")
                {
                    File_Explorer.Viewing = "Ccleaner";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Applications - Steam")
                {
                    File_Explorer.Viewing = "Steam";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                #endregion
                #region Windows
                else if (text == " Windows - DirectX Shader Cache")
                {
                    File_Explorer.Viewing = "DirectX Shader Cache";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Windows - Update Files")
                {
                    File_Explorer.Viewing = "Update Files";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Windows - Font Cache")
                {
                    File_Explorer.Viewing = "Font Cache";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Windows - Debug Files")
                {
                    File_Explorer.Viewing = "Debug Files";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Windows - Cache Files")
                {
                    File_Explorer.Viewing = "Cache Files";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Windows - Installers")
                {
                    File_Explorer.Viewing = "Installers";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Windows - Experience Index")
                {
                    File_Explorer.Viewing = "Experience Index";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Windows - Auto/Video Quality Experience")
                {
                    File_Explorer.Viewing = "Auto/Video Quality Experience";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Windows - Internet Explorer Cache")
                {
                    File_Explorer.Viewing = "Internet Explorer";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                #endregion
                #region Edge Chromium
                else if (text == " Edge Chromium - Cache")
                {
                    File_Explorer.Viewing = "Edge Cache";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Edge Chromium - Cookies")
                {
                    File_Explorer.Viewing = "Edge Cookies";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Edge Chromium - History")
                {
                    File_Explorer.Viewing = "Edge History";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Edge Chromium - Session Data")
                {
                    File_Explorer.Viewing = "Edge Session";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Edge Chromium - Passwords")
                {
                    File_Explorer.Viewing = "Edge Passwords";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Edge Chromium - Metrics Temp Files")
                {
                    File_Explorer.Viewing = "Edge Metrics";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                #endregion
                #region Google Chrome
                else if (text == " Google Chrome - Cache")
                {
                    File_Explorer.Viewing = "Chrome Cache";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Google Chrome - History")
                {
                    File_Explorer.Viewing = "Chrome History";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Google Chrome - Cookies")
                {
                    File_Explorer.Viewing = "Chrome Cookies";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Google Chrome - Download History")
                {
                    File_Explorer.Viewing = "Chrome Download History";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Google Chrome - Metrics Temp Files")
                {
                    File_Explorer.Viewing = "Chrome Metrics";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Google Chrome - Session Data")
                {
                    File_Explorer.Viewing = "Chrome Session";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Google Chrome - Passwords")
                {
                    File_Explorer.Viewing = "Chrome Passwords";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                #endregion
                #region Firefox
                else if (text == " Mozilla Firefox - Cache")
                {
                    File_Explorer.Viewing = "Firefox Cache";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Mozilla Firefox - History")
                {
                    File_Explorer.Viewing = "Firefox History";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Mozilla Firefox - Cookies")
                {
                    File_Explorer.Viewing = "Firefox Cookies";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Mozilla Firefox - Session Data")
                {
                    File_Explorer.Viewing = "Firefox Session";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Mozilla Firefox - Site Preferences")
                {
                    File_Explorer.Viewing = "Firefox Preferences";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Mozilla Firefox - Saved Form Information")
                {
                    File_Explorer.Viewing = "Firefox Form";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                else if (text == " Mozilla Firefox - Saved Passwords")
                {
                    File_Explorer.Viewing = "Firefox Passwords";

                    File_Explorer file_ = new File_Explorer();
                    file_.Show();
                }
                #endregion
            }
        }
        #endregion

        #region Loading Animation
        private void isRunning(bool Status, string Text)
        {
            if (Status)
            {
                Lbl2.Text = Text;
                Running.IsRunning = true;
                Running.Visible = true;
            }
            else if (!Status)
            {
                Lbl2.Text = Text;
                Running.IsRunning = false;
                Running.Visible = false;
            }
        }
        #endregion

        #region Subs
        public static long total;
        public static int step;
        public static int remove;
        #endregion

        #region Form Buttons
        private void Analyze_Click(object sender, EventArgs e)
        {
            List.Items.Clear();
            List.SmallImageList = this.images;

            total = 0;

            isRunning(true, "Analying Files Please Wait...");

            Scanner.Enabled = true;
            step = 1;
        }

        private void Cleaner_Click(object sender, EventArgs e)
        {
            Remover.Delete.Total_Deleted = 0;

            isRunning(true, "Cleaning Files Please Wait...");
            
            File.WriteAllText(Utils.path + "delete_logs.txt", "");

            Deleter.Enabled = true;
            remove = 1;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.ShowDialog();
        }
        #endregion

        #region Contex Menu
        private void Tray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
            ShowInTaskbar = true;
            Opacity = 100;
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
            Opacity = 0;
        }

        private void analyzeFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = true;
            ShowInTaskbar = true;
            Opacity = 100;

            Analyze.PerformClick();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebClient web = new WebClient();

            string x = web.DownloadString("https://raw.githubusercontent.com/alonelydev7932/Axolotl-PC-Cleaner/master/Latest%20Version");

            if (x.Contains("1"))
            {
                MessageBox.Show("You are using the latest version!", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The version you are using is outdated, please update!", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Process.Start("https://github.com/alonelydev7932/Axolotl-PC-Cleaner/releases");
                Application.Exit();
            }
        }

        private void aboutAxolotlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A advanced pc cleaner created in .Net" + "\nI decided to create this application due to the lack of examples found in C# on github...\nFor more information contact me on Discord!", ProductName, MessageBoxButtons.OK);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Scanner & Deleter
        private void Scanner_Tick(object sender, EventArgs e)
        {
            #region Edge Chromium
            if (step == 1)
            {
                if (node44.Checked == true)
                {
                    Lbl2.Text = "Scanning Edge Chromium Internet Cache...";

                    long lon1; long lon2; long lon3; long lon4; long lon5; long lon6; long lon7;
                    long lon8; long lon9; long lon10; long lon11; long lon12; long lon13; long lon14;
                    long lon15; long lon16; long lon17; long lon18; long lon19; long lon20; long lon21;

                    lon1 = CheckSize(Locations.Edge_Cache, Temp.EdgeCache, false);
                    lon2 = CheckSize(Locations.Edge_Cache2, Temp.EdgeCache, false);
                    lon3 = CheckSize(Locations.Edge_Cache3, Temp.EdgeCache, false);
                    lon4 = CheckSize(Locations.Edge_Cache4, Temp.EdgeCache, false);
                    lon5 = CheckSize(Locations.Edge_Cache5, Temp.EdgeCache, true);
                    lon6 = CheckSize(Locations.Edge_Cache6, Temp.EdgeCache, false);
                    lon7 = CheckSize(Locations.Edge_Cache7, Temp.EdgeCache, false);
                    lon8 = CheckSize(Locations.Edge_Cache8, Temp.EdgeCache, false);
                    lon9 = CheckSize(Locations.Edge_Cache9, Temp.EdgeCache, false);
                    lon10 = CheckSize(Locations.Edge_Cache10, Temp.EdgeCache, false);

                    lon11 = CheckSingle(Locations.Edge_Cache11, Temp.EdgeCache);
                    lon12 = CheckSingle(Locations.Edge_Cache12, Temp.EdgeCache);
                    lon13 = CheckSingle(Locations.Edge_Cache13, Temp.EdgeCache);
                    lon14 = CheckSingle(Locations.Edge_Cache14, Temp.EdgeCache);
                    lon15 = CheckSingle(Locations.Edge_Cache15, Temp.EdgeCache);
                    lon16 = CheckSingle(Locations.Edge_Cache16, Temp.EdgeCache);
                    lon17 = CheckSingle(Locations.Edge_Cache17, Temp.EdgeCache);
                    lon18 = CheckSingle(Locations.Edge_Cache18, Temp.EdgeCache);
                    lon19 = CheckSingle(Locations.Edge_Cache19, Temp.EdgeCache);
                    lon20 = CheckSingle(Locations.Edge_Cache20, Temp.EdgeCache);
                    lon21 = CheckSingle(Locations.Edge_Cache21, Temp.EdgeCache);


                    string result = ConvertToString(lon1 + lon2 + lon3 + lon4 + lon5 + lon6 + lon7 + lon8 + lon9 + lon10 + lon11 + lon12 + lon13 + lon14 + lon15 + lon16 + lon17 + lon18 + lon19 + lon20 + lon21);

                    if (result != "0B")
                    {
                        string[] row = { " Edge Chromium - Cache", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 1;
                        List.Items.Add(listViewItem);

                        total = total = lon1 + lon2 + lon3 + lon4 + lon5 + lon6 + lon7 + lon8 + lon9 + lon10 + lon11 + lon12 + lon13 + lon14 + lon15 + lon16 + lon17 + lon18 + lon19 + lon20 + lon21;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Edge Chromium Internet Cache...";
                }

                step++;
            }

            if (step == 2)
            {
                if (node45.Checked == true)
                {
                    Lbl2.Text = "Scanning Edge Chromium Internet Cookies...";

                    long lon1; long lon2;

                    lon1 = CheckSize(Locations.Edge_Cookies, Temp.EdgeCookies, true);
                    lon2 = CheckSingle(Locations.Edge_Cookies1, Temp.EdgeCookies);

                    string result = ConvertToString(lon1 + lon2);

                    if (result != "0B")
                    {
                        string[] row = { " Edge Chromium - Cookies", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 1;
                        List.Items.Add(listViewItem);

                        total = total = lon1 + lon2;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Edge Chromium Internet Cookies...";
                }

                step++;
            }

            if (step == 3)
            {
                if (node46.Checked == true)
                {
                    Lbl2.Text = "Scanning Edge Chromium Internet History...";

                    long lon1; long lon2; long lon3; long lon4; long lon5; long lon6; long lon7;
                    long lon8; long lon9; long lon10; long lon11; long lon12; long lon13; long lon14;

                    lon1 = CheckSingle(Locations.Edge_History, Temp.EdgeHistory);
                    lon2 = CheckSingle(Locations.Edge_History2, Temp.EdgeHistory);
                    lon3 = CheckSingle(Locations.Edge_History3, Temp.EdgeHistory);
                    lon4 = CheckSingle(Locations.Edge_History4, Temp.EdgeHistory);
                    lon5 = CheckSingle(Locations.Edge_History5, Temp.EdgeHistory);
                    lon6 = CheckSingle(Locations.Edge_History6, Temp.EdgeHistory);
                    lon7 = CheckSingle(Locations.Edge_History7, Temp.EdgeHistory);
                    lon8 = CheckSingle(Locations.Edge_History8, Temp.EdgeHistory);
                    lon9 = CheckSingle(Locations.Edge_History9, Temp.EdgeHistory);
                    lon10 = CheckSingle(Locations.Edge_History10, Temp.EdgeHistory);
                    lon11 = CheckSingle(Locations.Edge_History11, Temp.EdgeHistory);
                    lon12 = CheckSingle(Locations.Edge_History12, Temp.EdgeHistory);
                    lon13 = CheckSingle(Locations.Edge_History13, Temp.EdgeHistory);
                    lon14 = CheckSingle(Locations.Edge_History14, Temp.EdgeHistory);

                    string result = ConvertToString(lon1 + lon2 + lon3 + lon4 + lon5 + lon6 + lon7 + lon8 + lon9 + lon10 + lon11 + lon12 + lon13 + lon14);

                    if (result != "0B")
                    {
                        string[] row = { " Edge Chromium - History", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 1;
                        List.Items.Add(listViewItem);

                        total = total = lon1 + lon2 + lon3 + lon4 + lon5 + lon6 + lon7 + lon8 + lon9 + lon10 + lon11 + lon12 + lon13 + lon14;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Edge Chromium Internet History...";
                }

                step++;
            }

            if (step == 4)
            {
                if (node47.Checked == true)
                {
                    Lbl2.Text = "Scanning Edge Chromium Session Data...";

                    long lon1; long lon2; long lon3;

                    lon1 = CheckSize(Locations.Edge_Session, Temp.EdgeSession, false);
                    lon2 = CheckSize(Locations.Edge_Session2, Temp.EdgeSession, false);
                    lon3 = CheckSize(Locations.Edge_Session3, Temp.EdgeSession, false);

                    string result = ConvertToString(lon1 + lon2 + lon3);

                    if (result != "0B")
                    {
                        string[] row = { " Edge Chromium - Session Data", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 1;
                        List.Items.Add(listViewItem);

                        total = total = lon1 + lon2 + lon3;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Edge Chromium Session Data...";
                }

                step++;
            }

            if (step == 5)
            {
                if (node48.Checked == true)
                {
                    Lbl2.Text = "Scanning Edge Chromium Saved Passwords...";

                    string result = ConvertToString(CheckSingle(Locations.Edge_Passwords, Temp.EdgePasswords));

                    if (result != "0B")
                    {
                        string[] row = { " Edge Chromium - Passwords", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 1;
                        List.Items.Add(listViewItem);

                        total = total + CheckSingle(Locations.Edge_Passwords, Temp.EdgePasswords);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Edge Chromium Saved Passwords...";
                }

                step++;
            }

            if (step == 6)
            {
                if (node49.Checked == true)
                {
                    Lbl2.Text = "Scanning Edge Chromium Metrics Temp Files...";
                    long lon1; long lon2;

                    lon1 = PmaFiles(Locations.Edge_Metrics, Temp.EdgeMetrics);
                    lon2 = PmaFiles(Locations.Edge_Metrics2, Temp.EdgeMetrics);

                    string result = ConvertToString(lon1 + lon2);

                    if (result != "0B")
                    {
                        string[] row = { " Edge Chromium - Metrics Temp Files", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 1;
                        List.Items.Add(listViewItem);

                        total = total = lon1 + lon2;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Edge Chromium Metrics Temp Files...";
                }

                step++;
            }
            #endregion

            #region Google Chrome

            if (step == 7)
            {
                if (node51.Checked == true)
                {
                    Lbl2.Text = "Scanning Google Chrome Internet Cache...";

                    long lon1; long lon2; long lon3; long lon4; long lon5; long lon6; long lon7;
                    long lon8; long lon9; long lon10; long lon11; long lon12; long lon13; long lon14;
                    long lon15; long lon16; long lon17; long lon18; long lon19; long lon20; long lon21;
                    long lon22;

                    lon1 = CheckSize(Locations.Chrome_Cache, Temp.ChromeCache, false);
                    lon2 = CheckSize(Locations.Chrome_Cache2, Temp.ChromeCache, false);
                    lon3 = CheckSize(Locations.Chrome_Cache3, Temp.ChromeCache, false);
                    lon4 = CheckSize(Locations.Chrome_Cache4, Temp.ChromeCache, false);
                    lon5 = CheckSize(Locations.Chrome_Cache5, Temp.ChromeCache, true);
                    lon6 = CheckSize(Locations.Chrome_Cache6, Temp.ChromeCache, false);
                    lon7 = CheckSize(Locations.Chrome_Cache7, Temp.ChromeCache, false);
                    lon8 = CheckSize(Locations.Chrome_Cache8, Temp.ChromeCache, true);
                    lon9 = CheckSize(Locations.Chrome_Cache9, Temp.ChromeCache, false);
                    lon10 = CheckSize(Locations.Chrome_Cache10, Temp.ChromeCache, false);
                    lon11 = CheckSize(Locations.Chrome_Cache11, Temp.ChromeCache, false);
                    lon12 = CheckSize(Locations.Chrome_Cache12, Temp.ChromeCache, false);

                    lon13 = CheckSingle(Locations.Chrome_Cache13, Temp.EdgeCache);
                    lon14 = CheckSingle(Locations.Chrome_Cache14, Temp.EdgeCache);
                    lon15 = CheckSingle(Locations.Chrome_Cache15, Temp.EdgeCache);
                    lon16 = CheckSingle(Locations.Chrome_Cache16, Temp.EdgeCache);
                    lon17 = CheckSingle(Locations.Chrome_Cache17, Temp.EdgeCache);
                    lon18 = CheckSingle(Locations.Chrome_Cache18, Temp.EdgeCache);
                    lon19 = CheckSingle(Locations.Chrome_Cache19, Temp.EdgeCache);
                    lon20 = CheckSingle(Locations.Chrome_Cache20, Temp.EdgeCache);
                    lon21 = CheckSingle(Locations.Chrome_Cache21, Temp.EdgeCache);
                    lon22 = CheckSingle(Locations.Chrome_Cache22, Temp.EdgeCache);

                    string result = ConvertToString(lon1 + lon2 + lon3 + lon4 + lon5 + lon6 + lon7 + lon8 + lon9 + lon10 + lon11 + lon12 + lon13 + lon14 + lon15 + lon16 + lon17 + lon18 + lon19 + lon20 + lon21 + lon22);

                    if (result != "0B")
                    {
                        string[] row = { " Google Chrome - Cache", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 3;
                        List.Items.Add(listViewItem);

                        total = total = lon1 + lon2 + lon3 + lon4 + lon5 + lon6 + lon7 + lon8 + lon9 + lon10 + lon11 + lon12 + lon13 + lon14 + lon15 + lon16 + lon17 + lon18 + lon19 + lon20 + lon21 + lon22;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Edge Chromium Internet Cache...";
                }

                step++;
            }

            if (step == 8)
            {
                if (node52.Checked == true)
                {
                    Lbl2.Text = "Scanning Google Chrome Internet History...";

                    long lon1; long lon2; long lon3; long lon4; long lon5; long lon6; long lon7;
                    long lon8; long lon9;

                    lon1 = CheckSingle(Locations.Chrome_History, Temp.ChromeHistory);
                    lon2 = CheckSingle(Locations.Chrome_History2, Temp.ChromeHistory);
                    lon3 = CheckSingle(Locations.Chrome_History3, Temp.ChromeHistory);
                    lon4 = CheckSingle(Locations.Chrome_History4, Temp.ChromeHistory);
                    lon5 = CheckSingle(Locations.Chrome_History5, Temp.ChromeHistory);
                    lon6 = CheckSingle(Locations.Chrome_History6, Temp.ChromeHistory);
                    lon7 = CheckSingle(Locations.Chrome_History7, Temp.ChromeHistory);
                    lon8 = CheckSingle(Locations.Chrome_History8, Temp.ChromeHistory);
                    lon9 = CheckSize(Locations.Chrome_History9, Temp.ChromeHistory, false);

                    string result = ConvertToString(lon1 + lon2 + lon3 + lon4 + lon5 + lon6 + lon7 + lon8 + lon9);

                    if (result != "0B")
                    {
                        string[] row = { " Google Chrome - History", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 3;
                        List.Items.Add(listViewItem);

                        total = total = lon1 + lon2 + lon3 + lon4 + lon5 + lon6 + lon7 + lon8 + lon9;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Google Chrome Internet History...";
                }

                step++;
            }

            if (step == 9)
            {
                if (node53.Checked == true)
                {
                    Lbl2.Text = "Scanning Google Chrome Internet Cookies...";

                    long lon1; long lon2;

                    lon1 = CheckSize(Locations.Chrome_Cookies, Temp.ChromeCookies, false);
                    lon2 = CheckSingle(Locations.Chrome_Cookies2, Temp.ChromeHistory);

                    string result = ConvertToString(lon1 + lon2);

                    if (result != "0B")
                    {
                        string[] row = { " Google Chrome - Cookies", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 3;
                        List.Items.Add(listViewItem);

                        total = total = lon1 + lon2;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Google Chrome Internet Cookies...";
                }

                step++;
            }

            if (step == 10)
            {
                if (node54.Checked == true)
                {
                    Lbl2.Text = "Scanning Google Chrome Download History...";

                    string result = ConvertToString(CheckSingle(Locations.Chrome_Download, Temp.ChromeDownloadData));

                    if (result != "0B")
                    {
                        string[] row = { " Google Chrome - Download History", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 3;
                        List.Items.Add(listViewItem);

                        total = total + CheckSingle(Locations.Chrome_Download, Temp.ChromeDownloadData);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Google Chrome Download History...";
                }

                step++;
            }

            if (step == 11)
            {
                if (node55.Checked == true)
                {
                    Lbl2.Text = "Scanning Google Chrome Metrics Temp Files...";

                    string result = ConvertToString(PmaFiles(Locations.Chrome_Metrics, Temp.ChromeHistory));

                    if (result != "0B")
                    {
                        string[] row = { " Google Chrome - Metrics Temp Files", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 3;
                        List.Items.Add(listViewItem);

                        total = total + CheckSingle(Locations.Chrome_Metrics, Temp.ChromeHistory);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Google Chrome Metrics Temp Files...";
                }

                step++;
            }

            if (step == 12)
            {
                if (node56.Checked == true)
                {
                    Lbl2.Text = "Scanning Google Chrome Session Data...";

                    long lon1; long lon2; long lon3;

                    lon1 = CheckSize(Locations.Chrome_Session, Temp.ChromeSession, false);
                    lon2 = CheckSize(Locations.Chrome_Session2, Temp.ChromeSession, false);
                    lon3 = CheckSize(Locations.Chrome_Session3, Temp.ChromeSession, false);

                    string result = ConvertToString(lon1 + lon2);

                    if (result != "0B")
                    {
                        string[] row = { " Google Chrome - Session Data", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 3;
                        List.Items.Add(listViewItem);

                        total = total = lon1 + lon2 + lon3;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Google Chrome Session Data...";
                }

                step++;
            }

            if (step == 13)
            {
                if (node57.Checked == true)
                {
                    Lbl2.Text = "Scanning Google Chrome Saved Passwords...";

                    string result = ConvertToString(CheckSingle(Locations.Chrome_Passwords, Temp.ChromePasswords));

                    if (result != "0B")
                    {
                        string[] row = { " Google Chrome - Passwords", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 3;
                        List.Items.Add(listViewItem);

                        total = total + CheckSingle(Locations.Chrome_Passwords, Temp.ChromePasswords);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Google Chrome Saved Passwords...";
                }

                step++;
            }
            #endregion

            #region Firefox
            if (step == 14)
            {
                if (node59.Checked == true)
                {
                    Lbl2.Text = "Scanning Mozilla Firefox Internet Cache...";

                    long lon1; long lon2; long lon3; long lon4; long lon5;

                    lon1 = CheckSize(Locations.Firefox_Cache, Temp.FirefoxCache, false);
                    lon2 = CheckSize(Locations.Firefox_Cache2, Temp.FirefoxCache, false);
                    lon3 = CheckSize(Locations.Firefox_Cache3, Temp.FirefoxCache, false);
                    lon4 = CheckSize(Locations.Firefox_Cache4, Temp.FirefoxCache, false);
                    lon5 = CheckSize(Locations.Firefox_Cache5, Temp.FirefoxCache, false);

                    string result = ConvertToString(lon1 + lon2 + lon3 + lon4 + lon5);

                    if (result != "0B")
                    {
                        string[] row = { " Mozilla Firefox - Cache", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 2;
                        List.Items.Add(listViewItem);

                        total = total = lon1 + lon2 + lon3 + lon4 + lon5;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Mozilla Firefox Internet Cache...";
                }

                step++;
            }

            if (step == 15)
            {
                if (node60.Checked == true)
                {
                    Lbl2.Text = "Scanning Mozilla Firefox Internet History...";

                    string result = ConvertToString(CheckSize(Locations.Firefox_History, Temp.FirefoxHistory, false));

                    if (result != "0B")
                    {
                        string[] row = { " Mozilla Firefox - History", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 2;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Firefox_History, Temp.FirefoxHistory, false);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Mozilla Firefox Internet History...";
                }

                step++;
            }

            if (step == 16)
            {
                if (node61.Checked == true)
                {
                    Lbl2.Text = "Scanning Mozilla Firefox Internet Cookies...";

                    string result = ConvertToString(CheckSize(Locations.Firefox_Cookies, Temp.FirefoxCookies, true));

                    if (result != "0B")
                    {
                        string[] row = { " Mozilla Firefox - Cookies", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 2;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Firefox_Cookies, Temp.FirefoxCookies, true);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Mozilla Firefox Internet Cookies...";
                }

                step++;
            }

            if (step == 17)
            {
                if (node62.Checked == true)
                {
                    Lbl2.Text = "Scanning Mozilla Firefox Session Data...";

                    long lon1; long lon2;

                    lon1 = CheckSize(Locations.Firefox_Session, Temp.FirefoxSession, false);
                    lon2 = CheckSingle(Locations.Firefox_Session, Temp.FirefoxSession);

                    string result = ConvertToString(lon1 + lon2);

                    if (result != "0B")
                    {
                        string[] row = { " Mozilla Firefox - Session Data", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 2;
                        List.Items.Add(listViewItem);

                        total = total = lon1 + lon2;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Mozilla Firefox Session Data...";
                }

                step++;
            }

            if (step == 18)
            {
                if (node63.Checked == true)
                {
                    Lbl2.Text = "Scanning Mozilla Firefox Site Preferences...";

                    string result = ConvertToString(CheckSingle(Locations.Firefox_Site_Pref, Temp.FirefoxSite));

                    if (result != "0B")
                    {
                        string[] row = { " Mozilla Firefox - Site Preferences", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 2;
                        List.Items.Add(listViewItem);

                        total = total + CheckSingle(Locations.Firefox_Site_Pref, Temp.FirefoxSite);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Mozilla Firefox Site Preferences...";
                }

                step++;
            }

            if (step == 19)
            {
                if (node64.Checked == true)
                {
                    Lbl2.Text = "Scanning Mozilla Firefox Saved Form Information...";

                    string result = ConvertToString(CheckSingle(Locations.Firefox_Saved_Form, Temp.FirefoxForm));

                    if (result != "0B")
                    {
                        string[] row = { " Mozilla Firefox - Saved Form Information", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 2;
                        List.Items.Add(listViewItem);

                        total = total + CheckSingle(Locations.Firefox_Saved_Form, Temp.FirefoxForm);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Mozilla Firefox Saved Form Information...";
                }

                step++;
            }

            if (step == 20)
            {
                if (node65.Checked == true)
                {
                    Lbl2.Text = "Scanning Mozilla Firefox Saved Passowrds...";

                    long lon1; long lon2;

                    lon1 = CheckSingle(Locations.Firefox_Login, Temp.FirefoxPasswords);
                    lon2 = CheckSingle(Locations.Firefox_Login2, Temp.FirefoxPasswords);

                    string result = ConvertToString(lon1 + lon2);

                    if (result != "0B")
                    {
                        string[] row = { " Mozilla Firefox - Saved Passwords", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 2;
                        List.Items.Add(listViewItem);

                        total = total = lon1 + lon2;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Mozilla Firefox Saved Passowrds...";
                }

                step++;
            }
            #endregion

            #region Windows Explorer
            if (step == 21)
            {
                if (node2.Checked == true)
                {
                    Lbl2.Text = "Scanning Windows Temporary Files...";

                    string result = ConvertToString(CheckSize(Locations.Recent_Documents, Temp.Recent_Documents, false));

                    if (result != "0B")
                    {
                        string[] row = { " Windows Explorer - Recent Documents", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 6;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Recent_Documents, Temp.Recent_Documents, false);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Recent Documents...";
                }

                step++;
            }

            if (step == 22)
            {
                if (node3.Checked == true)
                {
                    Lbl2.Text = "Scanning Windows Temporary Files...";

                    string result = ConvertToString(CheckSize(Locations.Thumnail_Cache, Temp.Thumnail_Cache, false));

                    if (result != "0B")
                    {
                        string[] row = { " Windows Explorer - Thumnail Cache", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 6;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Thumnail_Cache, Temp.Thumnail_Cache, false);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Thumbnail Cache...";
                }

                step++;
            }

            if (step == 23)
            {
                if (node4.Checked == true)
                {
                    Lbl2.Text = "Scanning Windows Temporary Files...";

                    string result = ConvertToString(CheckSize(Locations.Mini_Dumps, Temp.Mini_Dumps, false));

                    if (result != "0B")
                    {
                        string[] row = { " Windows Explorer - Mini Dumps", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 6;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Mini_Dumps, Temp.Mini_Dumps, false);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Mini Dumps...";
                }

                step++;
            }

            if (step == 24)
            {
                if (node15.Checked == true)
                {
                    Lbl2.Text = "Scanning Windows Temporary Files...";

                    string result = ConvertToString(CheckSize(Locations.Win_Temp_Files, Temp.WinTempFiles, true));

                    if (result != "0B")
                    {
                        string[] row = { " Windows Explorer - Temporary Files", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 6;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Win_Temp_Files, Temp.WinTempFiles, true);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Windows Temporary Files...";
                }

                step++;
            }
            #endregion

            #region System
            if (step == 25)
            {
                if (node6.Checked == true)
                {
                    Lbl2.Text = "Scanning Recycle Bin...";

                    string result = ConvertToString(CheckSize(Locations.Recyle_Bin, Temp.Recylce_Bin, true));

                    if (result != "0B")
                    {
                        string[] row = { " System - Recycle Bin", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 5;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Recyle_Bin, Temp.Recylce_Bin, true);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Recycle Bin...";
                }

                step++;
            }

            if (step == 26)
            {
                if (node7.Checked == true)
                {
                    Lbl2.Text = "Scanning System Temporary Files...";

                    string result = ConvertToString(CheckSize(Locations.Temp_Files, Temp.TempFiles, true));

                    if (result != "0B")
                    {
                        string[] row = { " System - Temporary Files", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 5;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Temp_Files, Temp.TempFiles, true);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping System Temporary Files...";
                }

                step++;
            }

            if (step == 27)
            {
                if (node8.Checked == true)
                {
                    Lbl2.Text = "Scanning Memory Dumps...";

                    string result = ConvertToString(CheckSize(Locations.Memory_Dumps, Temp.MemoryDumps, false));

                    if (result != "0B")
                    {
                        string[] row = { " System - Memory Dumps", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 5;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Memory_Dumps, Temp.MemoryDumps, false);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Memory Dumps...";
                }

                step++;
            }

            if (step == 28)
            {
                if (node9.Checked == true)
                {
                    Lbl2.Text = "Scanning Windows Log Files...";

                    long lon; long lon1; long lon2; long lon3; long lon4; long lon5; long lon6; long lon7; long lon8; long lon9; long lon10; long lon11; long lon12; long lon13; long lon14;
                    long lon15; long lon16; long lon17; long lon18; long lon19; long lon20; long lon21; long lon22; long lon23; long lon24; long lon25; long lon26; long lon27; long lon28;
                    long lon29; long lon30; long lon31; long lon32; long lon33; long lon34; long lon35; long lon36; long lon37; long lon38; long lon39; long lon40;

                    lon = LogFiles(Locations.WinLogs, Temp.WindowsLogs);
                    lon1 = LogFiles(Locations.WinLogs1, Temp.WindowsLogs);
                    lon2 = LogFiles(Locations.WinLogs2, Temp.WindowsLogs);
                    lon3 = LogFiles(Locations.WinLogs3, Temp.WindowsLogs);
                    lon4 = LogFiles(Locations.WinLogs4, Temp.WindowsLogs);
                    lon5 = LogFiles(Locations.WinLogs5, Temp.WindowsLogs);
                    lon6 = LogFiles(Locations.WinLogs6, Temp.WindowsLogs);
                    lon7 = LogFiles(Locations.WinLogs7, Temp.WindowsLogs);
                    lon8 = LogFiles(Locations.WinLogs8, Temp.WindowsLogs);
                    lon9 = LogFiles(Locations.WinLogs9, Temp.WindowsLogs);
                    lon10 = LogFiles(Locations.WinLogs10, Temp.WindowsLogs);
                    lon11 = LogFiles(Locations.WinLogs11, Temp.WindowsLogs);
                    lon12 = LogFiles(Locations.WinLogs12, Temp.WindowsLogs);
                    lon13 = LogFiles(Locations.WinLogs13, Temp.WindowsLogs);
                    lon14 = LogFiles(Locations.WinLogs14, Temp.WindowsLogs);
                    lon15 = LogFiles(Locations.WinLogs15, Temp.WindowsLogs);
                    lon16 = LogFiles(Locations.WinLogs16, Temp.WindowsLogs);
                    lon17 = LogFiles(Locations.WinLogs17, Temp.WindowsLogs);
                    lon18 = LogFiles(Locations.WinLogs18, Temp.WindowsLogs);
                    lon19 = LogFiles(Locations.WinLogs19, Temp.WindowsLogs);
                    lon20 = LogFiles(Locations.WinLogs20, Temp.WindowsLogs);
                    lon21 = LogFiles(Locations.WinLogs21, Temp.WindowsLogs);
                    lon22 = LogFiles(Locations.WinLogs22, Temp.WindowsLogs);
                    lon23 = LogFiles(Locations.WinLogs23, Temp.WindowsLogs);
                    lon24 = LogFiles(Locations.WinLogs24, Temp.WindowsLogs);
                    lon25 = LogFiles(Locations.WinLogs25, Temp.WindowsLogs);
                    lon26 = LogFiles(Locations.WinLogs26, Temp.WindowsLogs);
                    lon27 = LogFiles(Locations.WinLogs27, Temp.WindowsLogs);
                    lon28 = LogFiles(Locations.WinLogs28, Temp.WindowsLogs);
                    lon29 = LogFiles(Locations.WinLogs29, Temp.WindowsLogs);
                    lon30 = LogFiles(Locations.WinLogs30, Temp.WindowsLogs);
                    lon31 = LogFiles(Locations.WinLogs31, Temp.WindowsLogs);
                    lon32 = LogFiles(Locations.WinLogs32, Temp.WindowsLogs);
                    lon33 = LogFiles(Locations.WinLogs33, Temp.WindowsLogs);
                    lon34 = LogFiles(Locations.WinLogs34, Temp.WindowsLogs);
                    lon35 = LogFiles(Locations.WinLogs35, Temp.WindowsLogs);
                    lon36 = LogFiles(Locations.WinLogs36, Temp.WindowsLogs);
                    lon37 = LogFiles(Locations.WinLogs37, Temp.WindowsLogs);
                    lon38 = LogFiles(Locations.WinLogs38, Temp.WindowsLogs);
                    lon39 = LogFiles(Locations.WinLogs39, Temp.WindowsLogs);
                    lon40 = LogFiles(Locations.WinLogs40, Temp.WindowsLogs);

                    string result = ConvertToString(lon + lon1 + lon2 + lon3 + lon4 + lon5 + lon6 + lon7 + lon8 + lon9 + lon10 + lon11 + lon12 + lon13 + lon14 + lon15 + lon16 + lon17 + lon18 + lon19
                         + lon20 + lon21 + lon22 + lon23 + lon24 + lon25 + lon26 + lon27 + lon28 + lon29 + lon30 + lon30 + lon31 + lon32 + lon33 + lon34 + lon35 + lon36 + lon37 + lon38 + lon39 + lon40);

                    if (result != "0B")
                    {
                        string[] row = { " System - Windows Log Files", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 5;
                        List.Items.Add(listViewItem);

                        total = total + lon + lon1 + lon2 + lon3 + lon4 + lon5 + lon6 + lon7 + lon8 + lon9 + lon10 + lon11 + lon12 + lon13 + lon14 + lon15 + lon16 + lon17 + lon18 + lon19
                         + lon20 + lon21 + lon22 + lon23 + lon24 + lon25 + lon26 + lon27 + lon28 + lon29 + lon30 + lon30 + lon31 + lon32 + lon33 + lon34 + lon35 + lon36 + lon37 + lon38 + lon39 + lon40;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Windows Log Files...";
                }

                step++;
            }

            if (step == 29)
            {
                if (node10.Checked == true)
                {
                    Lbl2.Text = "Scanning Event Trace Logs...";

                    long lon1; long lon2; long lon3; long lon4; long lon5; long lon6; long lon7; long lon8; long lon9; long lon10; long lon11;

                    lon1 = EtlFiles(Locations.WinLogs1, Temp.EventTraces);
                    lon2 = EtlFiles(Locations.WinLogs2, Temp.EventTraces);
                    lon3 = EtlFiles(Locations.WinLogs3, Temp.EventTraces);
                    lon4 = EtlFiles(Locations.WinLogs4, Temp.EventTraces);
                    lon5 = EtlFiles(Locations.WinLogs5, Temp.EventTraces);
                    lon6 = EtlFiles(Locations.WinLogs6, Temp.EventTraces);
                    lon7 = EtlFiles(Locations.WinLogs7, Temp.EventTraces);
                    lon8 = EtlFiles(Locations.WinLogs8, Temp.EventTraces);
                    lon9 = EtlFiles(Locations.WinLogs9, Temp.EventTraces);
                    lon10 = EtlFiles(Locations.WinLogs10, Temp.EventTraces);
                    lon11 = EtlFiles(Locations.WinLogs11, Temp.EventTraces);

                    string result = ConvertToString(lon1 + lon2 + lon3 + lon4 + lon5 + lon6 + lon7 + lon8 + lon9 + lon10 + lon11);

                    if (result != "0B")
                    {
                        string[] row = { " System - Event Trace Logs", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 5;
                        List.Items.Add(listViewItem);

                        total = total + lon1 + lon2 + lon3 + lon4 + lon5 + lon6 + lon7 + lon8 + lon9 + lon10 + lon11;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Event Trace Logs...";
                }

                step++;
            }

            if (step == 30)
            {
                if (node11.Checked == true)
                {
                    Lbl2.Text = "Scanning Error Reports...";

                    string result = ConvertToString(CheckSize(Locations.Error_Reports, Temp.ErrorReports, true));

                    if (result != "0B")
                    {
                        string[] row = { " System - Error Reporting", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 5;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Error_Reports, Temp.ErrorReports, true);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Error Reports...";
                }

                step++;
            }

            if (step == 31)
            {
                if (node12.Checked == true)
                {
                    Lbl2.Text = "Scanning Driver Installation Log Files";

                    string result = ConvertToString(CheckSingle(Locations.Driver_Installtion + "\\setupapi.dev.log", Temp.InstallationLogs));

                    if (result != "0B")
                    {
                        string[] row = { " System - Driver Installation Log Files", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 5;
                        List.Items.Add(listViewItem);

                        total = total + CheckSingle(Locations.Driver_Installtion + "\\setupapi.dev.log", Temp.InstallationLogs);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Driver Installation Log Files";
                }

                step++;
            }

            if (step == 32)
            {
                if (node13.Checked == true)
                {
                    Lbl2.Text = "Scanning Delivery Optimization Files...";

                    long lon1; long lon2;

                    lon1 = CheckSize(Locations.Delivery_Optimization + "\\Cache", Temp.EventTraces, false);
                    lon2 = LogFiles(Locations.Delivery_Optimization + "\\Logs", Temp.EventTraces);

                    string result = ConvertToString(lon1 + lon2);

                    if (result != "0B")
                    {
                        string[] row = { " System - Windows Delivery Optimization Files", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 5;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Delivery_Optimization + "\\Cache", Temp.EventTraces, false) + LogFiles(Locations.Delivery_Optimization + "\\Logs", Temp.EventTraces);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Delivery Optimization Files...";
                }

                step++;
            }

            if (step == 33)
            {
                if (node14.Checked == true)
                {
                    Lbl2.Text = "Scanning Network Data Usage...";

                    string result = ConvertToString(CheckSize(Locations.Network_Data, Temp.NetworkData, false));

                    if (result != "0B")
                    {
                        string[] row = { " System - Network Data Usage", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 5;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Network_Data, Temp.NetworkData, false);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Network Data Usage...";
                }

                step++;
            }
            #endregion

            #region Advanced
            if (step == 34)
            {
                if (node17.Checked == true)
                {
                    Lbl2.Text = "Scanning Prefetch Data...";

                    string result = ConvertToString(CheckSize(Locations.Prefetch, Temp.Prefetch, false));

                    if (result != "0B")
                    {
                        string[] row = { " Advanced - Prefetch Data", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 4;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Prefetch, Temp.Prefetch, false);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Prefetch Data...";
                }

                step++;
            }

            if (step == 35)
            {
                if (node18.Checked == true)
                {
                    Lbl2.Text = "Scanning Store Install Service Cache...";

                    string result = ConvertToString(CatalogFiles(Locations.Store_Install_Service, Temp.StoreInstall));

                    if (result != "0B")
                    {
                        string[] row = { " Advanced - Store Install Service Cache", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 4;
                        List.Items.Add(listViewItem);

                        total = total + CatalogFiles(Locations.Store_Install_Service, Temp.StoreInstall);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Store Install Service Cache...";
                }

                step++;
            }

            if (step == 36)
            {
                if (node19.Checked == true)
                {
                    Lbl2.Text = "Scanning QT Framework...";

                    string result = ConvertToString(CheckSize(Locations.QtFramework, Temp.QtFramework, true));

                    if (result != "0B")
                    {
                        string[] row = { " Advanced - QT Framework", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 4;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.QtFramework, Temp.QtFramework, true);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping QT Framework...";
                }

                step++;
            }

            if (step == 37)
            {
                if (node20.Checked == true)
                {
                    Lbl2.Text = "Scanning Power Efficiency Diagnostics...";

                    string result = ConvertToString(XmlFiles(Locations.Power_Efficiency, Temp.PowerEfficiency));

                    if (result != "0B")
                    {
                        string[] row = { " Advanced - Power Efficiency Diagnostics", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 4;
                        List.Items.Add(listViewItem);

                        total = total + XmlFiles(Locations.Power_Efficiency, Temp.PowerEfficiency);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Power Efficiency Diagnostics...";
                }

                step++;
            }

            if (step == 38)
            {
                if (node21.Checked == true)
                {
                    Lbl2.Text = "Scanning Notifications...";

                    string result = ConvertToString(CheckSize(Locations.Notifications, Temp.Notifications, true));

                    if (result != "0B")
                    {
                        string[] row = { " Advanced - Notifications", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 4;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Notifications, Temp.Notifications, true);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Notifications...";
                }

                step++;
            }

            if (step == 39)
            {
                if (node22.Checked == true)
                {
                    Lbl2.Text = "Scanning MS Search...";

                    long lon; long lon1; long lon2; long lon3; long lon4;

                    lon = EdbFiles(Locations.MS_Search, Temp.MsSearch);
                    lon1 = CrwlFiles(Locations.MS_Search2, Temp.MsSearch);
                    lon2 = CheckSize(Locations.MS_Search3, Temp.MsSearch, false);
                    lon3 = CheckSize(Locations.MS_Search4, Temp.MsSearch, true);
                    lon4 = CheckSize(Locations.MS_Search5, Temp.MsSearch, true);

                    string result = ConvertToString(lon + lon1 + lon2 + lon3 + lon4);

                    if (result != "0B")
                    {
                        string[] row = { " Advanced - MS Search", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 4;
                        List.Items.Add(listViewItem);

                        total = total + lon + lon1 + lon2 + lon3 + lon4;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping MS Search...";
                }

                step++;
            }

            if (step == 40)
            {
                if (node23.Checked == true)
                {
                    Lbl2.Text = "Scanning Jump List...";

                    string result = ConvertToString(CheckSize(Locations.Jump_List, Temp.JumpList, false));

                    if (result != "0B")
                    {
                        string[] row = { " Advanced - Jump List", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 4;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Jump_List, Temp.JumpList, false);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Jump List...";
                }

                step++;
            }

            if (step == 41)
            {
                if (node24.Checked == true)
                {
                    Lbl2.Text = "Scanning Font Cache...";

                    string result = ConvertToString(DatFiles(Locations.Font_Cache, Temp.FontCache));

                    if (result != "0B")
                    {
                        string[] row = { " Advanced - Font Cache", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 4;
                        List.Items.Add(listViewItem);

                        total = total + DatFiles(Locations.Font_Cache, Temp.FontCache);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Font Cache...";
                }

                step++;
            }
            #endregion

            #region Applications
            if (step == 42)
            {
                if (node26.Checked == true)
                {
                    Lbl2.Text = "Scanning Windows Defender...";

                    long lon; long lon1; long lon2; long lon3; long lon4; long lon5;

                    lon = CheckSize(Locations.Win_Defender, Temp.WindowsDefender, false);
                    lon1 = LogFiles(Locations.Win_Defender2, Temp.WindowsDefender);
                    lon2 = CheckSize(Locations.Win_Defender3, Temp.WindowsDefender, true);
                    lon3 = CheckSize(Locations.Win_Defender4, Temp.WindowsDefender, false);
                    lon4 = CheckSize(Locations.Win_Defender5, Temp.WindowsDefender, false);
                    lon4 = CheckSize(Locations.Win_Defender6, Temp.WindowsDefender, false);
                    lon5 = CheckSize(Locations.Win_Defender7, Temp.WindowsDefender, true);

                    string result = ConvertToString(lon + lon1 + lon2 + lon3 + lon4 + lon5);

                    if (result != "0B")
                    {
                        string[] row = { " Applications - Windows Defender", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 0;
                        List.Items.Add(listViewItem);

                        total = total + lon + lon1 + lon2 + lon3 + lon4 + lon5;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Windows Defender...";
                }

                step++;
            }

            if (step == 43)
            {
                if (node27.Checked == true)
                {
                    Lbl2.Text = "Scanning Origin Installers...";

                    string result = ConvertToString(CheckSize(Locations.Origin_Installers, Temp.OriginInstallers, true));

                    if (result != "0B")
                    {
                        string[] row = { " Applications - Origin Installers", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 0;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Origin_Installers, Temp.OriginInstallers, true);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Origin Installers...";
                }

                step++;
            }

            if (step == 44)
            {
                if (node28.Checked == true)
                {
                    Lbl2.Text = "Scanning Visual Studio Installation...";

                    string result = ConvertToString(CheckSize(Locations.Visual_Studio, Temp.VisualStudio, true));

                    if (result != "0B")
                    {
                        string[] row = { " Applications - Visual Studio Installation", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 0;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Visual_Studio, Temp.VisualStudio, true);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Visual Studio Installation...";
                }

                step++;
            }

            if (step == 45)
            {
                if (node29.Checked == true)
                {
                    Lbl2.Text = "Scanning One Drive...";

                    long lon; long lon1; long lon2;

                    lon = CheckSize(Locations.One_Drive, Temp.OneDrive, false);
                    lon1 = LogFiles(Locations.One_Drive2, Temp.OneDrive);
                    lon2 = CheckSize(Locations.One_Drive3, Temp.OneDrive, true);

                    string result = ConvertToString(lon + lon1 + lon2);

                    if (result != "0B")
                    {
                        string[] row = { " Applications - One Drive", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 0;
                        List.Items.Add(listViewItem);

                        total = total + lon + lon1 + lon2;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping One Drive...";
                }

                step++;
            }

            if (step == 46)
            {
                if (node30.Checked == true)
                {
                    Lbl2.Text = "Scanning Easy Anti-Cheat...";

                    string result = ConvertToString(LogFiles(Locations.Easy_AntiCheat, Temp.EasyAntiCheat));

                    if (result != "0B")
                    {
                        string[] row = { " Applications - Easy Anti-Cheat", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 0;
                        List.Items.Add(listViewItem);

                        total = total + LogFiles(Locations.Easy_AntiCheat, Temp.EasyAntiCheat);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Easy Anti-Cheat...";
                }

                step++;
            }

            if (step == 47)
            {
                if (node31.Checked == true)
                {
                    Lbl2.Text = "Scanning Battlenet...";

                    long lon; long lon1; long lon2; long lon3; long lon4;

                    lon = CheckSize(Locations.Battlenet, Temp.Battlenet, true);
                    lon1 = CheckSize(Locations.Battlenet2, Temp.Battlenet, false);
                    lon2 = CheckSize(Locations.Battlenet3, Temp.Battlenet, false);
                    lon3 = CheckSize(Locations.Battlenet4, Temp.Battlenet, false);
                    lon4 = CheckSize(Locations.Battlenet5, Temp.Battlenet, true);

                    string result = ConvertToString(lon + lon1 + lon2);

                    if (result != "0B")
                    {
                        string[] row = { " Applications - Battlenet", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 0;
                        List.Items.Add(listViewItem);

                        total = total + lon + lon1 + lon2;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Battlenet...";
                }

                step++;
            }

            if (step == 48)
            {
                if (node32.Checked == true)
                {
                    Lbl2.Text = "Scanning Ccleaner...";

                    string result = ConvertToString(LogFiles(Locations.Ccleaner, Temp.Ccleaner));

                    if (result != "0B")
                    {
                        string[] row = { " Applications - Ccleaner", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 0;
                        List.Items.Add(listViewItem);

                        total = total + LogFiles(Locations.Ccleaner, Temp.Ccleaner);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Ccleaner...";
                }

                step++;
            }

            if (step == 49)
            {
                if (node33.Checked == true)
                {
                    Lbl2.Text = "Scanning Steam...";

                    long lon; long lon1; long lon2;

                    lon = LogFiles(Locations.Steam, Temp.Steam);
                    lon1 = CheckSize(Locations.Steam2, Temp.Steam, false);
                    lon2 = CheckSize(Locations.Steam3, Temp.Steam, false);

                    string result = ConvertToString(lon + lon1 + lon2);

                    if (result != "0B")
                    {
                        string[] row = { " Applications - Steam", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 0;
                        List.Items.Add(listViewItem);

                        total = total + lon + lon1 + lon2;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Steam...";
                }

                step++;
            }
            #endregion

            #region Windows
            if (step == 50)
            {
                if (node35.Checked == true)
                {
                    Lbl2.Text = "Scanning DirectX Shader Cache...";

                    long lon; long lon1;

                    lon = CheckSize(Locations.DirectX, Temp.ShaderCache, true);
                    lon1 = CheckSize(Locations.DirectX2, Temp.ShaderCache, true);

                    string result = ConvertToString(lon + lon1);

                    if (result != "0B")
                    {
                        string[] row = { " Windows - DirectX Shader Cache", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 7;
                        List.Items.Add(listViewItem);

                        total = total + lon + lon1;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping DirectX Shader Cache...";
                }

                step++;
            }

            if (step == 51)
            {
                if (node36.Checked == true)
                {
                    Lbl2.Text = "Scanning Update Files...";

                    string result = ConvertToString(CheckSize(Locations.Windows_Update, Temp.WindowsUpdate, true));

                    if (result != "0B")
                    {
                        string[] row = { " Windows - Update Files", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 7;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Windows_Update, Temp.WindowsUpdate, true);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Update Files...";
                }

                step++;
            }

            if (step == 52)
            {
                if (node37.Checked == true)
                {
                    Lbl2.Text = "Scanning Font Cache...";

                    string result = ConvertToString(CheckSingle(Locations.Windows_Font_Cache, Temp.WindowsFontCache));

                    if (result != "0B")
                    {
                        string[] row = { " Windows - Font Cache", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 7;
                        List.Items.Add(listViewItem);

                        total = total + CheckSingle(Locations.Windows_Font_Cache, Temp.WindowsFontCache);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Font Cache...";
                }

                step++;
            }

            if (step == 53)
            {
                if (node38.Checked == true)
                {
                    Lbl2.Text = "Scanning Debug Files...";

                    string result = ConvertToString(LogFiles(Locations.Windows_Debug, Temp.WindowsDebug));

                    if (result != "0B")
                    {
                        string[] row = { " Windows - Debug Files", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 7;
                        List.Items.Add(listViewItem);

                        total = total + LogFiles(Locations.Windows_Debug, Temp.WindowsDebug);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Debug Files...";
                }

                step++;
            }

            if (step == 54)
            {
                if (node39.Checked == true)
                {
                    Lbl2.Text = "Scanning Cache Files...";

                    long lon; long lon1; long lon2; long lon3; long lon4;

                    lon = CheckSize(Locations.Windows_Cache, Temp.WindowsCache, true);
                    lon1 = CheckSize(Locations.Windows_Cache2, Temp.WindowsCache, true);
                    lon2 = CheckSize(Locations.Windows_Cache3, Temp.WindowsCache, true);
                    lon3 = CheckSize(Locations.Windows_Cache4, Temp.WindowsCache, true);
                    lon4 = CheckSize(Locations.Windows_Cache5, Temp.WindowsCache, true);

                    string result = ConvertToString(lon + lon1 + lon2 + lon3 + lon4);

                    if (result != "0B")
                    {
                        string[] row = { " Windows - Cache Files", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 7;
                        List.Items.Add(listViewItem);

                        total = total + lon + lon1 + lon2 + lon3 + lon4;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Cache Files...";
                }

                step++;
            }

            if (step == 55)
            {
                if (node40.Checked == true)
                {
                    Lbl2.Text = "Scanning Installers...";

                    string result = ConvertToString(CheckSize(Locations.Windows_Installer, Temp.WindowsInstaller, true));

                    if (result != "0B")
                    {
                        string[] row = { " Windows - Installers", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 7;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Windows_Installer, Temp.WindowsInstaller, true);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Installers...";
                }

                step++;
            }

            if (step == 56)
            {
                if (node41.Checked == true)
                {
                    Lbl2.Text = "Scanning Experience Index...";

                    long lon; long lon1;

                    lon = LogFiles(Locations.Windows_Experience, Temp.WindowsExperience);
                    lon1 = CheckSize(Locations.Windows_Experience2, Temp.WindowsExperience, true);

                    string result = ConvertToString(lon + lon1);

                    if (result != "0B")
                    {
                        string[] row = { " Windows - Experience Index", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 7;
                        List.Items.Add(listViewItem);

                        total = total + lon + lon1;
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Experience Index...";
                }

                step++;
            }

            if (step == 57)
            {
                if (node42.Checked == true)
                {
                    Lbl2.Text = "Scanning Auto/Video Quality Experience...";

                    string result = ConvertToString(DatFiles(Locations.Windows_Auto_Video_Experience, Temp.AutoVideoExperience));

                    if (result != "0B")
                    {
                        string[] row = { " Windows - Auto/Video Quality Experience", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 7;
                        List.Items.Add(listViewItem);

                        total = total + DatFiles(Locations.Windows_Auto_Video_Experience, Temp.AutoVideoExperience);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Auto/Video Quality Experience...";
                }

                step++;
            }

            if (step == 58)
            {
                if (node66.Checked == true)
                {
                    Lbl2.Text = "Scanning Internet Explorer Cache...";

                    string result = ConvertToString(CheckSize(Locations.Windows_Internet_Cache, Temp.WindowsInternetCache, true));

                    if (result != "0B")
                    {
                        string[] row = { " Windows - Internet Explorer Cache", result };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.ImageIndex = 7;
                        List.Items.Add(listViewItem);

                        total = total + CheckSize(Locations.Windows_Auto_Video_Experience, Temp.WindowsInternetCache, true);
                    }
                }
                else
                {
                    Lbl2.Text = "Skipping Internet Explorer Cache...";
                }

                step++;
            }
            #endregion

            else
            {
                Scanner.Enabled = false;
                step = 0;

                isRunning(false, "Total Clutter Found: " + ConvertToString(total));
            }
        }

        private void Deleter_Tick(object sender, EventArgs e)
        {
            #region Windows Explorer
            if (remove == 1)
            {
                if (node2.Checked == true)
                {
                    Lbl2.Text = "Removing Recent Documents...";
                    Delete.Files(Locations.Recent_Documents, false);
                }

                remove++;
            }

            if (remove == 2)
            {
                if (node3.Checked == true)
                {
                    Lbl2.Text = "Removing Thumnail Cache...";
                    Delete.Files(Locations.Thumnail_Cache, false);
                }

                remove++;
            }

            if (remove == 3)
            {
                if (node4.Checked == true)
                {
                    Lbl2.Text = "Removing Mini Dumps...";
                    Delete.Files(Locations.Mini_Dumps, true);
                }

                remove++;
            }

            if (remove == 4)
            {
                if (node15.Checked == true)
                {
                    Lbl2.Text = "Removing Windows Temporary Files......";
                    Delete.Files(Locations.Win_Temp_Files, true);
                }

                remove++;
            }
            #endregion

            #region System
            if (remove == 5)
            {
                if (node6.Checked == true)
                {
                    Lbl2.Text = "Emptying Recylce Bin...";
                    Delete.Files(Locations.Recyle_Bin, true);
                }

                remove++;
            }

            if (remove == 6)
            {
                if (node7.Checked == true)
                {
                    Lbl2.Text = "Removing System Temporary Files...";
                    Delete.Files(Locations.Temp_Files, true);
                }

                remove++;
            }

            if (remove == 7)
            {
                if (node8.Checked == true)
                {
                    Lbl2.Text = "Removing Memory Dumps...";
                    Delete.Files(Locations.Memory_Dumps, false);
                }

                remove++;
            }

            if (remove == 8)
            {
                if (node9.Checked == true)
                {
                    Lbl2.Text = "Removing Windows Log Files...";
                    Delete.Logs(Locations.WinLogs);
                    Delete.Files(Locations.WinLogs1, false);
                    Delete.Files(Locations.WinLogs2, false);
                    Delete.Files(Locations.WinLogs3, false);
                    Delete.Files(Locations.WinLogs4, false);
                    Delete.Files(Locations.WinLogs5, false);
                    Delete.Files(Locations.WinLogs6, false);
                    Delete.Files(Locations.WinLogs7, false);
                    Delete.Files(Locations.WinLogs8, false);
                    Delete.Files(Locations.WinLogs9, false);
                    Delete.Logs(Locations.WinLogs10);
                    Delete.Files(Locations.WinLogs11, false);
                    Delete.Logs(Locations.WinLogs12);
                    Delete.Logs(Locations.WinLogs13);
                    Delete.Logs(Locations.WinLogs14);
                    Delete.Logs(Locations.WinLogs15);
                    Delete.Logs(Locations.WinLogs16);
                    Delete.Logs(Locations.WinLogs17);
                    Delete.Logs(Locations.WinLogs18);
                    Delete.Logs(Locations.WinLogs19);
                    Delete.Logs(Locations.WinLogs20);
                    Delete.Logs(Locations.WinLogs21);
                    Delete.Logs(Locations.WinLogs22);
                    Delete.Logs(Locations.WinLogs23);
                    Delete.Logs(Locations.WinLogs24);
                    Delete.Logs(Locations.WinLogs25);
                    Delete.Logs(Locations.WinLogs26);
                    Delete.Logs(Locations.WinLogs27);
                    Delete.Logs(Locations.WinLogs28);
                    Delete.Logs(Locations.WinLogs29);
                    Delete.Logs(Locations.WinLogs30);
                    Delete.Logs(Locations.WinLogs31);
                    Delete.Logs(Locations.WinLogs32);
                    Delete.Logs(Locations.WinLogs33);
                    Delete.Files(Locations.WinLogs34, false);
                    Delete.Files(Locations.WinLogs35, false);
                    Delete.Files(Locations.WinLogs36, false);
                    Delete.Files(Locations.WinLogs37, false);
                    Delete.Files(Locations.WinLogs38, false);
                    Delete.Files(Locations.WinLogs39, false);
                    Delete.Files(Locations.WinLogs40, false);
                }

                remove++;
            }

            if (remove == 9)
            {
                if (node10.Checked == true)
                {
                    Lbl2.Text = "Removing Event Trace Logs...";
                    Delete.Etl(Locations.WinLogs1);
                    Delete.Etl(Locations.WinLogs2);
                    Delete.Etl(Locations.WinLogs3);
                    Delete.Etl(Locations.WinLogs4);
                    Delete.Etl(Locations.WinLogs5);
                    Delete.Etl(Locations.WinLogs6);
                    Delete.Etl(Locations.WinLogs7);
                    Delete.Etl(Locations.WinLogs8);
                    Delete.Etl(Locations.WinLogs9);
                    Delete.Etl(Locations.WinLogs10);
                    Delete.Etl(Locations.WinLogs11);
                }

                remove++;
            }

            if (remove == 10)
            {
                if (node11.Checked == true)
                {
                    Lbl2.Text = "Removing Error Reports...";
                    Delete.Files(Locations.Error_Reports, false);
                    Delete.Files(Locations.Error_Reports + "\\ReportArchive", true);
                    Delete.Files(Locations.Error_Reports + "\\ReportQueue", true);
                    Delete.Files(Locations.Error_Reports + "\\Temp", true);
                }

                remove++;
            }

            if (remove == 11)
            {
                if (node12.Checked == true)
                {
                    Lbl2.Text = "Removing Driver Installation Log Files...";
                    Delete.Single(Locations.Driver_Installtion + "\\setupapi.dev.log");
                }

                remove++;
            }

            if (remove == 12)
            {
                if (node13.Checked == true)
                {
                    Lbl2.Text = "Removing Delivery Optimization Filess...";
                    Delete.Files(Locations.Delivery_Optimization + "\\Cache", false);
                    Delete.Logs(Locations.Delivery_Optimization + "\\Logs");
                }

                remove++;
            }

            if (remove == 13)
            {
                if (node14.Checked == true)
                {
                    Lbl2.Text = "Removing Network Data...";
                    Delete.Files(Locations.Network_Data + "\\Cache", false);
                }

                remove++;
            }
            #endregion

            #region Advnaced
            if (remove == 14)
            {
                if (node17.Checked == true)
                {
                    Lbl2.Text = "Removing Prefetch Data...";
                    Delete.Files(Locations.Prefetch, true);
                }

                remove++;
            }

            if (remove == 15)
            {
                if (node18.Checked == true)
                {
                    Lbl2.Text = "Removing Store Install Service Files...";
                    Delete.Files(Locations.Store_Install_Service, false);
                }

                remove++;
            }

            if (remove == 16)
            {
                if (node19.Checked == true)
                {
                    Lbl2.Text = "Removing QT Framework...";
                    Delete.Files(Locations.QtFramework, true);
                }

                remove++;
            }

            if (remove == 17)
            {
                if (node20.Checked == true)
                {
                    Lbl2.Text = "Removing Store Installation Services...";
                    Delete.Xml(Locations.Store_Install_Service);
                }

                remove++;
            }

            if (remove == 18)
            {
                if (node21.Checked == true)
                {
                    Lbl2.Text = "Removing Notifications...";
                    Delete.Files(Locations.Notifications, true);
                }

                remove++;
            }

            if (remove == 19)
            {
                if (node22.Checked == true)
                {
                    Lbl2.Text = "Removing History...";
                    Delete.Edb(Locations.MS_Search);
                    Delete.Crwl(Locations.MS_Search2);
                    Delete.Files(Locations.MS_Search, true);
                    Delete.Files(Locations.MS_Search2, true);
                    Delete.Files(Locations.MS_Search3, true);
                    Delete.Files(Locations.MS_Search4, true);
                    Delete.Files(Locations.MS_Search5, true);
                }

                remove++;
            }

            if (remove == 20)
            {
                if (node23.Checked == true)
                {
                    Lbl2.Text = "Removing Jump List Data...";
                    Delete.Files(Locations.Jump_List, false);
                }

                remove++;
            }

            if (remove == 21)
            {
                if (node24.Checked == true)
                {
                    Lbl2.Text = "Removing Font Cache...";
                    Delete.Dat(Locations.Font_Cache);
                }

                remove++;
            }

            #endregion

            #region Applications
            if (remove == 22)
            {
                if (node26.Checked == true)
                {
                    Lbl2.Text = "Removing Windows Defender Files...";
                    Delete.Files(Locations.Win_Defender, false);
                    Delete.Logs(Locations.Win_Defender2);
                    Delete.Files(Locations.Win_Defender3, true);
                    Delete.Files(Locations.Win_Defender4, false);
                    Delete.Files(Locations.Win_Defender5, false);
                    Delete.Files(Locations.Win_Defender6, false);
                    Delete.Files(Locations.Win_Defender7 + @"\Quick", false);
                    Delete.Files(Locations.Win_Defender7 + @"\Resource", false);
                }

                remove++;
            }

            if (remove == 23)
            {
                if (node27.Checked == true)
                {
                    Lbl2.Text = "Removing Origin Installation Files...";
                    Delete.Files(Locations.Origin_Installers, true);
                }

                remove++;
            }

            if (remove == 24)
            {
                if (node28.Checked == true)
                {
                    Lbl2.Text = "Removing Visual Studio Installations...";
                    Delete.Files(Locations.Visual_Studio, true);
                }

                remove++;
            }

            if (remove == 25)
            {
                if (node29.Checked == true)
                {
                    Lbl2.Text = "Removing One Drive Logs...";
                    Delete.Files(Locations.One_Drive, false);
                    Delete.Logs(Locations.One_Drive2);
                    Delete.Files(Locations.One_Drive3, true);
                }

                remove++;
            }

            if (remove == 26)
            {
                if (node30.Checked == true)
                {
                    Lbl2.Text = "Removing Easy Anti Cheat Logs...";
                    Delete.Logs(Locations.Easy_AntiCheat);
                }

                remove++;
            }

            if (remove == 27)
            {
                if (node31.Checked == true)
                {
                    Lbl2.Text = "Removing Battlenet Files...";
                    Delete.Files(Locations.Battlenet, true);
                    Delete.Files(Locations.Battlenet2, false);
                    Delete.Files(Locations.Battlenet3, false);
                    Delete.Files(Locations.Battlenet4, false);
                    Delete.Files(Locations.Battlenet5, true);
                }

                remove++;
            }

            if (remove == 28)
            {
                if (node32.Checked == true)
                {
                    Lbl2.Text = "Removing CCleaner Logs...";
                    Delete.Logs(Locations.Ccleaner);
                }

                remove++;
            }

            if (remove == 29)
            {
                if (node33.Checked == true)
                {
                    Lbl2.Text = "Removing Steam Logs...";
                    Delete.Logs(Locations.Steam);
                    Delete.Files(Locations.Steam2, false);
                    Delete.Files(Locations.Steam3, false);
                }

                remove++;
            }
            #endregion

            #region Windows
            if (remove == 30)
            {
                if (node35.Checked == true)
                {
                    Lbl2.Text = "Removing DirectX Shader Cache...";
                    Delete.Files(Locations.DirectX, true);
                    Delete.Files(Locations.DirectX2, true);
                }

                remove++;
            }

            if (remove == 31)
            {
                if (node36.Checked == true)
                {
                    Lbl2.Text = "Removing Windows Update Files...";
                    Delete.Files(Locations.Windows_Update, true);
                }

                remove++;
            }

            if (remove == 32)
            {
                if (node37.Checked == true)
                {
                    Lbl2.Text = "Removing Windows Font Cache...";
                    Delete.Single(Locations.Windows_Font_Cache);
                }

                remove++;
            }

            if (remove == 33)
            {
                if (node38.Checked == true)
                {
                    Lbl2.Text = "Removing Windows Debug Files...";
                    Delete.Logs(Locations.Windows_Debug);
                }

                remove++;
            }

            if (remove == 34)
            {
                if (node39.Checked == true)
                {
                    Lbl2.Text = "Removing Windows Cache...";
                    Delete.Files(Locations.Windows_Cache, true);
                    Delete.Files(Locations.Windows_Cache2, true);
                    Delete.Files(Locations.Windows_Cache3, true);
                    Delete.Files(Locations.Windows_Cache4, true);
                    Delete.Files(Locations.Windows_Cache5, true);
                }

                remove++;
            }

            if (remove == 35)
            {
                if (node40.Checked == true)
                {
                    Lbl2.Text = "Removing Windows Installation Data...";
                    Delete.Files(Locations.Windows_Installer, true);
                }

                remove++;
            }

            if (remove == 36)
            {
                if (node41.Checked == true)
                {
                    Lbl2.Text = "Removing Windows Experience Files...";
                    Delete.Logs(Locations.Windows_Experience);
                    Delete.Files(Locations.Windows_Experience2, false);
                }

                remove++;
            }

            if (remove == 37)
            {
                if (node42.Checked == true)
                {
                    Lbl2.Text = "Removing Auto and Video Experience...";
                    Delete.Dat(Locations.Windows_Auto_Video_Experience);
                }

                remove++;
            }

            if (remove == 38)
            {
                if (node66.Checked == true)
                {
                    Lbl2.Text = "Removing Internet Explorer Cache...";
                    Delete.Files(Locations.Windows_Internet_Cache, true);
                }

                remove++;
            }
            #endregion

            #region Edge Chromium
            if (remove == 39)
            {
                if (node44.Checked == true)
                {
                    Lbl2.Text = "Removing Edge Chromium Internet Cache...";
                    Utils.KillProcess("msedge");

                    Delete.Files(Locations.Edge_Cache, false);
                    Delete.Files(Locations.Edge_Cache2, false);
                    Delete.Files(Locations.Edge_Cache3, false);
                    Delete.Files(Locations.Edge_Cache4, false);
                    Delete.Files(Locations.Edge_Cache5, true);
                    Delete.Files(Locations.Edge_Cache6, false);
                    Delete.Files(Locations.Edge_Cache7, false);
                    Delete.Files(Locations.Edge_Cache8, false);
                    Delete.Files(Locations.Edge_Cache9, false);
                    Delete.Files(Locations.Edge_Cache10, false);

                    Delete.Single(Locations.Edge_Cache11);
                    Delete.Single(Locations.Edge_Cache12);
                    Delete.Single(Locations.Edge_Cache13);
                    Delete.Single(Locations.Edge_Cache14);
                    Delete.Single(Locations.Edge_Cache15);
                    Delete.Single(Locations.Edge_Cache16);
                    Delete.Single(Locations.Edge_Cache17);
                    Delete.Single(Locations.Edge_Cache18);
                    Delete.Single(Locations.Edge_Cache19);
                    Delete.Single(Locations.Edge_Cache20);
                    Delete.Single(Locations.Edge_Cache21);
                }

                remove++;
            }

            if (remove == 40)
            {
                if (node45.Checked == true)
                {
                    Lbl2.Text = "Removing Edge Chromium Internet Cookies...";
                    Utils.KillProcess("msedge");

                    Delete.Files(Locations.Edge_Cookies, true);
                    Delete.Single(Locations.Edge_Cookies1);
                }

                remove++;
            }

            if (remove == 41)
            {
                if (node46.Checked == true)
                {
                    Lbl2.Text = "Removing Edge Chromium Internet History...";
                    Utils.KillProcess("msedge");

                    Delete.Single(Locations.Edge_History);
                    Delete.Single(Locations.Edge_History2);
                    Delete.Single(Locations.Edge_History3);
                    Delete.Single(Locations.Edge_History4);
                    Delete.Single(Locations.Edge_History5);
                    Delete.Single(Locations.Edge_History6);
                    Delete.Single(Locations.Edge_History7);
                    Delete.Single(Locations.Edge_History8);
                    Delete.Single(Locations.Edge_History9);
                    Delete.Single(Locations.Edge_History10);
                    Delete.Single(Locations.Edge_History11);
                    Delete.Single(Locations.Edge_History12);
                    Delete.Single(Locations.Edge_History13);
                    Delete.Single(Locations.Edge_History14);
                }

                remove++;
            }

            if (remove == 42)
            {
                if (node47.Checked == true)
                {
                    Lbl2.Text = "Removing Edge Chromium Session Data...";
                    Utils.KillProcess("msedge");

                    Delete.Files(Locations.Edge_Session, false);
                    Delete.Files(Locations.Edge_Session2, false);
                    Delete.Files(Locations.Edge_Session3, false);
                }

                remove++;
            }

            if (remove == 43)
            {
                if (node48.Checked == true)
                {
                    Lbl2.Text = "Removing Edge Chromium Saved Passwords...";
                    Utils.KillProcess("msedge");

                    Delete.Single(Locations.Edge_Passwords);
                }

                remove++;
            }

            if (remove == 44)
            {
                if (node49.Checked == true)
                {
                    Lbl2.Text = "Removing Edge Chromium Metrics Temp Data...";
                    Utils.KillProcess("msedge");

                    Delete.Pma(Locations.Edge_Metrics);
                    Delete.Pma(Locations.Edge_Metrics2);
                }

                remove++;
            }
            #endregion

            #region Google Chrome
            if (remove == 45)
            {
                if (node51.Checked == true)
                {
                    Lbl2.Text = "Removing Google Chrome Internet Cache...";
                    Utils.KillProcess("chrome");

                    Delete.Files(Locations.Chrome_Cache, false);
                    Delete.Files(Locations.Chrome_Cache2, false);
                    Delete.Files(Locations.Chrome_Cache3, false);
                    Delete.Files(Locations.Chrome_Cache4, false);
                    Delete.Files(Locations.Chrome_Cache5, true);
                    Delete.Files(Locations.Chrome_Cache6, true);
                    Delete.Files(Locations.Chrome_Cache7, false);
                    Delete.Files(Locations.Chrome_Cache8, true);
                    Delete.Files(Locations.Chrome_Cache9, false);
                    Delete.Files(Locations.Chrome_Cache10, false);
                    Delete.Files(Locations.Chrome_Cache11, false);
                    Delete.Files(Locations.Chrome_Cache12, false);

                    Delete.Single(Locations.Chrome_Cache13);
                    Delete.Single(Locations.Chrome_Cache14);
                    Delete.Single(Locations.Chrome_Cache15);
                    Delete.Single(Locations.Chrome_Cache16);
                    Delete.Single(Locations.Chrome_Cache17);
                    Delete.Single(Locations.Chrome_Cache18);
                    Delete.Single(Locations.Chrome_Cache19);
                    Delete.Single(Locations.Chrome_Cache20);
                    Delete.Single(Locations.Chrome_Cache21);
                    Delete.Single(Locations.Chrome_Cache22);
                }

                remove++;
            }

            if (remove == 46)
            {
                if (node52.Checked == true)
                {
                    Lbl2.Text = "Removing Google Chrome Internet History...";
                    Utils.KillProcess("chrome");

                    Delete.Single(Locations.Chrome_History);
                    Delete.Single(Locations.Chrome_History2);
                    Delete.Single(Locations.Chrome_History3);
                    Delete.Single(Locations.Chrome_History4);
                    Delete.Single(Locations.Chrome_History5);
                    Delete.Single(Locations.Chrome_History6);
                    Delete.Single(Locations.Chrome_History7);
                    Delete.Single(Locations.Chrome_History8);
                    Delete.Files(Locations.Chrome_History9, false);
                }

                remove++;
            }

            if (remove == 47)
            {
                if (node53.Checked == true)
                {
                    Lbl2.Text = "Removing Google Chrome Internet Cookies...";
                    Utils.KillProcess("chrome");

                    Delete.Files(Locations.Chrome_Cookies, true);
                    Delete.Single(Locations.Chrome_Cookies2);
                }

                remove++;
            }

            if (remove == 48)
            {
                if (node54.Checked == true)
                {
                    Lbl2.Text = "Removing Google Chrome Internet Download Data...";
                    Utils.KillProcess("chrome");

                    Delete.Single(Locations.Chrome_Download);
                }

                remove++;
            }

            if (remove == 49)
            {
                if (node55.Checked == true)
                {
                    Lbl2.Text = "Removing Google Chrome Metrics Temp Data...";
                    Utils.KillProcess("chrome");

                    Delete.Pma(Locations.Chrome_Metrics);
                }

                remove++;
            }

            if (remove == 50)
            {
                if (node56.Checked == true)
                {
                    Lbl2.Text = "Removing Google Chrome Session Data...";
                    Utils.KillProcess("chrome");

                    Delete.Files(Locations.Chrome_Session, false);
                    Delete.Files(Locations.Chrome_Session2, false);
                    Delete.Files(Locations.Chrome_Session3, false);
                }

                remove++;
            }

            if (remove == 51)
            {
                if (node57.Checked == true)
                {
                    Lbl2.Text = "Removing Google Chrome Saved Passwords...";
                    Utils.KillProcess("chrome");

                    Delete.Single(Locations.Chrome_Passwords);
                }

                remove++;
            }
            #endregion

            #region Firefox
            if (remove == 52)
            {
                if (node59.Checked == true)
                {
                    Lbl2.Text = "Removing Firefox Internet Cache...";
                    Utils.KillProcess("firefox");

                    Delete.Files(Locations.Firefox_Cache, false);
                    Delete.Files(Locations.Firefox_Cache2, false);
                    Delete.Files(Locations.Firefox_Cache3, false);
                    Delete.Files(Locations.Firefox_Cache4, false);
                    Delete.Files(Locations.Firefox_Cache5, false);
                }

                remove++;
            }

            if (remove == 53)
            {
                if (node60.Checked == true)
                {
                    Lbl2.Text = "Removing Firefox Internet History...";
                    Utils.KillProcess("firefox");

                    Delete.Files(Locations.Firefox_History, false);
                }

                remove++;
            }

            if (remove == 54)
            {
                if (node61.Checked == true)
                {
                    Lbl2.Text = "Removing Firefox Internet Cookies...";
                    Utils.KillProcess("firefox");

                    Delete.Files(Locations.Firefox_Cookies, true);
                }

                remove++;
            }

            if (remove == 55)
            {
                if (node62.Checked == true)
                {
                    Lbl2.Text = "Removing Firefox Session Data...";
                    Utils.KillProcess("firefox");

                    Delete.Files(Locations.Firefox_Session, false);
                    Delete.Single(Locations.Firefox_Session2);
                }

                remove++;
            }

            if (remove == 56)
            {
                if (node63.Checked == true)
                {
                    Lbl2.Text = "Removing Firefox Site Preferences...";
                    Utils.KillProcess("firefox");

                    Delete.Single(Locations.Firefox_Site_Pref);
                }

                remove++;
            }

            if (remove == 57)
            {
                if (node64.Checked == true)
                {
                    Lbl2.Text = "Removing Firefox Saved Passwords...";
                    Utils.KillProcess("firefox");

                    Delete.Single(Locations.Firefox_Saved_Form);
                }

                remove++;
            }

            if (remove == 58)
            {
                if (node65.Checked == true)
                {
                    Lbl2.Text = "Removing Firefox Saved Passwords...";
                    Utils.KillProcess("firefox");

                    Delete.Single(Locations.Firefox_Login);
                    Delete.Single(Locations.Firefox_Login2);
                }

                remove++;
            }
            #endregion

            else
            {
                Deleter.Enabled = false;
                remove = 0;

                if (Properties.Settings.Default.CloseAfterClean)
                {
                    Process.Start(Utils.path + "delete_logs.txt");
                    Application.Exit();
                }
                else if (Properties.Settings.Default.ShowReadOnly)
                {
                    Analyze.PerformClick();
                }
                else if (!Properties.Settings.Default.ShowReadOnly)
                {
                    List.Items.Clear();

                    List<string> data = File.ReadAllLines(Utils.path + "delete_logs.txt").ToList();

                    foreach (string d in data)
                    {
                        string[] items = d.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        var listViewItem = new ListViewItem(items);
                        listViewItem.ImageIndex = 9;
                        List.Items.Add(listViewItem);
                    }
                }

                isRunning(false, "Total Clutter Removed: " + ConvertToString(Remover.Delete.Total_Deleted));
            }
        }
        #endregion
    }
}
