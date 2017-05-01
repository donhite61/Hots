using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Timeclock
{
    public interface IData
    {
        int GetStoreId();
        DataTable GetStores(int storeId, int inactive);
        bool UpdateStore(string command, int id, string nicName, string name, string address, string city, string state, string zip, string phone, int inactive);

        DataTable GetJoinEmployees(int storeId, int inactive);
        bool UpdateEmployee(string command, int id, string nicName, int storeId, string lName, string fName, string phone, string eMail, int inactive);

        bool UpdateUser(string macAddress, int storeId);

    }

    public class Database : IData
    {
        private string ConnString;

        public Database(string source)
        {
            if (source == "Local")
                ConnString = "server=localhost;user=root;database=timeclock;port=3306;password=6716;";

            if (source == "Web")
                ConnString = "server=69.89.31.188;user=hitephot_don;database=hitephot_timeclock;port=3306;password=Hite1985;";
        }

        public int GetStoreId()
        {
            var sql = "select usrStoreId from users where usrMacAddress = '" + Clock.MacAddress + "'";
            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result == null)
                    return -1;

                return Convert.ToInt32(result);
            }
        }

        public int GetIdFromNicName(string table, string _NicName)
        {
            var sql = "";
            if (table == "employees")
                sql = "select empId from employees where empNicName = '" + _NicName + "'";
            if (table == "stores")
                sql = "select strId from stores where strNicName = '" + _NicName + "'";
            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result == null)
                    return -1;

                return Convert.ToInt32(result);
            }
        }

        public DataTable GetStores(int storeId, int inactive)
        {
            string sql = "select strId,strNicName,strName,strAddress, strCity, " +
                             "strState, strZip, strPhone, strInactive from stores";

            if (storeId != -1)// get one store, used by set store info
            {
                sql = sql + " Where strId = " + storeId;
            }
            else
            {
                if (inactive == 0)
                    sql = sql + " Where strInactive = 0";
            }

            sql = sql + " ORDER BY strNicName";

            DataTable dtable = new DataTable();
            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dtable.Load(reader);
                }
          
            }

            dtable.Columns["strId"].ColumnName = "Id";
            dtable.Columns["strNicName"].ColumnName = "NicName";
            dtable.Columns["strName"].ColumnName = "Name";
            dtable.Columns["strAddress"].ColumnName = "Address";
            dtable.Columns["strCity"].ColumnName = "City";
            dtable.Columns["strState"].ColumnName = "State";
            dtable.Columns["strZip"].ColumnName = "Zip";
            dtable.Columns["strPhone"].ColumnName = "Phone";
            dtable.Columns["strInactive"].ColumnName = "Inactive";
            return dtable;
        }

        public bool UpdateStore(string command, int id, string nicName, string name, string address, string city, string state, string zip, string phone, int inactive)
        {
            string sql;
            if (command == "DELETE")
            {
                sql = "DELETE from stores Where strId = " + id;
            }
            else if (command == "INSERT")
            {
                sql = "INSERT INTO stores (strNicName,strName,strAddress," +
                                      "strCity,strState,strZip,strPhone,strInactive)" +
                                      " VALUES(?nicName,?name,?address,?city,?state,?zip,?phone,?inactive)";
            }
            else if (command == "UPDATE")
            {
                sql = "UPDATE stores SET strNicName = ?nicName, " +
                                         "strName = ?name, " +
                                         "strAddress = ?address, " +
                                         "strCity = ?city, " +
                                         "strState = ?state, " +
                                         "strZip = ?zip, " +
                                         "strPhone = ?phone, " +
                                         "strInactive = ?inactive " +
                       "WHERE strId = ?id";
            }
            else
            {
                sql = "";
                MessageBox.Show("EditStoreForm send an unknown database command \r\n Cannot continue");
                Application.Exit();
            }

            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@?Id", id);
                cmd.Parameters.AddWithValue("@?nicName", nicName);
                cmd.Parameters.AddWithValue("@?name", name);
                cmd.Parameters.AddWithValue("@?address", address);
                cmd.Parameters.AddWithValue("@?city", city);
                cmd.Parameters.AddWithValue("@?state", state);
                cmd.Parameters.AddWithValue("@?zip", zip);
                cmd.Parameters.AddWithValue("@?phone", phone);
                cmd.Parameters.AddWithValue("@?inactive", inactive);
                conn.Open();
                try
                {
                    //return cmd.ExecuteNonQuery() > 0 ? true : false;
                    var success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    return success;
                }
                catch (MySqlException ex)
                {
                    switch(ex.Number)
                        {
                        case 1062:
                             MessageBox.Show("Store Nicname and/or Store name already \r\n" +
                                        " exist, please choose another name.");
                        break;

                        case 1451:
                            MessageBox.Show("You cannot delete because emps/punches \r\n "+
                                "would be left parentless \r n Please delete them first");

                            break;

                        default:
                            MessageBox.Show("Unknown error occured updating store database \r\n \r n" + ex.Number + "\r\n" + ex);

                            break;

                    }

                    return false;
                }
            }
        }


        public DataTable GetJoinEmployees(int storeId, int inactive)
        {
            string sql = "SELECT empId, empNicName, strNicName, empFname," +
                        "empLname, empPhone, empEmail, empStoreId," +
                        "empInactive FROM employees " +
                        "INNER JOIN stores ON strId = empStoreId";

            if (storeId != -1)
                sql = sql + " WHERE empStoreId =" + storeId;

            if (inactive == 0 & storeId == -1)
                sql = sql + " WHERE empInactive = 0";

            if (inactive == 0 & storeId != -1)
                sql = sql + " AND empInactive = 0";

            sql = sql + " ORDER BY empStoreId ASC, empNicName ASC";
            
            DataTable dtable = new DataTable();
            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dtable.Load(reader);
                }
            }

            dtable.Columns["empId"].ColumnName = "Id";
            dtable.Columns["empNicName"].ColumnName = "NicName";
            dtable.Columns["strNicName"].ColumnName = "Store";
            dtable.Columns["empFname"].ColumnName = "First Name";
            dtable.Columns["empLname"].ColumnName = "Last Name";
            dtable.Columns["empPhone"].ColumnName = "Phone";
            dtable.Columns["empEmail"].ColumnName = "Email";
            dtable.Columns["empStoreId"].ColumnName = "StoreId";
            dtable.Columns["empInactive"].ColumnName = "Inactive";
            return dtable;
        }

        public bool UpdateEmployee(string command, int id, string nicName, int storeId, string lName, string fName, string phone, string eMail, int inactive)
        {
            string sql;
            if (command == "DELETE")
            {
                sql = "DELETE from Employees Where empId = ?id";
            }
            else if (command == "INSERT")
            {
                sql = "INSERT INTO employees(empNicName,empStoreId,empFname,empLname,empPhone,empEmail,empInactive)" +
                                   "VALUES(?nicName,?storeId,?fName,?lName,?phone,?eMail,?inactive)";
            }
            else if (command == "UPDATE")
            {
                sql = "UPDATE employees SET empNicName = ?nicName, " +
                                         "empStoreId = ?storeId, " +
                                         "empFname = ?fName, " +
                                         "empLname = ?lName, " +
                                         "empPhone = ?phone, " +
                                         "empEmail = ?eMail, " +
                                         "empInactive = ?inactive " +
                       "WHERE empId = ?id";
            }
            else
            {
                sql = "";
                MessageBox.Show("EditEmpForm send an unknown database command \r\n Cannot continue");
                Application.Exit();
            }

            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("?id", id);
                cmd.Parameters.AddWithValue("?nicName", nicName);
                cmd.Parameters.AddWithValue("?storeId", storeId);
                cmd.Parameters.AddWithValue("?fName", fName);
                cmd.Parameters.AddWithValue("?lName", lName);
                cmd.Parameters.AddWithValue("?phone", phone);
                cmd.Parameters.AddWithValue("?eMail", eMail);
                cmd.Parameters.AddWithValue("?inactive", inactive);
                conn.Open();
                try
                {
                    return cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 1062:
                            MessageBox.Show("Employee Nicname  already exists, \r\n" +
                                            " please choose another name.");
                            break;

                        case 1451:
                            MessageBox.Show("You cannot delete because there are \r\n " +
                                "punches for this employee. \r n Please delete them first" +
                                " or mark employee inactive instead.");

                            break;

                        default:
                            MessageBox.Show("Unknown error occured updating store database \r\n \r n" + ex.Number + "\r\n" + ex);

                            break;

                    }

                    return false;
                }
            }
        }


        public DataTable GetJoinPunches(int empId, int storeId, DateTime sDate, DateTime eDate)
        {
            var sqlSdate = "'" + sDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            var sqlEdate = "'" + eDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";

            String sql = "SELECT pchId, empNicName, pchTimeIn, pchTimeOut, pchNote," +
                    "strNicName, pchEmpId, pchStoreId, pchOrgTimeIn, pchOrgTimeOut " +
                    "from punches INNER JOIN stores ON strId = pchStoreId " +
                    "INNER JOIN employees ON empId = pchEmpId " +
                    "WHERE pchInactive = 0 " +
                    "AND pchTimeIn BETWEEN " + sqlSdate + " AND " + sqlEdate;

            if (empId != -1)
                sql = sql + " AND pchEmpId = " + empId;

            if (storeId != -1)
                sql = sql + " AND pchStoreId = " + storeId;

            sql = sql + " ORDER BY pchStoreId ASC, empNicName ASC, pchTimeIn DESC";

            DataTable dtable = new DataTable();
            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dtable.Load(reader);
                }
            }

            dtable.Columns["pchId"].ColumnName = "Id";
            dtable.Columns["empNicName"].ColumnName = "Emp Name";
            dtable.Columns["pchTimeIn"].ColumnName = "Time In";
            dtable.Columns["pchTimeOut"].ColumnName = "Time Out";
            dtable.Columns["pchNote"].ColumnName = "Note";
            dtable.Columns["strNicName"].ColumnName = "Store";
            dtable.Columns["pchEmpId"].ColumnName = "Emp Id";
            dtable.Columns["pchStoreId"].ColumnName = "Store Id";
            dtable.Columns["pchOrgTimeIn"].ColumnName = "Org TimeIn";
            dtable.Columns["pchOrgTimeOut"].ColumnName = "Org TimeOut";
            dtable.Columns.Add("Hrs Worked", typeof(string));

            foreach (System.Data.DataRow row in dtable.Rows)
            {
                if (row["Time Out"] != DBNull.Value) //dont calc hrs worked if still punched in
                {
                    TimeSpan hrsWorked = Convert.ToDateTime(row["Time Out"]) - Convert.ToDateTime(row["Time In"]);
                    // row["Hrs Worked"] = hrsWorked.Hours.ToString() + ":" + hrsWorked.Minutes.ToString();
                    row["Hrs Worked"] = hrsWorked.ToString("' 'hh':'mm");
                }
            }

            return dtable;
        }
        public bool UpdatePunch(string command, int id, DateTime timeIn, DateTime? timeOut, string note, int empId, int storeId)
        {
            string sql;
            if (command == "DELETE")
            {
                sql = "DELETE from punches Where pchId = ?id";
            }
            else if (command == "INSERT")
            {
                sql = "INSERT INTO punches(pchTimeIn,pchTimeOut,pchNote,pchEmpId,pchStoreId)" +
                                   "VALUES(?timeIn,?timeOut,?note,?empId,?storeId)";
            }
            else if (command == "UPDATE")
            {
                sql = "UPDATE punches SET pchTimeIn = ?timeIn, "+
                                         "pchTimeOut = ?timeOut, "+
                                         "pchNote = ?note, "+
                                         "pchEmpId = ?empId, "+
                                         "pchStoreId = ?storeId "+
                       "WHERE pchID = ?id";
            }
            else
            {
                sql = "";
                MessageBox.Show("EditPunchForm send an unknown database command \r\n Cannot continue");
                return false;
            }

            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("?id", id);
                cmd.Parameters.AddWithValue("?timeIn", timeIn);
                cmd.Parameters.AddWithValue("?timeOut", timeOut);
                cmd.Parameters.AddWithValue("?note", note);
                cmd.Parameters.AddWithValue("?empId", empId);
                cmd.Parameters.AddWithValue("?storeId", storeId);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception e)
                {
                    MessageBox.Show( e.ToString());
                    return false;
                }

            }
        }

        public List<KeyValuePair<int,string>> GetList(string table, int storeId = -1)
        {
            string sql;
            if (table == "employees")
            {
                sql = "SELECT empId, empNicName FROM employees WHERE empInactive = 0";
                if (storeId != -1)
                    sql = sql + " AND empStoreId =" + storeId;

                sql = sql + " ORDER BY empNicName";
            }
            else
            {
                sql = "SELECT strId, strNicName FROM stores WHERE strInactive = 0 ORDER BY strNicName";
            }

            List<KeyValuePair<int, string>> cmbList = new List<KeyValuePair<int, string>>();
            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        cmbList.Add(new KeyValuePair<int, string>(reader.GetInt32(0), reader.GetString(1)));
                }

            }
            return cmbList;
        }

        /// <summary>inserts new user or updates store id if user exists</summary>
        /// <param name="macAddress"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public bool UpdateUser(string macAddress, int storeId)
        {
            object found;
            var sql = "select usrId from users where usrMacAddress = '" + Clock.MacAddress + "'";
            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                found = cmd.ExecuteScalar();
            }
                if (found == null)
                {
                    sql = "INSERT INTO users(usrId,usrMacAddress,usrStoreId)" +
                          "VALUES(?id,?macAddress, ?storeId)";
                found = 0;
                }
                else
                {
                    sql = "REPLACE INTO users(usrId,usrMacAddress,usrStoreId)" +
                          "VALUES(?id,?macAddress, ?storeId)";
                }
            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@?id",found);
                cmd.Parameters.AddWithValue("@?MacAddress", macAddress);
                cmd.Parameters.AddWithValue("@?StoreId", storeId);
                conn.Open();
                var numrows = cmd.ExecuteNonQuery();
                return numrows > 0 ? true : false;
            }
        }

        public bool CheckForDependants(string table, int Id)
        {
            string recordFound = "false";
            string sql;
            if (table == "stores")
            {
               // sql = "select usrId from users where usrStoreId = '" + Id + "'";
               // recordFound = RecordExists(sql, recordFound);
                sql = "select empId from employees where empStoreId = '" + Id + "'";
                recordFound = RecordExists(sql, recordFound);
                sql = "select pchId from punches where pchStoreId = '" + Id + "'";
                recordFound = RecordExists(sql, recordFound);
                return recordFound == "false" ? false : true;
            }
            else if (table == "employees")
            {
                sql = "select pchId from punches where pchEmpId = '" + Id + "'";
                recordFound = RecordExists(sql, recordFound);
                return recordFound == "false" ? false : true;
            }
            else
            {
                throw new Exception("invalid table passed to CheckForDependants()");
            }

        }
        private string RecordExists(string sql, string recordFound)
        {
            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                return cmd.ExecuteScalar() != null ? "true" : recordFound;
            }
        }

        public void ChangeEmpPunchesActiveState(int empId, int inactive)
        {
            string sql = "UPDATE punches SET pchInactive = "+inactive+ " WHERE pchEmpId = "+ empId;

            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                int numRowsUpdated = cmd.ExecuteNonQuery() ;
            }
        }

        public Employee GetLastPunch(Employee _emp)
        {
            var sql = "SELECT pchId, pchTimeIn, pchTimeOut FROM punches "+
                      "WHERE pchEmpId = "+ _emp.Id +
                      " ORDER BY pchId DESC LIMIT 1";
            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
               while(reader.Read())
                {
                    _emp.lastPunchId = Convert.ToInt32(reader[0]);
                    DateTime _timeIn;
                    DateTime _timeOut;
                    if (DateTime.TryParse(reader[1].ToString(), out _timeIn))
                        _emp.TimeIn = _timeIn;

                    if (DateTime.TryParse(reader[2].ToString(), out _timeOut))
                        _emp.TimeOut = _timeOut;
                }
                reader.Close();
                return _emp;
            }
        }

        public List<Employee> GetEmployeesForButtons()
        {
            string sql = "SELECT empId, empNicName, empStoreId, empStatus" +
                        " FROM employees" +
                        " WHERE empInactive = 0"+
                        " ORDER BY empNicName ASC";

            var list = new List<Employee>();
            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while(rd.Read())
                    {
                        var emp = new Employee(Convert.ToInt32(rd[0]),
                                               Convert.ToString(rd[1]),
                                               Convert.ToInt32(rd[2]),
                                               Convert.ToString(rd[3]));
                        list.Add(emp);
                    }
                }
            }
            return list;
        }

        internal void PunchOut(int lastPunchId)
        {
            var dateTimeMySql = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "UPDATE punches SET pchTimeOut = '" + dateTimeMySql +
                        "', pchOrgTimeOut = '" + dateTimeMySql +"' WHERE pchId = " + lastPunchId;

            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                int numRowsUpdated = cmd.ExecuteNonQuery();
            }
        }

        internal void PunchIn(int _empId, int _empStoreId)
        {
            var dateTimeMySql = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var sql = "INSERT INTO punches(pchEmpId, pchStoreId, pchTimeIn, pchOrgTimeIn)" +
                                    "VALUES(?empId, ?storeId, ?timeIn, ?orgTimeIn )";

            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("?timeIn", dateTimeMySql);
                cmd.Parameters.AddWithValue("?orgTimeIn", dateTimeMySql);
                cmd.Parameters.AddWithValue("?empId", _empId);
                cmd.Parameters.AddWithValue("?storeId", _empStoreId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}

