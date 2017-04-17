using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hots
{
    [Serializable]
    public class OrderSystem
    {
        public string Os_Name { get; set; }
        public string Os_WatchFldr { get; set; }
        public string Os_Ext { get; set; }
        public string Os_ReadFld { get; set; }
        public string Os_OutFldr { get; set; }
        public string Os_PrdSubFldr { get; set; }
        public string Os_WaitFile { get; set; }
        public bool Os_WaitIsFldr { get; set; }
        public bool Os_Active { get; set; }
    }
}

