using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Data;

namespace Hots
{
    public static class Set
    {
        private static string iniFile = Directory.GetCurrentDirectory() + @"\HotsSavedData.xml";
        public enum OrdSysName { Null, Roes, Dakis, DGift }
        public static Form1 MainForm;
        public static string ConnString { get; private set; }
        public static string PickupLoc { get; set; }
        public static List<PickupLocation> PickupLocList { get; set; }
        public static List<OrderSystem> OrdSysList { get; set; }

        public static void CreateDefaultSettings()
        {
            DialogResult result = MessageBox.Show("create default settings file?",
                            "Settings file read error", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                Environment.Exit(1);

            ConnString = "server=69.89.31.188;uid=hitephot_don;database=hitephot_hots;port=3306;password=Hite1985;";
            PickupLoc = "Please select Store";
            OrdSysList = new List<OrderSystem>();
            foreach (Set.OrdSysName name in Enum.GetValues(typeof(Set.OrdSysName)))
            {
                if (name.ToString() != "Null")
                {
                    var os = new OrderSystem();
                    os.Name = name;
                    OrdSysList.Add(os);
                }
            }
        }

        public static void SetConnString(LocalSettings savedSet)
        {
            ConnString = savedSet.ConnString;
        }

        public static bool LoadSettings()
        {
            LocalSettings savedSet = Hots.LocalSettings.readSettingsfromDisk(iniFile);
            if (savedSet != null)
            {
                ConnString = savedSet.ConnString;
                PickupLoc = savedSet.SelectedPickupLocation;
                OrdSysList = new List<OrderSystem>();
                foreach (var savedOrdSys in savedSet.LocOrdSysSetList)
                {
                    var os = new OrderSystem();
                    os.Id = savedOrdSys.Id;
                    os.WatchFldr = savedOrdSys.WchFldr;
                    os.OutFldr = savedOrdSys.OutFldr;
                    os.LabInFldr = savedOrdSys.LabInFldr;
                    os.Active = savedOrdSys.Active;
                    OrdSysList.Add(os);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool SaveSettings()
        {
            LocalSettings saveSet = new LocalSettings();
            saveSet.ConnString = Set.ConnString;
            saveSet.SelectedPickupLocation = Set.PickupLoc;
            saveSet.LocOrdSysSetList = new List<LocOrdSysSettings>();
            foreach (var os in Set.OrdSysList)
            {
                var locOrdSysSet = new LocOrdSysSettings();
                locOrdSysSet.Id = os.Id;
                locOrdSysSet.WchFldr = os.WatchFldr;
                locOrdSysSet.OutFldr = os.OutFldr;
                locOrdSysSet.LabInFldr = os.PrdSubFldr;
                locOrdSysSet.Active = os.Active;
            }
            return Hots.LocalSettings.WriteSettingsToDisk(saveSet, Set.iniFile) ? true : false;
            //if (Hots.LocalSettings.WriteSettingsToDisk(saveSet, Set.iniFile))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }


    [Serializable]
     public class LocalSettings
    {
        public string ConnString;
        public string SelectedPickupLocation;
        public List<LocOrdSysSettings> LocOrdSysSetList { get; set; }

        public static LocalSettings readSettingsfromDisk(string iniFile)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(LocalSettings));
                using (var stream = new StreamReader(iniFile))
                {
                    return (LocalSettings)(serializer.Deserialize(stream));
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool WriteSettingsToDisk(LocalSettings locSet, string iniFile)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(LocalSettings));
                using (var stream = new StreamWriter(iniFile))
                {
                    serializer.Serialize(stream, locSet);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    [XmlInclude(typeof(LocOrdSysSettings))]
    public class LocOrdSysSettings
    {
        public UInt32 Id;
        public string WchFldr;
        public string OutFldr;
        public string LabInFldr;
        public bool Active;
    }
}
