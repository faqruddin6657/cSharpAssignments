using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementProgram
{                                                       //transactiondata.txt contaings bookid,userid,issuedata,returndate
    internal class TransactionData
    {
        
        public int RECORDS;
        public String[] bookids;
        public String[] userids;
        public String[] issuedates;
        public String[] returndates;
      

        public TransactionData()
        {

            
        }
        public void fetch()
        {
            FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\LibraryManagementProgram\TransactionData.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            int n = NumberOfRecords();
            if (n == 0)
            {

                fs.Close();
                sr.Close();
                return;
            }
            RECORDS = n;
            String[] bookid = new string[n];
            String[] userid = new string[n];
            String[] issuedate = new string[n];
            String[] returndate = new string[n];
            

            for (int i = 0; i < n; i++)
            {
                String record = sr.ReadLine();
                String[] fields = record.Split(',');
                bookid[i] = fields[0];
                userid[i] = fields[1];
                issuedate[i] = fields[2];
                returndate[i] = fields[3];
                

            }

            bookids = bookid;
            userids = userid;
            issuedates = issuedate;
            returndates = returndate;

            fs.Close();
            sr.Close();


        }

        public int NumberOfRecords()
        {
            int size = 0;
            FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\LibraryManagementProgram\TransactionData.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.ReadLine() != null)
            {
                ++size;
            }

            fs.Close();
            sr.Close();
            return size;

            

        }

        public void add(String bookid,String username,String issuedate,string returndate)
        {
            FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\LibraryManagementProgram\TransactionData.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
           
          
            sw.Write(bookid + "," + username + "," + issuedate + "," + returndate+",");
            sw.Write("\n");
            sw.Close();
            fs.Close();
          

        }

        public void showdata()
        {
            Console.WriteLine("bookid,userid,issuedate,returndate");
            for (int i = 0; i < RECORDS; i++)
            {
                Console.WriteLine(bookids[i] + "," + userids[i] + "," + issuedates[i] + "," + returndates[i]);
            }
        }

        public void remove(String userId,String bookId)
        {



            int flag = 0;

            //Console.WriteLine("enter bookid");
            //String bookId = Console.ReadLine();

           // Console.WriteLine("enter userid");
          //  String userId = Console.ReadLine();



            for (int i = 0; i < RECORDS; i++)
            {
               
                if ( bookids[i].Equals(bookId) &&  userids[i].Equals(userId))
                {

                    
                    userids[i] = null;
                    bookids[i] = null;
                    issuedates[i] = null;
                    returndates[i] = null;
                    flag = 1;


                }
            }

            if (flag == 1)
            {
                FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\LibraryManagementProgram\TransactionData.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                for (int i = 0; i < RECORDS; i++)
                {
                    
                    if (userids[i] == null)
                    {
                        continue;
                    }
                    sw.WriteLine(bookids[i] + "," + userids[i] + "," + issuedates[i] + "," + returndates[i] + "," );
                    
                }
                sw.Close();
                fs.Close();

                Console.WriteLine("deleted");


            }
            else
            {
                Console.WriteLine("no such userid found");
            }

        }

    }
}
