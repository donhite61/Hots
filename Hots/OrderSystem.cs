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

        public static OrderSystem GetOrdSysByInputFolder(string _filePath)
        {
            Settings set = Settings.GetSettings();
            OrderSystem OrdSys = null;
            if (_filePath.ToUpper().Contains(set.ListOrdSys[0].WatchFldr.ToUpper()))
            {
                OrdSys = new OrdSysRoes();
            }
            else if (_filePath.ToUpper().Contains(set.ListOrdSys[1].WatchFldr.ToUpper()))
            {
                OrdSys = new OrdSysDakis();
            }
            else if (_filePath.ToUpper().Contains(set.ListOrdSys[2].WatchFldr.ToUpper()))
            {
                OrdSys = new OrdSysDGift();
            }
            return OrdSys;
        }

        internal List<string> MakeListFromFile(string _filePath)
        {
            var newRoesfile = _filePath;
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

        public abstract Order ReadIncomingOrderFile(Order _newOrder, string filename);
    }

 #region Roes Order System
    public class OrdSysRoes : OrderSystem
    {
        int i;
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

        public override Order ReadIncomingOrderFile(Order _order, string _filePath)
        {
            i = 0;
            _order.FileLineList = MakeListFromFile(_filePath);
            _order.OrdStatus = "new";
            while (_order.FileLineList[i] != "</Order>")
            {
                switch (_order.FileLineList[i])
                {
                    case "<Order Info>":
                        _order = fillOrderInfo(_order);
                        break;
                    case "<Customer>":
                        _order = fillCustomerInfo(_order);
                        break;
                    case "<Billing>":
                        _order = fillBillingInfo(_order);
                        break;
                    case "<Shipping>":
                        _order = fillShippingInfo(_order);
                        break;
                    case "<Payment>":
                        _order = fillPaymentInfo(_order);
                        break;
                    case "<OrderItems>":
                        _order.ItemsList = fillOrderItems(_order);
                        _order.ItemsList = addUpIdenticalItems(_order.ItemsList);
                        _order.Products = makeTextFieldFromItemsList(_order.ItemsList);
                        break;
                    case "<OrderOptions>":
                        _order.OrderOptionsList = fillOrderOptions(_order);
                        break;
                    default:
                        break;
                }
                i++;
            }
            return _order;
        }

        private string makeTextFieldFromItemsList(List<OrderItems> itemsList)
        {
            string prodField = "";
            foreach (var item in itemsList)
            {
                prodField = (prodField == "") ? item.ItemCode : prodField + "," + item.ItemCode;
            }
            return prodField;
        }

        private Order fillOrderInfo(Order _newOrder)
        {
            string orderDate = "";
            string orderTime = "";
            while (_newOrder.FileLineList[i] != "</Order Info>")
            {
                i++;
                var aLineSplit = _newOrder.FileLineList[i].Split('=');
                switch (aLineSplit[0])
                {
                    case "Lab Order ID":
                        _newOrder.HiteId = aLineSplit[1];
                        break;
                    case "Customer Order ID":
                        _newOrder.AlternateId = aLineSplit[1];
                        break;
                    case "Current Date":
                        orderDate = aLineSplit[1];
                        break;
                    case "Current Time":
                        orderTime = aLineSplit[1];
                        break;
                    case "Pre Tax Total":
                        if (Decimal.TryParse(aLineSplit[1], out decimal value))
                            _newOrder.PreTaxTotal = value;
                        break;
                    case "Promo Code":
                        _newOrder.PromoCode = aLineSplit[1];
                        break;
                    case "Discount Amount":
                        if (Decimal.TryParse(aLineSplit[1], out decimal value1))
                            _newOrder.DiscAmount = value1;
                        break;
                    case "Sales Tax":
                        if (Decimal.TryParse(aLineSplit[1], out decimal value2))
                            _newOrder.SalesTax = value2;
                        break;
                    case "Total Price":
                        if (Decimal.TryParse(aLineSplit[1], out decimal value3))
                            _newOrder.TotalPrice = value3;
                        break;
                    case "Pre-Paid":
                        _newOrder.PrePaid = Convert.ToBoolean(aLineSplit[1]);
                        break;
                    case "Lab-Label":
                        _newOrder.LabLabel = aLineSplit[1];
                        break;
                    case "Catalog":
                        _newOrder.Catalog = aLineSplit[1];
                        break;
                    default:
                        break;
                }
            }
            _newOrder.TimeIn = Convert.ToDateTime(orderDate + " " + orderTime);
            return _newOrder;
        }

        private Order fillCustomerInfo(Order _newOrder)
        {
            while (_newOrder.FileLineList[i] != "</Customer>")
            {
                i++;
                var aLineSplit = _newOrder.FileLineList[i].Split('=');

                switch (aLineSplit[0])
                {
                    case "Customer ID":
                        _newOrder.CusId = aLineSplit[1];
                        break;
                    case "Customer Name":
                        _newOrder.CusName = aLineSplit[1];
                        break;
                    case "Customer Address":
                        _newOrder.CusAddress1 = aLineSplit[1];
                        break;
                    case "Customer City":
                        _newOrder.CusCity = aLineSplit[1];
                        break;
                    case "Customer State":
                        _newOrder.CusState = aLineSplit[1];
                        break;
                    case "Customer Zip":
                        _newOrder.CusZip = aLineSplit[1];
                        break;
                    case "Customer Country":
                        _newOrder.CusCountry = aLineSplit[1];
                        break;
                    case "Customer Phone":
                        _newOrder.CusPhone = aLineSplit[1];
                        break;
                    case "Customer Email":
                        _newOrder.CusEmail = aLineSplit[1];
                        break;
                    default:
                        break;
                }
            }
            return _newOrder;
        }

        private Order fillBillingInfo(Order _newOrder)
        {
            while (_newOrder.FileLineList[i] != "</Billing>")
            {
                i++;
                var aLineSplit = _newOrder.FileLineList[i].Split('=');

                switch (aLineSplit[0])
                {
                    case "Payment Bill To":
                        _newOrder.BillTo = aLineSplit[1];
                        break;
                    case "Payment Credit Card Name":
                        _newOrder.BillCCName = aLineSplit[1];
                        break;
                    case "Payment Credit Card Address":
                        _newOrder.BillCCAddress = aLineSplit[1];
                        break;
                    case "Payment Credit Card City":
                        _newOrder.BillCCCity = aLineSplit[1];
                        break;
                    case "Payment Credit Card State":
                        _newOrder.BillCCState = aLineSplit[1];
                        break;
                    case "Payment Credit Card Zip":
                        _newOrder.BillCCZip = aLineSplit[1];
                        break;
                    default:
                        break;
                }
            }
            return _newOrder;
        }

        private Order fillShippingInfo(Order _newOrder)
        {
            while (_newOrder.FileLineList[i] != "</Shipping>")
            {
                i++;
                var aLineSplit = _newOrder.FileLineList[i].Split('=');

                switch (aLineSplit[0])
                {
                    case "Shipping Method":
                        _newOrder.ShipMethod = aLineSplit[1];
                        break;
                    case "Shipping Cost":
                        var temp = aLineSplit[1].Remove(0, 1);
                        if (decimal.TryParse(aLineSplit[1].Remove(0, 1), out Decimal value))
                            _newOrder.ShipCost = value;
                        break;
                    case "Payment Ship To":
                        _newOrder.ShipTo = aLineSplit[1];
                        break;
                    case "Payment Ship To Name":
                        _newOrder.ShipName = aLineSplit[1];
                        break;
                    case "Payment Ship To Address":
                        _newOrder.ShipAddress = aLineSplit[1];
                        break;
                    case "Payment Ship To City":
                        _newOrder.ShipCity = aLineSplit[1];
                        break;
                    case "Payment Ship To State":
                        _newOrder.ShipState = aLineSplit[1];
                        break;
                    case "Payment Ship To Zip":
                        _newOrder.ShipZip = aLineSplit[1];
                        break;
                    case "Payment Phone":
                        _newOrder.ShipPhone = aLineSplit[1];
                        break;
                    case "Payment Email":
                        _newOrder.ShipEmail = aLineSplit[1];
                        break;
                    default:
                        break;
                }
            }
            return _newOrder;
        }

        private Order fillPaymentInfo(Order _newOrder)
        {
            while (_newOrder.FileLineList[i] != "</Payment>")
            {
                i++;
                var aLineSplit = _newOrder.FileLineList[i].Split('=');

                switch (aLineSplit[0])
                {
                    case "Payment Credit Card Type":
                        _newOrder.PayCCType = aLineSplit[1];
                        break;
                    case "Payment Credit Card Number":
                        _newOrder.PayCCNumber = aLineSplit[1];
                        break;
                    case "Payment Credit Card CVV":
                        _newOrder.PayCCcvv = aLineSplit[1];
                        break;
                    case "Payment Credit Card Exp":
                        _newOrder.PayCCExp = aLineSplit[1];
                        break;
                    default:
                        break;
                }
            }
            return _newOrder;
        }

        private List<OrderItems> fillOrderItems(Order _newOrder)
        {
            OrderItems item = new OrderItems();
            var itemList = new List<OrderItems>();
            var itemOptionList = new List<ItemOptions>();
            while (_newOrder.FileLineList[i] != "</OrderItems>")
            {
                i++;
                if (_newOrder.FileLineList[i] == "</OrderItemInfo>")
                {
                    item.OptionsList = itemOptionList;
                    itemList.Add(item);
                    item = new OrderItems();
                    itemOptionList = new List<ItemOptions>();
                }
                var aLineSplit = _newOrder.FileLineList[i].Split('=');
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
                        var itemOpt = fillItemOptions(_newOrder);
                        item.Description = item.Description + "-" + itemOpt.Description;
                        itemOptionList.Add(itemOpt);
                        break;
                    default:
                        break;
                }
            }
            return itemList;
        }

        private ItemOptions fillItemOptions(Order _newOrder)
        {
            ItemOptions ItemOption = new ItemOptions();
            while (_newOrder.FileLineList[i] != "</OrderItemOption>")
            {
                i++;
                var aLineSplit = _newOrder.FileLineList[i].Split('=');
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

        private List<OrderOptions> fillOrderOptions(Order _newOrder)
        {
            OrderOptions OrderOption = new OrderOptions();
            var list = new List<OrderOptions>();
            while (_newOrder.FileLineList[i] != "</OrderOptions>")
            {
                i++;
                if (_newOrder.FileLineList[i] == "</OrderOptionInfo>")
                {
                    list.Add(OrderOption);
                    OrderOption = new OrderOptions();
                }
                var aLineSplit = _newOrder.FileLineList[i].Split('=');
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

    }
 #endregion Roes Order System

 #region Dakis Order System
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

        public override Order ReadIncomingOrderFile(Order _order, string _filePath)
        {
            return _order;
        }
    }
#endregion

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

        public override Order ReadIncomingOrderFile(Order order, string _filePath)
        {
            return order;
        }
    }
}

