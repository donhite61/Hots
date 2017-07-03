using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hots
{
    class Startup
    {
      

        public static void DoStartUp()
        {
        string iniFile = Directory.GetCurrentDirectory() + @"\HotsSavedData.xml";
        string connString = "server=69.89.31.188;uid=hitephot_don;database=hitephot_hots;port=3306;password=Hite1985;";
        LocalSettings savedSet;
        List<OrderSystem> webOrdSysList;
        List<PickupKeyword> pukList;
        List<Locations> locList;


        Data.LogEvents(1, "Hots Downloader started");
        savedSet = LocalSettings.readSettingsfromDisk(iniFile);
        Set.SetSettingsFromReadFile(savedSet, iniFile, connString);//fills default inifile & connstring if blank

        locList = Locations.GetLocationList();
        Set.LocList = locList;

        if (savedSet != null) 
            Set.ThisLocation = Locations.GetLocById(savedSet.SelectedPickupLocationId);




        Set.MakeOrdSysList();
        webOrdSysList = OrderSystem.GetOrdSysListFromServer();
        while (webOrdSysList.Count < 3)
            webOrdSysList.Add(new OrderSystem());

        pukList = PickupKeyword.GetPickupKeyListFromServer();
        FillOrdSysProperties(Set.OrdSysList, webOrdSysList, pukList, savedSet);

        Watchers.MakeFolderWatchers();
        }

        private static void FillOrdSysProperties(List<OrderSystem> osList,
                       List<OrderSystem> webOrdSysList, List<PickupKeyword> pukList, LocalSettings savedSet)
        {
            foreach (OrderSystem os in osList)
            {
                var i = Convert.ToInt32(os.Id);
                if (savedSet != null)
                {
                    os.Active = (string.IsNullOrWhiteSpace(savedSet.LocOrdSysSetList[i].Active.ToString())) ? false : savedSet.LocOrdSysSetList[i].Active;
                    os.WatchedFolder = (string.IsNullOrWhiteSpace(savedSet.LocOrdSysSetList[i].WchFldr)) ? "" : savedSet.LocOrdSysSetList[i].WchFldr;
                    os.OutputFolder = (string.IsNullOrWhiteSpace(savedSet.LocOrdSysSetList[i].OutFldr)) ? "" : savedSet.LocOrdSysSetList[i].OutFldr;
                    os.LabInFldr = (string.IsNullOrWhiteSpace(savedSet.LocOrdSysSetList[i].LabInFldr)) ? "" : savedSet.LocOrdSysSetList[i].LabInFldr;
                }

                os.ProductSubFolder = (string.IsNullOrWhiteSpace(webOrdSysList[i].ProductSubFolder)) ? "" : webOrdSysList[i].ProductSubFolder;
                os.WaitFile = (string.IsNullOrWhiteSpace(webOrdSysList[i].WaitFile)) ? "" : webOrdSysList[i].WaitFile;
                os.WaitIsFolder = (string.IsNullOrWhiteSpace(webOrdSysList[i].WaitIsFolder.ToString())) ? false : webOrdSysList[i].WaitIsFolder;
                os.Ext = (string.IsNullOrWhiteSpace(webOrdSysList[i].Ext)) ? "" : webOrdSysList[i].Ext;

                os.PuKeyWordList = new List<PickupKeyword>();
                foreach (PickupKeyword puk in pukList)
                {
                    if (puk.OrdSysId == os.Id)
                        os.PuKeyWordList.Add(puk);
                }
            }
        }
    }
}
