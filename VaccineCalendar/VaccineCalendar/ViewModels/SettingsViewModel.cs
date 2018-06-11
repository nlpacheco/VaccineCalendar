using VaccineCalendar.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VaccineCalendar.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public Command SaveSettingsCommand { get; set; }

        private bool _syncCanUse3G;

        public bool SyncCanUse3G
        {
            get { return _syncCanUse3G; }
            set { _syncCanUse3G = value; }
        }


        public SettingsViewModel()
        {

        }

        public Task InitializeAsync(object navigationData)
        {
            return Task.Factory.StartNew(() => SyncCanUse3G = Settings.SyncCanUse3G);



        }
    }
}