using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hots
{
    public class OrdHdrShort
    {
        public int id { get; set; }
        public DateTime timeIn { get; set; }
        public DateTime timeDue { get; set; }
        public string hiteId { get; set; }
        public int cusId { get; set; }
        public string cusName { get; set; }
        public string cusPhone { get; set; }
        public string ordSystem { get; set; }
        public string pickup { get; set; }
        public string status { get; set; }
        public string location { get; set; }
        public string products { get; set; }

        public OrdHdrShort(string _hiteId, string _ordSystem)
        {
            hiteId = _hiteId;
            ordSystem = _ordSystem;

            if(hiteIdAlreadyInDatabase(hiteId))
            {

            }
        }

        private List<string> readOrdHdrShortDataToList()
        {
            throw new NotImplementedException();
        }

        private OrdHdrShort fillPropertiesFromList(OrdHdrShort newOrder, List<string> newOrderDataList)
        {
            throw new NotImplementedException();
        }



        private bool hiteIdAlreadyInDatabase(string hiteId)
        {
            throw new NotImplementedException();
        }
    }
}
