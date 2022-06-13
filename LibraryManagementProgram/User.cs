using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementProgram
{
    internal class User
    {
       private UserData userData= new UserData();
       private BooksData booksData= new BooksData();
       private TransactionData transactionsData= new TransactionData();
       private String MRUSER;

        public void userhandle()
        {
            int choice;
            Console.WriteLine("for login press 1 ");
            Console.WriteLine("for registratoin press 2");
            choice = Convert.ToInt32(Console.ReadLine());
            if(choice == 1)
            {
                String username, password;
                Console.WriteLine("enter use name ");
                username = Console.ReadLine();
                Console.WriteLine("enter password ");
                password = Console.ReadLine();
                verification(username,password);
                return;
                
            }
            if(choice==2)
            {
                userData.add();
                return;
            }
            if(choice>2||choice<1)
            {
                Console.WriteLine("enter a valid input\n ");
                
            }
        }
        private void verification(String username,String password)
        {
            userData.fetch();
            
            for(int i = 0; i < userData.RECORDS; i++)
            {
                if (username == userData.usernames[i]&& password == userData.passwords[i])
                {
                    MRUSER = username;
                    Console.WriteLine("\nwelcome " + username);
                    
                    showmenu();
                    return;
                }
               
            }
            
                Console.WriteLine("no such user is found ... please register");
            

        }
        private void charges()
        {
            Console.WriteLine(" book issuance fees is 50rs");
            Console.WriteLine(" + book price (which will be given back after retriveing the book");
            Console.WriteLine(" + 5Rs(number of days)");
            
        }
        private String returnbookname(string bookiD)
        {
            String bookname=" ";
            booksData.fetch();
            for(int i=0;i<booksData.NumberOfRecords();i++)
            {
                if (booksData.bookids[i].Equals(bookiD))
                {
                    return booksData.booknames[i];
                }
            }
            return bookname;
        }
        private void showmenu()
        {
            int choice;
            Console.WriteLine("\npress 1 to check the books available with us ");
            Console.WriteLine("press 2 to know the library charges");
            Console.WriteLine("press 3 to know the borrowed books");
            Console.WriteLine("press 4 to see you info");
            Console.WriteLine("press 5 to change your info");
            Console.WriteLine("press 6 to logout");


            choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                booksData.fetch();
                booksData.showdata();

            }
            if (choice == 2)
            {
                charges();


            }
            if (choice == 3)
            {
                int flag = 0;
                transactionsData.fetch();
                for (int i = 0; i < transactionsData.NumberOfRecords(); i++)
                {
                    if (MRUSER == transactionsData.userids[i])
                    {
                        Console.WriteLine("the books borrowed are");
                        Console.WriteLine(returnbookname(transactionsData.bookids[i]));
                        flag = 1;
                    }
                }
                if(flag == 0)
                {
                    Console.WriteLine("no books borrowed");
                }


            }
            if (choice == 4)
            {
                int index = -1;
                userData.fetch();
                for (int i = 0; i < userData.RECORDS; i++)
                {
                    if (userData.usernames[i].Equals(MRUSER))
                    {
                        index = i;
                    }
                }
                Console.WriteLine("username,password,state,city,mobileno");
                Console.WriteLine(userData.usernames[index] + "," + userData.passwords[index] + "," + userData.states[index] + "," + userData.cities[index] + "," + userData.mobiles[index]);



            }
            if (choice == 5)
            {
                userData.fetch();
                userData.update();


            }
           
            if (choice == 6)
            {
                return;
            }
            if(choice<1||choice>6)
            {
                Console.WriteLine("enter a valid input");
                showmenu();
            }

        }

    }
}
