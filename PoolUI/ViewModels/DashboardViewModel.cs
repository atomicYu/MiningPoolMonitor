using Caliburn.Micro;
using Newtonsoft.Json;
using PoolApiClientLibrary;
using PoolApiClientLibrary.Models;
using PoolUI.Models;
using PoolUI.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace PoolUI.ViewModels
{
    public class DashboardViewModel : Caliburn.Micro.Screen
    {
        private PoolSettings _poolSettings;
        #region props
        private decimal _reportedHashrate;
        private decimal _averageHashrate;
        private decimal _currentHashrate;
        private int _activeWorkers;
        private int _validShares;
        private int _invalidShares;
        private int _staleShares;
        private decimal _unpaid;
        private decimal _usdPerMonth;
        private string _minerStatus;

        private string _minerStatusColor;

        public string MinerStatusColor
        {
            get { return _minerStatusColor; }
            set
            {
                _minerStatusColor = value;
                NotifyOfPropertyChange(() => MinerStatusColor);
            }
        }
        public string MinerStatus
        {
            get { return _minerStatus; }
            set
            {
                _minerStatus = value;
                NotifyOfPropertyChange(() => MinerStatus);
            }
        }
        public decimal ReportedHashrate
        {
            get { return _reportedHashrate; }
            set
            {
                _reportedHashrate = value;
                NotifyOfPropertyChange(() => ReportedHashrate);
            }
        }
        public decimal AverageHashrate
        {
            get { return _averageHashrate; }
            set
            {
                _averageHashrate = value;
                NotifyOfPropertyChange(() => AverageHashrate);
            }
        }
        public decimal CurrentHashrate
        {
            get { return _currentHashrate; }
            set
            {
                _currentHashrate = value;
                NotifyOfPropertyChange(() => CurrentHashrate);
            }
        }
        public int ActiveWorkers
        {
            get { return _activeWorkers; }
            set
            {
                _activeWorkers = value;
                NotifyOfPropertyChange(() => ActiveWorkers);
            }
        }
        public int ValidShares
        {
            get { return _validShares; }
            set
            {
                _validShares = value;
                NotifyOfPropertyChange(() => ValidShares);
            }
        }
        public int InvalidShares
        {
            get { return _invalidShares; }
            set
            {
                _invalidShares = value;
                NotifyOfPropertyChange(() => InvalidShares);
            }
        }
        public int StaleShares
        {
            get { return _staleShares; }
            set
            {
                _staleShares = value;
                NotifyOfPropertyChange(() => StaleShares);
            }
        }
        public decimal Unpaid
        {
            get { return _unpaid; }
            set
            {
                _unpaid = value;
                NotifyOfPropertyChange(() => Unpaid);
            }
        }
        public decimal USDPerMonth
        {
            get { return _usdPerMonth; }
            set
            {
                _usdPerMonth = Math.Round(value * 43200, 2); ;
                NotifyOfPropertyChange(() => USDPerMonth);
            }
        }
        #endregion

        public DashboardViewModel(MinerStatistics Stats, PoolSettings poolSettings)
        {
            _poolSettings = poolSettings;
            BindPoolData(Stats);
        }

       public void BindPoolData(MinerStatistics Stats)
        {            
            if (Stats != null)
            {
                ReportedHashrate = Stats.ReportedHashrate;
                AverageHashrate = Stats.AverageHashrate;
                CurrentHashrate = Stats.CurrenyHashrate;
                ActiveWorkers = Stats.ActiveWorkers;
                ValidShares = Stats.ValidShares;
                InvalidShares = Stats.InvalidShares;
                StaleShares = Stats.StaleShares;
                Unpaid = Stats.Unpaid;
                USDPerMonth = Stats.USDPerMin;
                if (ReportedHashrate < _poolSettings.MinHeshRate)
                {
                    MinerStatus = "LOW HASH-RATE";
                    MinerStatusColor = "Yellow";
                }
                else
                {
                    MinerStatus = "WORKING PROPERLY";
                    MinerStatusColor = "#FF069FD8";                    
                }
            }
            else
            {
                ReportedHashrate = 0;
                AverageHashrate = 0;
                CurrentHashrate = 0;
                ActiveWorkers = 0;
                ValidShares = 0;
                InvalidShares = 0;
                StaleShares = 0;
                Unpaid = 0;
                USDPerMonth = 0;
                MinerStatus = "LOW HASH-RATE";
                MinerStatusColor = "Yellow";
            }            
        }
        
        public void CloseBtn()
        {
            TryClose();
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

