using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Admin admin = new Admin();
            while(true)
            {
                Console.WriteLine("enter 1 for admin");
                Console.WriteLine("enter 2 for customer");
                Console.WriteLine("enter 3 to exit");
                int choice =Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:admin.AdminLogin(); break;
                    case 2:customer.HandleCustomer(); break;
                    case 3:return;break;
                    default:Console.WriteLine("enter a valid input");break;
                }

            }
            Console.ReadLine(); 
        }
    }
}
