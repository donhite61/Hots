using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hots
{
    public class ReadWrite
    {

        public ReadWrite()
        {

        }

        public void ReadINI()
        {
           if (File.Exists(Settings.IniFile))
            {
                var lines = File.ReadLines(Settings.IniFile);
                foreach (var line in lines)
                {
                    string[] words = line.Split('=');
                    if (words.Length == 2)
                    {
                        switch (words[0])
                        {
                            case "FileWatcherNewPath":
                                Settings.FileWatcherNewPath = words[1];
                                break;

                            case "FileWatcherReadPath":
                                Settings.FileWatcherReadPath = words[1];
                                break;

                            case "RoesWatchPath":
                                Settings.RoesWatchPath = words[1];
                                break;

                            case "DakisWatchPath":
                                Settings.DakisWatchPath = words[1];
                                break;

                            case "DakisOrderPath":
                                Settings.DakisOrderPath = words[1];
                                break;

                            case "RoesOrderPath":
                                Settings.RoesOrderPath = words[1];
                                break;
                        }

                    }

                }
            }
        }

        public void WriteINI()
        {
            using (StreamWriter writer = new StreamWriter(Settings.IniFile))
            {
                writer.WriteLine("FileWatcherNewPath="+ Settings.FileWatcherNewPath);
                writer.WriteLine("FileWatcherReadPath=" + Settings.FileWatcherReadPath);
                writer.WriteLine("RoesWatchPath=" + Settings.RoesWatchPath);
                writer.WriteLine("DakisWatchPath=" + Settings.DakisWatchPath);
                writer.WriteLine("DakisOrderPath=" + Settings.DakisOrderPath);
                writer.WriteLine("RoesOrderPath=" + Settings.RoesOrderPath);
            }
        }
    }
}
