using Caliburn.Micro;
using Newtonsoft.Json;
using PoolApiClientLibrary;
using PoolUI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace PoolUI
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {           
            Initialize(); 
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<NotifyViewModel>();
        }      
    }
}
