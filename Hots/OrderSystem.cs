using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Hots
{
    [Serializable]
    public class OrderSystem
    {
        public bool Active { get; set; }
        public string Name { get; set; }
        public string WatchFldr { get; set; }
        public string Ext { get; set; }
        public string ReadFld { get; set; }
        public string OutFldr { get; set; }
        public string PrdSubFldr { get; set; }
        public string WaitFile { get; set; }
        public bool WaitIsFldr { get; set; }
       
      
    }

    public class OrderSysList // this class follows the "singleton" pattern (not thread safe?)
    {
        private static string IniFile = Directory.GetCurrentDirectory() + @"\HotsSettings.xml";
        private static List<OrderSystem> osList;

        protected OrderSysList()
        {
        }

        public static List<OrderSystem> getOrdSysList()
        {
            if (osList == null) // get or create blank list if not exists, else return existing list
            {
                osList = new List<OrderSystem>();
                try
                {
                    ReadWrite.ReadOrdSys(osList, IniFile);
                }
                catch
                {
                    var osR = new OrderSystem();
                    var osD = new OrderSystem();
                    var osG = new OrderSystem();

                    osR.Name = "Roes";
                    osR.WatchFldr = "RoesIn";
                    osR.Ext = "pov";
                    osR.ReadFld = "ReadOrders";
                    osR.OutFldr = "";
                    osR.PrdSubFldr = "none";
                    osR.WaitFile = "Originals";
                    osR.WaitIsFldr = true;
                    osR.Active = false;
                   
                    osD.Name = "Dakis Photo";
                    osD.WatchFldr = "DakisIn";
                    osD.Ext = "xml";
                    osD.ReadFld = "ReadOrders";
                    osD.OutFldr = "";
                    osD.PrdSubFldr = "prints";
                    osD.WaitFile = "metadata\\download_complete";
                    osD.WaitIsFldr = false;
                    osD.Active = false;

                    osG.Name = "Dakis Gift";
                    osG.WatchFldr = "Dakis Gift In";
                    osG.Ext = "xml";
                    osG.ReadFld = "ReadOrders";
                    osG.OutFldr = "";
                    osG.PrdSubFldr = "photo_products";
                    osG.WaitFile = "metadata\\download_complete";
                    osG.WaitIsFldr = false;
                    osG.Active = false;

                    osList.Add(osR);
                    osList.Add(osD);
                    osList.Add(osG);
                    SaveOrdSysList();
                }
            }
            return osList;
        }

        public static void SaveOrdSysList()
        {
            ReadWrite.WriteOrdSys(osList, IniFile);
        }

        public static void UpdateOrdSysInOrdSysList(OrderSystem _ordSys)
        {
            for (int i = 0; i < osList.Count; i++)
            {
                if (osList[i].Name == _ordSys.Name)
                {
                    osList[i].WatchFldr = _ordSys.WatchFldr;
                    osList[i].Ext = _ordSys.Ext;
                    osList[i].ReadFld = _ordSys.ReadFld;
                    osList[i].OutFldr = _ordSys.OutFldr;
                    osList[i].PrdSubFldr = _ordSys.PrdSubFldr;
                    osList[i].WaitFile = _ordSys.WaitFile;
                    osList[i].Active = _ordSys.Active;
                    osList[i].WaitIsFldr = _ordSys.WaitIsFldr;
                    SaveOrdSysList();
                }

            }

        }
    }

    [Serializable]
    public class Set
    {
        public static string IniFile = Directory.GetCurrentDirectory() + @"\HotsSettings.ini";

        public static string WchRoot { get; set; }

        public static List<OrderSystem> OrdSysList { get; set; }
    }

    public static class ReadWrite
    {
        public static void WriteOrdSys(this List<OrderSystem> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<OrderSystem>));
            using (var stream = File.OpenWrite(fileName))
            {
                serializer.Serialize(stream, list);
            }
        }

        public static void ReadOrdSys(this List<OrderSystem> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<OrderSystem>));
            using (var stream = File.OpenRead(fileName))
            {
                var OrderSystems = (List<OrderSystem>)(serializer.Deserialize(stream));
                list.Clear();
                list.AddRange(OrderSystems);
            }
        }

        public static void WriteSettings(this List<Set> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Set>));
            using (var stream = File.OpenWrite(fileName))
            {
                serializer.Serialize(stream, list);
            }
        }

        public static void ReadSettings(this List<Set> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Set>));
            using (var stream = File.OpenRead(fileName))
            {
                var OrderSystems = (List<Set>)(serializer.Deserialize(stream));
                list.Clear();
                list.AddRange(OrderSystems);
            }
        }

    }


}

