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
        IEnumerable<string> lines;
         string IniFile = Directory.GetCurrentDirectory() + @"\HotsSettings.ini";
        List<OrderSystem> osList;
        public List<OrderSystem> List { get; set; }

        public OrderSysList getOSList()
        {
            if (osList == null)
            {
                if (File.Exists(IniFile))
                    lines = File.ReadLines(IniFile);

                osList = new List<OrderSystem>();
                var os = new OrderSystem();
                osList.Add(os);
                os = new OrderSystem();
                os.Name = "Dakis ";
                osList.Add(os);
                os = new OrderSystem();
                os.Name = "DGift";
                osList.Add(os);
                
            }
            MyClass.SerializeObject(osList, "car.xml");
            List = osList;
            return this;
        }


    }
    public static class MyClass
    {
        public static void SerializeObject(this List<OrderSystem> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<OrderSystem>));
            using (var stream = File.OpenWrite(fileName))
            {
                serializer.Serialize(stream, list);
            }
        }

        public static void Deserialize(this List<OrderSystem> list, string fileName)
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

