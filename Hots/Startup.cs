using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hots
{
    class Startup
    {
        private static string iniFile = Directory.GetCurrentDirectory() + @"\HotsSavedData.xml";
        private static string connString = "server=69.89.31.188;uid=hitephot_don;database=hitephot_hots;port=3306;password=Hite1985;";
        private static LocalSettings savedSet;

        public static void DoStartUp()
        {
            Data.LogEvents(1, "Hots Downloader started");
            try
            {
                savedSet = Hots.LocalSettings.readSettingsfromDisk(iniFile);
                Set.PickupLoc = savedSet.SelectedPickupLocation;
                Set.SetConnString(savedSet);
                Data.LogEvents(1, "Local settings loaded successfully");
            }
            catch
            {
                try
                {
                    Set.CreateDefaultSettings(iniFile, connString);
                    Set.SaveSettings();
                    Data.LogEvents(1, "Default local settings created and saved");
                }
                catch
                {
                    Data.LogEvents(0, "Error creating new settings file");
                    MessageBox.Show("Error saving settings");
                    Environment.Exit(1);
                }
            }

            try
            {
                Set.PickupLocList = Data.GetPickupLocListFromServer();
            }
            catch
            {
                MessageBox.Show("Error getting Pickup Loc List from server");
                Environment.Exit(1);
            }
            try
            {
                Set.OrdSysList = Data.GetOrdSysListFromServer();
            }
            catch
            {
                MessageBox.Show("Error getting Order Sys List from server");
                Environment.Exit(1);
            }
            try
            {
                Set.FillOrdSysWithSavedPaths(Set.OrdSysList, savedSet);
            }
            catch
            {
                MessageBox.Show("Error filling Set with web data");
                Environment.Exit(1);
            }
            try
            {
                Watchers.MakeFolderWatchers();
            }
            catch
            {
                MessageBox.Show("Error making folder watchers");
                Environment.Exit(1);
            }
        }
    }
}
