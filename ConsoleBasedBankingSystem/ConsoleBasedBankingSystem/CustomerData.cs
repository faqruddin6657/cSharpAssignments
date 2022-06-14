using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleBasedBankingSystem
{
    internal class CustomerData
    {
        //customer data contains username,password,Account number, first name, last name, mobile number, address, account balance, atm-status,account type
        public List<string> UserNames = new List<string>();
        public List<string> Passwords = new List<string>();
        public List<string> AccountNumbers = new List<string>();
       public List<string> FirstName = new List<string>();
       public List<string> LastName = new List<string>();
       public List<string> MobileNumber = new List<string>();
       public List<string> Address = new List<string>();
       public List<int> AccountBalance = new List<int>();
       public List<string> AtmStatus = new List<string>();
        public List<string> AccountType = new List<string>();

        public void Fetch()
        {
           FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\bankaccountdetails\CustomerData.txt",FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while(sr.Peek()>0)
            {
                string line = sr.ReadLine();
                string[] data = line.Split(',');

                AccountNumbers.Add(data[0]);
                FirstName.Add(data[1]);
                LastName.Add(data[2]);  
                MobileNumber.Add(data[3]);
                Address.Add(data[4]);
                AccountBalance.Add(Convert.ToInt32(data[5]));
                AtmStatus.Add(data[6]);
                AccountType.Add(data[7]);
                UserNames.Add(data[8]);
                Passwords.Add(data[9]);

            }

            fs.Close();
            sr.Close();
            


        }

        public void Add()
        {
            FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\bankaccountdetails\CustomerData.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            Console.WriteLine("select user name");
            string username = Console.ReadLine();
            Console.WriteLine("set password");
            string password = Console.ReadLine();

            Console.WriteLine("Choose account number of 8 digit with as your date of birth.. without slashes //");
            string accountnumber = Console.ReadLine();
            Console.WriteLine("Enter first name");
            string firstname = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter mobile number");
            string mobilenumber = Console.ReadLine();
            Console.WriteLine("Enter address");
            string address = Console.ReadLine();
            int accountbalance = 0;
            Console.WriteLine("your current atm status in --none");
            string atmstatus = "none";
            Console.WriteLine("type of account you want for current press 1 and for savings press 2");
            int choice = Convert.ToInt32(Console.ReadLine());
            string accounttype="savings";
            if(choice == 1)
            {
                accounttype = "current";
            }
            else if(choice == 2)
            {
                accounttype = "savings";

            }
            else
            {
                Console.WriteLine("enter a valid input");
            }
            sr.WriteLine(accountnumber+","+firstname+","+lastname + "," + mobilenumber + "," + address + "," + accountbalance + "," + atmstatus + "," + accounttype+","+username+","+password);
            sr.Close();
                fs.Close();

        }

        public void AddMoney(string curruser)
        {
            Console.WriteLine("enter the amount of money to be deposited");
            int amount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < AccountBalance.Count; i++)
            {
                if (curruser == UserNames[i])
                {
                    AccountBalance[i] = amount;
                    Console.WriteLine("amount deposited successfuly");
                }

            }
            UpdateinFile();

        }

        public void AtmIssuance(string curruser)
        {
            
            int index = -1, flag = 0;
            for (int i = 0; i < UserNames.Count; i++)
            {
                if (curruser == UserNames[i])
                {
                    flag = 1;
                    index = i;
                    
                }
            }

            if(flag == 1)
            {
                AtmStatus[index] = "pending";
                Console.WriteLine("requested for Atm issuance");
            }
            UpdateinFile();

        }

        public void MoneyWithdraw(string curruser)
        {
            int index = -1, flag = 0;
            for(int i=0;i<UserNames.Count;i++)
            {
                if(curruser == UserNames[i])
                {
                    flag = 1;
                    index = i;
                }
            }

            Console.WriteLine("enter the amount to be withdrawn");
            int deduction = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("to withdraw from the bank press 1 to withdraw from atm press 2 ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if(choice==1)
            {
                if (deduction <= AccountBalance[index])
                {
                    AccountBalance[index] = AccountBalance[index] - deduction;
                    Console.WriteLine("amount of " + deduction + " is withdrawn from bank");
                }
                else
                {
                    Console.WriteLine("not sufficient funds");
                }

            }
            else if (choice == 2)
            {


                if (AtmStatus[index] == "granted" && flag == 1)
                {
                    if (deduction <= AccountBalance[index])
                    {
                        AccountBalance[index] = AccountBalance[index] - deduction;
                        Console.WriteLine("amount of " + deduction + " is withdrawn from atm");
                    }
                    else
                    {
                        Console.WriteLine("not sufficient funds");
                    }
                }
                else
                {
                    Console.WriteLine("please apply for atm... you don't have one");
                }
            }
            else
            {
                Console.WriteLine("enter valid input");
            }
            UpdateinFile();

        }
        public void UpdateinFile()
        {
            FileStream fs = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\bankaccountdetails\CustomerData.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs); 

            for(int i = 0; i < AccountBalance.Count; i++)
            {
                sw.WriteLine(AccountNumbers[i] + "," + FirstName[i] + "," + LastName[i] + "," + MobileNumber[i] + "," + Address[i] + "," + AccountBalance[i] + "," + AtmStatus[i] + "," + AccountType[i] + "," + UserNames[i] + "," + Passwords[i]);

            }
            sw.Close();
            fs.Close();
        }


    }
}
