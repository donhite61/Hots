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

        public static void DoStartUp()
        {
            Data.LogEvents(1, "Hots Downloader started");
            LocalSettings savedSet = Hots.LocalSettings.readSettingsfromDisk(iniFile);
            if (!Set.LoadSettings())
            {
                Set.CreateDefaultSettings();
                if (!Set.SaveSettings())
                {
                    Data.LogEvents(0, "Error creating new settings file");
                    MessageBox.Show("Error saving settings");
                    Environment.Exit(1);
                }
                else
                {
                    Data.LogEvents(1, "Default settings created and saved");
                }
            }
            else
            {
                Data.LogEvents(1, "Settings loaded successfully");
            }
            Set.SetConnString(savedSet);
            Set.PickupLocList = Data.GetPickupLocListFromServer();
            Set.OrdSysList = Data.GetOrdSysListFromServer();
            foreach (OrderSystem os in Set.OrdSysList)
            {
                foreach (LocOrdSysSettings locOs in savedSet.LocOrdSysSetList)
                {
                    if (os.Id == locOs.Id)
                    {
                        os.WatchFldr = locOs.WchFldr;
                        os.OutFldr = locOs.OutFldr;
                        os.LabInFldr = locOs.LabInFldr;
                        os.Active = locOs.Active;
                    }
                }
                os.PuKeyWords = Data.GetKeywordListFromServerByOrdSys(os.Name);
            }
            Watchers.MakeFolderWatchers();
        }
    }
}
