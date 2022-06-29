using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceKiosk
{
    public class RWTextFiles
    {
        public static IDictionary<string, string> CreateSSDict(string filename) 
        {
            string line;
            string[] aline;
            IDictionary<string, string> lib = new Dictionary<string, string>();
            try
            {
                using (TextReader reader = new StreamReader(filename))
                {
                    while (true)
                    {
                        line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                        aline = line.Split(',');
                        lib.Add(aline[0], aline[1]);
                    }
                }
            }
            catch
            { }
            return lib;
        }

        public static IDictionary<string, int> CreateSIDict(string filename)
        {
            string line;
            string[] aline;
            IDictionary<string, int> lib = new Dictionary<string, int>();
            try
            {
                using (TextReader reader = new StreamReader(filename))
                {
                    while (true)
                    {
                        line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                        aline = line.Split(',');
                        lib.Add(aline[0], Int32.Parse(aline[1]));
                    }
                }
            }
            catch
            { }
            return lib;
        }

        public static void Write(string filename, IDictionary<string, int> dict) 
        {
            using (TextWriter w = new StreamWriter(filename))
            {
                foreach (var entry in dict)
                {
                    w.WriteLine($"{entry.Key},{entry.Value}");
                }
            }
        }

        public static void Write(string filename, IDictionary<string, string> dict)
        {
            using (TextWriter w = new StreamWriter(filename))
            {
                foreach (var entry in dict)
                {
                    w.WriteLine($"{entry.Key},{entry.Value}");
                }
            }
        }
    }
}
