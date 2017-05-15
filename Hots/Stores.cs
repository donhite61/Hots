using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hots
{
    public class Stores
    {
        public UInt32 StrId { get; set; }
        public string StrNicName { get; set; }
        public string StrName { get; set; }
        public string StrAddress { get; set; }
        public string StrCity { get; set; }
        public string StrState { get; set; }
        public string StrZip { get; set; }
        public string StrPhone { get; set; }
        public bool StrInactive { get; set; }

        public static DataTable GetStoreDataTable()
        {
            string sql = "SELECT strId, strNicName,strName,strAddress,strCity,strState," +
                         "strZip,strPhone,strInactive FROM stores ORDER BY strNicName";

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
            return strTable;
        }

        public static bool AddStore(string sNicName, string sName, string sAdd,
                           string sCity, string sSt, string sZip, string sPhone, bool sIa)
        {
            string sql;
            {
                sql = "INSERT INTO stores " +
                    "(strId,strNicName,strName,strAddress,strCity,strState,strZip,strPhone,strInactive)" +
                    "VALUES(?strId,?NicName,?Name,?Address,?City,?State,?Zip,?Phone,?Inactive)";
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
                   string sCity, string sSt, string sZip, string sPhone, bool sIa)
        {
            string sql;
            {
                sql = "UPDATE stores SET strId = ?Id, " +
                         "strNicName = ?nicName, " +
                         "strName = ?name, " +
                         "strAddress = ?address, " +
                         "strCity = ?city, " +
                         "strState = ?state, " +
                         "strZip = ?zip, " +
                         "strPhone = ?phone, " +
                         "strInactive = ?inactive " +
                         "WHERE strId = ?id";
            }

            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@?Id", sId);
                cmd.Parameters.AddWithValue("@?NicName", sNicName);
                cmd.Parameters.AddWithValue("@?Name", sName);
                cmd.Parameters.AddWithValue("@?Address", sAdd);
                cmd.Parameters.AddWithValue("@?City", sCity);
                cmd.Parameters.AddWithValue("@?State", sSt);
                cmd.Parameters.AddWithValue("@?Zip", sZip);
                cmd.Parameters.AddWithValue("@?Phone", sPhone);
                cmd.Parameters.AddWithValue("@?Inactive", sIa);

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

        public static bool DeleteStore(int sId)
        {
            var sql = "DELETE from stores Where strId = " + sId;

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
