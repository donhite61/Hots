using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace Hots
{
    [Serializable]
    public class Settings
    {
        protected static Settings instance;
        protected static string iniFile = Directory.GetCurrentDirectory() + @"\HotsSettings.xml";

        public string WchRoot { get; set; }
        public List<OrderSystem> ListOrdSys { get; set; }

        protected Settings()
        {
        }

        public static Settings GetSettings()
        {
            if (instance == null)
            {
                try
                {
                    readSettingsfromDisk();
                }
                catch
                {
                    CreateDefaultSettings();
                }
            }
            return instance;
        }

        public static void SaveSettings(Settings _set)
        {
            instance.WchRoot = _set.WchRoot;
            for (var i=0; i< instance.ListOrdSys.Count; i++)
            {
                instance.ListOrdSys[i].Active = _set.ListOrdSys[i].Active;
                instance.ListOrdSys[i].WatchFldr = _set.ListOrdSys[i].WatchFldr;
                instance.ListOrdSys[i].Ext = _set.ListOrdSys[i].Ext;
                instance.ListOrdSys[i].ReadFld = _set.ListOrdSys[i].ReadFld;
                instance.ListOrdSys[i].OutFldr = _set.ListOrdSys[i].OutFldr;
                instance.ListOrdSys[i].PrdSubFldr = _set.ListOrdSys[i].PrdSubFldr;
                instance.ListOrdSys[i].WaitFile = _set.ListOrdSys[i].WaitFile;
                instance.ListOrdSys[i].WaitIsFldr = _set.ListOrdSys[i].WaitIsFldr;
            }
            writeSettingstoDisk();
        }

        private static void CreateDefaultSettings()
        {
            instance = new Settings();
            instance.ListOrdSys = new List<OrderSystem>();
            instance.WchRoot = "";
            var RoesOrdSys = new OrdSysRoes();
            var DakisOrdSys = new OrdSysDakis();
            var DGiftOrdSys = new OrdSysDGift();
            instance.ListOrdSys.Add(RoesOrdSys);
            instance.ListOrdSys.Add(DakisOrdSys);
            instance.ListOrdSys.Add(DGiftOrdSys);
            writeSettingstoDisk();
        }

        private static void writeSettingstoDisk()
        {
            var serializer = new XmlSerializer(typeof(Settings));
            using (var stream = new StreamWriter(iniFile))
            {
                serializer.Serialize(stream, instance);
            }
        }

        private static void readSettingsfromDisk()
        {
            var serializer = new XmlSerializer(typeof(Settings));
            using (var stream = new StreamReader(iniFile))
            {
                instance = (Settings)(serializer.Deserialize(stream));
            }
        }
    }
}
