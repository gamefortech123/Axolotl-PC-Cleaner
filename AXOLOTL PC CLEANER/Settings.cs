using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AXOLOTL_PC_CLEANER
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            startup.Checked = Properties.Settings.Default.Startup;
            minimized.Checked = Properties.Settings.Default.Minimized;
            expandall.Checked = Properties.Settings.Default.ExpandAll;
            rescan.Checked = Properties.Settings.Default.ShowReadOnly;
            showwindows.Checked = Properties.Settings.Default.ShowWindows;
            showadvanced.Checked = Properties.Settings.Default.ShowAdvanced;
            showapps.Checked = Properties.Settings.Default.ShowApps;
            closeafter.Checked = Properties.Settings.Default.CloseAfterClean;
            edge.Checked = Properties.Settings.Default.ShowEdge;
            chrome.Checked = Properties.Settings.Default.ShowChrome;
            firefox.Checked = Properties.Settings.Default.ShowFirefox;
            guna2TextBox1.Text = Properties.Settings.Default.FirefoxPath;
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Startup = startup.Checked;
            Properties.Settings.Default.Minimized = minimized.Checked;
            Properties.Settings.Default.ExpandAll = expandall.Checked;
            Properties.Settings.Default.ShowReadOnly = rescan.Checked;
            Properties.Settings.Default.ShowWindows = showwindows.Checked;
            Properties.Settings.Default.ShowAdvanced = showadvanced.Checked;
            Properties.Settings.Default.ShowApps = showapps.Checked;
            Properties.Settings.Default.CloseAfterClean = closeafter.Checked;
            Properties.Settings.Default.ShowEdge = edge.Checked;
            Properties.Settings.Default.ShowChrome = chrome.Checked;
            Properties.Settings.Default.ShowFirefox = firefox.Checked;

            Properties.Settings.Default.Save();
        }

        private void msg1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This features enables Axolotl Cleaner to run and Winodws startup.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void msg2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This features allows the cleaner to be minimized to tray on load.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void msg3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Expand all options on application load.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void msg4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If enabled after cleaning the rescan will appear displaying read only items, if not the cleaner will display a list of deleted items.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void msg5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enable Windows options on main form on load.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void msg6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enabled advanced options on main form on load.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void msg7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enable application options on main form on load.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void msg8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("When the cleaning process has been completed the Axolotl will close and a log file will be displayed.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void msg9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Show Edge Chromium privacy options, on the main form.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void msg10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Show Google Chrome privacy options, on the main form.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void msg11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Show Firefox privacy options, on the main form.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void msg12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click the go to path button on the right.\nOnce you are there copy the folder name that ends with release.\nPaste the folder name into the textbox and click save!\n\nIf you don't do this you will have trouble cleaning and scanning Firefox information...", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FirefoxPath = guna2TextBox1.Text;
            Properties.Settings.Default.Save();

            MessageBox.Show("Firefox path has now been updated!", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Mozilla\Firefox\Profiles\");
        }

        private void startup_CheckedChanged(object sender, EventArgs e)
        {
            if (startup.Checked == true)
            {
                Helper.Utils.SetStartup(true);
            }
            else if (startup.Checked == false)
            {
                Helper.Utils.SetStartup(false);
            }
        }

        private void Sid_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Sid = "";
            Properties.Settings.Default.Save();
        }

        private void Cpu_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Cpu = "";
            Properties.Settings.Default.Save();
        }

        private void System_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Windows = "";
            Properties.Settings.Default.Save();
        }

        private void Gpu_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Gpu = "";
            Properties.Settings.Default.Save();
        }

        private void Ram_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Ram = "";
            Properties.Settings.Default.Save();
        }
    }
}
