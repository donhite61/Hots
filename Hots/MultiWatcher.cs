using System;
using System.IO;
using System.Security.Permissions;
using System.Collections.Generic;
using System.ComponentModel;

namespace Hots
{
    public class Watchers
    {
        private static BackgroundWorker bWorker; //create global variable for backgroundworker object
        private static Queue<string> newOrderQueue = new Queue<string>();

        public static void MakeFolderWatchers()
        {
            bWorker = new BackgroundWorker();
            bWorker.DoWork += new DoWorkEventHandler(bWorker_DoWork);
            bWorker.ProgressChanged += new ProgressChangedEventHandler(bWorker_ProgressChanged);
            bWorker.WorkerReportsProgress = true;
            bWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bWorker_RunWorkerCompleted);

            for (int i = 0; i < Set.OrdSysList.Count; i++)
            {
                try
                {
                    if (Directory.Exists(Set.OrdSysList[i].WatchedFolder))
                    {
                        Set.OrdSysList[i].fW = new FileSystemWatcher();
                        Set.OrdSysList[i].fW.Path = Set.OrdSysList[i].WatchedFolder;
                        Set.OrdSysList[i].fW.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                      | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                        Set.OrdSysList[i].fW.Filter = "*."+Set.OrdSysList[i].Ext;
                        Set.OrdSysList[i].fW.Created += new FileSystemEventHandler(OnChanged);
                        Data.LogEvents(1, Set.OrdSysList[i].Name.ToString()+" Folder watcher created");
                        StartStopWatcher(Set.OrdSysList[i]);
                    }
                }
                catch
                {
                    Data.LogEvents(1, Set.OrdSysList[i].Name.ToString() + " Folder watcher creation FAILED");
                }
            }
           

        }
        public static void StartStopWatcher(OrderSystem ordSys)
        {
            if (ordSys.Active == true)
            {
                ordSys.fW.EnableRaisingEvents = true;
                ordSys.fwActive = true;
                Data.LogEvents(1, ordSys.Name + " watch started");
            }
            else
            {
                ordSys.fW.EnableRaisingEvents = false;
                ordSys.fwActive = false;
                Data.LogEvents(1, ordSys.Name + " watch stopped");
            }
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            String ordPath = Path.GetFullPath(e.FullPath);
            newOrderQueue.Enqueue(ordPath);
            if (!bWorker.IsBusy)
            {
                processOrder();
            }
        }

        private static void processOrder()
        {
            if (newOrderQueue.Count > 0)
            {
                Queue<string> bwQueue = new Queue<string>();
                foreach (string path in newOrderQueue)
                {
                    bwQueue.Enqueue(path);
                }
                newOrderQueue.Clear();
                bWorker.RunWorkerAsync(bwQueue);
            }
        }

        private static bool FileIsReady(string path)
        {
            var fileIdle = false;
            const int MaximumAttemptsAllowed = 30;
            var attemptsMade = 0;

            while (!fileIdle && attemptsMade <= MaximumAttemptsAllowed)
            {
                try
                {
                    using (File.Open(path, FileMode.Open, FileAccess.ReadWrite))
                    {
                        fileIdle = true;
                    }
                }
                catch
                {
                    attemptsMade++;
                    System.Threading.Thread.Sleep(1000);
                }
            }
            return fileIdle;

        }

        #region Backgroundworker
        static void bWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            processOrder();
        }

        static void bWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var status = e.ProgressPercentage;
            Data.LogEvents(status, e.UserState as String);
        }

        static void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var orderQueue = (Queue<string>)e.Argument;
            foreach (string ordPath in orderQueue)
            {
                string[] words = ordPath.Split('\\');
                var ordName = words[words.Length - 1];
                if (FileIsReady(ordPath))
                    Order.CreateNewOrderFromDroppedFile(ordPath);
            }
        }
        #endregion Backgroundworker
    }
}