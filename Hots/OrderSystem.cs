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
        public string Name { get; set; }
        public string WatchFldr { get; set; }
        public string Ext { get; set; }
        public string ReadFld { get; set; }
        public string OutFldr { get; set; }
        public string PrdSubFldr { get; set; }
        public string WaitFile { get; set; }
        public bool WaitIsFldr { get; set; }
        public bool Active { get; set; }
      
    }

    public class OrderSysList
    {
        string IniFile = Directory.GetCurrentDirectory() + @"\HotsSettings.xml";
        List<OrderSystem> osList;
        public List<OrderSystem> List { get; set; }

        public OrderSysList getOrdSysList()
        {
            if (osList == null) // get or create blank list if not exists, else return existing list
            {
                osList = new List<OrderSystem>();
                try
                {
                    ReadWrite.ReadXML(osList, IniFile);
                }
                catch
                {
                    var os = new OrderSystem();
                    osList.Add(os);
                }
            }
            List = osList;
            return this;
        }

        public void SaveOrdSysList()
        {
            ReadWrite.WriteXML(osList, IniFile);

        }


    }
    public static class ReadWrite
    {
        public static void WriteXML(this List<OrderSystem> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<OrderSystem>));
            using (var stream = File.OpenWrite(fileName))
            {
                serializer.Serialize(stream, list);
            }
        }

        public static void ReadXML(this List<OrderSystem> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<OrderSystem>));
            using (var stream = File.OpenRead(fileName))
            {
                var other = (List<OrderSystem>)(serializer.Deserialize(stream));
                list.Clear();
                list.AddRange(other);
            }
        }
    }


}

