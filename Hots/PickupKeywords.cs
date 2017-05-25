using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hots
{
    public class PickupKeywords
    {
        public Set.OrdSysName OrdSysName { get; set; }
        public UInt32? Id { get; set; }
        public string Keyword { get; set; }
        public string PickupLocation { get; set; }

        public static DataTable GetSPickupKeywordDTableFilterByOrdSys(string ordSysName)
        {
            string sql = "SELECT puk_Id, puk_OrdSysName, puk_KeyWord, puk_PickupLocation " +
                         "FROM pickupkeywords "+
                         "Where puk_OrdSysName = '" + ordSysName + 
                         "' ORDER BY puk_KeyWord ";

            DataTable pukTable = new DataTable();
            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    pukTable.Load(reader);
                }
            }
            pukTable.Columns["puk_Id"].ColumnName = "Id";
            pukTable.Columns["puk_OrdSysname"].ColumnName = "Order Sys";
            pukTable.Columns["puk_KeyWord"].ColumnName = "Keyword";
            pukTable.Columns["puk_PickupLocation"].ColumnName = "Pickup";
            return pukTable;
        }

        public static bool SaveKeyWord(PickupKeywords keyword)
        {
            string sql;
            if (keyword.Id != null)
            {
                sql = "REPLACE INTO pickupKeywords(puk_OrdSysName,puk_KeyWord,puk_PickupLocation)" +
                     " VALUES(?puk_OrdSysName,?puk_KeyWord,?pukPickupLocation)"+
                      " WHERE puk_Id = " + keyword.Id ;
            }
            else
            {
                sql = "INSERT INTO pickupkeywords(puk_OrdSysName, puk_KeyWord,puk_PickupLocation)" +
                     " VALUES(?puk_OrdSysName,?puk_KeyWord,?puk_PickupLocation)";
            }

            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@?puk_Id", keyword.Id);
                cmd.Parameters.AddWithValue("@?puk_KeyWord", keyword.Keyword);
                cmd.Parameters.AddWithValue("@?puk_OrdSysName", keyword.OrdSysName.ToString());
                cmd.Parameters.AddWithValue("@?puk_PickupLocation", keyword.PickupLocation);

                conn.Open();
                var success = cmd.ExecuteNonQuery() > 0 ? true : false;
                return success;
            }

        }

        public static bool DelKeyWord(PickupKeywords keyword)
        {
            var sql = "DELETE from pickupkeywords Where strId = puk_Id = ?puk_Id";
            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@?puk_Id", keyword.Id);

                conn.Open();
                var success = cmd.ExecuteNonQuery() > 0 ? true : false;
                return success;
            }
        }
    }
}
