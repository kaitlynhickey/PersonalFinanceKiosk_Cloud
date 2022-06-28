using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceKiosk
{
    public class User
    {
        private string username;
        private Password pass;
        private IDictionary<string, int> usrLib = new Dictionary<string, int>();
        public int uid;
        public bool newUser = true;

        public User(string username, string password)
        {
            this.username = username;
            CreateUsrLib();

            foreach (var entry in this.usrLib)
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
                foreach (var entry in this.usrLib)
                {
                    if (entry.Value == this.uid)
                    {
                        this.uid++;
                    }
                }
                this.usrLib.Add(this.username, this.uid);
                WriteUsr();
            }
            this.pass = new Password(password, this.uid, newUser);
        }

        private async void CreateUsrLib()
        {
            string line;
            string[] uline;
            try
            {
                TextReader reader = new StreamReader("User.txt");
                while (true)
                {
                    line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    uline = line.Split(',');
                    this.usrLib.Add(uline[0], Int32.Parse(uline[1]));
                }
                reader.Close();
            }
            catch
            { }
        }

        private async void WriteUsr()
        {
            using (TextWriter w = new StreamWriter("User.txt"))
            {
                foreach (var entry in usrLib)
                {
                    w.WriteLine($"{entry.Key},{entry.Value}");
                }
            }
        }

        public bool SignIn() 
        {
            return this.pass.ComparePass();
        }
    }
}
