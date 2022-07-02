using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXOLOTL_PC_CLEANER.Calculations
{
    internal class Size
    {
        public static long DirectorySize(DirectoryInfo dInfo, bool SubDir)
        {
            long totalSize = dInfo.EnumerateFiles().Sum(file => file.Length);

            if (SubDir)
            {
                totalSize += dInfo.EnumerateDirectories().Sum(dir => DirectorySize(dir, true));
            }
            return totalSize;
        }

        public static string ConvertToString(long bytecount)
        {
            string[] size = { "B", "KB", "MB", "GB", "TB" };

            if (bytecount == 0)
            {
                return "0" + size[0];
            }

            long bytes = Math.Abs(bytecount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));

            double num = Math.Round(bytes / Math.Pow(1024, place), 1);

            return (Math.Sign(bytecount) * num).ToString() + " " + size[place];
        }

        public static long CheckSize(string location, long size, bool both)
        {
            size = 0;
            var Dir = new DirectoryInfo(location);

            if (Dir.Exists)
            {
                if (both == true)
                {
                    try
                    {
                        foreach (DirectoryInfo dir in Dir.GetDirectories())
                        {
                            try
                            {
                                size += DirectorySize(dir, true);
                            }
                            catch
                            {
                                return 0;
                            }
                        }
                    }
                    catch { }
                }

                try
                {
                    foreach (FileInfo filez in Dir.GetFiles())
                    {
                        try
                        {
                            if (Helper.Utils.IsFileLocked(filez) == false)
                            {
                                if (filez.IsReadOnly == false)
                                {
                                    size += filez.Length;
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                }
                catch { }
            }

            return size;
        }

        public static long LogFiles(string location, long size)
        {
            size = 0;

            var Dir = new DirectoryInfo(location);

            if (Dir.Exists)
            {
                try
                {
                    foreach (FileInfo Filez in Dir.GetFiles("*.log").Where(p => p.Extension == ".log").ToArray())
                    {
                        try
                        {
                            size += Filez.Length;
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {

                }
            }

            return size;
        }

        public static long EtlFiles(string location, long size)
        {
            size = 0;

            var Dir = new DirectoryInfo(location);

            if (Dir.Exists)
            {
                try
                {
                    foreach (FileInfo Filez in Dir.GetFiles("*.etl").Where(p => p.Extension == ".etl").ToArray())
                    {
                        try
                        {
                            size += Filez.Length;
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {

                }
            }

            return size;
        }

        public static long XmlFiles(string location, long size)
        {
            size = 0;

            var Dir = new DirectoryInfo(location);

            if (Dir.Exists)
            {
                try
                {
                    foreach (FileInfo Filez in Dir.GetFiles("*.xml").Where(p => p.Extension == ".xml").ToArray())
                    {
                        try
                        {
                            size += Filez.Length;
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {

                }
            }

            return size;
        }

        public static long EdbFiles(string location, long size)
        {
            size = 0;

            var Dir = new DirectoryInfo(location);

            if (Dir.Exists)
            {
                try
                {
                    foreach (FileInfo Filez in Dir.GetFiles("*.edb").Where(p => p.Extension == ".edb").ToArray())
                    {
                        try
                        {
                            size += Filez.Length;
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {

                }
            }

            return size;
        }

        public static long CrwlFiles(string location, long size)
        {
            size = 0;

            var Dir = new DirectoryInfo(location);

            if (Dir.Exists)
            {
                try
                {
                    foreach (FileInfo Filez in Dir.GetFiles("*.crwl").Where(p => p.Extension == ".crwl").ToArray())
                    {
                        try
                        {
                            size += Filez.Length;
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {

                }
            }

            return size;
        }

        public static long PmaFiles(string location, long size)
        {
            size = 0;

            var Dir = new DirectoryInfo(location);

            if (Dir.Exists)
            {
                try
                {
                    foreach (FileInfo Filez in Dir.GetFiles("*.pma").Where(p => p.Extension == ".pma").ToArray())
                    {
                        try
                        {
                            size += Filez.Length;
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {

                }
            }

            return size;
        }

        public static long DatFiles(string location, long size)
        {
            size = 0;

            var Dir = new DirectoryInfo(location);

            if (Dir.Exists)
            {
                try
                {
                    foreach (FileInfo Filez in Dir.GetFiles("*.dat").Where(p => p.Extension == ".dat").ToArray())
                    {
                        try
                        {
                            size += Filez.Length;
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {

                }
            }

            return size;
        }

        public static long CatalogFiles(string location, long size)
        {
            size = 0;

            var Dir = new DirectoryInfo(location);

            if (Dir.Exists)
            {
                try
                {
                    foreach (FileInfo Filez in Dir.GetFiles("*.catalogItem").Where(p => p.Extension == ".catalogItem").ToArray())
                    {
                        try
                        {
                            size += Filez.Length;
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {

                }
            }

            return size;
        }

        public static long CheckSingle(string location, long size)
        {
            size = 0;

            if (File.Exists(location))
                try { return new FileInfo(location).Length; } catch { }

            return size;
        }
    }
}
