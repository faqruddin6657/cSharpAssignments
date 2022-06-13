using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementProgram
{
    internal class StaffData
    {
        
        public String[] staffuserids;
        public String[] staffpasswords;

        public void fetch()
        {
            FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\LibraryManagementProgram\StaffData.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            int n = NumberOfRecords();
            if (n == 0)
            {
                fs.Close();
                sr.Close();

                return;

            }
            
            String[] staffuserid = new string[n];
            String[] staffpassword = new string[n];

           
            for (int i = 0; i < n; i++)
            {
                String record = sr.ReadLine();
                String[] fields = record.Split(',');
                staffuserid[i] = fields[0];
                staffpassword[i] = fields[1];
               
                

            }

            staffuserids = staffuserid;
            staffpasswords = staffpassword;
      

            fs.Close();
            sr.Close();

        }
        public int NumberOfRecords()
        {
            int size = 0;
            FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\LibraryManagementProgram\StaffData.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.ReadLine() != null)
            {
                ++size;
            }
            fs.Close();
            sr.Close();
            return size;

        }
        public void add()
        {
            FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\LibraryManagementProgram\StaffData.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            String username;
            String password;
            Console.WriteLine("enter username");
            username= Console.ReadLine();
            Console.WriteLine("enter password");
            password= Console.ReadLine();
            sw.Write(username + "," + password + ",");
            sw.Write("\n");
            sw.Close();
            fs.Close();
            Console.WriteLine("\nsuccessfully registered....login now");

        }
    }
}
