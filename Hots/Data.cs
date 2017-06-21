using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Hots
{
    public static class Data
    {
        private static List<Tuple<int, string>> LogList;

        public static void LogEvents(int status, string text)
        {
            text = DateTime.Now.ToString("MM/dd h:mm:ss tt") + "  " + text;
            if (Set.MainForm == null)//Form has not yet been created
            {
                if (LogList == null)
                    LogList = new List<Tuple<int, string>>();

                LogList.Add(new Tuple<int, string>(status, text));
                writeToLogFile(status, text);
            }
            else//Form has been created
            {
                if (LogList.Count > 0)//there is a list waiting to be added to txtbox
                {
                    foreach (Tuple<int, string> entry in LogList)
                        Set.MainForm.UpdateStatusWindow(entry.Item1, entry.Item2);

                    LogList.Clear();
                }
                Set.MainForm.UpdateStatusWindow(status, text);
            }
        }

        private static void writeToLogFile(int status, string text)
        {
            var stringToWrite = (status == 1) ? text : "ERROR  " + text;
          //todo  throw new NotImplementedException();
        }

        #region Save Order
        public static UInt32 SaveOrdertoSqlServer(Order _fl)
        {
            string sql;
            {
                sql = "INSERT INTO orderheaders " +
                    "(Ord_OrdStatus,Ord_HiteId,Ord_AltId,Ord_TimeIn,Ord_TimeDue,Ord_PreTaxTotal,Ord_PromoCode,Ord_DiscAmount,Ord_SalesTax," +
                    "Ord_TotalPrice,Ord_PrePaid,Ord_labLabel,Ord_Catalog,Ord_FullfillmentStore,Ord_Location,Ord_ServiceTime," +
                    "Ord_OrderSystem,Ord_Products,Ord_CusId,Ord_CusName,Ord_CusAddress1,Ord_CusAddress2," +
                    "Ord_CusCity,Ord_CusState,Ord_CusZip,Ord_CusCountry,Ord_CusPhone,Ord_CusEmail,Ord_BillTo," +
                    "Ord_BillCCName,Ord_BillCCCity,Ord_BillCCState,Ord_BillCCZip,Ord_ShipMethod,Ord_ShipCost," +
                    "Ord_ShipTo,Ord_ShipName,Ord_ShipAddress,Ord_ShipCity,Ord_ShipState,Ord_ShipZip," +
                    "Ord_ShipPhone,Ord_ShipEmail,Ord_PayCCType,Ord_PayCCNumber,Ord_PayCCCvv,Ord_PayCCExp)" +

                    "VALUES(?OrdStatus,?HiteId,?AltId,?Timein,?TimeDue,?PreTaxTotal,?PromoCode,?DiscAmount,?SalesTax," +
                    "?TotalPrice,?PrePaid,?LabLabel,?Catalog,?Fullfillment,?OrdLocation,?ServiceTime," +
                    "?OrderSystem,?Products,?CusId,?CusName,?CusAddress1,?CusAddress2," +
                    "?CusCity,?CusState,?CusZip,?CusCountry,?CusPhone,?CusEmail,?BillTo," +
                    "?BillCCName,?BillCCCity,?BillCCState,?BillCCZip,?ShipMethod,?ShipCost," +
                    "?ShipTo,?ShipName,?ShipAddress,?ShipCity,?ShipState,?ShipZip,?ShipPhone," +
                    "?ShipEmail,?PayCCType,?PayCCNumber,?Paycvv,?PayCCExp)"; 
            }               

            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                
                cmd.Parameters.AddWithValue("@?OrdLocation", _fl.OrdLocation);
                cmd.Parameters.AddWithValue("@?OrdStatus", _fl.OrdStatus);
                cmd.Parameters.AddWithValue("@?HiteId", _fl.HiteId);
                cmd.Parameters.AddWithValue("@?AltId", _fl.AlternateId);
                cmd.Parameters.AddWithValue("@?Timein", _fl.TimeIn);
                cmd.Parameters.AddWithValue("@?TimeDue", _fl.TimeDue);
                cmd.Parameters.AddWithValue("@?PreTaxTotal", _fl.PreTaxTotal);
                cmd.Parameters.AddWithValue("@?PromoCode", _fl.PromoCode);
                cmd.Parameters.AddWithValue("@?DiscAmount", _fl.DiscAmount);
                cmd.Parameters.AddWithValue("@?SalesTax", _fl.SalesTax);
                cmd.Parameters.AddWithValue("@?TotalPrice", _fl.TotalPrice);
                cmd.Parameters.AddWithValue("@?PrePaid", _fl.PrePaid);
                cmd.Parameters.AddWithValue("@?LabLabel", _fl.LabLabel);
                cmd.Parameters.AddWithValue("@?Catalog", _fl.Catalog);
                cmd.Parameters.AddWithValue("@?Fullfillment", _fl.Fullfillment);
                cmd.Parameters.AddWithValue("@?ServiceTime", _fl.ServiceTime);
                cmd.Parameters.AddWithValue("@?OrderSystem", _fl.OrdSysName);
                cmd.Parameters.AddWithValue("@?Products", _fl.Products);
                cmd.Parameters.AddWithValue("@?CusId", _fl.CusId);
                cmd.Parameters.AddWithValue("@?CusName", _fl.CusName);
                cmd.Parameters.AddWithValue("@?CusAddress1", _fl.CusAddress1);
                cmd.Parameters.AddWithValue("@?CusAddress2", _fl.CusAddress2);
                cmd.Parameters.AddWithValue("@?CusCity", _fl.CusCity);
                cmd.Parameters.AddWithValue("@?CusState", _fl.CusState);
                cmd.Parameters.AddWithValue("@?CusZip", _fl.CusZip);
                cmd.Parameters.AddWithValue("@?CusCountry", _fl.CusCountry);
                cmd.Parameters.AddWithValue("@?CusPhone", _fl.CusPhone);
                cmd.Parameters.AddWithValue("@?CusEmail", _fl.CusEmail);
                cmd.Parameters.AddWithValue("@?BillTo", _fl.BillTo);
                cmd.Parameters.AddWithValue("@?BillCCName", _fl.BillCCName);
                cmd.Parameters.AddWithValue("@?BillCCCity", _fl.BillCCCity);
                cmd.Parameters.AddWithValue("@?BillCCState", _fl.BillCCState);
                cmd.Parameters.AddWithValue("@?BillCCZip", _fl.BillCCZip);
                cmd.Parameters.AddWithValue("@?ShipMethod", _fl.ShipMethod);
                cmd.Parameters.AddWithValue("@?ShipCost", _fl.ShipCost);
                cmd.Parameters.AddWithValue("@?ShipTo", _fl.ShipTo);
                cmd.Parameters.AddWithValue("@?ShipName", _fl.ShipName);
                cmd.Parameters.AddWithValue("@?ShipAddress", _fl.ShipAddress);
                cmd.Parameters.AddWithValue("@?ShipCity", _fl.ShipCity);
                cmd.Parameters.AddWithValue("@?ShipState", _fl.ShipState);
                cmd.Parameters.AddWithValue("@?ShipZip", _fl.ShipZip);
                cmd.Parameters.AddWithValue("@?ShipPhone", _fl.ShipPhone);
                cmd.Parameters.AddWithValue("@?ShipEmail", _fl.ShipEmail);
                cmd.Parameters.AddWithValue("@?PayCCType", _fl.PayCCType);
                cmd.Parameters.AddWithValue("@?PayCCNumber", _fl.PayCCNumber);
                cmd.Parameters.AddWithValue("@?Paycvv", _fl.PayCCcvv);
                cmd.Parameters.AddWithValue("@?PayCCExp", _fl.PayCCExp);

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    UInt32 mySqlId = Convert.ToUInt32(cmd.LastInsertedId);
                    SaveNewOrderItems(conn, mySqlId, _fl);
                    SaveNewOrderOptions(conn, mySqlId, _fl.OrderOptionsList);
                    return mySqlId;
                }
                catch (MySqlException)
                {
                    return 0;
                }
            }
        }

        private static void SaveNewOrderItems(MySqlConnection conn, uint mySqlId, Order _fl)
        {
            foreach (OrderItems item in _fl.ItemsList)
            {
                var cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO orderitems(OrdItem_OrdHdrId,OrdItem_ItemCode,OrdItem_Description," +
                                                            "OrdItem_Quant,OrdItem_Price,OrdItem_LineTotal)" +
                                                    "Values(?OrdHdrId,?ItemCode,?Description,?Quant,?Price,?Total)";
                item.MySqlOrderId = mySqlId;
                cmd.Parameters.AddWithValue("?OrdHdrId", mySqlId);
                cmd.Parameters.AddWithValue("?ItemCode", Convert.ToString(item.ItemCode));
                cmd.Parameters.AddWithValue("?Description", Convert.ToString(item.Description));
                cmd.Parameters.AddWithValue("?Quant", Convert.ToInt32(item.Quant));
                cmd.Parameters.AddWithValue("?Price", Convert.ToDecimal(item.Price));
                cmd.Parameters.AddWithValue("?Total", Convert.ToDecimal(item.LineTotal));
                cmd.ExecuteNonQuery();

                SaveNewOrderItemOptions(conn, mySqlId, item);
            }
        }

        private static void SaveNewOrderItemOptions(MySqlConnection conn, uint mySqlId, OrderItems item)
        {
            foreach (ItemOptions iOption in item.OptionsList)
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO orderitemoptions(OrdItmOpt_OrdHdrId,OrdItmOpt_OptCode,OrdItmOpt_Description," +
                                  "OrdItmOpt_Quant,OrdItmOpt_Price)" +
                                  "Values(?OrdHdrId,?OptCode,?Description,?Quant,?Price)";
                iOption.MySqlOrderId = mySqlId;
                cmd.Parameters.AddWithValue("?OrdHdrId", mySqlId);
                cmd.Parameters.AddWithValue("?OptCode", Convert.ToString(iOption.OptCode));
                cmd.Parameters.AddWithValue("?Description", Convert.ToString(iOption.Description));
                cmd.Parameters.AddWithValue("?Quant", Convert.ToInt32(iOption.Quant));
                cmd.Parameters.AddWithValue("?Price", Convert.ToDecimal(iOption.Price));
                cmd.ExecuteNonQuery();
            }
        }

        private static void SaveNewOrderOptions(MySqlConnection conn, uint mySqlId, List<OrderOptions> options)
        {
            foreach (OrderOptions option in options)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO orderoptions(OrdOpt_OrdHdrId,OrdOpt_OptCode,OrdOpt_Description," +
                                  "OrdOpt_Quant,OrdOpt_Price,OrdOpt_Text)" +
                                  "Values(?OrdHdrId,?OptCode,?Description,?Quant,?Price,?Text)";
                option.MySqlOrderId = mySqlId;
                cmd.Parameters.AddWithValue("?OrdHdrId", mySqlId);
                cmd.Parameters.AddWithValue("?OptCode", Convert.ToString(option.OptCode));
                cmd.Parameters.AddWithValue("?Description", Convert.ToString(option.Description));
                cmd.Parameters.AddWithValue("?Quant", Convert.ToInt32(option.Quant));
                cmd.Parameters.AddWithValue("?Price", Convert.ToDecimal(option.Price));
                cmd.Parameters.AddWithValue("?Text", Convert.ToString(option.Text));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion Save Order

        public static DataTable GetDataTable(string sql)
        {
            DataTable tb = new DataTable();
            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    tb.Load(reader);
                }
            }
            return tb;
        }

        public static List<PickupKeyword> GetKeywordListFromServerByOrdSys(Set.OrdSysName ordSysName)
        {
            string sql = "select * FROM pickupkeywords WHERE puk_OrdSysName = '"+ ordSysName.ToString() +"'";
            List<PickupKeyword> list = new List<PickupKeyword>();
            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var puk = new PickupKeyword();
                        puk.Id = Convert.ToUInt32(rd[0]);
                        puk.Keyword = Convert.ToString(rd[1]);
                        puk.LocId = Convert.ToUInt32(rd[2]);
                        list.Add(puk);
                    }
                }
            }
            return list;
        }

        public static List<Location> GetPickupLocListFromServer()
        {
            string sql = "select * FROM pickuplocations";
            List<Location> list = new List<Location>();
            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                try
                {
                    conn.Open();
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var pul = new Location();
                            pul.Id = Convert.ToUInt32(rd[0]);
                            pul.NicName = Convert.ToString(rd[1]);
                            pul.Name = Convert.ToString(rd[2]);
                            pul.Address = Convert.ToString(rd[3]);
                            pul.City = Convert.ToString(rd[4]);
                            pul.State = Convert.ToString(rd[5]);
                            pul.Zip = Convert.ToString(rd[6]);
                            pul.Phone = Convert.ToString(rd[7]);
                            pul.Inactive = Convert.ToBoolean(rd[8]);
                            pul.ShipCode = Convert.ToString(rd[9]);
                            list.Add(pul);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error connecting to server");
                }
            }
            return list;
        }

#region Get Orders
        public static DataTable GetShortOrderList()
        {
            string sql = "select Ord_HiteId,Ord_CusName,Ord_OrdStatus,Ord_Location," +
                         "Ord_TimeIn,Ord_Products,Ord_ShipMethod FROM orderheaders";
          //  sql = sql + " Where Ord_OrdStatus = " + _status;
          //  sql = sql + " ORDER BY Ord_HiteId";

            DataTable ordtable = new DataTable();
            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    ordtable.Load(reader);
                }
            }

            ordtable.Columns["Ord_OrdStatus"].ColumnName = "Status";
            ordtable.Columns["Ord_HiteId"].ColumnName = "Order#";
            ordtable.Columns["Ord_TimeIn"].ColumnName = "Time In";
            ordtable.Columns["Ord_CusName"].ColumnName = "Name";
            ordtable.Columns["Ord_Products"].ColumnName = "Products";
            ordtable.Columns["Ord_Location"].ColumnName = "Location";
            ordtable.Columns["Ord_ShipMethod"].ColumnName = "Pickup";
            return ordtable;
        }
        #endregion Get Orders

    }
}
