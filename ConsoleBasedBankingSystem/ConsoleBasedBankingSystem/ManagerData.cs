using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleBasedBankingSystem
{
    internal class ManagerData
    {
        //manager data contains username,password
        public List<string> UserNames = new List<string>();
        public List<string> Passwords = new List<string>();

        public void Fetch()
        {
            FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\bankaccountdetails\ManagerData.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() > 0)
            {
                string line = sr.ReadLine();
                string[] data = line.Split(',');

                UserNames.Add(data[0]);
                Passwords.Add(data[1]);


            }

            fs.Close();
            sr.Close();

        }

        public void Add()
        {
            FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\bankaccountdetails\ManagerData.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            Console.WriteLine("select user name");
            string username = Console.ReadLine();
            Console.WriteLine("set password");
            string password = Console.ReadLine();



            sr.WriteLine(username + "," + password);
            sr.Close();
            fs.Close();
        }
    }
}
