using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Timeclock
{
    public class ClkScreen
    {
        private TabPage tab_Clock;
        private Database LdataR;

        public ClkScreen(TabPage _tab_Clock)
        {
            this.tab_Clock = _tab_Clock;
            this.LdataR = new Database(Clock.DataLocation);
        }

        public void SetupClockScreen()
        {
            tab_Clock.Controls.Clear();

            var listOfEmp = GenerateEmployees();

        }

        private List<Employee> GenerateEmployees()
        {
            int topThisStore = -40;
            int topOtherStore = -40;
            int rightColumn = 25;
            int leftColumn = 430;
            int left;
            int top;
            var listOfEmp = LdataR.GetEmployeesForButtons();

            for (int i = 0; i < listOfEmp.Count; i++)
            {
                listOfEmp[i] = LdataR.GetLastPunch(listOfEmp[i]); //fill emp punch fields
                listOfEmp[i].Status = (listOfEmp[i].TimeIn == null
                                     | listOfEmp[i].TimeOut != null)
                                     ? "Out" : "In";

                if (listOfEmp[i].StoreId == Clock.StoreId)
                {
                    left = rightColumn;
                    topThisStore += 65;
                    top = topThisStore;
                }
                else
                {
                    topOtherStore += 65;
                    left = leftColumn;
                    top = topOtherStore;
                }
                listOfEmp[i].pchButton = GenerateEmpButton(listOfEmp[i], top, left);
            }
            return listOfEmp;
        }
        

        private Button GenerateEmpButton(Employee emp, int top, int left)
        {
            var button = new Button();
            button.Name = "btn_"+emp.Id.ToString();
            button.Top = top;
            button.Left = left;
            button.Width = 100;
            button.Height = 50;
            button.Tag = emp;
            button.Text = emp.NicName;
            if (emp.StoreId != Clock.StoreId)
                button.Enabled = false;
            button.BackColor = emp.Status == "In"
                ? System.Drawing.Color.LightSeaGreen
                : System.Drawing.Color.MistyRose;
            button.Click += new System.EventHandler(this.Button_Click);
            tab_Clock.Controls.Add(button);
            return button;

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            var emp = but.Tag as Employee;
            emp = LdataR.GetLastPunch(emp);
            if (emp.Status == "Out")
            {
                LdataR.PunchIn(emp.Id, emp.StoreId);
                emp.Status = "In";
                emp.pchButton.BackColor = System.Drawing.Color.LightSeaGreen;
            }
            else
            {
                LdataR.PunchOut(emp.lastPunchId);
                emp.Status = "Out";
                emp.pchButton.BackColor = System.Drawing.Color.MistyRose;
            }
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string NicName { get; set; }
        public int StoreId { get; set; }
        public string Status { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public Button pchButton { get; set; }
        public int lastPunchId { get; set; }

        public Employee(int _empId, string _nicName, int _strId, string _status)
        {
            Id = _empId;
            NicName = _nicName;
            StoreId = _strId;
            Status = _status;
        }

    }
}
