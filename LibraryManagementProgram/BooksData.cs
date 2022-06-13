using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementProgram
{
    internal class BooksData                                      //bookdata.txt contains bookid,bookname,author,publications,price
    {
        public int RECORDS;
        public String[] bookids;
        public String[] booknames;
        public String[] authors;
        public String[] publications;
        public String[] prices;


         public BooksData()
         {

             
         }
         public void fetch()
         {
            FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\LibraryManagementProgram\BookData.txt", FileMode.Open, FileAccess.Read);
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
             String[] bookname = new string[n];
             String[] author = new string[n];
             String[] publication = new string[n];
             String[] price = new string[n];


             for (int i = 0; i < n; i++)
             {
                 String record = sr.ReadLine();
                 String[] fields = record.Split(',');

                 bookid[i] = fields[0];
                 bookname[i] = fields[1];
                 author[i] = fields[2];
                 publication[i] = fields[3];
                 price[i] = fields[4];



             }

             bookids = bookid;
             booknames = bookname;
             authors = author;
             publications = publication;
             prices = price;
            fs.Close();
            sr.Close();
             

         }
        
        

        public int NumberOfRecords()
        {
            int size = 0;
            FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\LibraryManagementProgram\BookData.txt", FileMode.Open, FileAccess.Read);
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
            FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\LibraryManagementProgram\BookData.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            String[] record = new string[5];
            Console.WriteLine("enter bookid");
            record[0] = Console.ReadLine();
            Console.WriteLine("enter booksname");
            record[1] = Console.ReadLine();
            Console.WriteLine("enter author");
            record[2] = Console.ReadLine();
            Console.WriteLine("enter publication");
            record[3] = Console.ReadLine();
            Console.WriteLine("enter price");
            record[4] = Console.ReadLine();

            sw.WriteLine(record[0] + "," + record[1] + "," + record[2] + "," + record[3] + "," + record[4] + ",");
            sw.Close();
            fs.Close();
            Console.WriteLine("successfully added the book");
        

        }

        public void showdata()
        {
            Console.WriteLine("bookid,bookname,authors,publications,price");
            for (int i = 0; i < RECORDS; i++)
            {
                Console.WriteLine(bookids[i] + "," + booknames[i] + "," + authors[i] + "," + publications[i] + "," + prices[i]);
            }
        }
    }
}

