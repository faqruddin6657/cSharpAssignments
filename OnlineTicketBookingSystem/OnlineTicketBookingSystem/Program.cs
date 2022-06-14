using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicketBookingSystem
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Bookings bookings = new Bookings();
            while (true)
            {
                Console.WriteLine("for booking press 1 ");
                Console.WriteLine("for admin press 2" );
                int choice =Convert.ToInt32(Console.ReadLine());
                if(choice==1)
                {
                    bookings.BookTicket();
                }
                else if(choice==2)
                {
                    Console.WriteLine("this is the booking info(mobilenos) of customers");
                    bookings.PrintSeatingArngmnt();

                }
            }
        }
    }
}
