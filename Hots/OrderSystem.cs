using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Hots
{
    [XmlInclude(typeof(OrdSysRoes)), XmlInclude(typeof(OrdSysDakis)), XmlInclude(typeof(OrdSysDGift))]
    public abstract class OrderSystem
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

    public class OrdSysRoes : OrderSystem
    {
        public OrdSysRoes()
        {
            Active = false;
            Name = "Roes";
            WatchFldr = @"NewOrders\RoesIn";
            Ext = "pov";
            ReadFld = "";
            OutFldr = "";
            PrdSubFldr = "";
            WaitFile = "Originals";
            WaitIsFldr = true;
        }
    }

    public class OrdSysDakis : OrderSystem
    {
        public OrdSysDakis()
        {
            Active = false;
            Name = "Dakis";
            WatchFldr = @"NewOrders\DakisIn";
            Ext = "xml";
            ReadFld = "";
            OutFldr = "";
            PrdSubFldr = "";
            WaitFile = "download_complete";
            WaitIsFldr = false;
        }
    }

    public class OrdSysDGift : OrderSystem
    {
        public OrdSysDGift()
        {
            Active = false;
            Name = "DGift";
            WatchFldr = @"NewOrders\DGiftIn";
            Ext = "xml";
            ReadFld = "";
            OutFldr = "";
            PrdSubFldr = "";
            WaitFile = "download_complete";
            WaitIsFldr = false;
        }
    }
}

