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

        public static string WchRoot { get; set; }

        public static string WchRoes { get; set; }
        public static string RoesExt { get; set; }
        public static string ReadRoes { get; set; }
        public static string OutRoes { get; set; }
        public static string ProdSubRoes { get; set; }
        public static string WaitForRoes { get; set; }
        public static bool RoesActivate { get; set; }
        public static bool RoesWaitIsFldr { get; set; }

        public static string WchDakis { get; set; }
        public static string DakisExt { get; set; }
        public static string ReadDakis { get; set; }
        public static string OutDakis { get; set; }
        public static string ProdSubDakis { get; set; }
        public static string WaitForDakis { get; set; }
        public static bool DakisActivate { get; set; }
        public static bool DakisWaitIsFldr { get; set; }

        public static string WchDGift { get; set; }
        public static string DGiftExt { get; set; }
        public static string ReadDGift { get; set; }
        public static string OutDGift { get; set; }
        public static string ProdSubDGift { get; set; }
        public static string WaitForDGift { get; set; }
        public static bool DGiftActivate { get; set; }
        public static bool DGiftWaitIsFldr { get; set; }

        public static void WriteINI()
        {
            using (StreamWriter writer = new StreamWriter(Settings.IniFile))
            {
                writer.WriteLine("WchRoot=" + Settings.WchRoot);

                writer.WriteLine("WchRoes=" + Settings.WchRoes);
                writer.WriteLine("RoesExt=" + Settings.RoesExt);
                writer.WriteLine("ReadRoes=" + Settings.ReadRoes);
                writer.WriteLine("OutRoes=" + Settings.OutRoes);
                writer.WriteLine("ProdSubRoes=" + Settings.ProdSubRoes);
                writer.WriteLine("WaitForRoes=" + Settings.WaitForRoes);
                writer.WriteLine("RoesActivate=" + Settings.RoesActivate);
                writer.WriteLine("RoesWaitIsFldr=" + Settings.RoesWaitIsFldr);

                writer.WriteLine("WchDakis=" + Settings.WchDakis);
                writer.WriteLine("DakisExt=" + Settings.DakisExt);
                writer.WriteLine("ReadDakis=" + Settings.ReadDakis);
                writer.WriteLine("OutDakis=" + Settings.OutDakis);
                writer.WriteLine("ProdSubDakis=" + Settings.ProdSubDakis);
                writer.WriteLine("WaitForDakis=" + Settings.WaitForDakis);
                writer.WriteLine("DakisActivate=" + Settings.DakisActivate);
                writer.WriteLine("DakisWaitIsFldr=" + Settings.DakisWaitIsFldr);

                writer.WriteLine("WchDGift=" + Settings.WchDGift);
                writer.WriteLine("DGiftExt=" + Settings.DGiftExt);
                writer.WriteLine("ReadDGift=" + Settings.ReadDGift);
                writer.WriteLine("OutDGift=" + Settings.OutDGift);
                writer.WriteLine("ProdSubDGift=" + Settings.ProdSubDGift);
                writer.WriteLine("WaitForDGift=" + Settings.WaitForDGift);
                writer.WriteLine("DGiftActivate=" + Settings.DGiftActivate);
                writer.WriteLine("DGiftWaitIsFldr=" + Settings.DGiftWaitIsFldr);
            }
        }

        public static void ReadINI()
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
                            case "WchRoot":
                                Settings.WchRoot = words[1];
                                break;
                            case "WchRoes":
                                Settings.WchRoes = words[1];
                                break;
                            case "RoesExt":
                                Settings.RoesExt = words[1];
                                break;
                            case "ReadRoes":
                                Settings.ReadRoes = words[1];
                                break;
                            case "OutRoes":
                                Settings.OutRoes = words[1];
                                break;
                            case "ProdSubRoes":
                                Settings.ProdSubRoes = words[1];
                                break;
                            case "WaitForRoes":
                                Settings.WaitForRoes = words[1];
                                break;
                            case "RoesActivate":
                                Settings.RoesActivate = Convert.ToBoolean(words[1]);
                                break;
                            case "RoesWaitIsFldr":
                                Settings.RoesWaitIsFldr = Convert.ToBoolean(words[1]);
                                break;

                            case "WchDakis":
                                Settings.WchDakis = words[1];
                                break;
                            case "DakisExt":
                                Settings.DakisExt = words[1];
                                break;
                            case "ReadDakis":
                                Settings.ReadDakis = words[1];
                                break;
                            case "OutDakis":
                                Settings.OutDakis = words[1];
                                break;
                            case "ProdSubDakis":
                                Settings.ProdSubDakis = words[1];
                                break;
                            case "WaitForDakis":
                                Settings.WaitForDakis = words[1];
                                break;
                            case "DakisActivate":
                                Settings.DakisActivate = Convert.ToBoolean(words[1]);
                                break;
                            case "DakisWaitIsFldr":
                                Settings.DakisWaitIsFldr = Convert.ToBoolean(words[1]);
                                break;

                            case "WchDGift":
                                Settings.WchDGift = words[1];
                                break;
                            case "DGiftExt":
                                Settings.DGiftExt = words[1];
                                break;
                            case "ReadDGift":
                                Settings.ReadDGift = words[1];
                                break;
                            case "OutDGift":
                                Settings.OutDGift = words[1];
                                break;
                            case "ProdSubDGift":
                                Settings.ProdSubDGift = words[1];
                                break;
                            case "WaitForDGift":
                                Settings.WaitForDGift = words[1];
                                break;
                            case "DGiftActivate":
                                Settings.DGiftActivate = Convert.ToBoolean(words[1]);
                                break;
                            case "DGiftWaitIsFldr":
                                Settings.DGiftWaitIsFldr = Convert.ToBoolean(words[1]);
                                break;
                        }
                    }
                }
            }
        }
    }


}
