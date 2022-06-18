using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace EmailAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
            CustomerMaster customerMaster = new CustomerMaster();
           while(true)
            {
               // EmailSend emailSend = new EmailSend();
               // emailSend.SendMail("","","");
                
                Console.WriteLine("enter 1 for login");
                Console.WriteLine("enter 2 for registeration");
                Console.WriteLine("enter 3 to exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:customerMaster.Login();break;
                    case 2:customerMaster.Register();break;
                    case 3:return;break;
                    default:Console.WriteLine("enter a valid iput"); break;

                }
                
           
            }
        }
    }
}
