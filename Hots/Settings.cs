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
        public static string ThisLocation { get; set; }
        public static List<Location> LocList { get; set; }
        public static List<OrderSystem> OrdSysList { get; set; }

        internal static void SetSettingsFromReadFile(LocalSettings _savedSet, string _iniFile, string _connString)
        {
            iniFile = _iniFile;
            if (_savedSet == null)
            {
                ConnString = _connString;
                ThisLocation = "Please select Store";
            }
           else
            {
                ConnString = _savedSet.ConnString;
                ThisLocation = _savedSet.SelectedPickupLocation;
            }
        }

        public static bool MakeOrdSysList()
        {
            OrdSysList = new List<OrderSystem>();
            var osNames = Enum.GetValues(typeof(Set.OrdSysName));
            UInt32 i = 0;
            foreach (Set.OrdSysName name in osNames)
            {
                if (name.ToString() != "Null")
                {
                    var os = new OrderSystem();
                    os.Id = i;
                    os.Name = name;
                    OrdSysList.Add(os);
                    i++;
                }
            }
            return (OrdSysList.Count == 3) ? true : false;
        }

        public static void SaveSettings()
        {
            LocalSettings saveSet = new LocalSettings();
            saveSet.ConnString = Set.ConnString;
            saveSet.SelectedPickupLocation = Set.ThisLocation;
            saveSet.LocOrdSysSetList = new List<LocOrdSysSettings>();
            foreach (var os in Set.OrdSysList)
            {
                var locOrdSysSet = new LocOrdSysSettings();
                locOrdSysSet.Id = os.Id;
                locOrdSysSet.WchFldr = os.WatchedFolder;
                locOrdSysSet.OutFldr = os.OutputFolder;
                locOrdSysSet.LabInFldr = os.LabInFldr;
                locOrdSysSet.Active = os.Active;
                saveSet.LocOrdSysSetList.Add(locOrdSysSet);
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
            try
            {
                LocalSettings lset;
                var serializer = new XmlSerializer(typeof(LocalSettings));
                using (var stream = new StreamReader(iniFile))
                {
                    lset = (LocalSettings)(serializer.Deserialize(stream));
                }
                Data.LogEvents(1, "Local settings loaded");
                return lset;
            }
            catch
            {
                Data.LogEvents(0, "**ERROR** reading Local settings file");
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
