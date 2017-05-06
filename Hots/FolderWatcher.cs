using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;

namespace Hots
{
    public class FolderWatcher
    {
        BackgroundWorker bWorker; //create global variable for backgroundworker object
        FileSystemWatcher fwatch;
        Form1 form;
        Queue<string> newOrderQueue = new Queue<string>();

        #region Backgroundworker

        void bWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            processOrder();
        }

        void bWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var status = e.ProgressPercentage;
            form.UpdateStatusWindow(status, e.UserState as String);
        }

        void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var orderQueue = (Queue<string>)e.Argument;
            foreach (string ordPath in orderQueue)
            {
                string[] words = ordPath.Split('\\');
                var ordName = words[words.Length - 1];
                bWorker.ReportProgress(1, ordName + "  Found");
                if (FileIsReady(ordPath))
                {
                    var newOrder = new Order(ordPath);
                    if(newOrder.OrdSys == null)
                    {
                        bWorker.ReportProgress(0, ordName + " skipped, unknown file ext");
                        continue;
                    }
                    else
                    {
                        bWorker.ReportProgress(1, ordName + "  Ext matched " + newOrder.OrdSys.Name + " order system");
                        newOrder.OrdStatus = "unread";
                    }

                    newOrder = newOrder.FillProperties(newOrder, ordPath);
                    if (newOrder.OrdStatus == "error reading file")
                    {
                        bWorker.ReportProgress(0, ordName + "  failed to read dropped file");
                        continue;
                    }
                    else
                    {
                        bWorker.ReportProgress(1, ordName + "  successfully read dropped file");
                    }
                    var sqlId = LData.SaveOrdertoSqlServer(newOrder);
                    if (sqlId == 0)
                    {
                        bWorker.ReportProgress(0, ordName + "  failed to save to server");
                        continue;
                    }
                    else
                    {
                        bWorker.ReportProgress(1, ordName + "  saved to server SqlId is " + sqlId);
                    }
                }
            }
        }

        #endregion Backgroundworker

        public FolderWatcher(string _wchRoot, Form1 _form)
        {
            bWorker = new BackgroundWorker();
            bWorker.DoWork += new DoWorkEventHandler(bWorker_DoWork);
            bWorker.ProgressChanged += new ProgressChangedEventHandler(bWorker_ProgressChanged);
            bWorker.WorkerReportsProgress = true;
            bWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bWorker_RunWorkerCompleted);

            form = _form;
            fwatch = new FileSystemWatcher(_wchRoot);

            fwatch.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
          | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // fwatch.Changed += new FileSystemEventHandler(OnChanged);
            fwatch.Created += new FileSystemEventHandler(OnChanged);
            fwatch.IncludeSubdirectories = true;
            // fwatch.Deleted += new FileSystemEventHandler(OnChanged);

            fwatch.Filter = "*.*";
        }

        public void StartWatching()
        {
            fwatch.EnableRaisingEvents = true;
        }

        public void StopWatching()
        {
            fwatch.EnableRaisingEvents = false;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            String ordPath = Path.GetFullPath(e.FullPath);
            newOrderQueue.Enqueue(ordPath);
            if (!bWorker.IsBusy)
            {
                processOrder();
            }
        }

        private void processOrder()
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
    }
}
