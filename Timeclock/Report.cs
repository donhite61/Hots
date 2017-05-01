using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Timeclock
{
    public class Report
    {
        private List<Punch> t_punches;
        public Report(DataTable punchTable)
        {
            t_punches = new List<Punch>();

            foreach (DataRow row in punchTable.Rows)
            {

            }

                t_punches.Add(new Punch("Lahser", "Don", 10.41, 18.19, 8.62, 1));

        }

        public List<Punch> GetPunches()
        {
            return t_punches;
        }
    }

    public class Punch
    {
        public string Store { get; set; }
        public string Employee { get; set; }
        public double In { get; set; }
        public double Out { get; set; }
        public double Worked { get; set; }
        public int Week { get; set; }
        public Punch(string _store, string _emp, double _in, double _out, double _worked, int _week)
        {
            Store = _store;
            Employee = _emp;
            In = _in;
            Out = _out;
            Worked = _worked;
            Week = _week;
        }
    }
}
