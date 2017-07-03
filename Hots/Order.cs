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
        public Set.OrdSysName OrdSysName { get; set; }
        public string HiteId { get; set; }
        public string AlternateId { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeDue { get; set; }
        public Decimal PreTaxTotal { get; set; }
        public string PromoCode { get; set; } //should be list
        public Decimal DiscAmount { get; set; }
        public Decimal SalesTax { get; set; }
        public Decimal TotalPrice { get; set; }
        public Boolean PrePaid { get; set; }
        public string LabLabel { get; set; }
        public string Catalog { get; set; }
        public UInt32? FullfillmentLocId { get; set; }//should be list
        public UInt32? OrdLocation { get; set; }
        
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

        public List<OrderItems> ItemsList { get; set; }
        public List<OrderOptions> OrderOptionsList { get; set; }

        private static Set.OrdSysName GetOrdSysNameFromFilepath(string folder, string fileName)
        {
            Set.OrdSysName osn = Set.OrdSysName.Null;
            foreach (var os in Set.OrdSysList)
            {
                if (folder.ToUpper() == os.WatchedFolder.ToUpper())
                {
                    osn = os.Name;
                    break;
                }
            }

            return osn;
        }

        public static void CreateNewOrderFromDroppedFile(string filePath)
        {
            string[] words = filePath.Split('\\');
            var droppedFileName = words[words.Length - 1];
            var folder = filePath.Substring(0, filePath.Length - (droppedFileName.Length + 1));

            var ordSysName = GetOrdSysNameFromFilepath(folder, droppedFileName);
            if (ordSysName == Set.OrdSysName.Null) return;

            Order order = null;
            switch (ordSysName)
            {
                case Set.OrdSysName.Roes:
                    order = OrderSystem.RoesMakeOrder(filePath, droppedFileName);
                    break;
                case Set.OrdSysName.Dakis:
                    order = DakisOrder.MakeDakisOrder(droppedFileName);
                    break;
                case Set.OrdSysName.DGift:
                    //order = DakisReadListFile(fileName);
                    break;
                case Set.OrdSysName.Null:
                    Data.LogEvents(0, "Unknown filetype " + droppedFileName + " skipped");
                    break;
            }

            var sqlId = Data.SaveOrdertoSqlServer(order);
            if (sqlId != 0) return;
                //MoveFileToRead(folder, fileName);
        }

        private static void MoveFileToRead(string folder, string fileName)
        {
            if (!Directory.Exists(folder + @"Read"))
                Directory.CreateDirectory(folder + @"Read");

            var from = folder + fileName;
            var to = folder + @"Read\"+ fileName;
            File.Move(from, to); // Try to move
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
        public UInt32 FulfillerId { get; set; }
        public List<ItemOptions> OptionsList { get; set; }
        public string Catagory { get; set; }
        public string SubCatagory { get; set; }

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
