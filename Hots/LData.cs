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
    class LData
    {
        private string ConnString;
        public LData(string source)
        {
            if (source == "Local")
                ConnString = "server=localhost;user=root;database=hots;port=3306;password=6716;";

            if (source == "Web")
                ConnString = "server=69.89.31.188;user=hitephot_don;database=hitephot_hots;port=3306;password=Hite1985;";
        }

        public UInt32 SaveNewOrderHeader(ReadRoesIncomingOrderFile _fl)
        {
            string sql;
            {
                sql = "INSERT INTO orderheaders " +
                    "(Ord_HiteId,Ord_AltId,Ord_TimeIn,Ord_PreTaxTotal,Ord_PromoCode,Ord_DiscAmount,Ord_SalesTax," +
                    "Ord_TotalPrice,Ord_PrePaid,Ord_labLabel,Ord_Catalog,Ord_FullfillmentStore,Ord_ServiceTime," +
                    "Ord_OrderSystem,Ord_Products,Ord_CusId,Ord_CusName,Ord_CusAddress1,Ord_CusAddress2," +
                    "Ord_CusCity,Ord_CusState,Ord_CusZip,Ord_CusCountry,Ord_CusPhone,Ord_CusEmail,Ord_BillTo," +
                    "Ord_BillCCName,Ord_BillCCCity,Ord_BillCCState,Ord_BillCCZip,Ord_ShipMethod,Ord_ShipCost," +
                    "Ord_ShipTo,Ord_ShipName,Ord_ShipAddress,Ord_ShipCity,Ord_ShipState,Ord_ShipZip," +
                    "Ord_ShipPhone,Ord_ShipEmail,Ord_PayCCType,Ord_PayCCNumber,Ord_PayCCCvv,Ord_PayCCExp)" +

                    "VALUES(?HiteId,?AltId,?Timein,?PreTaxTotal,?PromoCode,?DiscAmount,?SalesTax," +
                    "?TotalPrice,?PrePaid,?LabLabel,?Catalog,?Fullfillment,?ServiceTime," +
                    "?OrderSystem,?Products,?CusId,?CusName,?CusAddress1,?CusAddress2," +
                    "?CusCity,?CusState,?CusZip,?CusCountry,?CusPhone,?CusEmail,?BillTo," +
                    "?BillCCName,?BillCCCity,?BillCCState,?BillCCZip,?ShipMethod,?ShipCost," +
                    "?ShipTo,?ShipName,?ShipAddress,?ShipCity,?ShipState,?ShipZip,?ShipPhone," +
                    "?ShipEmail,?PayCCType,?PayCCNumber,?Paycvv,?PayCCExp)"; 
            }               

            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@?HiteId", _fl.HiteId);
                cmd.Parameters.AddWithValue("@?AltId", _fl.AlternateId);
                cmd.Parameters.AddWithValue("@?Timein", _fl.TimeIn);
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
                cmd.Parameters.AddWithValue("@?OrderSystem", _fl.OrderSystem);
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
                    //MessageBox.Show(mySqlId.ToString());
                    SaveNewOrderItems(mySqlId, _fl);
                    SaveNewOrderOptions(mySqlId, _fl.OrderOptionsList);
                    return mySqlId;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Unknown error occured updating store database \r\n \r n" + ex.Number + "\r\n" + ex);
                    return 0;
                }
            }
        }

        private void SaveNewOrderItems(uint mySqlId, ReadRoesIncomingOrderFile _fl)
        {
            using (var conn = new MySqlConnection(ConnString))
            {
                foreach (OrderItems item in _fl.ItemsList)
                {
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
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
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    SaveNewOrderItemOptions(mySqlId, item);

                }
            }
            
        }

        private void SaveNewOrderItemOptions(uint mySqlId, OrderItems item)
        {
            using (var conn = new MySqlConnection(ConnString))
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
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private void SaveNewOrderOptions(uint mySqlId, List<OrderOptions> options)
        {
            using (var conn = new MySqlConnection(ConnString))
            {
                foreach (OrderOptions option in options)
                {
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
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
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
