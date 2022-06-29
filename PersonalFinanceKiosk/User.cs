using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceKiosk
{
    public class User
    {
        private Password pass;
        private bool newUser;
        private IDictionary<string, int> usrDict = new Dictionary<string, int>();
        public int uid;
        public string username;

        public User(string username, string password, bool newUser)
        {
            this.username = username;
            this.newUser = newUser;
            this.usrDict = RWTextFiles.CreateSIDict("User.txt");

            foreach (var entry in this.usrDict)
            {
                if (entry.Key == username)
                {
                    this.newUser = false;
                    this.uid = entry.Value;
                }
            }
            if (this.newUser)
            {
                this.uid = 1;
                foreach (var entry in this.usrDict)
                {
                    if (entry.Value == this.uid)
                    {
                        this.uid++;
                    }
                }
                this.usrDict.Add(this.username, this.uid);
                RWTextFiles.Write("User.txt", this.usrDict);
            }
            this.pass = new Password(password, this.uid, newUser);
        }

        public static bool UsernameInUse(string username) 
        {
            bool result = false;
            IDictionary<string, int> usrDict = RWTextFiles.CreateSIDict("User.txt");
            if (usrDict.ContainsKey(username)) 
            {
                result = true;
            }
            return result;
        }

        public bool SignIn() 
        {
            return this.pass.ComparePass();
        }
    }
}
