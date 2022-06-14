using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBasedBankingSystem
{
    internal class CustomerHandle
    {
        string currentuser;
        CustomerData Cdata = new CustomerData();
        
        
        public void Handle()
        {
            
            Cdata.Fetch();
            Console.WriteLine("press 1 for registration or press 2 for login");
            int choice=Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Cdata.Add();
                Console.WriteLine("successfully registered");
            }
            else if(choice ==2){
                int flag = 0;
                Console.WriteLine("enter Customer username");
                string username = Console.ReadLine();

                Console.WriteLine("enter password");
                string password = Console.ReadLine();
                for(int i=0;i<Cdata.UserNames.Count;i++)
                {
                    if(Cdata.UserNames[i] == username && Cdata.Passwords[i]==password)
                    {
                        currentuser = username;
                        Console.WriteLine("Welcome  " + username);
                        flag = 1;
                        ShowMenu();

                    }
                }
                if(flag==0)
                {
                    Console.WriteLine("no such user is found... please register");
                }


            }
            else
            {
                Console.WriteLine("enter a valid input");
            }

        }

        private void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n\npress 1 to view account details");
                Console.WriteLine("press 2 to show bank balance");
                Console.WriteLine("press 3 withdraw money");
                Console.WriteLine("press 4 to add money");
                Console.WriteLine("press 5 change password");
                Console.WriteLine("press 6 to apply for atm");
                Console.WriteLine("press 7 to logout");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1: AccountDetails(); break;
                    case 2: BankBalance(); break;
                    case 3: WithdrawMoney(); break;
                    case 4: AddMoney(); break;
                    case 5: ChangePassword(); break;
                    case 6:AtmApply();break;
                    case 7: return;
                    default: Console.WriteLine("enter a valid input"); break;

                }
            }
            

        }

        private void AccountDetails()
        {
            int flag = 0;
            int index=-1;
            for(int i=0;i<Cdata.UserNames.Count;i++)
            {
                if (currentuser == Cdata.UserNames[i])
                {
                    flag = 1;
                    index = i;
                }
            }
            if (flag == 1 && index>-1)
            {
                Console.WriteLine("username: " + Cdata.UserNames[index]+ "\nfirstname: " + Cdata.FirstName[index]+"\nlastname: "+ Cdata.LastName[index]
                    +"\naccount type: "+ Cdata.AccountType[index]+"\naccount number: " + Cdata.AccountNumbers[index] + "\naccount Balance: " + Cdata.AccountBalance[index]
                    + "\nmobile number: " + Cdata.MobileNumber[index] + "\nAddress: " + Cdata.Address[index] + "\natm status: " + Cdata.AtmStatus[index]);
            }
        }
        private void BankBalance()
        {
           
            for (int i = 0; i < Cdata.AccountBalance.Count; i++)
            {
                if (currentuser == Cdata.UserNames[i])
                {
                    Console.WriteLine(Cdata.FirstName[i]+" "+Cdata.LastName[i]+" "+Cdata.AccountType[i]+" account balance is " +Cdata.AccountBalance[i]);
                }
            }

        }
        private void AtmApply()
        {
            Cdata.AtmIssuance(currentuser);
        }
        private void AddMoney()
        {
            Cdata.AddMoney(currentuser);
            Console.WriteLine("money added in your account");


        }
        private void WithdrawMoney()
        {
            
            Cdata.MoneyWithdraw(currentuser);
        }
        private void ChangePassword()
        {
            for (int i = 0; i < Cdata.AccountBalance.Count; i++)
            {
                if (currentuser == Cdata.UserNames[i])
                {
                    Console.WriteLine("enter new password");
                    string pass1=Console.ReadLine();
                    Console.WriteLine("re enter password");
                    string pass2 = Console.ReadLine();
                    if(pass1 == pass2)
                    {
                        Cdata.Passwords[i]=pass1;
                        Console.WriteLine("passwords updated successfully");

                    }
                    else
                    {
                        Console.WriteLine("passwords do not match reset again");
                    }
                }
            }
            Cdata.UpdateinFile();   

        }
    }
}
