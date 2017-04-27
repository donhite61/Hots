using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hots
{
    interface IReadIncomingOrderFile
    {
        UInt32 mysqlId { get; set; }
        string HiteId { get; set; }
        string AlternateId { get; set; }
        DateTime TimeIn { get; set; }
        Decimal PreTaxTotal { get; set; }
        string PromoCode { get; set; }
        Decimal DiscAmount { get; set; }
        Decimal SalesTax { get; set; }
        Decimal TotalPrice { get; set; }
        Boolean PrePaid { get; set; }
        string LabLabel { get; set; }
        string Catalog { get; set; }
        string Fullfillment { get; set; }
        string ServiceTime { get; set; }
        string OrderSystem { get; set; }
        string Products { get; set; }

        string CusId { get; set; }
        string CusName { get; set; }
        string CusAddress1 { get; set; }
        string CusAddress2 { get; set; }
        string CusCity { get; set; }
        string CusState { get; set; }
        string CusZip { get; set; }
        string CusCountry { get; set; }
        string CusPhone { get; set; }
        string CusEmail { get; set; }

        string BillTo { get; set; }
        string BillCCName { get; set; }
        string BillCCAddress { get; set; }
        string BillCCCity { get; set; }
        string BillCCState { get; set; }
        string BillCCZip { get; set; }

        string ShipMethod { get; set; }
        decimal ShipCost { get; set; }
        string ShipTo { get; set; }
        string ShipName { get; set; }
        string ShipAddress { get; set; }
        string ShipCity { get; set; }
        string ShipState { get; set; }
        string ShipZip { get; set; }
        string ShipPhone { get; set; }
        string ShipEmail { get; set; }

        string PayCCType { get; set; }
        string PayCCNumber { get; set; }
        string PayCCcvv { get; set; }
        string PayCCExp { get; set; }

        // List<string> FileLineList { get; set; }
        List<OrderItems> ItemsList { get; set; }
        List<OrderOptions> OrderOptionsList { get; set; }

    }

    class ReadRoesIncomingOrderFile : IReadIncomingOrderFile
    {
        public uint mysqlId { get; set; }
        public string HiteId { get; set; }
        public string AlternateId { get; set; }
        public DateTime TimeIn { get; set; }
        public Decimal PreTaxTotal { get; set; }
        public string PromoCode { get; set; }
        public Decimal DiscAmount { get; set; }
        public Decimal SalesTax { get; set; }
        public Decimal TotalPrice { get; set; }
        public Boolean PrePaid { get; set; }
        public string LabLabel { get; set; }
        public string Catalog { get; set; }
        public string Fullfillment { get; set; }
        public string ServiceTime { get; set; }
        public string OrderSystem { get; set; }
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

        private List<string> FileLineList { get; set; }
        public List<OrderItems> ItemsList { get; set; }
        public List<OrderOptions> OrderOptionsList { get; set; }
        int i = 0;

        public ReadRoesIncomingOrderFile(string _hiteId)
        {
            FileLineList = MakeListForFile(_hiteId);
            while (FileLineList[i] != "</Order>")
            {
                switch (FileLineList[i])
                {
                    case "<Order Info>":
                        fillOrderInfo();
                        break;
                    case "<Customer>":
                        fillCustomerInfo();
                        break;
                    case "<Billing>":
                        fillBillingInfo();
                        break;
                    case "<Shipping>":
                        fillShippingInfo();
                        break;
                    case "<Payment>":
                        fillPaymentInfo();
                        break;
                    case "<OrderItems>":
                        ItemsList = fillOrderItems();
                        ItemsList = addUpIdenticalItems(ItemsList);
                        break;
                    case "<OrderOptions>":
                        OrderOptionsList = fillOrderOptions();
                        break;
                    default:
                        break;
                }
                i++;
            }
        }

        private List<OrderItems> addUpIdenticalItems(List<OrderItems> itemsList)
        {
            var sortedItemList = new List<OrderItems>();
            sortedItemList = itemsList.OrderBy(o => o.Description).ToList();

            for (int j = sortedItemList.Count - 1; j > 0; j--)
            {
                if (sortedItemList[j].Description == sortedItemList[j - 1].Description)
                {
                    sortedItemList[j - 1].Quant += sortedItemList[j].Quant;
                    sortedItemList[j - 1].LineTotal += sortedItemList[j].LineTotal;
                    sortedItemList.RemoveAt(j);
                }
            }
            return sortedItemList;
        }

        private List<OrderItems> fillOrderItems()
        {
            OrderItems item = new OrderItems();
            var itemList = new List<OrderItems>();
            var itemOptionList = new List<ItemOptions>();
            while (FileLineList[i] != "</OrderItems>")
            {
                i++;
                if (FileLineList[i] == "</OrderItemInfo>")
                {
                    item.OptionsList = itemOptionList;
                    itemList.Add(item);
                    item = new OrderItems();
                    itemOptionList = new List<ItemOptions>();
                }
                var aLineSplit = FileLineList[i].Split('=');
                switch (aLineSplit[0])
                {
                    case "Item Product Code":
                        item.ItemCode = aLineSplit[1];
                        break;
                    case "Item Product Description":
                        item.Description = aLineSplit[1];
                        break;
                    case "Item Quantity Each":
                        if (int.TryParse(aLineSplit[1], out int value))
                            item.Quant = value;
                        break;
                    case "Item Price":
                        var temp = aLineSplit[1].Remove(0, 1);
                        if (decimal.TryParse(aLineSplit[1].Remove(0, 1), out Decimal value1))
                            item.Price = value1;
                        break;
                    case "Item Total Price":
                        if (Decimal.TryParse(aLineSplit[1], out decimal value2))
                            item.LineTotal = value2;
                        break;
                    case "<OrderItemOption>":
                        var itemOpt = fillItemOptions();
                        item.Description = item.Description + "-" + itemOpt.Description;
                        itemOptionList.Add(itemOpt);
                        break;
                    default:
                        break;
                }
            }
            return itemList;
        }

        private ItemOptions fillItemOptions()
        {
            ItemOptions ItemOption = new ItemOptions();
            while (FileLineList[i] != "</OrderItemOption>")
            {
                i++;
                var aLineSplit = FileLineList[i].Split('=');
                switch (aLineSplit[0])
                {
                    case "Item Option ID":
                        ItemOption.OptCode = aLineSplit[1];
                        break;
                    case "Item Option Label":
                        ItemOption.Description = aLineSplit[1];
                        break;
                    case "Item Option Quantity":
                        if (int.TryParse(aLineSplit[1], out int value))
                            ItemOption.Quant = value;
                        break;
                    case "Item Option Price":
                        if (decimal.TryParse(aLineSplit[1], out decimal value1))
                            ItemOption.Price = value1;
                        break;
                    default:
                        break;
                }
            }
            return ItemOption;
        }

        private List<OrderOptions> fillOrderOptions()
        {
            OrderOptions OrderOption = new OrderOptions();
            var list = new List<OrderOptions>();
            while (FileLineList[i] != "</OrderOptions>")
            {
                i++;
                if (FileLineList[i] == "</OrderOptionInfo>")
                {
                    list.Add(OrderOption);
                    OrderOption = new OrderOptions();
                }
                var aLineSplit = FileLineList[i].Split('=');
                switch (aLineSplit[0])
                {
                    case "Order Option ID":
                        OrderOption.OptCode = aLineSplit[1];
                        break;
                    case "Order Option Label":
                        OrderOption.Description = aLineSplit[1];
                        break;
                    case "Order Option Quantity":
                        if (int.TryParse(aLineSplit[1], out int value))
                            OrderOption.Quant = value;
                        break;
                    case "Order Option Price":
                        if (decimal.TryParse(aLineSplit[1], out decimal value1))
                            OrderOption.Price = value1;
                        break;
                    case "Order Option Text":
                        OrderOption.Text = (aLineSplit[1]);
                        break;
                    default:
                        break;
                }
            }
            return list;
        }

        private int fillPaymentInfo()
        {
            while (FileLineList[i] != "</Payment>")
            {
                i++;
                var aLineSplit = FileLineList[i].Split('=');

                switch (aLineSplit[0])
                {
                    case "Payment Credit Card Type":
                        PayCCType = aLineSplit[1];
                        break;
                    case "Payment Credit Card Number":
                        PayCCNumber = aLineSplit[1];
                        break;
                    case "Payment Credit Card CVV":
                        PayCCcvv = aLineSplit[1];
                        break;
                    case "Payment Credit Card Exp":
                        PayCCExp = aLineSplit[1];
                        break;
                    default:
                        break;
                }
            }
            return i;
        }

        private int fillShippingInfo()
        {
            while (FileLineList[i] != "</Shipping>")
            {
                i++;
                var aLineSplit = FileLineList[i].Split('=');

                switch (aLineSplit[0])
                {
                    case "Shipping Method":
                        ShipMethod = aLineSplit[1];
                        break;
                    case "Shipping Cost":
                        var temp = aLineSplit[1].Remove(0, 1);
                        if (decimal.TryParse(aLineSplit[1].Remove(0, 1), out Decimal value))
                            ShipCost = value;
                        break;
                    case "Payment Ship To":
                        ShipTo = aLineSplit[1];
                        break;
                    case "Payment Ship To Name":
                        ShipName = aLineSplit[1];
                        break;
                    case "Payment Ship To Address":
                        ShipAddress = aLineSplit[1];
                        break;
                    case "Payment Ship To City":
                        ShipCity = aLineSplit[1];
                        break;
                    case "Payment Ship To State":
                        ShipState = aLineSplit[1];
                        break;
                    case "Payment Ship To Zip":
                        ShipZip = aLineSplit[1];
                        break;
                    case "Payment Phone":
                        ShipPhone = aLineSplit[1];
                        break;
                    case "Payment Email":
                        ShipEmail = aLineSplit[1];
                        break;
                    default:
                        break;
                }
            }
            return i;
        }

        private int fillBillingInfo()
        {
            while (FileLineList[i] != "</Billing>")
            {
                i++;
                var aLineSplit = FileLineList[i].Split('=');

                switch (aLineSplit[0])
                {
                    case "Payment Bill To":
                        BillTo = aLineSplit[1];
                        break;
                    case "Payment Credit Card Name":
                        BillCCName = aLineSplit[1];
                        break;
                    case "Payment Credit Card Address":
                        BillCCAddress = aLineSplit[1];
                        break;
                    case "Payment Credit Card City":
                        BillCCCity = aLineSplit[1];
                        break;
                    case "Payment Credit Card State":
                        BillCCState = aLineSplit[1];
                        break;
                    case "Payment Credit Card Zip":
                        BillCCZip = aLineSplit[1];
                        break;
                    default:
                        break;
                }
            }
            return i;
        }

        private int fillOrderInfo()
        {
            string orderDate = "";
            string orderTime = "";
            while (FileLineList[i] != "</Order Info>")
            {
                i++;
                var aLineSplit = FileLineList[i].Split('=');
                switch (aLineSplit[0])
                {
                    case "Lab Order ID":
                        HiteId = aLineSplit[1];
                        break;
                    case "Customer Order ID":
                        AlternateId = aLineSplit[1];
                        break;
                    case "Current Date":
                        orderDate = aLineSplit[1];
                        break;
                    case "Current Time":
                        orderTime = aLineSplit[1];
                        break;
                    case "Pre Tax Total":
                        if (Decimal.TryParse(aLineSplit[1], out decimal value))
                            PreTaxTotal = value;
                        break;
                    case "Promo Code":
                        PromoCode = aLineSplit[1];
                        break;
                    case "Discount Amount":
                        if (Decimal.TryParse(aLineSplit[1], out decimal value1))
                            DiscAmount = value1;
                        break;
                    case "Sales Tax":
                        if (Decimal.TryParse(aLineSplit[1], out decimal value2))
                            SalesTax = value2;
                        break;
                    case "Total Price":
                        if (Decimal.TryParse(aLineSplit[1], out decimal value3))
                            TotalPrice = value3;
                        break;
                    case "Pre-Paid":
                        PrePaid = Convert.ToBoolean(aLineSplit[1]);
                        break;
                    case "Lab-Label":
                        LabLabel = aLineSplit[1];
                        break;
                    case "Catalog":
                        Catalog = aLineSplit[1];
                        break;
                    default:
                        break;
                }
            }
            TimeIn = Convert.ToDateTime(orderDate + " " + orderTime);
            return i;
        }

        private int fillCustomerInfo()
        {
            while (FileLineList[i] != "</Customer>")
            {
                i++;
                var aLineSplit = FileLineList[i].Split('=');

                switch (aLineSplit[0])
                {
                    case "Customer ID":
                        CusId = aLineSplit[1];
                        break;
                    case "Customer Name":
                        CusName = aLineSplit[1];
                        break;
                    case "Customer Address":
                        CusAddress1 = aLineSplit[1];
                        break;
                    case "Customer City":
                        CusCity = aLineSplit[1];
                        break;
                    case "Customer State":
                        CusState = aLineSplit[1];
                        break;
                    case "Customer Zip":
                        CusZip = aLineSplit[1];
                        break;
                    case "Customer Country":
                        CusCountry = aLineSplit[1];
                        break;
                    case "Customer Phone":
                        CusPhone = aLineSplit[1];
                        break;
                    case "Customer Email":
                        CusEmail = aLineSplit[1];
                        break;
                    default:
                        break;
                }
            }
            return i;
        }

        private List<string> MakeListForFile(string hiteId)
        {
            var newRoesfile = "Set.WchRoes" + @"\" + hiteId;
            List<string> lines = new List<string>();

            using (StreamReader sr = new StreamReader(newRoesfile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
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
