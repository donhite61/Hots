using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hots
{
    public class PickupLocation
    {
        public UInt32 PuId { get; set; }
        public string PuNicName { get; set; }
        public string PuName { get; set; }
        public string PuAddress { get; set; }
        public string PuCity { get; set; }
        public string PuState { get; set; }
        public string PuZip { get; set; }
        public string PuPhone { get; set; }
        public bool PuInactive { get; set; }
        public string PuShipCode { get; set; }

        public static DataTable GetStoreDataTable()
        {
            string sql = "SELECT strId, strNicName,strName,strAddress,strCity,strState," +
                         "strZip,strPhone,strInactive,strShipCode FROM stores ORDER BY strNicName";

            DataTable strTable = new DataTable();
            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    strTable.Load(reader);
                }
            }
            strTable.Columns["strId"].ColumnName = "Store Id";
            strTable.Columns["strNicName"].ColumnName = "Store";
            strTable.Columns["strName"].ColumnName = "Full Name";
            strTable.Columns["strAddress"].ColumnName = "Address";
            strTable.Columns["strCity"].ColumnName = "City";
            strTable.Columns["strState"].ColumnName = "State";
            strTable.Columns["strZip"].ColumnName = "Zip";
            strTable.Columns["strPhone"].ColumnName = "Phone";
            strTable.Columns["strInactive"].ColumnName = "Inactive";
            strTable.Columns["strShipCode"].ColumnName = "Ship Code";
            return strTable;
        }

        public static bool AddStore(string sNicName, string sName, string sAdd,
                           string sCity, string sSt, string sZip, string sPhone, bool sIa, string sSc)
        {
            string sql;
            {
                sql = "INSERT INTO stores " +
                    "(strId,strNicName,strName,strAddress,strCity,strState,strZip,strPhone,strInactive,strShipCode)" +
                    "VALUES(?strId,?NicName,?Name,?Address,?City,?State,?Zip,?Phone,?Inactive,?ShipCode)";
            }

            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@?strId", null);
                cmd.Parameters.AddWithValue("@?NicName", sNicName);
                cmd.Parameters.AddWithValue("@?Name", sName);
                cmd.Parameters.AddWithValue("@?Address", sAdd);
                cmd.Parameters.AddWithValue("@?City", sCity);
                cmd.Parameters.AddWithValue("@?State", sSt);
                cmd.Parameters.AddWithValue("@?Zip", sZip);
                cmd.Parameters.AddWithValue("@?Phone", sPhone);
                cmd.Parameters.AddWithValue("@?Inactive", sIa);
                cmd.Parameters.AddWithValue("@?ShipCode", sSc);

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    UInt32 mySqlId = Convert.ToUInt32(cmd.LastInsertedId);
                    return true;
                }
                catch (MySqlException)
                {
                    return false;
                }
            }
        }

        public static bool UpdateStore(int sId, string sNicName, string sName, string sAdd,
                   string sCity, string sSt, string sZip, string sPhone, bool sIa, string sSc)
        {
            string sql;
            {
                sql = "UPDATE stores SET strNicName = ?nicName, " +
                                         "strName = ?name, " +
                                         "strAddress = ?address, " +
                                         "strCity = ?city, " +
                                         "strState = ?state, " +
                                         "strZip = ?zip, " +
                                         "strPhone = ?phone, " +
                                         "strInactive = ?inactive, " +
                                         "strShipCode = ?shipCode " +
                       "WHERE strId = ?id";
            }

            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@?id", sId);
                cmd.Parameters.AddWithValue("@?nicName", sNicName);
                cmd.Parameters.AddWithValue("@?name", sName);
                cmd.Parameters.AddWithValue("@?address", sAdd);
                cmd.Parameters.AddWithValue("@?city", sCity);
                cmd.Parameters.AddWithValue("@?state", sSt);
                cmd.Parameters.AddWithValue("@?zip", sZip);
                cmd.Parameters.AddWithValue("@?phone", sPhone);
                cmd.Parameters.AddWithValue("@?inactive", sIa);
                cmd.Parameters.AddWithValue("@?shipCode", sSc);

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException)
                {
                    return false;
                }
            }
        }

        public static bool DeleteStore(int sId)
        {
            var sql = "DELETE from stores Where strId = ?Id";

            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@?Id", sId);
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException)
                {
                    return false;
                }
            }
        }

        internal static bool DoesStoreExist(string sNicName)
        {
            var sql = "select strId from stores where strNicName = '" + sNicName + "'";
            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result == null)
                    return false;

                return true;
            }
        }
    }
}
