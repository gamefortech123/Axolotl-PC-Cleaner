using AXOLOTL_PC_CLEANER.Calculations;
using AXOLOTL_PC_CLEANER.Helper;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AXOLOTL_PC_CLEANER.Remover
{
    internal class Delete
    {
        public static long Total_Deleted;

        public static void Files(string Location, bool both)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(Location);

            try
            {
                foreach (FileInfo file in di.GetFiles())
                {
                    try 
                    {
                        file.Delete();
                        Total_Deleted = Total_Deleted + file.Length;
                        Utils.Logger(file.FullName + "," + Size.ConvertToString(file.Length));
                    }
                    catch 
                    {
                        Total_Deleted = Total_Deleted + 0;
                    }
                }
            }
            catch { }

            if (both == true)
            {
                try
                {
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        try 
                        { 
                            dir.Delete(true);
                            Total_Deleted = Total_Deleted += Calculations.Size.DirectorySize(dir, true);
                            Utils.Logger(dir.FullName + "," + Calculations.Size.DirectorySize(dir, true));
                        } 
                        catch 
                        {
                            Total_Deleted = Total_Deleted + 0;
                        }
                    }
                }
                catch { }
            }
        }

        public static void Single(string Location)
        {
            if (File.Exists(Location))
                try 
                { 
                    File.Delete(Location);
                    string file = Location;
                    Total_Deleted = Total_Deleted + file.Length;
                    Utils.Logger(file + "," + Size.ConvertToString(file.Length));
                } 
                catch
                {
                    Total_Deleted = Total_Deleted + 0;
                }
        }

        public static void Logs(string Location)
        {
            try
            {
                foreach (string file in Directory.GetFiles(Location, "*.log").Where(item => item.EndsWith(".log")))
                {
                    try
                    {
                        File.Delete(file);
                        Total_Deleted = Total_Deleted + file.Length;
                        Utils.Logger(file + "," + Size.ConvertToString(file.Length));
                    }
                    catch
                    {
                        Total_Deleted = Total_Deleted + 0;
                    }
                }
            }
            catch 
            {
                
            }
        }

        public static void Etl(string Location)
        {
            try
            {
                foreach (string file in Directory.GetFiles(Location, "*.etl").Where(item => item.EndsWith(".etl")))
                {
                    try
                    {
                        File.Delete(file);
                        Total_Deleted = Total_Deleted + file.Length;
                        Utils.Logger(file + "," + Size.ConvertToString(file.Length));
                    }
                    catch 
                    {
                        Total_Deleted = Total_Deleted + 0;
                    }
                }
            }
            catch
            {

            }
        }

        public static void Xml(string Location)
        {
            try
            {
                foreach (string file in Directory.GetFiles(Location, "*.xml").Where(item => item.EndsWith(".xml")))
                {
                    try
                    {
                        File.Delete(file);
                        Total_Deleted = Total_Deleted + file.Length;
                        Utils.Logger(file + "," + Size.ConvertToString(file.Length));
                    }
                    catch
                    {
                        Total_Deleted = Total_Deleted + 0;
                    }
                }
            }
            catch
            {

            }
        }

        public static void Edb(string Location)
        {
            try
            {
                foreach (string file in Directory.GetFiles(Location, "*.edb").Where(item => item.EndsWith(".edb")))
                {
                    try
                    {
                        File.Delete(file);
                        Total_Deleted = Total_Deleted + file.Length;
                        Utils.Logger(file + "," + Size.ConvertToString(file.Length));
                    }
                    catch
                    {
                        Total_Deleted = Total_Deleted + 0;
                    }
                }
            }
            catch
            {

            }
        }

        public static void Crwl(string Location)
        {
            try
            {
                foreach (string file in Directory.GetFiles(Location, "*.crwl").Where(item => item.EndsWith(".crwl")))
                {
                    try
                    {
                        File.Delete(file);
                        Total_Deleted = Total_Deleted + file.Length;
                        Utils.Logger(file + "," + Size.ConvertToString(file.Length));
                    }
                    catch
                    {
                        Total_Deleted = Total_Deleted + 0;
                    }
                }
            }
            catch
            {

            }
        }

        public static void Dat(string Location)
        {
            try
            {
                foreach (string file in Directory.GetFiles(Location, "*.dat").Where(item => item.EndsWith(".dat")))
                {
                    try
                    {
                        File.Delete(file);
                        Total_Deleted = Total_Deleted + file.Length;
                        Utils.Logger(file + "," + Size.ConvertToString(file.Length));
                    }
                    catch
                    {
                        Total_Deleted = Total_Deleted + 0;
                    }
                }
            }
            catch
            {

            }
        }

        public static void Pma(string Location)
        {
            try
            {
                foreach (string file in Directory.GetFiles(Location, "*.pma").Where(item => item.EndsWith(".pma")))
                {
                    try
                    {
                        File.Delete(file);
                        Total_Deleted = Total_Deleted + file.Length;
                        Utils.Logger(file + "," + Size.ConvertToString(file.Length));
                    }
                    catch
                    {
                        Total_Deleted = Total_Deleted + 0;
                    }
                }
            }
            catch
            {

            }
        }
    }
}
