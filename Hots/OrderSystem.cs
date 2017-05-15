using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Hots
{
    public class OrderSystem
    {
        public OrdSysName Name { get; set; }
        public bool Active { get; set; }
        public string WatchFldr { get; set; }
        public string Ext { get; set; }
        public string OutFldr { get; set; }
        public string PrdSubFldr { get; set; }
        public string WaitFile { get; set; }
        public bool WaitIsFldr { get; set; }
        public FileSystemWatcher fW { get; set; }
        public bool fwActive { get; set; }
        public enum OrdSysName { Null, Roes, Dakis, DGift }
        static int i;

        public static Order MakeOrderFromFileList(OrdSysName ordSysName, List<string> orderLineList, Order order)
        {
            switch (ordSysName)
            {
                case OrdSysName.Roes:
                    order = RoesReadListFile(orderLineList, order);
                    break;
                case OrdSysName.Dakis:
                    break;
                case OrdSysName.DGift:
                    break;
            }
            return order;
        }

        #region Roes Order System

        private static Order RoesReadListFile(List<string> orderLineList, Order order)
        {
            try
            {
                i = 0;
                while (orderLineList[i] != "</Order>")
                {
                    switch (orderLineList[i])
                    {
                        case "<Order Info>":
                            order = fillOrderInfo(orderLineList, order);
                            break;
                        case "<Customer>":
                            order = fillCustomerInfo(orderLineList, order);
                            break;
                        case "<Billing>":
                            order = fillBillingInfo(orderLineList, order);
                            break;
                        case "<Shipping>":
                            order = fillShippingInfo(orderLineList, order);
                            break;
                        case "<Payment>":
                            order = fillPaymentInfo(orderLineList, order);
                            break;
                        case "<OrderItems>":
                            order.ItemsList = fillOrderItems(orderLineList, order);
                            order.ItemsList = addUpIdenticalItems(order.ItemsList);
                            order.Products = makeTextFieldFromItemsList(order.ItemsList);
                            break;
                        case "<OrderOptions>":
                            order.OrderOptionsList = fillOrderOptions(orderLineList, order);
                            break;
                        default:
                            break;
                    }
                    i++;
                }
                order.OrdStatus = "new";
            }
            catch
            {
                order.OrdStatus = "error parsing file";
            }
            return order;
        }

        private static Order fillOrderInfo(List<string> orderLineList, Order _newOrder)
        {
            string orderDate = "";
            string orderTime = "";
            while (orderLineList[i] != "</Order Info>")
            {
                i++;
                var aLineSplit = orderLineList[i].Split('=');
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

        private static Order fillCustomerInfo(List<string> orderLineList, Order _newOrder)
        {
            while (orderLineList[i] != "</Customer>")
            {
                i++;
                var aLineSplit = orderLineList[i].Split('=');

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

        private static Order fillBillingInfo(List<string> orderLineList, Order _newOrder)
        {
            while (orderLineList[i] != "</Billing>")
            {
                i++;
                var aLineSplit = orderLineList[i].Split('=');

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

        private static Order fillShippingInfo(List<string> orderLineList, Order _newOrder)
        {
            while (orderLineList[i] != "</Shipping>")
            {
                i++;
                var aLineSplit = orderLineList[i].Split('=');

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

        private static Order fillPaymentInfo(List<string> orderLineList, Order _newOrder)
        {
            while (orderLineList[i] != "</Payment>")
            {
                i++;
                var aLineSplit = orderLineList[i].Split('=');

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

        private static List<OrderItems> fillOrderItems(List<string> orderLineList, Order _newOrder)
        {
            OrderItems item = new OrderItems();
            var itemList = new List<OrderItems>();
            var itemOptionList = new List<ItemOptions>();
            while (orderLineList[i] != "</OrderItems>")
            {
                i++;
                if (orderLineList[i] == "</OrderItemInfo>")
                {
                    item.OptionsList = itemOptionList;
                    itemList.Add(item);
                    item = new OrderItems();
                    itemOptionList = new List<ItemOptions>();
                }
                var aLineSplit = orderLineList[i].Split('=');
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
                        var itemOpt = fillItemOptions(orderLineList, _newOrder);
                        item.Description = item.Description + "-" + itemOpt.Description;
                        itemOptionList.Add(itemOpt);
                        break;
                    default:
                        break;
                }
            }
            return itemList;
        }

        private static ItemOptions fillItemOptions(List<string> orderLineList, Order _newOrder)
        {
            ItemOptions ItemOption = new ItemOptions();
            while (orderLineList[i] != "</OrderItemOption>")
            {
                i++;
                var aLineSplit = orderLineList[i].Split('=');
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

        private static List<OrderItems> addUpIdenticalItems(List<OrderItems> itemsList)
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

        private static string makeTextFieldFromItemsList(List<OrderItems> itemsList)
        {
            string prodField = "";
            foreach (var item in itemsList)
            {
                prodField = (prodField == "") ? item.ItemCode : prodField + "," + item.ItemCode;
            }
            return prodField;
        }

        private static List<OrderOptions> fillOrderOptions(List<string> orderLineList, Order _newOrder)
        {
            OrderOptions OrderOption = new OrderOptions();
            var list = new List<OrderOptions>();
            while (orderLineList[i] != "</OrderOptions>")
            {
                i++;
                if (orderLineList[i] == "</OrderOptionInfo>")
                {
                    list.Add(OrderOption);
                    OrderOption = new OrderOptions();
                }
                var aLineSplit = orderLineList[i].Split('=');
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
}

