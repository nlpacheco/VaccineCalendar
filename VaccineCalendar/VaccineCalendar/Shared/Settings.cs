using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace VaccineCalendar.Shared
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string syncCanUse3GKey= "syncCanUse3G";
        private static readonly bool syncCanUse3G = false;

        #endregion


        public static bool SyncCanUse3G
        {
            get
            {
                return AppSettings.GetValueOrDefault(syncCanUse3GKey, syncCanUse3G);
            }
            set
            {
                AppSettings.AddOrUpdateValue(syncCanUse3GKey, value);
            }
        }

        public static bool DebugMode
        {
            get
            {
                return true;
            }
        }

    }
}
