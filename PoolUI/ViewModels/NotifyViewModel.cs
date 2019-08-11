using Caliburn.Micro;
using PoolApiClientLibrary;
using PoolApiClientLibrary.Models;
using PoolUI.Models;
using PoolUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoolUI.ViewModels
{
    class NotifyViewModel
    {
        static IWindowManager _windowManager;
        static NotifyIcon notifyIcon = new NotifyIcon();
        static PoolSettings poolSettings = new PoolSettings();
        static MinerStatistics Stats = new MinerStatistics();

        public static decimal ReportedHashrate { get; set; }

        public NotifyViewModel()
        {
            GetPoolData();
            GetPoolStats();

            notifyIcon.Icon = Properties.Resources.NotReadyIcon;
            notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += new MouseEventHandler(NotifyIcon_DoubleClick);
            notifyIcon.MouseMove += new MouseEventHandler(NotifyIcon_Hover);

            ContextMenuStrip notifyIconContextMenu = new ContextMenuStrip();
            notifyIconContextMenu.Items.Add(ToolStripMenuItemWithHandler("Miner &Status", "Show a pool dashboard", ShowDashboard));
            notifyIconContextMenu.Items.Add(ToolStripMenuItemWithHandler("&Settings", "Settings", ShowSettings));
            notifyIconContextMenu.Items.Add(new ToolStripSeparator());
            notifyIconContextMenu.Items.Add(ToolStripMenuItemWithHandler("&Exit", "Exit", ExitItem_Click));
            notifyIcon.ContextMenuStrip = notifyIconContextMenu;           
        }

        private void NotifyIcon_DoubleClick(object sender, MouseEventArgs e)
        {
            ShowDashboard(sender, e);
        }

        private void NotifyIcon_Hover(object sender, MouseEventArgs e)
        {
            notifyIcon.Text = $"Mining Pool Monitor \nReported Hashrate: {ReportedHashrate}MH/s";
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ShowSettings(object sender, EventArgs e)
        {
            if (_windowManager == null)
            {
                _windowManager = new WindowManager();

                _windowManager.ShowDialog(new SettingsViewModel(), null, null);

                _windowManager = null;
            }
        }

        private void ShowDashboard(object sender, EventArgs e)
        {
            if (_windowManager == null)
            {
                _windowManager = new WindowManager();

                _windowManager.ShowDialog(new DashboardViewModel(Stats, poolSettings), null, null);

                _windowManager = null;
            }
        }

        public static async void GetPoolData()
        {

            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MiningPoolMonitor\\config.cfg");


            poolSettings = FileProcessor.ReadFile(poolSettings, filePath);
           
            Stats = await Task.Run(() => PoolStatusProccesor.GetPoolStats(poolSettings.MinerAddress, poolSettings.Pool));

            //if (_windowManager != null)
            //{
            //    DashboardViewModel dVm = new DashboardViewModel(Stats, poolSettings);
            //    dVm.BindPoolData(Stats);
            //}


            if (Stats != null)
            {
                ReportedHashrate = Stats.ReportedHashrate;

                if (ReportedHashrate < poolSettings.MinHeshRate)
                {
                    notifyIcon.Icon = Properties.Resources.NotReadyIcon;
                    notifyIcon.ShowBalloonTip(500, "Warning", "Low Hash-rate!", ToolTipIcon.Warning);
                }
                else
                {
                    notifyIcon.Icon = Properties.Resources.ReadyIcon;
                }
            }
            else
            {
                ReportedHashrate = 0;
                notifyIcon.Icon = Properties.Resources.NotReadyIcon;
                notifyIcon.ShowBalloonTip(500, "Error", "No connection!", ToolTipIcon.Error);
            }
        }

        private void GetPoolStats()
        {
            System.Timers.Timer timer;
            timer = new System.Timers.Timer(poolSettings.RefreshTime * 60000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(GetPoolStats_Tick);
            timer.AutoReset = true;
            timer.Enabled = true;


        }
        public void GetPoolStats_Tick(object sender, EventArgs e)
        {
            GetPoolData();
        }

        public static void RegisterInStartUp()
        {
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                Assembly curAssembly = Assembly.GetExecutingAssembly();
                var appName = curAssembly.GetName().Name;
                if (poolSettings.Startup)
                {
                    key.SetValue(appName, curAssembly.Location);
                }
                else
                {
                    key.DeleteValue(appName);
                }
                
            }
            catch { }
        }

        private ToolStripMenuItem ToolStripMenuItemWithHandler(string displayText, string tooltipText, EventHandler eventHandler)
        {
            var item = new ToolStripMenuItem(displayText);
            if (eventHandler != null)
            {
                item.Click += eventHandler;
            }

            item.ToolTipText = tooltipText;
            return item;
        }
    }
}

