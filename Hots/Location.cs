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
    public class Location
    {
        public UInt32? Id { get; set; }
        public string NicName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public bool Inactive { get; set; }
        public string ShipCode { get; set; }

        public static Location GetLocByKeyWord(Set.OrdSysName ordSysName, string text)
        {
            var ind = (int)ordSysName-1; //
            foreach (PickupKeyword kw in Set.OrdSysList[ind].PuKeyWordList)
            {
                if (text.Contains(kw.Keyword))
                {
                    foreach (Location loc in Set.LocList)
                    {
                        if (loc.Id == kw.LocId)
                            return  loc;
                    }
                }
            }
            return null;
        }

        public static string GetLocNicNameByCity(string city)
        {
            var nicName = city;
            foreach (PickupKeyword kw in Set.OrdSysList[0].PuKeyWordList)
            {
                if (city.Contains(kw.Keyword))
                {
                    foreach (Location loc in Set.LocList)
                    {
                        if (loc.Id == kw.LocId)
                            nicName = loc.NicName;
                    }
                }
            }
            return nicName;
        }

        public static string GetLocShipCodeByCity(string city)
        {
            var shipCode = city;
            foreach (PickupKeyword kw in Set.OrdSysList[0].PuKeyWordList)
            {
                if (city.Contains(kw.Keyword))
                {
                    foreach (Location loc in Set.LocList)
                    {
                        if (loc.Id == kw.LocId)
                            shipCode = loc.ShipCode;
                    }
                }
            }
            return shipCode;
        }

        public static List<Location> GetLocationList()
        {
            var list = new List<Location>();
            string sql = "SELECT loc_Id,loc_NicName,loc_Name,loc_Address,loc_City,"+
                         "loc_State,loc_Zip,loc_Phone,loc_Inactive,loc_Shipcode "+
                         "FROM locations ORDER BY loc_NicName";

            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var loc = new Location();
                        loc.Id = rd.GetUInt32(0);
                        loc.NicName = rd.GetString(1);
                        loc.Name = rd.GetString(2);
                        loc.Address = rd.GetString(3);
                        loc.City = rd.GetString(4);
                        loc.State = rd.GetString(5);
                        loc.Zip = rd.GetString(6);
                        loc.Phone = rd.GetString(7);
                        loc.Inactive = rd.GetBoolean(8);
                        loc.ShipCode = rd.GetString(9);
                        list.Add(loc);
                    }
                }
            }
            return list;
        }

        public static List<KeyValuePair<UInt32, string>> GetLocDropdownList()
        {
            var list = new List<KeyValuePair<UInt32, string>>();
            foreach (Location loc in Set.LocList)
            {
                list.Add(new KeyValuePair<UInt32,string>(Convert.ToUInt32(loc.Id), loc.NicName));
            }
            return list;
        }

        public static bool SaveLocation(Location loc)
        {
            string sql;
            if(loc.Id == null)
            {
                sql = "INSERT INTO locations " +
                      "(loc_Id,loc_NicName,loc_Name,loc_Address,loc_City,loc_State,loc_Zip,loc_Phone,loc_Inactive,loc_Shipcode)" +
                      "VALUES(@lId,@lNicName,@lName,@lAddress,@lCity,@lState,@lZip,@lPhone,@lInactive,@lShipCode)";
            }
            else
            {
                sql = "UPDATE locations SET " +
                      "loc_Id=@lId, loc_NicName=@lNicName, loc_Name=@lName, loc_Address=@lAddress, loc_City=@lCity, " +
                      "loc_State=@lState, loc_Zip=@lZip, loc_Phone=@lPhone, loc_Inactive=@lInactive, loc_Shipcode=@lShipcode " +
                      "WHERE loc_Id=@lId";
            }

            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@lId", loc.Id);
                cmd.Parameters.AddWithValue("@lNicName", loc.NicName);
                cmd.Parameters.AddWithValue("@lName", loc.Name);
                cmd.Parameters.AddWithValue("@lAddress", loc.Address);
                cmd.Parameters.AddWithValue("@lCity", loc.City);
                cmd.Parameters.AddWithValue("@lState", loc.State);
                cmd.Parameters.AddWithValue("@lZip", loc.Zip);
                cmd.Parameters.AddWithValue("@lPhone", loc.Phone);
                cmd.Parameters.AddWithValue("@lInactive", loc.Inactive);
                cmd.Parameters.AddWithValue("@lShipCode", loc.ShipCode);

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    if(sql.Substring(0,6) == "INSERT")
                    {
                        loc.Id = Convert.ToUInt32(cmd.LastInsertedId);
                        Set.LocList.Add(loc);
                    }
                    return true;
                }
                catch (MySqlException)
                {
                    MessageBox.Show("ERROR updating location");
                    return false;
                }
            }
        }

        public static bool DeleteLocation(Location loc)
        {
            var sql = "DELETE from locations Where loc_Id = @Id";

            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", loc.Id);
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    Set.LocList.Remove(loc);
                    return true;
                }
                catch (MySqlException)
                {
                    MessageBox.Show("ERROR deleting location");
                    return false;
                }
            }
        }
    }
}
