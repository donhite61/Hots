using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Hots
{
    static class Settings
    {
        public static string IniFile = Directory.GetCurrentDirectory() + @"\HotsSettings.ini";
        public static string FileWatcherNewPath;
        public static string FileWatcherReadPath;
        public static string RoesWatchPath;
        public static string DakisWatchPath;
        public static string DakisOrderPath;
        public static string RoesOrderPath;

    }
}
