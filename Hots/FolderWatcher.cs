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
        FileSystemWatcher fwatch;
        Form1 form;

        public FolderWatcher(string _wchRoot, Form1 _form)
        {
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
            String filePath = Path.GetFullPath(e.FullPath);
            if (FileIsReady(filePath))
            {
                form.FolderWatcherFoundOrder(true);
                Order.ProcessNewOrder(filePath);
                form.FolderWatcherFoundOrder(false);
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
