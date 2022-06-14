using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBasedBankingSystem
{
    
    
    internal class ManagerHandle
    {
        ManagerData Mdata = new ManagerData();
        CustomerData Customers = new CustomerData();
        
        public void Handle()
        {
            Console.WriteLine("press 1 for Manager Registration and 2 for mangager login");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Mdata.Add();
                Console.WriteLine("successfully registered");
            }
            else if (choice == 2)
            {

                int flag = 0;
                Mdata.Fetch();
                Console.WriteLine("enter Manager username");
                string username = Console.ReadLine();

                Console.WriteLine("enter password");
                string password = Console.ReadLine();

                for (int i = 0; i < Mdata.UserNames.Count; i++)
                {
                    if (Mdata.UserNames[i] == username && Mdata.Passwords[i] == password)
                    {
                        Console.WriteLine("welcome  " + username);
                        Customers.Fetch();
                        menu();
                        flag = 1;
                    }

                }
                if (flag == 0)
                {
                    Console.WriteLine("no such user is found");
                }
            }
            else
            {
                Console.WriteLine("enter a valid input");
            }

            


        }

        private void menu()
        {
            
                
                Console.WriteLine("press 1 to view all the user data");
                Console.WriteLine("press 2 to see issue requests for atm ");
                Console.WriteLine("press 3 to remove a customer");
                
                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:ShowUsers();break;
                    case 2:ShowIssueRequests();break;
                    case 3:TerminateUser();break;
                   
                        
                    defualt: Console.WriteLine("enter valid input");
                }
                
            


        }

        private void ShowUsers()
        {
            Console.WriteLine("account number,firstname,lastname,mobile number,address,account-balance,atm-status,account-type,username");
            
            for (int i = 0; i < Customers.AccountBalance.Count; i++)
            {
                Console.WriteLine(Customers.AccountNumbers[i] + "," + Customers.FirstName[i] + "," + Customers.LastName[i] + "," + Customers.MobileNumber[i]
                    + "," + Customers.Address[i] + "," + Customers.AccountBalance[i] + "," + Customers.AtmStatus[i] + "," + Customers.AccountType[i] 
                    + "," + Customers.UserNames[i]);

            }

        }
        private void ShowIssueRequests()
        {
            if (Customers.UserNames.Count > 0)
            {
                int index = -1, flag = 0;

                for (int i = 0; i < Customers.AccountBalance.Count; i++)
                {
                    if (Customers.AtmStatus[i] == "pending")
                    {
                        Console.WriteLine(Customers.UserNames[i] + " ---->" + Customers.AtmStatus[i]);
                    }
                }

                Console.WriteLine("\npress 1 to issue atm and press 2 to get back to menu ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("enter the username of the customer to issue atm card");
                    string custname = Console.ReadLine();

                    for (int i = 0; i < Customers.AccountBalance.Count; i++)
                    {
                        if (Customers.UserNames[i] == custname)
                        {
                            index = i;
                            flag = 1;
                        }
                    }

                    if (flag == 1 && index > -1)
                    {
                        Customers.AtmStatus[index] = "granted";
                        Console.WriteLine("atm issued");
                    }
                    else
                    {
                        Console.WriteLine("no such user is found");
                    }

                }
                else
                {
                    return;
                }

                Customers.UpdateinFile();
            }
            
        }
        private void TerminateUser()
        {
            int index = -1, flag = 0;
            ShowUsers();
            Console.WriteLine("\n enter the username of customer to be terminated");
            string cusname = Console.ReadLine();
            for (int i = 0; i < Customers.UserNames.Count; i++)
            {
                if (cusname == Customers.UserNames[i])
                {
                    index = i;
                    flag = 1;
                }
            }

            if (flag == 1 && index > -1)
            {
                Customers.UserNames.RemoveAt(index);
                Customers.FirstName.RemoveAt(index);
                Customers.LastName.RemoveAt(index);
                Customers.AccountNumbers.RemoveAt(index);
                Customers.AccountBalance.RemoveAt(index);
                Customers.AccountType.RemoveAt(index);
                Customers.Passwords.RemoveAt(index);
                Customers.MobileNumber.RemoveAt(index);
                Customers.Address.RemoveAt(index);
                Customers.AtmStatus.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("no such record is found");
            }
            Customers.UpdateinFile();


        }
    }
}
