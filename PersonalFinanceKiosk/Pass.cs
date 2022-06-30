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
        private IDictionary<string, string> saltDict = new Dictionary<string, string>();
        private IDictionary<string, string> hashDict = new Dictionary<string, string>();

        public Password(string pass, int uid, bool newPass)
        {
            this.uid = uid.ToString();
            saltDict = RWTextFiles.CreateSSDict("Salt.txt");
            hashDict = RWTextFiles.CreateSSDict("Pass.txt");

            if (newPass)
            {
                this.salt = CreateSalt();
                saltDict.Add(this.uid, this.salt);
                RWTextFiles.Write("Salt.txt", this.saltDict);
            }
            else
            {
                GetSalt();
            }

            this.pass = GenerateSaltedHash(pass, this.salt);

            if (newPass)
            {
                hashDict.Add(this.uid, this.pass);
                RWTextFiles.Write("Pass.txt", this.hashDict);
            }
        }

        private string CreateSalt()
        {
 
            // Below code copied from https://stackoverflow.com/questions/2138429/hash-and-salt-passwords-in-c-sharp and modified to meet personal program needs.
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            Random rand = new Random();
            byte[] buff = new byte[64];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }

        private void GetSalt()
        {
            foreach (var entry in this.saltDict)
            {
                if (entry.Key == this.uid)
                {
                    this.salt = entry.Value;
                }
            }
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

            foreach (var entry in this.hashDict)
            {
                if (entry.Key == this.uid)
                {
                    hash = entry.Value;
                }
            }

            return hash;
        }
        
        public bool ComparePass()
        {
            return this.pass == GetHash();
        }
    }
}
