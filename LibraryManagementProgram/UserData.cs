using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementProgram
{

    internal class UserData                                             //   UserData.txt contains username,password,state,city,mobile
    {
        
        public int RECORDS;
        public String[] usernames;
        public String[] passwords;
        public String[] states;
        public String[] cities;
        public String[] mobiles;

        public UserData()
        {

            
        }
        public void fetch()
        {
            FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\LibraryManagementProgram\UserData.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr= new StreamReader(fs);
            int n=NumberOfRecords();
            if(n==0)
            {
                fs.Close();
                sr.Close();
                
                return;
                
            }
            RECORDS = n;
            String[] username = new string[n];
            String[] password = new string[n];
            String[] state = new string[n];
            String[] city= new string[n];
            String[] mobile = new string[n];
            
            for(int i=0; i<n; i++)
            {
              

                String record=sr.ReadLine();
                String[] fields = record.Split(',');
                username[i] = fields[0];
                password[i] = fields[1];
                state[i] = fields[2];
                city[i] = fields[3];
                mobile[i] = fields[4];

            }

            usernames = username;
            passwords = password;
            states = state;
            cities = city;
            mobiles= mobile;

            fs.Close();
            sr.Close();
           


        }

        public int NumberOfRecords()
        {
            int size = 0;
            FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\LibraryManagementProgram\UserData.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while(sr.ReadLine() != null)
            {
                ++size;
            }
            fs.Close();
            sr.Close();
            return size;

        }

        public void add()
        {
           FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\LibraryManagementProgram\UserData.txt", FileMode.Append, FileAccess.Write);
           StreamWriter sw = new StreamWriter(fs);
            String[] record = new string[5];
            Console.WriteLine("enter username");
            record[0] = Console.ReadLine();
            Console.WriteLine("enter password");
            record[1] = Console.ReadLine();
            Console.WriteLine("enter state");
            record[2] = Console.ReadLine();
            Console.WriteLine("enter city");
            record[3] = Console.ReadLine();
            Console.WriteLine("enter mobile");
            record[4] = Console.ReadLine();

           sw.WriteLine(record[0] + "," + record[1] + "," + record[2] + "," + record[3] + "," + record[4] + ",");
            
           sw.Close();
           fs.Close();
            Console.WriteLine("\nsuccessfully registered....login now");
            
        }

        
        public void showdata()
        {
            Console.WriteLine("username,state,city,mobile");
            for(int i=0;i<RECORDS;i++)
            {
                Console.WriteLine(usernames[i] + "," + states[i] + "," + cities[i] + "," + mobiles[i]);
            }
        }

        public int getindexofuser(String uname)
        {
            for(int i=0;i<RECORDS;i++)
            {
                if(usernames[i].Equals(uname))
                {
                    return usernames[i].IndexOf(uname);
                }
            }
            return -1;
        }

        public void update()
        {
            int choice, index = -1, flag = 0;
            Console.WriteLine("enter which field to update");
            Console.WriteLine("press 1 for state");
            Console.WriteLine("press 2 for password");
            Console.WriteLine("press 3 for city");
            Console.WriteLine("press 4 for mobile");
            
            choice = Convert.ToInt32(Console.ReadLine());
            if(choice == 1)
            {
                Console.WriteLine("enter the new state");
                String tempstate = Console.ReadLine();
                Console.WriteLine("enter user name");
                String tempuser = Console.ReadLine();

                for (int i = 0; i < RECORDS; i++)
                {
                    if (usernames[i].Equals(tempuser))
                    {
                        index = i;
                        Console.WriteLine("true");
                    }
                }
                if ( index != -1)
                {

                    FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\LibraryManagementProgram\UserData.txt", FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);

                    states[index] = tempstate;
                    for (int i = 0; i < RECORDS; i++)
                    {
                        
                        
                        sw.WriteLine(usernames[i] + "," + passwords[i] + "," + states[i] + "," + cities[i] + "," + mobiles[i] + ",");
                        flag = 1;
                     
                    }

                    sw.Close();
                    fs.Close();
                    Console.WriteLine("\nsuccessully updated");

                }
                if(flag==0)
                {
                    Console.WriteLine("no user found");
                }
            }

            if(choice==2)
            {
                Console.WriteLine("enter the new password");
                String temppass = Console.ReadLine();
                Console.WriteLine("enter user name");
                String tempuser = Console.ReadLine();

                
                
                    for(int i = 0; i < RECORDS; i++)
                    {
                        if (usernames[i].Equals(tempuser))
                            {
                            index = i;
                         }
                    }
                
                if (index != -1)
                {
                    FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\LibraryManagementProgram\UserData.txt", FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    passwords[index] = temppass;
                    for (int i = 0; i < RECORDS; i++)
                    {
                       

                        sw.WriteLine(usernames[i] + "," + passwords[i] + "," + states[i] + "," + cities[i] + "," + mobiles[i] + ",");
                        flag = 1;
                    }
                    sw.Close();
                    fs.Close();
                    Console.WriteLine("\nsuccessully updated");
                }
                if (flag == 0)
                { Console.WriteLine("no user found"); }


            }

            if(choice ==3)
            {
                Console.WriteLine("enter the new city");
                String tempcity = Console.ReadLine();
                Console.WriteLine("enter user name");
                String tempuser = Console.ReadLine();

                for (int i = 0; i < RECORDS; i++)
                {
                    if (usernames[i].Equals(tempuser))
                    {
                        index = i;
                    }
                }
                if (index != -1 )
                {
                    FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\LibraryManagementProgram\UserData.txt", FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    cities[index] = tempcity;
                    for (int i = 0; i < RECORDS; i++)
                    {
                       

                        sw.WriteLine(usernames[i] + "," + passwords[i] + "," + states[i] + "," + cities[i] + "," + mobiles[i] + ",");
                        flag = 1;
                    }
                    sw.Close();
                    fs.Close();
                    Console.WriteLine("\nsuccessully updated");
                }
                if (flag == 0) { Console.WriteLine("no user found"); }
            }
            if(choice==4)
            {
                Console.WriteLine("enter the new mobile number");
                String tempmobile = Console.ReadLine();
                Console.WriteLine("enter user name");
                String tempuser = Console.ReadLine();

                for (int i = 0; i < RECORDS; i++)
                {
                    if (usernames[i].Equals(tempuser))
                    {
                        index = i;
                    }
                }
                if (index != -1)
                {

                    FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\LibraryManagementProgram\UserData.txt", FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    mobiles[index] = tempmobile;
                    for (int i = 0; i < RECORDS; i++)
                    {

                        sw.WriteLine(usernames[i] + "," + passwords[i] + "," + states[i] + "," + cities[i] + "," + mobiles[i] + ",");
                        flag = 1;
                    
                    }
                    sw.Close();
                    fs.Close();
                    Console.WriteLine("\nsuccessully updated");
                }
                if (flag == 0) { Console.WriteLine("no user found"); }
            }

        }

          
        

    }

   
}
