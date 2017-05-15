using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace Hots
{
    static class Set
    {
        private static string iniFile = Directory.GetCurrentDirectory() + @"\HotsSavedData.xml";
        public static Form1 MainForm;
        public static string ConnString = "server=69.89.31.188;user=hitephot_don;database=hitephot_hots;port=3306;password=Hite1985;";
        public static string SelectedStore { get; set; }
        public static List<OrderSystem> ListOrdSys { get; set; }

        public static void CreateDefaultSettings()
        {
            DialogResult result = MessageBox.Show("create default settings file?",
                            "Settings file read error", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                Environment.Exit(1);

            SelectedStore = "Please select Store";
            ListOrdSys = new List<OrderSystem>();
            foreach (OrderSystem.OrdSysName name in Enum.GetValues(typeof(OrderSystem.OrdSysName)))
            {
                if (name.ToString() != "Null")
                {
                    var os = new OrderSystem();
                    os.Name = name;
                    ListOrdSys.Add(os);
                }
            }
        }

        public static bool LoadSettings()
        {
            SaveSettings savedSet = Hots.SaveSettings.readSettingsfromDisk(iniFile);
            if (savedSet != null)
            {
                ConnString = savedSet.ConnString;
                SelectedStore = savedSet.SelectedStore;
                ListOrdSys = new List<OrderSystem>();
                foreach (var savedOrdSys in savedSet.OrdSysList)
                {
                    var os = new OrderSystem();
                    os.Name = savedOrdSys.Name;
                    os.Active = savedOrdSys.Active;
                    os.WatchFldr = savedOrdSys.WchFldr;
                    os.Ext = savedOrdSys.Ext;
                    os.OutFldr = savedOrdSys.OutFldr;
                    os.PrdSubFldr = savedOrdSys.PrdSubFldr;
                    os.WaitFile = savedOrdSys.WaitFile;
                    os.WaitIsFldr = savedOrdSys.WaitIsFldr;
                    ListOrdSys.Add(os);
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
            SaveSettings saveSet = new SaveSettings();
            saveSet.ConnString = Set.ConnString;
            saveSet.SelectedStore = Set.SelectedStore;
            saveSet.OrdSysList = new List<SaveOrdSystems>();
            foreach (var os in Set.ListOrdSys)
            {
                var sOs = new SaveOrdSystems();
                sOs.Name = os.Name;
                sOs.Active = os.Active;
                sOs.WchFldr = os.WatchFldr;
                sOs.Ext = os.Ext;
                sOs.OutFldr = os.OutFldr;
                sOs.PrdSubFldr = os.PrdSubFldr;
                sOs.WaitFile = os.WaitFile;
                sOs.WaitIsFldr = os.WaitIsFldr;
                saveSet.OrdSysList.Add(sOs);
            }
            if(Hots.SaveSettings.WriteSettingsToDisk(saveSet, Set.iniFile))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
    


    [Serializable]
     public class SaveSettings
    {
        public string ConnString;
        public string SelectedStore;
        public List<SaveOrdSystems> OrdSysList { get; set; }

        public static SaveSettings readSettingsfromDisk(string iniFile)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(SaveSettings));
                using (var stream = new StreamReader(iniFile))
                {
                    return (SaveSettings)(serializer.Deserialize(stream));
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool WriteSettingsToDisk(SaveSettings locSet, string iniFile)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(SaveSettings));
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

    [XmlInclude(typeof(SaveOrdSystems))]
    public class SaveOrdSystems
    {
        public OrderSystem.OrdSysName Name;
        public bool Active;
        public string WchFldr;
        public string Ext;
        public string OutFldr;
        public string PrdSubFldr;
        public string WaitFile;
        public bool WaitIsFldr;
    }
}
