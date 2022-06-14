using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBasedBankingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            while(true)
            {
                Console.WriteLine("****************** Console Based Banking System *************");
                Console.WriteLine("\n for manager press 1 ");
                Console.WriteLine("for customer press 2 ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if(choice == 1)
                {
                    ManagerHandle managerHandle = new ManagerHandle();
                    managerHandle.Handle();
                    

                }
                else if(choice == 2)
                {
                    CustomerHandle customerHandle = new CustomerHandle();
                    customerHandle.Handle();
                }
                else
                {
                    Console.WriteLine("please enter a valid input");
                }
            }
        }
    }
}
