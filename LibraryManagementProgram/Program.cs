using System;

namespace LibraryManagementProgram
{
     class Program
    {
        public static void Main(String[] args)
        {
            User u= new User();
            Staff s = new Staff();  
            
            int choice;
          
            
                Console.WriteLine("*********************************Welcome to library********************************************");
                Console.WriteLine("for User 1");
                Console.WriteLine("for staff 2");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    u.userhandle();
                    return;

                }
                if (choice == 2)
                {
                    s.staffhandle();
                    return; 


                }
                else
                {
                    Console.WriteLine("please give the correct input");
                }
            
            

        }

    }
}
