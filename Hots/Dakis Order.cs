using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Hots
{
    class DakisOrder
    {
        private string month { get; set; }
        private string day { get; set; }
        private string year { get; set; }
        private string hour { get; set; }
        private string min { get; set; }
        private string sec { get; set; }
        private string comment { get; set; }
        private List<dakisStore> dStoreList { get; set; }
        private static int i { get; set; }

        public static Order DakisMakeOrder(string droppedFileName)
        {
            var ordFldrName = droppedFileName.Replace("labworks_", "order ").Replace(".xml", "");
            var dakisOrdPath = Set.OrdSysList[1].OutputFolder + "\\" + ordFldrName + "\\order.yml";

            var order = new Order();
            order.OrdLocation = Set.ThisLocation;
            order.OrdSysName = Set.OrdSysName.Dakis;
            order.HiteId = droppedFileName.Replace("labworks_", "").Replace(".xml", "");

            var ldList = makeListFromFile(dakisOrdPath);
            if (ldList == null)
            {
                order.OrdStatus = "error reading dropped file";
                return order;
            }

            try
            {
                order = DakisFillOrder(ldList, order);
            }
            catch
            {
                Data.LogEvents(0, "Error parsing " + order.HiteId);
                order.OrdStatus = "error parsing file";
            }

            return order;
        }

        private static List<LineDetails> makeListFromFile(string _path)
        {
            var lineDetailList = new List<LineDetails>();
            try
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var ld = LineDetails.GetLineDetails(line);
                        if (ld == null) continue;
                        lineDetailList.Add(ld);
                    }
                }
                return lineDetailList;
            }
            catch
            {
                return null;
            }
        }

        private static Order DakisFillOrder(List<LineDetails> ld, Order order)
        {
            var dOrder = new DakisOrder();
            while (i < ld.Count)
            {
                var detail = ld[i];
                switch (ld[i].Key)
                {
                    case "taxes":
                    case "additional_info":
                    case "print_formats":
                    case "fulfillment":
                        skipcatagory(ld);
                        break;

                    case "month":
                        dOrder.month = ld[i].Value;
                        break;
                    case "day":
                        dOrder.day = ld[i].Value;
                        break;
                    case "year":
                        dOrder.year = ld[i].Value;
                        break;
                    case "hour":
                        dOrder.hour = ld[i].Value;
                        break;
                    case "minute":
                        dOrder.min = ld[i].Value;
                        break;
                    case "second":
                        dOrder.sec = ld[i].Value;
                        break;
                    case "id":
                        order.HiteId = ld[i].Value;
                        break;
                    case "been_paid":
                        order.PrePaid = Convert.ToBoolean(ld[i].Value);
                        break;
                    case "sub_total":
                        order.PreTaxTotal = Convert.ToDecimal(ld[i].Value);
                        break;
                    case "total_taxes":
                        order.SalesTax = Convert.ToDecimal(ld[i].Value);
                        break;
                    case "charged_price":
                        order.TotalPrice = Convert.ToDecimal(ld[i].Value);
                        break;
                    case "comment":
                        dOrder.comment = ld[i].Value;
                        break;
                    case "payment_method_en":
                        //order.payment method = ld[i].Value;
                        break;

                    case "all_stores":
                        fillAllStores(ld, dOrder, order.OrdSysName);
                        break;
                    case "photo_gift_orders":
                        skipcatagory(ld);
                        //order = fillGiftOrders(ld, order);
                        break;
                    case "shipping":
                        order = fillShipping(ld, order);
                        break;
                    case "photos":
                        order = fillPhotos(ld, order);
                        order.ItemsList = addUpIdenticalItems(order.ItemsList);
                        order.Products = makeTextFieldFromItemsList(order.ItemsList);
                        break;
                    case "shopping_cart":
                        order = fillShoppingCart(ld, order);
                        break;
                    case "customer":
                        order = fillCustomer(ld, order);
                        break;
                    case "printing_order_options":
                        order = fillOrderOptions(ld, order);
                        break;
                    case "store":
                        order = fillStore(ld, order);
                        break;
                }
                i++;
            }
            return order;
        }

        private static Order fillGiftOrders(List<LineDetails> ld, Order order)
        {
            throw new NotImplementedException();
        }


        private static void skipcatagory(List<LineDetails> ld)
        {
            var baseLevel = ld[i].level;
            i++;
            while (ld[i].level > baseLevel && i < ld.Count - 1)//till end of store
            {
                i++;
            }
            i--;
        }

        private static Order fillOrderOptions(List<LineDetails> ld, Order order)
        {
            order.OrderOptionsList = new List<OrderOptions>();
            var option = new OrderOptions();
            var baseLevel = ld[i].level;

            i++;
            while (ld[i].level > baseLevel && i < ld.Count - 1)//till end of all stores
            {
                if (ld[i].startList == true && option.OptCode != null)
                {
                    order.OrderOptionsList.Add(option);
                    option = new OrderOptions();
                }

                switch (ld[i].Key)
                {
                    case "text_en":
                        option.Description = ld[i].Value;
                        break;
                    case "price":
                        option.Price = Convert.ToDecimal(ld[i].Value);
                        break;
                    case "quantity":
                        option.Quant = Convert.ToInt32(ld[i].Value);
                        break;
                    case "labworks_item_code":
                        option.OptCode = ld[i].Value;
                        break;
                }
                i++;
            }
            if (option.OptCode != null)
                order.OrderOptionsList.Add(option);

            i--;
            return order;
        }

        private static Order fillPhotos(List<LineDetails> ld, Order order)
        {
            order.ItemsList = new List<OrderItems>();
            var item = new OrderItems();
            var baseLevel = ld[i].level;

            i++;
            while (ld[i].level > baseLevel && i < ld.Count - 1)//till end of all stores
            {
                if (ld[i].startList == true && item.ItemCode != null)
                {
                    order.ItemsList.Add(item);
                    item = new OrderItems();
                }

                switch (ld[i].Key)
                {
                    case "text":
                        item.Description = ld[i].Value;
                        break;
                    case "fulfillment_store_id":
                        var loc = Location.GetLocByKeyWord(order.OrdSysName, ld[i].Value);
                        item.FulfillerName = loc.NicName;
                        break;
                    case "unit_price":
                        item.Price = Convert.ToDecimal(ld[i].Value);
                        break;
                    case "quantity":
                        item.Quant = Convert.ToInt32(ld[i].Value);
                        break;
                    case "labworks_item_code":
                        item.ItemCode = ld[i].Value;
                        break;
                }
                i++;
            }
            if (item.ItemCode != null)
                order.ItemsList.Add(item);

            i--;
            return order;
        }

        private static Order fillShoppingCart(List<LineDetails> ld, Order order)
        {
            var baseLevel = ld[i].level;
            i++;
            while (ld[i].level > baseLevel && i < ld.Count - 1)//till end of store
            {
                if (ld[i].Key == "promotions")
                {
                    if (ld[i].Value != "[]")
                    {
                        fillPromotions(ld, order);
                    }
                    else
                    {
                        order.PromoCode = "";
                    }
                }
                else if (ld[i].Key == "channel")
                {
                    order.Catalog = ld[i].Value;
                }
                else if (ld[i].Key == "id")
                {
                    order.AlternateId = ld[i].Value;
                }
                i++;
            }
            i--;
            return order;

        }

        private static Order fillPromotions(List<LineDetails> ld, Order order)
        {
            var baseLevel = ld[i].level;
            i++;
            while (ld[i].level > baseLevel && i < ld.Count - 1)//till end of store
            {
                if (ld[i].Key == "text")
                {
                    order.PromoCode = ld[i].Value;
                }
                else if (ld[i].Key == "sub_total")
                {
                    order.DiscAmount = Convert.ToDecimal(ld[i].Value);
                }
            }
            i--;
            return order;
        }

        private static Order fillShipping(List<LineDetails> ld, Order order)
        {
            var pickup = false;
            var method = "";

            var baseLevel = ld[i].level;
            i++;
            while (ld[i].level > baseLevel && i < ld.Count - 1)//till end of store
            {
                if (ld[i].Key == "method")
                {
                    method = ld[i].Value;
                }
                else if (ld[i].Key == "pickup_in_store") //match based on 
                {
                    pickup = Convert.ToBoolean(ld[i].Value);
                }
                else if (ld[i].Key == "price") //match based on 
                {
                    order.ShipCost = Convert.ToDecimal(ld[i].Value);
                }
                i++;
            }
            if (pickup == false)
                order.ShipMethod = method;
            i--;
            return order;
        }

        private static Order fillCustomer(List<LineDetails> ld, Order order)
        {
            string fName = "", lName = "", ship_fName = "", ship_lName = "";
            var baseLevel = ld[i].level;
            i++;
            while (ld[i].level > baseLevel && i < ld.Count - 1)//till end of store
            {
                switch (ld[i].Key)
                {
                    case "id":
                        order.CusId = ld[i].Value;
                        break;
                    case "first_name":
                        fName = ld[i].Value;
                        break;
                    case "last_name":
                        lName = ld[i].Value;
                        break;
                    case "address_1":
                        order.CusAddress1 = ld[i].Value;
                        break;
                    case "address_2":
                        order.CusAddress2 = ld[i].Value;
                        break;
                    case "city":
                        order.CusCity = ld[i].Value;
                        break;
                    case "state":
                        order.CusState = ld[i].Value;
                        break;
                    case "postal_code":
                        order.CusZip = ld[i].Value;
                        break;
                    case "country":
                        order.CusCountry = ld[i].Value;
                        break;
                    case "phone":
                        order.CusPhone = ld[i].Value;
                        break;
                    case "email":
                        order.CusEmail = ld[i].Value;
                        break;

                    case "shipping_first_name":
                        ship_fName = ld[i].Value;
                        break;
                    case "shipping_last_name":
                        ship_lName = ld[i].Value;
                        break;

                    case "billing_address_1":
                        order.BillCCAddress = ld[i].Value;
                        break;
                    case ":billing_city:":
                        order.BillCCCity = ld[i].Value;
                        break;
                    case "billing_state":
                        order.BillCCState = ld[i].Value;
                        break;
                    case "billing_postal_code":
                        order.BillCCZip = ld[i].Value;
                        break;
                }
                i++;
            }
            order.CusName = lName + " " + fName;
            order.ShipName = ship_lName + " " + ship_fName;
            order.OrdStatus = "new";
            i--;
            return order;
        }

        private static void fillAllStores(List<LineDetails> ld, DakisOrder dOrder, Set.OrdSysName ordSysName)
        {
            dOrder.dStoreList = new List<dakisStore>();
            var store = new dakisStore();
            var baseLevel = ld[i].level;

            i++;
            while (ld[i].level > baseLevel && i < ld.Count - 1)//till end of all stores
            {
                if (ld[i].startList == true && store.Name != null)
                {
                    store = store.replaceInfo(ordSysName, store);
                    dOrder.dStoreList.Add(store);
                    store = new dakisStore();
                }

                switch (ld[i].Key)
                {
                    case "name":
                        store.Name = ld[i].Value;
                        store.ShipCode = ld[i].Value;
                        break;
                    case "id":
                        store.DakisId = ld[i].Value;
                        break;
                }
                i++;
            }

            if (store.Name != null)
            {
                store = store.replaceInfo(ordSysName, store);
                dOrder.dStoreList.Add(store);
            }
            i--;
        }

        private static Order fillStore(List<LineDetails> ld, Order order)
        {
           
            var baseLevel = ld[i].level;
            i++;
            while (ld[i].level > baseLevel && i < ld.Count - 1)//till end of store
            {
                if (ld[i].Key == "name") //match based on name
                {
                    if (order.ShipMethod != null)
                    {
                        var loc = Location.GetLocByKeyWord(order.OrdSysName, ld[i].Value);
                        if (loc != null)
                        {
                            order.ShipMethod = loc.ShipCode;
                        }
                        else
                        {
                            order.ShipMethod = ld[i].Value;
                        }
                    }
                }
            i++;
            }
            i--;
            return order;
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

        private class dakisStore
        {
            public string ShipCode { get; set; }
            public string DakisId { get; set; }
            public string Name { get; set; }

            public dakisStore replaceInfo(Set.OrdSysName ordSysName, dakisStore dStore)
            {
                Location loc = null;
                if (dStore.Name != null)
                    loc = Location.GetLocByKeyWord(ordSysName, dStore.Name);

                if (loc != null)
                {
                    dStore.Name = loc.NicName;
                    dStore.ShipCode = loc.ShipCode;
                }
                return dStore;
            }
        }

        private class LineDetails
        {
            public int Indent { get; set; }
            public string Key { get; set; }
            public string Value { get; set; }
            public bool startList { get; set; }
            public int level { get; set; }

            public static LineDetails GetLineDetails(string line)
            {
                int splitlimit = 3;
                char[] sep = { Convert.ToChar(":") };
                var split = line.Split(sep, splitlimit);
                var ld = new LineDetails();
                try
                {
                    ld.Indent = split[0].Length;
                    ld.level = (ld.Indent < 2) ? 0 : ld.Indent / 2;
                    ld.Key = split[1];
                    ld.Value = split[2];
                    if (ld.Indent > 1)
                        if (split[0].Substring(ld.Indent - 2, 2) == "- ")
                            ld.startList = true;

                    return ld;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}