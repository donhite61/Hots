using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hots
{
    public class PickupKeyword
    {
        public UInt32? Id { get; set; }
        public UInt32 OrdSysId { get; set; }
        public string Keyword { get; set; }
        public UInt32 LocId { get; set; }


        public static List<PickupKeyword> GetPickupKeyListFromServer()
        {
            string sql = "select * FROM pickupkeywords";
            var list = new List<PickupKeyword>();
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
                            var puk = new PickupKeyword();
                            puk.Id = Convert.ToUInt32(rd[0]);
                            puk.OrdSysId = Convert.ToUInt32(rd[1]);
                            puk.Keyword = Convert.ToString(rd[2]);
                            puk.LocId = Convert.ToUInt32(rd[3]);
                            list.Add(puk);
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

        public static bool UpdateKeywords(PickupKeyword puk)
        {
            string sql;
            if (puk.Id == null)
            {
                sql = "INSERT INTO pickupkeywords " +
                    "(puk_Id,puk_OrdSysId,puk_KeyWord,puk_LocId)" +
                    "VALUES(@Id,@OrdSysId,@KeyWord,@pukLocId)";
            }
            else
            {
                sql = "UPDATE pickupkeywords SET " +
                    "puk_Id=@Id, puk_OrdSysId=@OrdSysId, puk_KeyWord=@KeyWord, puk_LocId=@pukLocId, " +
                         "WHERE puk_Id=@Id";
            }

            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", puk.Id);
                cmd.Parameters.AddWithValue("@OrdSysId", puk.OrdSysId);
                cmd.Parameters.AddWithValue("@KeyWord", puk.Keyword);
                cmd.Parameters.AddWithValue("@pukLocId", puk.LocId);

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    if (sql.Substring(0, 6) == "INSERT")
                    {
                        puk.Id = Convert.ToUInt32(cmd.LastInsertedId);
                        Set.OrdSysList[Convert.ToInt32(puk.OrdSysId)].PuKeyWordList.Add(puk);
                    }
                    return true;
                }
                catch (MySqlException)
                {
                    MessageBox.Show("ERROR updating pickup keyword");
                    return false;
                }
            }
        }

        public static bool DelKeyWord(PickupKeyword puk)
        {
            var sql = "DELETE from pickupkeywords Where puk_Id = @Id";

            using (var conn = new MySqlConnection(Set.ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", puk.Id);
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    Set.OrdSysList[Convert.ToInt32(puk.OrdSysId)].PuKeyWordList.Remove(puk);
                    return true;
                }
                catch (MySqlException)
                {
                    MessageBox.Show("ERROR deleting pickup keyword");
                    return false;
                }
            }
        }
    }
}
