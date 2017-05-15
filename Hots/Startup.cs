using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hots
{
    class Startup
    {

        public static void DoStartUp()
        {
            Data.LogEvents(1, "Hots Downloader started");
            if (!Set.LoadSettings())
            {
                Set.CreateDefaultSettings();
                if (!Set.SaveSettings())
                {
                    Data.LogEvents(0, "Error creating new settings file");
                }
                else
                {
                    Data.LogEvents(1, "Default settings created and saved");
                }
            }
            else
            {
                Data.LogEvents(1, "Settings loaded successfully");
            }
            Watchers.MakeFolderWatchers();
        }
    }
}
