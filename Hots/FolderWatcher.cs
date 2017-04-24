using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hots
{
    public class FolderWatcher
    {
        public FileSystemWatcher fwatch;

        public FolderWatcher()
        {
            fwatch = new FileSystemWatcher(Set.WchRoot);

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
            String Filename = Path.GetFileName(e.FullPath);
            String FilePath = Path.GetFullPath(e.FullPath);
            if (FileIsReady(FilePath))
            {
                var FullOrder = new ReadRoesIncomingOrderFile(Filename);
                var localDB = new LData("Web");
                localDB.SaveNewOrderHeader(FullOrder);
            }
            else
            {
                // start scan of folder to pick up missed file
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
