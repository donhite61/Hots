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
        private string payment_method { get; set; }
        private decimal charged_price { get; set; }
        private bool new_kiosk { get; set; }
        private string month { get; set; }
        private shopping_cart shopcart { get; set; }
        private string comment { get; set; }
        private string zone { get; set; }
        private string second { get; set; }
        private List<dakisStore> dStoreList { get; set; }
        private string order_status { get; set; }
        private string year { get; set; }
        private string format_version { get; set; }
        private List<printOrdOptions> prtOrdOptList { get; set; }
        private decimal sub_total { get; set; }
        private string hour { get; set; }
        private List<taxes> taxesList { get; set; }
        private additionalInfo addnlInfo { get; set; }
        private List<printFormats> prtFrmtList { get; set; }
        private dakisStore thisStore { get; set; }
        private shipInfo shipping { get; set; }
        private List<gifts> giftOrdList{ get; set; }
        private string minute { get; set; }
        private customer thisCust { get; set; }
        private List<photos> photoList { get; set; }
        private decimal total_taxes { get; set; }
        private bool been_paid { get; set; }
        private string day { get; set; }
        private string id { get; set; }
        private string payment_date { get; set; }
        private string order_fulfillment { get; set; }
        private string currency { get; set; }

        private static int i { get; set; }

        private string getOrderShipMethod(DakisOrder dOrder)
        {
            Locations loc;
            if (dOrder.addnlInfo != null)
            {
                loc = Locations.GetLocByKeyWord(Set.OrdSysName.Dakis, Set.ThisLocation.Name);// for kiosk
            }
            else if (dOrder.shipping.method.ToUpper().Contains("PICK UP"))
            {
                loc = Locations.GetLocByKeyWord(Set.OrdSysName.Dakis, dOrder.thisStore.city);
            }
            else
            {
                loc = Locations.GetLocByKeyWord(Set.OrdSysName.Dakis, dOrder.shipping.method);
            }
            return loc.ShipCode;
        }

        public static Order MakeDakisOrder(string droppedFileName)
        {
            var ordFldrName = droppedFileName.Replace("labworks_", "order ").Replace(".xml", "");
            var ordId = ordFldrName.Replace("order ", "");
            var dakisOrdPath = Set.OrdSysList[1].OutputFolder + "\\" + ordFldrName + "\\order.yml";

            var dOrder = new DakisOrder();
            var order = new Order();
            dOrder.id = ordId;

            var ldList = makeListFromFile(dakisOrdPath);
            if (ldList == null)
            {
                Data.LogEvents(0, "error reading dropped file" + ordId);
                order.OrdStatus = "error reading dropped file";
                return order;
            }

            //try
            {
                dOrder = dOrder.DakisFillOrder(ldList, dOrder);
                order = dOrder.MakeOrderFromdDorder(dOrder, order);
            }
            //catch
            //{
            //    Data.LogEvents(0, "Error parsing " + ordId);
            //    order.OrdStatus = "error parsing file";
            //}


            return order;
        }

        protected DakisOrder DakisFillOrder(List<LineDetails> ld, DakisOrder order)
        {
            i = 0;
            var dOrder = new DakisOrder();
            while (i < ld.Count)
            {
                var detail = ld[i];
                switch (ld[i].Key)
                {
                    case "payment_method_en":
                        dOrder.payment_method = ld[i].Value;
                        break;
                    case "charged_price":
                        dOrder.charged_price = Convert.ToDecimal(ld[i].Value);
                        break;
                    case "new_kiosk":
                        dOrder.new_kiosk = Convert.ToBoolean(ld[i].Value);
                        break;
                    case "month":
                        dOrder.month = ld[i].Value;
                        break;
                    case "shopping_cart":
                        dOrder.shopcart = dOrder.makeShopping_cart(ld);
                        break;
                    case "comment":
                        dOrder.comment = ld[i].Value;
                        break;
                    case "zone":
                        dOrder.zone = ld[i].Value;
                        break;
                    case "second":
                        dOrder.second = ld[i].Value;
                        break;
                    case "all_stores":
                        dOrder.dStoreList = dOrder.getAllStoresList(ld);
                        break;
                    case "order_status":
                        dOrder.order_status = ld[i].Value;
                        break;
                    case "year":
                        dOrder.year = ld[i].Value;
                        break;
                    case "format_version":
                        dOrder.format_version = ld[i].Value;
                        break;
                    case "printing_order_options":
                        dOrder.prtOrdOptList = dOrder.getPrntOrdOptList(ld);
                        break;
                    case "sub_total":
                        dOrder.sub_total = Convert.ToDecimal(ld[i].Value);
                        break;
                    case "hour":
                        dOrder.hour = ld[i].Value;
                        break;
                    case "taxes":
                        dOrder.taxesList = dOrder.getTaxesList(ld);
                        break;
                    case "additional_info":
                        dOrder.addnlInfo = dOrder.getAddnlInfo(ld);
                        break;
                    case "print_formats":
                        dOrder.prtFrmtList = dOrder.getPrntFrmtList(ld);
                        break;
                    case "store":
                        dOrder.thisStore = dOrder.getStore(ld);
                        break;
                    case "shipping":
                        dOrder.shipping = dOrder.GetShipInfo(ld);
                        break;
                    case "photo_gift_orders":
                        dOrder.giftOrdList = dOrder.getGiftList(ld);
                        break;
                    case "minute":
                        dOrder.minute = ld[i].Value;
                        break;
                    case "customer":
                        dOrder.thisCust = dOrder.getCustomer(ld);
                        break;
                    case "photos":
                        dOrder.photoList = getPhotoList(ld);
                        break;
                    case "total_taxes":
                        dOrder.total_taxes = Convert.ToDecimal(ld[i].Value);
                        break;
                    case "been_paid":
                        dOrder.been_paid = Convert.ToBoolean(ld[i].Value);
                        break;
                    case "day":
                        dOrder.day = ld[i].Value;
                        break;
                    case "id":
                        dOrder.id = ld[i].Value;
                        break;
                    case "payment_date":
                        dOrder.payment_date = ld[i].Value;
                        break;
                    case "order_fulfillment":
                        dOrder.order_fulfillment = ld[i].Value;
                        break;
                    case "currency":
                        dOrder.currency = ld[i].Value;
                        break;
                }
                i++;
            }
            return dOrder;
        }

        private Order MakeOrderFromdDorder(DakisOrder dOrder, Order order)
        {
           
            order.OrdSysName = Set.OrdSysName.Dakis;
            order.HiteId = dOrder.id;
            if (dOrder.addnlInfo == null)
            {
                order.AlternateId = dOrder.shopcart.id;
            }
            else
            {
                order.AlternateId = addnlInfo.orderId;
            }
            order.TimeIn = getTimeIn(dOrder);
            order.PreTaxTotal = dOrder.sub_total;
            order.PromoCode = getPromoCodeLineFromList(dOrder);
            order.DiscAmount = getPromoCodeDiscFromList(dOrder);
            order.SalesTax = dOrder.total_taxes;
            order.TotalPrice = dOrder.charged_price;
            order.PrePaid = dOrder.been_paid;
            order.LabLabel = dOrder.shopcart.channel;
            order.Catalog = "";
            order.FullfillmentLocId = dOrder.GetProductionLocId(dOrder);
            order.OrdLocation =order.FullfillmentLocId;
            order.ItemsList = makeListOfOrderItems(dOrder);
            order.ItemsList = addUpIdenticalItems(order.ItemsList);
            order.Products = dOrder.makeTextFieldFromItemsList(order.ItemsList);

            order.CusId = dOrder.thisCust.id;
            order.CusName = dOrder.thisCust.lName.Replace("\"", "") + ", " + dOrder.thisCust.fName.Replace("\"", "");
            order.CusAddress1 = dOrder.thisCust.address1.Replace("\"", "");
            order.CusAddress2 = dOrder.thisCust.address2.Replace("\"", "");
            order.CusCity = dOrder.thisCust.city.Replace("\"", "");
            order.CusState = dOrder.thisCust.state;
            order.CusZip = dOrder.thisCust.zip.Replace("\"", "");
            order.CusCountry = dOrder.thisCust.country;
            order.CusPhone = dOrder.thisCust.phone;
            order.CusEmail = dOrder.thisCust.email;

            order.BillCCName = dOrder.thisCust.fName.Replace("\"", "") + " " + dOrder.thisCust.lName.Replace("\"", "");
            order.BillCCAddress = dOrder.thisCust.billAdd1.Replace("\"", "").Replace("\"", "");
            order.BillCCCity = dOrder.thisCust.billCity.Replace("\"", "").Replace("\"", "");
            order.BillCCState = dOrder.thisCust.billState;
            order.BillCCZip = dOrder.thisCust.billZip.Replace("\"", "");


            order.ShipMethod = dOrder.getOrderShipMethod(dOrder);

            order.ShipCost = dOrder.shipping.price;
            order.ShipName = dOrder.thisCust.shpFname.Replace("\"", "") + " " + dOrder.thisCust.shpFname.Replace("\"", "").Replace("\"", "");
            order.ShipAddress = dOrder.thisCust.address1.Replace("\"", "");
            order.ShipCity = dOrder.thisCust.city.Replace("\"", "");
            order.ShipState = dOrder.thisCust.state;
            order.ShipZip = dOrder.thisCust.zip.Replace("\"", "");
            order.ShipPhone = dOrder.thisCust.phone;
            order.ShipEmail = dOrder.thisCust.email;

            order.OrderOptionsList = makeOrdOptListFromDakisOrdOpt(dOrder);

            order.OrdStatus = "new";
            return order;
        }


        private List<OrderOptions> makeOrdOptListFromDakisOrdOpt(DakisOrder dOrder)
        {
            var list = new List<OrderOptions>();
            foreach(printOrdOptions dOpt in dOrder.prtOrdOptList)
            {
                OrderOptions opt = new OrderOptions();
                opt.OptCode = dOpt.labworksCode;
                opt.Text = dOpt.text;
                opt.Description = dOpt.text;
                opt.Quant = dOpt.quant;
                opt.Price = dOpt.price;
                list.Add(opt);
            }
            return list;
        }

        private uint? GetProductionLocId(DakisOrder dOrder)
        {
            string dakisId = "";

            foreach (photos photo in dOrder.photoList)// find first print fulfillment location
            {
                foreach (prints print in photo.printList)
                {
                    dakisId = print.fulfillment_store_id;
                    if (dakisId != "")
                        break;
                }
                if (dakisId != "")
                    break;
            }

            if (dakisId == "")
            {
                foreach (gifts gift in dOrder.giftOrdList)// find first gift fulfillment location
                {
                    dakisId = gift.fulfillment_store_id;
                    if (dakisId != "")
                        break;
                }
            }

            foreach(dakisStore store in dOrder.dStoreList) //lookup 
            {
                if (dakisId == store.dakisId)
                {
                   var hiteLoc = Locations.GetLocByKeyWord(Set.OrdSysName.Dakis, store.name);
                    if (hiteLoc != null)
                        return hiteLoc.Id;
                }
            }
            return null;
        }

        private decimal getPromoCodeDiscFromList(DakisOrder dOrder)
        {
            decimal disc = 0;

            foreach (shopping_cart.promotions promo in dOrder.shopcart.promoList)
            {
                disc = disc + promo.discAmnt;
            }
            return disc;
        }

        private string getPromoCodeLineFromList(DakisOrder dOrder)
        {
            string line = "";

            foreach (shopping_cart.promotions promo in dOrder.shopcart.promoList)
            {
                line = line + promo.promoName + ",";
            }
            return line;
        }

        private DateTime getTimeIn(DakisOrder dOrder)
        {
            var hr = dOrder.hour.Trim();
            hr = (hr.Length == 1) ? "0" + hr : hr;
            var min = dOrder.minute.Trim();
            min = (min.Length == 1) ? "0" + min : min;
            var sec = dOrder.second.Trim();
            sec = (sec.Length == 1) ? "0" + sec : sec;
            var year = dOrder.year.Trim();
            var mon = dOrder.month.Trim();
            mon = (mon.Length == 1) ? "0" + mon : mon;
            var day = dOrder.day.Trim();
            day = (day.Length == 1) ? "0" + day : day;
            return DateTime.ParseExact(year+mon+day+" "+hr+min+sec, "yyyyMMdd HHmmss",null);
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

        #region make Dakis order

        private dakisStore getStore(List<LineDetails> ld)
        {
            var store = new dakisStore();
            var baseIndent = ld[i].Indent;

            i++;
            while (ld[i].Indent > baseIndent && i < ld.Count - 1)//till end of all stores
            {
                switch (ld[i].Key)
                {
                    case "city":
                        store.city = ld[i].Value;
                        break;
                    case "country":
                        store.country = ld[i].Value;
                        break;
                    case "address":
                        store.address = ld[i].Value;
                        break;
                    case "state":
                        store.state = ld[i].Value;
                        break;
                    case "postage_code":
                        store.zip = ld[i].Value;
                        break;
                    case "name":
                        store.name = ld[i].Value;
                        break;
                }
                i++;
            }
            i--;
            return store;
        }

        private class shopping_cart
        {
            public string status { get; set; }
            public List<items> itemlist { get; set; }
            public promotion_pass promoPass { get; set; }
            public string sub_total { get; set; }
            public string created_at { get; set; }
            public string channel { get; set; }
            public List<promotions> promoList { get; set; }
            public string id { get; set; }
            public string currency_code { get; set; }

            public string getStatus(List<LineDetails> ld)
            {
                var status = "";
                var baseIndent = ld[i].Indent;
                i++;
                while (ld[i].Indent > baseIndent && i < ld.Count - 1)//till end of store
                {
                    if (ld[i].Key == "status")
                    {
                        status = ld[i].Value;
                    }
                    i++;
                }
                i--;
                return status;
            }

            public class items
            {
                public string typeName { get; set; }
                public decimal sub_total { get; set; }
                public string text { get; set; }

            }

            public List<items> makeCartItemsList(List<LineDetails> ld)
            {
                var itemsList = new List<items>();
                var item = new items();
                var baseIndent = ld[i].Indent;

                i++;
                while (ld[i].Indent > baseIndent && i < ld.Count - 1)//till end of all stores
                {
                    if (ld[i].startList == true && item.typeName != null)
                    {
                        itemsList.Add(item);
                        item = new items();
                    }

                    switch (ld[i].Key)
                    {
                        case "type":
                            item.typeName = ld[i].Value;
                            break;
                        case "sub_total":
                            item.sub_total = Convert.ToDecimal(ld[i].Value);
                            break;
                        case "text":
                            item.text = ld[i].Value;
                            break;
                    }
                    i++;
                }
                if (item.typeName != null)
                    itemsList.Add(item);

                i--;
                return itemsList;
            }

            public class promotion_pass
            {
                public string type { get; set; }
                public string code { get; set; }
                public string name { get; set; }
            }

            public promotion_pass makePromoPass(List<LineDetails> ld)
            {
                var promoPass = new promotion_pass();
                var baseLevel = ld[i].Indent;
                i++;
                while (ld[i].Indent > baseLevel && i < ld.Count - 1)
                {
                    switch (ld[i].Key)
                    {
                        case "type":
                            promoPass.type = ld[i].Value;
                            break;
                        case "code":
                            promoPass.code = ld[i].Value;
                            break;
                        case "name":
                            promoPass.name = ld[i].Value;
                            break;
                    }
                    i++;
                }
                i--;
                return promoPass;

            }

            public class promotions
            {
                public string promoName { get; set; }
                public decimal discAmnt { get; set; }
            }

            public List<promotions> makePromotionsList(List<LineDetails> ld)
            {
                var list = new List<promotions>();
                var promo = new promotions();
                var baseIndent = ld[i].Indent;

                i++;
                while (ld[i].Indent > baseIndent && i < ld.Count - 1)//till end of all stores
                {
                    if (ld[i].startList == true && promo.promoName != null)
                    {
                        list.Add(promo);
                        promo = new promotions();
                    }

                    switch (ld[i].Key)
                    {
                        case "sub_total":
                            promo.discAmnt = Convert.ToDecimal(ld[i].Value);
                            break;
                        case "text":
                            promo.promoName = ld[i].Value;
                            break;
                    }
                    i++;
                }
                if (promo.promoName != null)
                    list.Add(promo);
                i--;
                return list;
            }

        }

        private shopping_cart makeShopping_cart(List<LineDetails> ld)
        {
            var shopCart = new shopping_cart();
            var baseLevel = ld[i].Indent;
            i++;
            while (ld[i].Indent > baseLevel && i < ld.Count - 1)
            {
                switch (ld[i].Key)
                {
                    case "status":
                        shopCart.status = shopCart.getStatus(ld);
                        break;
                    case "items":
                        shopCart.itemlist = shopCart.makeCartItemsList(ld);
                        break;
                    case "promotion_pass":
                        shopCart.promoPass = shopCart.makePromoPass(ld);
                        break;
                    case "sub_total":
                        shopCart.sub_total = ld[i].Value;
                        break;
                    case "created_at":
                        shopCart.created_at = ld[i].Value;
                        break;
                    case "channel":
                        shopCart.channel = ld[i].Value;
                        break;
                    case "promotions":
                        shopCart.promoList = shopCart.makePromotionsList(ld);
                        break;
                    case "transaction_data":
                        skipcatagory(ld);
                        break;
                    case "id":
                        shopCart.id = ld[i].Value;
                        break;
                    case "currency_code":
                        shopCart.currency_code = ld[i].Value;
                        break;
                }
                i++;
            }
            i--;
            return shopCart;
            }

        class dakisStore
        {
            public string email { get; set; }
            public string phone { get; set; }
            public string dakisId { get; set; }
            public string state { get; set; }
            public string zip { get; set; }
            public string address { get; set; }
            public string name { get; set; }
            public string city { get; set; }
            public string country { get; set; }

        }

        private List<dakisStore> getAllStoresList(List<LineDetails> ld)
        {
            var list = new List<dakisStore>();
            var store = new dakisStore();
            var baseIndent = ld[i].Indent;

            i++;
            while (ld[i].Indent > baseIndent && i < ld.Count - 1)//till end of all stores
            {
                if (ld[i].startList == true && store.name != null)
                {
                    list.Add(store);
                    store = new dakisStore();
                }

                switch (ld[i].Key)
                {
                    case "email":
                        store.email = ld[i].Value;
                        break;
                    case "phone_number":
                        store.phone = ld[i].Value;
                        break;
                    case "id":
                        store.dakisId = ld[i].Value;
                        break;
                    case "state":
                        store.state = ld[i].Value;
                        break;
                    case "postal_code":
                        store.zip = ld[i].Value;
                        break;
                    case "address":
                        store.address = ld[i].Value;
                        break;
                    case "name":
                        store.name = ld[i].Value;
                        break;
                    case "city":
                        store.city = ld[i].Value;
                        break;
                    case "country":
                        store.country = ld[i].Value;
                        break;
                }
                i++;
            }
            if (store.name != null)
            {
                list.Add(store);
            }
            i--;
            return list;
        }

        class printOrdOptions
        {
            public string text { get; set; }
            public string withQuant { get; set; }
            public string perItem { get; set; }
            public string groupText { get; set; }
            public string labworksCode { get; set; }
            public int quant { get; set; }
            public decimal price { get; set; }
        }

        private List<printOrdOptions> getPrntOrdOptList(List<LineDetails> ld)
        {
            var list = new List<printOrdOptions>();
            var option = new printOrdOptions();
            var baseIndent = ld[i].Indent;

            i++;
            while (ld[i].Indent > baseIndent && i < ld.Count - 1)//till end of all stores
            {
                if (ld[i].startList == true && option.text != null)
                {
                    list.Add(option);
                    option = new printOrdOptions();
                }

                switch (ld[i].Key)
                {
                    case "text_en":
                        option.text = ld[i].Value;
                        break;
                    case "with_quantity":
                        option.withQuant = ld[i].Value;
                        break;
                    case "per_item":
                        option.perItem = ld[i].Value;
                        break;
                    case "group_text_en":
                        option.groupText = ld[i].Value;
                        break;
                    case "labworks_item_code":
                        option.labworksCode = ld[i].Value;
                        break;
                    case "quantity":
                        option.quant = Convert.ToInt32(ld[i].Value);
                        break;
                    case "price":
                        option.price = Convert.ToDecimal(ld[i].Value);
                        break;
                }
                i++;
            }
            if (option.text != null)
                list.Add(option);

            i--;
            return list;
        }

        class taxes
        {
            public decimal combined { get; set; }
            public string name { get; set; }
        }

        private List<taxes> getTaxesList(List<LineDetails> ld)
        {
            var list = new List<taxes>();
            var tax = new taxes();
            var baseIndent = ld[i].Indent;

            i++;
            while (ld[i].Indent > baseIndent && i < ld.Count - 1)//till end of all stores
            {
                if (ld[i].startList == true && tax.name != null)
                {
                    list.Add(tax);
                    tax = new taxes();
                }

                switch (ld[i].Key)
                {
                    case "combined":
                        tax.combined = Convert.ToDecimal(ld[i].Value);
                        break;
                    case "name":
                        tax.name = ld[i].Value;
                        break;
                }
                i++;
            }
            if (tax.name != null)
            {
                list.Add(tax);
            }
            i--;
            return list;
        }

        public class additionalInfo
        {
            public string orderId { get; set; }
            public string month { get; set; }
            public string sec { get; set; }
            public string year { get; set; }
            public string hour { get; set; }
            public string min { get; set; }
            public string kioskVer { get; set; }
            public string day { get; set; }
            public string kioskId { get; set; }
        }

        private additionalInfo getAddnlInfo(List<LineDetails> ld)
        {
            var aInfo = new additionalInfo();
            var baseIndent = ld[i].Indent;

            i++;
            while (ld[i].Indent > baseIndent && i < ld.Count - 1)
            {
                switch (ld[i].Key)
                {
                    case "orderid":
                        aInfo.orderId = ld[i].Value;
                        break;
                    case "month":
                        aInfo.month = ld[i].Value;
                        break;
                    case "second":
                        aInfo.sec = ld[i].Value;
                        break;
                    case "year":
                        aInfo.year = ld[i].Value;
                        break;
                    case "hour":
                        aInfo.hour = ld[i].Value;
                        break;
                    case "minute":
                        aInfo.min = ld[i].Value;
                        break;
                    case "kioskVersion":
                        aInfo.kioskVer = ld[i].Value;
                        break;
                    case "day":
                        aInfo.day = ld[i].Value;
                        break;
                    case "kioskid":
                        aInfo.kioskId = ld[i].Value;
                        break;
                }
                i++;
            }
            i--;
            return aInfo;
        }

        class printFormats
        {
            public string name { get; set; }
            public string labworksCode { get; set; }
            public string id { get; set; }
        }

        private List<printFormats> getPrntFrmtList(List<LineDetails> ld)
        {
            var list = new List<printFormats>();
            var prtFrmt = new printFormats();
            var baseIndent = ld[i].Indent;

            i++;
            while (ld[i].Indent > baseIndent && i < ld.Count - 1)//till end of all stores
            {
                if (ld[i].startList == true && prtFrmt.name != null)
                {
                    list.Add(prtFrmt);
                    prtFrmt = new printFormats();
                }

                switch (ld[i].Key)
                {
                    case "name_en":
                        prtFrmt.name = ld[i].Value;
                        break;
                    case "labworks_item_code":
                        prtFrmt.labworksCode = ld[i].Value;
                        break;
                    case "id":
                        prtFrmt.id = ld[i].Value;
                        break;
                }
                i++;
            }
            if (prtFrmt.name != null)
                list.Add(prtFrmt);

            i--;
            return list;
        }

        class shipInfo
        {
            public string labworksShpCode { get; set; }
            public string method { get; set; }
            public decimal price { get; set; }
            public bool pickupInStore { get; set; }
        }

        private shipInfo GetShipInfo(List<LineDetails> ld)
        {
            var sInfo = new shipInfo();
            var baseIndent = ld[i].Indent;

            i++;
            while (ld[i].Indent > baseIndent && i < ld.Count - 1)
            {
                switch (ld[i].Key)
                {
                    case "labworks_shipping_code":
                        sInfo.labworksShpCode = ld[i].Value;
                        break;
                    case "method":
                        sInfo.method = ld[i].Value;
                        break;
                    case "price":
                        sInfo.price = Convert.ToDecimal(ld[i].Value);
                        break;
                    case "pickup_in_store":
                        sInfo.pickupInStore = Convert.ToBoolean(ld[i].Value);
                        break;
                }
                i++;
            }
            i--;
            return sInfo;
        }

        class customer
        {
            public string id { get; set; }
            public string fName { get; set; }
            public string lName { get; set; }
            public string company { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string zip { get; set; }
            public string country { get; set; }
            public string phone { get; set; }
            public string email { get; set; }

            public string shpFname { get; set; }
            public string shpLname { get; set; }
            public string shpCompany { get; set; }

            public string billAdd1 { get; set; }
            public string billAdd2 { get; set; }
            public string billCity { get; set; }
            public string billState { get; set; }
            public string billZip { get; set; }
            public string billCountry { get; set; }
        }

        private customer getCustomer(List<LineDetails> ld)
        {
            var cus = new customer();
            var baseIndent = ld[i].Indent;

            i++;
            while (ld[i].Indent > baseIndent && i < ld.Count - 1)//till end of all stores
            {
                switch (ld[i].Key)
                {
                    case "email":
                        cus.email = ld[i].Value;
                        break;
                    case "shipping_last_name":
                        cus.shpLname = ld[i].Value;
                        break;
                    case "id":
                        cus.id = ld[i].Value;
                        break;
                    case "state":
                        cus.state = ld[i].Value;
                        break;
                    case "billing_postal_code":
                        cus.billZip = ld[i].Value;
                        break;
                    case "shipping_first_name":
                        cus.shpFname = ld[i].Value;
                        break;
                    case "last_name":
                        cus.lName = ld[i].Value;
                        break;
                    case "billing_address_2":
                        cus.billAdd1 = ld[i].Value;
                        break;
                    case "billing_address_1":
                        cus.billAdd2 = ld[i].Value;
                        break;
                    case "shipping_company":
                        cus.shpCompany = ld[i].Value;
                        break;
                    case "postal_code":
                        cus.zip = ld[i].Value;
                        break;
                    case "billing_state":
                        cus.billState = ld[i].Value;
                        break;
                    case "billing_city":
                        cus.billCity = ld[i].Value;
                        break;
                    case "billing_country":
                        cus.billCountry = ld[i].Value;
                        break;
                    case "first_name":
                        cus.fName = ld[i].Value;
                        break;
                    case "city":
                        cus.city = ld[i].Value;
                        break;
                    case "address_2":
                        cus.address2 = ld[i].Value;
                        break;
                    case "address_1":
                        cus.address1 = ld[i].Value;
                        break;
                    case "country":
                        cus.country = ld[i].Value;
                        break;
                    case "company":
                        cus.company = ld[i].Value;
                        break;
                    case "phone":
                        cus.phone = ld[i].Value;
                        break;
                }
                i++;
            }
            i--;
            return cus;
        }

        class photos
        {
            public List<prints> printList { get; set; }
            public bool sourceAvailable { get; set; }
            public string publicUrl { get; set; }
            public string filename { get; set; }
            public string id { get; set; }
        }

        private List<photos> getPhotoList(List<LineDetails> ld)
        {
            var list = new List<photos>();
            var photo = new photos();
            var baseIndent = ld[i].Indent;

            i++;
            while (ld[i].Indent > baseIndent && i < ld.Count - 1)//till end of all stores
            {
                if (ld[i].startList == true && photo.filename != null)
                {
                    list.Add(photo);
                    photo = new photos();
                }

                switch (ld[i].Key)
                {
                    case "prints":
                        photo.printList = getPrintList(ld);
                        break;
                    case "source_file_available":
                        photo.sourceAvailable = Convert.ToBoolean(ld[i].Value);
                        break;
                    case "public_url":
                        photo.publicUrl = ld[i].Value;
                        break;
                    case "filename":
                        photo.filename = ld[i].Value;
                        break;
                    case "id":
                        photo.id = ld[i].Value;
                        break;
                }
                i++;
            }
            if (photo.filename != null)
                list.Add(photo);

            i--;
            return list;
        }

        class prints
        {
            public string fulfillment_type { get; set; }
            public string fulfillment_retailer_id { get; set; }
            public string text { get; set; }
            public string fulfillment_store_id { get; set; }
            public decimal unit_price { get; set; }
            public int quantity { get; set; }
            public string labworks_code { get; set; }
            public string prt_format_id { get; set; }
        }

        private List<prints> getPrintList(List<LineDetails> ld)
        {
            var list = new List<prints>();
            var print = new prints();
            var baseIndent = ld[i].Indent;

            i++;
            while (ld[i].Indent > baseIndent && i < ld.Count - 1)//till end of all stores
            {
                if (ld[i].startList == true && print.text != null)
                {
                    list.Add(print);
                    print = new prints();
                }

                switch (ld[i].Key)
                {
                    case "fulfillment_type":
                        print.fulfillment_type = ld[i].Value;
                        break;
                    case "fulfillment_retailer_id":
                        print.fulfillment_retailer_id = ld[i].Value;
                        break;
                    case "text":
                        print.text = ld[i].Value;
                        break;
                    case "fulfillment_store_id":
                        print.fulfillment_store_id = ld[i].Value;
                        break;
                    case "unit_price":
                        print.unit_price = Convert.ToDecimal(ld[i].Value);
                        break;
                    case "quantity":
                        print.quantity = Convert.ToInt32(ld[i].Value);
                        break;
                    case "labworks_item_code":
                        print.labworks_code = ld[i].Value;
                        break;
                    case "print_format_id":
                        print.prt_format_id = ld[i].Value;
                        break;
                }
                i++;
            }
            if (print.text != null)
                list.Add(print);

            i--;
            return list;
        }



        class gifts
        {
            public string itemCode { get; set; }
            public string descript { get; set; }
            public int quant { get; set; }
            public decimal price { get; set; }
            public string fulfillment_store_id { get; set; }
            public List<giftOptions> giftOptList { get; set; }
            public string editUrl { get; set; }
            public string catagory { get; set; }
            public string subCatagory { get; set; }
            public string text { get; set; }
            public string spec_values { get; set; }

        }

        private List<gifts> getGiftList(List<LineDetails> ld)
        {
            var list = new List<gifts>();
            var gift = new gifts();
            var baseIndent = ld[i].Indent;

            i++;
            while (ld[i].Indent > baseIndent && i < ld.Count - 1)//till end of all stores
            {
                if (ld[i].startList == true && gift.descript != null)
                {
                    list.Add(gift);
                    gift = new gifts();
                }

                switch (ld[i].Key)
                {
                    case "labworks_item_code":
                        gift.itemCode = ld[i].Value;
                        break;
                    case "text":
                        gift.descript = ld[i].Value;
                        break;
                    case "quantity":
                        gift.quant = Convert.ToInt32(ld[i].Value);
                        break;
                    case "price":
                        gift.price = Convert.ToDecimal(ld[i].Value);
                        break;
                    case "fulfillment_store_id":
                        gift.fulfillment_store_id = ld[i].Value;
                        break;
                    case "labworks_photo_gift_options":
                        gift.giftOptList = getGiftOptList(ld);
                        break;
                    case "edit_url":
                        gift.editUrl = ld[i].Value;
                        break;
                    case "category":
                        gift.catagory = ld[i].Value;
                        break;
                    case "sub_category":
                        gift.subCatagory = ld[i].Value;
                        break;
                    case "spec_values":
                        gift.spec_values = ld[i].Value;
                        break;
                    case "page_orders":
                        skipcatagory(ld);
                        break;

                }
                i++;
            }
            if ( gift.descript != null)
                list.Add(gift);

            i--;
            return list;
        }

        class giftOptions
        {
            public string OptCode { get; set; }
            public string Description { get; set; }
            public int Quant { get; set; }
            public decimal Price { get; set; }
        }

        private List<giftOptions> getGiftOptList(List<LineDetails> ld)
        {
            var list = new List<giftOptions>();
            var giftOpt = new giftOptions();
            var baseIndent = ld[i].Indent;

            i++;
            while (ld[i].Indent > baseIndent && i < ld.Count - 1)//till end of all stores
            {
                if (ld[i].startList == true && giftOpt.Description != null)
                {
                    list.Add(giftOpt);
                    giftOpt = new giftOptions();
                }

                switch (ld[i].Key)
                {
                    case "labworks_code":
                        giftOpt.OptCode = ld[i].Value;
                        break;
                    case "text_en":
                        giftOpt.Description = ld[i].Value;
                        break;
                    case "quantity":
                        giftOpt.Quant = Convert.ToInt32(ld[i].Value);
                        break;
                    case "price":
                        giftOpt.Price = Convert.ToUInt32(ld[i].Value);
                        break;
                }
                i++;
            }
            if (giftOpt.Description != null)
                list.Add(giftOpt);

            i--;
            return list;
        }

        private static void skipcatagory(List<LineDetails> ld)
        {
            var baseLevel = ld[i].Indent;
            i++;
            while (ld[i].Indent > baseLevel && i < ld.Count - 1)//till end of store
            {
                i++;
            }
            i--;
        }

        private static List<OrderItems> makeListOfOrderItems(DakisOrder dOrder)
        {
            OrderItems item;
            var itemsList = new List<OrderItems>();

            if (dOrder.photoList.Count > 0)
            {
                foreach (photos photo in dOrder.photoList)// find first fulfillment location
                {
                    foreach (prints print in photo.printList)
                    {
                        item = new OrderItems();
                        item.ItemCode = print.labworks_code;
                        item.Description = print.text;
                        item.Quant = print.quantity;
                        item.Price = print.unit_price;
                        foreach (dakisStore dStore in dOrder.dStoreList)
                        {
                            if (dStore.dakisId == print.fulfillment_store_id)
                            {
                                var fillLoc = Locations.GetLocByKeyWord(Set.OrdSysName.Dakis, dStore.name);
                                if(fillLoc == null)
                                    Data.LogEvents(0, "Dakis location lookup by keyword not found for \n"+ dStore.name);
                                item.FulfillerId = Convert.ToUInt32(fillLoc.Id);
                            }
                        }
                        item.OptionsList = new List<ItemOptions>();
                        itemsList.Add(item);
                    }
                }
            }
            if (dOrder.giftOrdList.Count > 0)
            {
                foreach (gifts gift in dOrder.giftOrdList)
                {
                    item = new OrderItems();
                    item.ItemCode = gift.itemCode;
                    if(item.ItemCode ==" \"\"")
                        item.ItemCode = gift.spec_values;

                    item.Description = gift.descript;
                    item.Quant = gift.quant;
                    item.Price = gift.price;
                    item.Catagory = gift.catagory;
                    item.SubCatagory = gift.subCatagory;
                    foreach (dakisStore dStore in dOrder.dStoreList)
                    {
                        if (dStore.dakisId == gift.fulfillment_store_id)
                        {
                            var fillLoc = Locations.GetLocByKeyWord(Set.OrdSysName.Dakis, dStore.name);
                            item.FulfillerId = Convert.ToUInt32(fillLoc.Id);
                        }
                    }
                    item.OptionsList = new List<ItemOptions>();
                    itemsList.Add(item);
                }
            }
            return itemsList;
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

        private string makeTextFieldFromItemsList(List<OrderItems> itemsList)
        {
            string prodField = "";
            foreach (var item in itemsList)
            {
                prodField = (prodField == "") ? item.ItemCode : prodField + "," + item.ItemCode;
            }
            return prodField;
        }

        public class LineDetails
        {
            public int Indent { get; set; }
            public string Key { get; set; }
            public string Value { get; set; }
            public bool startList { get; set; }

            public static LineDetails GetLineDetails(string line)
            {
                int splitlimit = 3;
                char[] sep = { Convert.ToChar(":") };
                var split = line.Split(sep, splitlimit);
                var ld = new LineDetails();
                try
                {
                    ld.Indent = split[0].Length;
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
#endregion
}