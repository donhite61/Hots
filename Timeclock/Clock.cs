using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Timeclock
{
    public static class Clock
    {
        public static string MacAddress = null;
        public static int StoreId = -1;
        public static string DataLocation = "Local";
        //public static string DataLocation = "Web";


        /// <summary>
        /// Sets TC.MacAddress or exits on error
        /// </summary>
        public static void GetMacAddress()
        {
            MacAddress =
            (
                from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up
                select nic.GetPhysicalAddress().ToString()
            ).FirstOrDefault();
            if (MacAddress == "")
            {
               // MacAddress = "DC5360673031";
                MessageBox.Show("ERROR: MacAddress not found, \r\n " +
                             "are you connected to a network? \r\n" +
                             "Cannot continue");
                Application.Exit();
            }
        }
    }
}


