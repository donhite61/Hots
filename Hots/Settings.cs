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
        private static string iniFile;
        public enum OrdSysName { Null, Roes, Dakis, DGift }
        public static Form1 MainForm;
        public static string ConnString { get; private set; }
        public static string PickupLoc { get; set; }
        public static List<PickupLocation> PickupLocList { get; set; }
        public static List<OrderSystem> OrdSysList { get; set; }

        public static void CreateDefaultSettings(string _iniFile, string _connString)
        {
            DialogResult result = MessageBox.Show("create default settings file?",
                            "Settings file read error", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                throw new Exception();

            ConnString = _connString;
            iniFile = _iniFile;
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

        internal static void FillOrdSysWithSavedPaths(List<OrderSystem> ordSysList, LocalSettings savedSet)
        {
            foreach (LocOrdSysSettings locOs in savedSet.LocOrdSysSetList)
            {
                foreach (OrderSystem os in Set.OrdSysList)
                {
                    if (os.Id == locOs.Id)
                    {
                        os.WatchFldr = locOs.WchFldr;
                        os.OutFldr = locOs.OutFldr;
                        os.LabInFldr = locOs.LabInFldr;
                        os.Active = locOs.Active;
                        os.PuKeyWords = Data.GetKeywordListFromServerByOrdSys(os.Name);

                    }
                }
            }
        }

        public static void SaveSettings()
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
            Hots.LocalSettings.WriteSettingsToDisk(saveSet, Set.iniFile);
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
            LocalSettings lset;
            var serializer = new XmlSerializer(typeof(LocalSettings));
            using (var stream = new StreamReader(iniFile))
            {
                lset = (LocalSettings)(serializer.Deserialize(stream));
            }
            return lset;
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
