using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementProgram
{
    internal class Staff
    {
        private int Records;
        private UserData userData = new UserData();
        private BooksData bookData = new BooksData();
        private TransactionData transactionData = new TransactionData();
        private StaffData staffData = new StaffData();
        

        public void staffhandle()
        {
            int choice;
            Console.WriteLine("for login press 1 ");
            Console.WriteLine("for registratoin press 2");
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                String username, password;
                Console.WriteLine("enter use name ");
                username = Console.ReadLine();
                Console.WriteLine("enter password ");
                password = Console.ReadLine();
                verification(username, password);
                return;

            }
            if (choice == 2)
            {

                staffData.add();
            }
            if (choice > 2 || choice < 1)
            {
                Console.WriteLine("enter a valid input\n ");

            }


        }

        private void verification(String username, String password)
        {
            staffData.fetch();
           
            Records = staffData.NumberOfRecords();
            int flag = 0;
            


            for (int i = 0; i < Records; i++)
            {
                
                if (staffData.staffuserids[i].Equals(username) && staffData.staffpasswords[i].Equals(password))
                {
                    
                    Console.WriteLine("\nwelcome " + username);
                    flag = 1;
                    showmenu();

                    
                }

            }
            
            if (flag == 0)
            {
                Console.WriteLine("no such user is found ... please register");
            }

        }

        private int numofdays(String username,String bookid)
        {
            
            int days=-1;
            transactionData.fetch();
            int numofrec = transactionData.NumberOfRecords();
            DateTime[] issuedates = new DateTime[numofrec];
            DateTime[] returnDates = new DateTime[numofrec];
            int[] numdays = new int[numofrec];
            int index = -1;

            for (int i = 0; i < numofrec; i++)
            {
                issuedates[i] = Convert.ToDateTime(transactionData.issuedates[i]);
                returnDates[i] = Convert.ToDateTime(transactionData.returndates[i]);
            }

            for (int i = 0; i < numofrec; i++)
            {
                var d = returnDates[i] - issuedates[i];
                numdays[i] = d.Days;
            }

            /*   Console.WriteLine("number of days for all the transactions are ");
               for (int i = 0; i < numofrec; i++)
               {
                   Console.WriteLine(numdays[i]);
               }
            */
           
            
            for (int i = 0; i < numofrec; i++)
            {
             
               
                if ((transactionData.userids[i].Equals(username)) &&( transactionData.bookids[i].Equals(bookid)))
                    {
                    days = numdays[i];
                    }


            }
            

                return days;
        }




        private void showCharges()
        {
            // evaluating price of a the given book
            int usuanceCharges = 50;
            int chargesperday = 5;
            int thegivenbookprice=-40000;
            int numberofdays;
            int totalPrice;
            int flag = 0;
            bookData.fetch();
            int numofbooks = bookData.NumberOfRecords();
            int[] bookprices = new int[numofbooks];

            for (int i = 0; i < numofbooks; i++)
            {
                bookprices[i] = Convert.ToInt32(bookData.prices[i]);
            }
            Console.WriteLine("enter username");
            String username = Console.ReadLine();
            Console.WriteLine("enter bookid");
            String bookid = Console.ReadLine();

            for (int i = 0; i < numofbooks; i++)
            {
                if (bookData.bookids[i].Equals(bookid))
                {
                    thegivenbookprice = bookprices[i];
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("no such book exists");
                return;
            }
            //evaluating number of days from issue date and return date
            numberofdays = numofdays(username, bookid);
            if(numberofdays==-1)
            {
                Console.WriteLine("please provide the correct transctinoal record username and bookid");
                return;
            }
            totalPrice = thegivenbookprice + usuanceCharges + (chargesperday * numberofdays);

            Console.WriteLine("\n\nthe amount to be paid is "+totalPrice);  

                 transactionData.fetch();
                transactionData.remove(username,bookid);
        }

        private void showmenu()
        {
            int choice;
            Console.WriteLine("\npress 1 to check the books in inventory ");
            Console.WriteLine("press 2 to check the the users details");
            Console.WriteLine("press 3 to know the transactions details");
            Console.WriteLine("press 4 to add books");
            Console.WriteLine("press 5 to add a transactions");
            Console.WriteLine("press 6 to charge a user and delete the record from the transaction");
            Console.WriteLine("press 7 to logout");



            choice = Convert.ToInt32(Console.ReadLine());

            if(choice == 1)
            {
                bookData.fetch();
                bookData.showdata();
                showmenu();
            }
            if(choice==2)
            {
                userData.fetch();
                userData.showdata();
                showmenu();
            }
            if(choice==3)
            {
                transactionData.fetch();
                transactionData.showdata();
                showmenu();
            }
            if(choice==4)
            {
                bookData.add();
                showmenu();
            }
            if(choice==5)
            {
                Console.WriteLine("enter the bookid ");
                String bookid= Console.ReadLine();
                Console.WriteLine("enter the username ");
                String username = Console.ReadLine();

                Console.WriteLine("enter the issue date in mm/dd/yy ");
                String issuedate = Console.ReadLine();
                Console.WriteLine("enter the return date in mm/dd/yy ");
                String returndate = Console.ReadLine();

                userData.fetch();
                bookData.fetch();
                int numberofbooks = bookData.NumberOfRecords();
                int numberofusers = userData.NumberOfRecords();
                bool bookPresence=false;
                bool userpresence=false;
                

                for (int i = 0; i < numberofbooks; i++)
                {
                    
                    if (bookData.bookids[i].Equals(bookid))
                    {
                        
                        userpresence = true;
                    }
                }
                for (int i = 0; i < numberofusers; i++)
                {
                    
                    if (userData.usernames[i].Equals(username))
                    {
                        
                        bookPresence = true;
                    }
                }
               
                if(userpresence&&bookPresence)
                {
                    transactionData.add(bookid, username, issuedate, returndate);
                    Console.WriteLine("transaction added successfull");

                    
                }
                else
                {
                    Console.WriteLine("\neither there is no such username or there is no such book");
                }
                showmenu();

            }
            if(choice==6)
            {
                showCharges();
                showmenu();
 
            }
            if(choice ==7)
            {
                return;
            }
          
            if(choice<1 || choice>7)
            {
                Console.WriteLine("enter a valid input");
            }

            

        }

    }
}
