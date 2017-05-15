using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hots
{
    public class Order
    {
        public uint mysqlId { get; set; }
        public string OrdStatus { get; set; }
        public OrderSystem.OrdSysName OrdSysName { get; set; }
        public string HiteId { get; set; }
        public string AlternateId { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeDue { get; set; }
        public Decimal PreTaxTotal { get; set; }
        public string PromoCode { get; set; }
        public Decimal DiscAmount { get; set; }
        public Decimal SalesTax { get; set; }
        public Decimal TotalPrice { get; set; }
        public Boolean PrePaid { get; set; }
        public string LabLabel { get; set; }
        public string Catalog { get; set; }
        public string Fullfillment { get; set; }
        public string OrdLocation { get; set; }
        
        public string ServiceTime { get; set; }
        public string Products { get; set; }

        public string CusId { get; set; }
        public string CusName { get; set; }
        public string CusAddress1 { get; set; }
        public string CusAddress2 { get; set; }
        public string CusCity { get; set; }
        public string CusState { get; set; }
        public string CusZip { get; set; }
        public string CusCountry { get; set; }
        public string CusPhone { get; set; }
        public string CusEmail { get; set; }

        public string BillTo { get; set; }
        public string BillCCName { get; set; }
        public string BillCCAddress { get; set; }
        public string BillCCCity { get; set; }
        public string BillCCState { get; set; }
        public string BillCCZip { get; set; }

        public string ShipMethod { get; set; }
        public decimal ShipCost { get; set; }
        public string ShipTo { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipState { get; set; }
        public string ShipZip { get; set; }
        public string ShipPhone { get; set; }
        public string ShipEmail { get; set; }

        public string PayCCType { get; set; }
        public string PayCCNumber { get; set; }
        public string PayCCcvv { get; set; }
        public string PayCCExp { get; set; }

        public List<OrderItems> ItemsList { get; set; }
        public List<OrderOptions> OrderOptionsList { get; set; }

        private Order()
        {
        }

        public static void CreateNewOrderFromDroppedFile(string filePath)
        {
            string[] words = filePath.Split('\\');
            var fileName = words[words.Length - 1];

            var ordSysName = GetOrdSysNameFromFilepath(filePath);
            if (ordSysName == OrderSystem.OrdSysName.Null)
            {
                Data.LogEvents(0, "Unknown filetype " + fileName + " skipped");
                return;
            }

            var fileLineList = makeListFromFile(filePath);
            if (fileLineList == null)
            {
                Data.LogEvents(0, "Error reading " + fileName + " from disk");
                return;
            }

            var newOrder = new Order();
            newOrder.OrdLocation = Set.SelectedStore;
            newOrder = OrderSystem.MakeOrderFromFileList(ordSysName, fileLineList, newOrder);
            if (newOrder.OrdStatus == "error parsing file")
            {
                Data.LogEvents(0, "Error parsing " + fileName);
                return;
            }

            var sqlId = Data.SaveOrdertoSqlServer(newOrder);
            if (sqlId == 0)
            {
                Data.LogEvents(0, "Error uploading to server " + fileName);
            }
            else
            {
                Data.LogEvents(1, fileName +" Uploaded to server ");
            }
        }

        private static OrderSystem.OrdSysName GetOrdSysNameFromFilepath(string filepath)
        {
            OrderSystem.OrdSysName osn = OrderSystem.OrdSysName.Null;
            foreach (var os in Set.ListOrdSys)
            {
                if(os.fwActive == true)
                    if (filepath.Contains(os.WatchFldr))
                        osn = os.Name;
            }
            return osn;
        }

        private static List<string> makeListFromFile(string _path)
        {
            try
            {
                List<string> readFileList = new List<string>();
                using (StreamReader sr = new StreamReader(_path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        readFileList.Add(line);
                    }
                }
                return readFileList;
            }
            catch
            {
                return null;
            }
           
        }
    }

    public class OrderItems
    {
        public uint MysqlId { get; set; }
        public uint MySqlOrderId { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public int Quant { get; set; }
        public decimal Price { get; set; }
        public decimal LineTotal { get; set; }
        public List<ItemOptions> OptionsList { get; set; }
    }

    public class ItemOptions
    {
        public uint MysqlId { get; set; }
        public uint MySqlOrderId { get; set; }
        public string OptCode { get; set; }
        public string Description { get; set; }
        public int Quant { get; set; }
        public decimal Price { get; set; }
    }

    public class OrderOptions
    {
        public uint MysqlId { get; set; }
        public uint MySqlOrderId { get; set; }
        public string OptCode { get; set; }
        public int Quant { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Text { get; set; }
    }

    public class OrderHeaderShort
    {
        public int mysqlId { get; set; }
        public string HiteId { get; set; }
        public string AlternateId { get; set; }
        public string CusId { get; set; }
        public string CusName { get; set; }
        public string CusPhone { get; set; }
        public string CusEmail { get; set; }
        public DateTime TimeIn { get; set; }
        public string Fullfillment { get; set; }
        public string ServiceTime { get; set; }
        public string OrderSystem { get; set; }
        public string ShipMethod { get; set; }
        public string Products { get; set; }
    }

    public class OrderDetails
    {
        public Decimal PreTaxTotal { get; set; }
        public string PromoCode { get; set; }
        public Decimal DiscAmount { get; set; }
        public Decimal SalesTax { get; set; }
        public Decimal TotalPrice { get; set; }
        public Boolean PrePaid { get; set; }
        public string LabLabel { get; set; }
        public string Catalog { get; set; }

        public string CusAddress1 { get; set; }
        public string CusAddress2 { get; set; }
        public string CusCity { get; set; }
        public string CusState { get; set; }
        public string CusZip { get; set; }
        public string CusCountry { get; set; }

        public string BillTo { get; set; }
        public string BillCCName { get; set; }
        public string BillCCAddress { get; set; }
        public string BillCCCity { get; set; }
        public string BillCCState { get; set; }
        public string BillCCZip { get; set; }

        public string ShipTo { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipState { get; set; }
        public string ShipZip { get; set; }
        public string ShipPhone { get; set; }
        public string ShipEmail { get; set; }

        public string PayCCType { get; set; }
        public string PayCCNumber { get; set; }
        public string PayCCcvv { get; set; }
        public string PayCCExp { get; set; }
    }

}
