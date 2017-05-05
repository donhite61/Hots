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
    public class Set
    {
        public static string WchRoot { get; set; }
        public static string ConnString { get; set; }
        public static List<OrderSystem> ListOrdSys { get; set; }

        public static string iniFile = Directory.GetCurrentDirectory() + @"\HotsSettings.xml";
        public string prvWchRoot;
        public string prvConnString;
        public List<OrderSystem> prvListOrdSys;

        protected Set()
        {
        }

        public static void SaveSettings()
        {
            var instance = new Set();
            instance.prvWchRoot = WchRoot;
            instance.prvConnString = ConnString;
            instance.prvListOrdSys = ListOrdSys;

            var serializer = new XmlSerializer(typeof(Set));
            using (var stream = new StreamWriter(iniFile))
            {
                serializer.Serialize(stream, instance);
            }
        }

        public static void LoadSettings()
        {
            try
            {
                readSettingsfromDisk();
            }
            catch
            {
                CreateDefaultSettings();
                SaveSettings();
            }
        }

        private static void readSettingsfromDisk()
        {
            var serializer = new XmlSerializer(typeof(Set));
            using (var stream = new StreamReader(iniFile))
            {
                Set instance = (Set)(serializer.Deserialize(stream));
                WchRoot = instance.prvWchRoot;
                if (WchRoot == null)
                    throw new Exception();
                ConnString = instance.prvConnString;
                if (ConnString == null)
                    throw new Exception();
                ListOrdSys = instance.prvListOrdSys;
                if (ListOrdSys == null)
                    throw new Exception();
            }
        }

        private static void CreateDefaultSettings()
        {
            ListOrdSys = new List<OrderSystem>();
            WchRoot = "Set this folder to start";
            ConnString = "server=69.89.31.188;user=hitephot_don;database=hitephot_hots;port=3306;password=Hite1985;";
            var roesOrdSys = new OrdSysRoes();
            var dakisOrdSys = new OrdSysDakis();
            var dGiftOrdSys = new OrdSysDGift();
            ListOrdSys.Add(roesOrdSys);
            ListOrdSys.Add(dakisOrdSys);
            ListOrdSys.Add(dGiftOrdSys);
        }
    }
}
