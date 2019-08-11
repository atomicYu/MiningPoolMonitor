using Caliburn.Micro;
using Newtonsoft.Json;
using PoolApiClientLibrary;
using PoolUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PoolUI.ViewModels
{
    public class SettingsViewModel : Screen
    {
        readonly string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MiningPoolMonitor\\config.cfg");

        private PoolSettings _poolSet = new PoolSettings();

        public BindableCollection<string> _pools = new BindableCollection<string>();

        private string _selectedPool;

        public string SelectedPool
        {
            get { return _selectedPool; }
            set
            {
                _selectedPool = value;
                NotifyOfPropertyChange(() => SelectedPool);
            }
        }

        public BindableCollection<string> Pools
        {
            get { return _pools; }
            set { _pools = value; }
        }

        public PoolSettings PoolSet
        {
            get { return _poolSet; }
            set { _poolSet = value; }
        }

        public SettingsViewModel()
        {
            Pools.Add("Ethermine");
            Pools.Add("Ethpool");
            Pools.Add("Flypool");

            ReadSettings();
        }

        public void SaveSettings()
        {
            FileProcessor.WriteFile(_poolSet, filePath);

            NotifyViewModel.GetPoolData();
            NotifyViewModel.RegisterInStartUp();
            TryClose();
        }

        public void ReadSettings()
        {
            PoolSet = FileProcessor.ReadFile(_poolSet, filePath);

            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MiningPoolMonitor")))
            {
                try
                {
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MiningPoolMonitor"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
