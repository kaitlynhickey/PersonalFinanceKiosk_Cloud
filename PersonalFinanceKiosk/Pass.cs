using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PersonalFinanceKiosk
{
    internal class Password
    {
        private string pass;
        private string salt;
        private string uid;
        private IDictionary<string, string> saltLib = new Dictionary<string, string>();
        private IDictionary<string, string> hashLib = new Dictionary<string, string>();

        public Password(string pass, int uid, bool newPass) 
        {
            this.uid = uid.ToString();
            CreateSaltLib();
            CreateHashLib();

            if (newPass) 
            {
                this.salt = CreateSalt();
                saltLib.Add(this.uid, this.salt);
                WriteSalt();
            }
            else 
            {
                GetSalt();
            }

            this.pass = GenerateSaltedHash(pass, this.salt);

            if (newPass)
            {
                hashLib.Add(this.uid, this.pass);
                WriteHash();
            }
        }

        private void CreateSaltLib()
        {
            string line;
            string[] sline;
            try
            {
                TextReader reader = new StreamReader("Salt.txt");
                while (true)
                {
                    line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    sline = line.Split(',');
                    this.saltLib.Add(sline[0], sline[1]);
                }
                reader.Close();
            }
            catch
            { }
        }

        private string CreateSalt()
        {
 
            // Below code copied from https://stackoverflow.com/questions/2138429/hash-and-salt-passwords-in-c-sharp and modified to meet personal program needs.
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            Random rand = new Random();
            byte[] buff = new byte[rand.Next(100)];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }

        private void GetSalt()
        {
            foreach (var entry in this.saltLib)
            {
                if (entry.Key == this.uid)
                {
                    this.salt = entry.Value;
                }
            }
        }

        private void WriteSalt()
        {
            using (TextWriter w = new StreamWriter("Salt.txt"))
            {
                foreach (var entry in saltLib) 
                {
                    w.WriteLine($"{entry.Key},{entry.Value}");
                }
            }
        }

        //private void WriteSalt()
        //{
        //    try
        //    {
        //        using (StreamWriter w = File.AppendText("Salt.txt"))
        //        {
        //            w.WriteLine($"{this.uid},{this.salt}");
        //        }
        //    }
        //    catch
        //    {
        //        using (TextWriter w = new StreamWriter("Salt.txt"))
        //        {
        //            w.WriteLine($"{this.uid},{this.salt}");
        //        }
        //    }
        //}

        //private string GetSalt(string uid)
        //{
        //    string line;
        //    string[] sline;
        //    string salt = "unassigned";

        //    try
        //    {
        //        TextReader reader = new StreamReader("Salt.txt");
        //        while (true)
        //        {
        //            line = reader.ReadLine();
        //            if (line == null)
        //            {
        //                break;
        //            }
        //            sline = line.Split(',');
        //            if (sline[0] == uid) 
        //            { 
        //                salt =  sline[1];
        //            }
        //        }
        //        reader.Close();
        //    }
        //    catch
        //    {
        //        salt = "Error with text file";
        //    }

        //    return salt;
        //}

        private void CreateHashLib()
        {
            string line;
            string[] hline;
            try
            {
                using (TextReader reader = new StreamReader("Pass.txt"))
                {
                    while (true)
                    {
                        line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                        hline = line.Split(',');
                        this.saltLib.Add(hline[0], hline[1]);
                    }
                }
            }
            catch
            { }
        }

        private static string GenerateSaltedHash(string pass, string s)
        {
            byte[] plainText = Encoding.UTF8.GetBytes(pass);
            byte[] salt = Encoding.UTF8.GetBytes(s);

            // Below code copied from https://stackoverflow.com/questions/2138429/hash-and-salt-passwords-in-c-sharp and modified to meet personal program needs.
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return Convert.ToBase64String(algorithm.ComputeHash(plainTextWithSaltBytes));
        }

        private string GetHash()
        {
            string hash = "";

            foreach (var entry in this.hashLib)
            {
                if (entry.Key == this.uid)
                {
                    hash = entry.Value;
                }
            }

            return hash;
        }

        private void WriteHash()
        {
            using (TextWriter w = new StreamWriter("Pass.txt"))
            {
                foreach (var entry in saltLib)
                {
                    w.WriteLine($"{entry.Key},{entry.Value}");
                }
            }
        }
        
        public bool ComparePass()
        {
            return this.pass == GetHash();
        }
    }
}
