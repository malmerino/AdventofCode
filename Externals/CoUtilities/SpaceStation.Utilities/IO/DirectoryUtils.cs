using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStation.Utilities.IO
{
    public class DirectoryUtils
    {
        public static void CreateIfMissing(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public static void CreateIfMissing(string path, Action ifMissing)
        {
            if (Directory.Exists(path)) return;
            Directory.CreateDirectory(path);
            ifMissing.Invoke();
        }

        public static void DeleteIfExist(string path)
        {
            if (Directory.Exists(path))
                Directory.Delete(path, true);
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
