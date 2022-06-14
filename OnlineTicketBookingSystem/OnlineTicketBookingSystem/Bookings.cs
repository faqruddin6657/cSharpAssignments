using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OnlineTicketBookingSystem
{
    internal class Bookings
    {
       public string[][] MorningShow = new string[6][]; // storing the seats in 2d array
       public string[][] EveningShow= new string[6][];
       public string[][] NightShow = new string[6][];
      

        public void fetch()
        {
            FileStream Es = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\CSharpAssignments\cSharpAssignments\OnlineTicketBookingSystem\EShow.txt", FileMode.Open,FileAccess.Read);
            FileStream Ms = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\CSharpAssignments\cSharpAssignments\OnlineTicketBookingSystem\MShow.txt", FileMode.Open, FileAccess.Read);
            FileStream Ns = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\CSharpAssignments\cSharpAssignments\OnlineTicketBookingSystem\NShow.txt", FileMode.Open, FileAccess.Read);
            StreamReader EsR = new StreamReader(Es);
            StreamReader MsR = new StreamReader(Ms);
            StreamReader NsR = new StreamReader(Ns);
            for(int i = 0; i < 5; i++)
            {
                string line = EsR.ReadLine();   
                string[] record= line.Split(',');
                EveningShow[i] = record;
                
            }
            for (int i = 0; i < 5; i++)
            {
                string line = NsR.ReadLine();
                string[] record = line.Split(',');
                NightShow[i] = record;

            }
            for (int i = 0; i < 5; i++)
            {
                string line = MsR.ReadLine();
                string[] record = line.Split(',');
                MorningShow[i] = record;

            }
            MsR.Close();
            NsR.Close();
            EsR.Close();
            Es.Close();
            Ns.Close();
            Es.Close();
        }

        public void PrintSeatingArngmnt()
        {
            fetch();
            Console.WriteLine("******** Tickets Availibilty *****\n");
            Console.WriteLine("  B denotes booked\n");
            Console.WriteLine("******* Morning Bookings *****\n");
            for(int i=0;i<5;i++)
            {
                for(int j=0;j<5;j++)
                {
                    Console.Write(MorningShow[i][j]+"\t");   
                }
                Console.WriteLine();
            }

            Console.WriteLine("******* Evening Bookings *****\n");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(EveningShow[i][j]+"\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("******* Night Bookings *****\n");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(NightShow[i][j]+"\t");
                }
                Console.WriteLine();
            }
        }

        public void BookTicket()
        {
            fetch();
            seatingUsers();
            Console.WriteLine("To book the morning Show press 1 ");
            Console.WriteLine("To book the Evening Show press 2 ");
            Console.WriteLine("To book the Night Show press 3 ");
            Console.WriteLine("to see your bookiings");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:BookM();break; ;
                case 2:BookE();break;
                case 3:BookN();break;
                case 4:YourBookings();break;
                default:Console.WriteLine("enter valid input");break;
            }
        }

        private void BookM()
        {
            fetch();
            Console.WriteLine("Select Which row");
            int r= Convert.ToInt32(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Select Which column");
            int c = Convert.ToInt32(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("enter mobile number");
            string mob = Console.ReadLine();
            if(MorningShow[r-1][c-1] =="----------")
            {
                MorningShow[r - 1][c - 1] = mob;
                update();

            }
            else
            {
                Console.WriteLine("already booked");
            }
            

        }
        private void BookE()
        {
            fetch();
            Console.WriteLine("Select Which row");
            int r = Convert.ToInt32(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Select Which column");
            int c = Convert.ToInt32(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("enter mobile number");
            string mob = Console.ReadLine();
            
            if (EveningShow[r - 1][c - 1] == "----------")
            {
                EveningShow[r - 1][c - 1] = mob;
                update();

            }
            else
            {
                Console.WriteLine("already booked");
            }
            
        }
        private void BookN()
        {
            fetch();
            Console.WriteLine("Select Which row");
            int r = Convert.ToInt32(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Select Which column");
            int c = Convert.ToInt32(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("enter mobile number");
            string mob = Console.ReadLine();
            NightShow[r-1][c-1] = mob;
            if (NightShow[r - 1][c - 1] == "----------")
            {
                NightShow[r - 1][c - 1] = mob;
                update();

            }
            else
            {
                Console.WriteLine("already booked");
            }

            

        }


        public void update()
        {
            FileStream Es = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\CSharpAssignments\cSharpAssignments\OnlineTicketBookingSystem\EShow.txt", FileMode.Create, FileAccess.Write);
            FileStream Ms = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\CSharpAssignments\cSharpAssignments\OnlineTicketBookingSystem\MShow.txt", FileMode.Create, FileAccess.Write);
            FileStream Ns = new FileStream(@"C:\Users\shaikh faqruddin\OneDrive\Desktop\CSharpAssignments\cSharpAssignments\OnlineTicketBookingSystem\NShow.txt", FileMode.Create, FileAccess.Write);
            StreamWriter EsW = new StreamWriter(Es);
            StreamWriter MsW = new StreamWriter(Ms);
            StreamWriter NsW = new StreamWriter(Ns);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    EsW.Write(EveningShow[i][j] + ",");
                }
                EsW.Write("\n");
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    MsW.Write(MorningShow[i][j] + ",");
                }
                MsW.Write("\n");
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    NsW.Write(NightShow[i][j] + ",");
                }
                NsW.Write("\n");
            }

            MsW.Close();
            NsW.Close();
            EsW.Close();
            Es.Close();
            Ns.Close();
            Es.Close();

        }

        public void seatingUsers()
        {
            fetch();
            Console.WriteLine("******** Tickets Availibilty *****\n");
            Console.WriteLine("  B denotes booked\n");
            Console.WriteLine("******* Morning Bookings *****\n");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if(MorningShow[i][j]!="----------")
                    {
                        Console.Write("--Booked--" + "\t");
                    }
                    else
                    {
                        Console.Write("----------" + "\t");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("******* Evening Bookings *****\n");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (EveningShow[i][j] != "----------")
                    {
                        Console.Write("--Booked--" + "\t");
                    }
                    else
                    {
                        Console.Write("----------" + "\t");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("******* Night Bookings *****\n");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (NightShow[i][j] != "----------")
                    {
                        Console.Write("--Booked--" + "\t");
                    }
                    else
                    {
                        Console.Write("----------"+"\t");
                    }
                }
                Console.WriteLine();
            }
        }

        public void YourBookings()
        {
            Console.WriteLine("Enter your mobile Number");
            string mobile = Console.ReadLine();
            fetch();
            Console.WriteLine("******** Tickets Availibilty *****\n");
            Console.WriteLine("  B denotes booked\n");
            Console.WriteLine("******* Morning Bookings *****\n");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (MorningShow[i][j] == mobile)
                    {
                        Console.Write("ur-booking" + "\t");
                    }
                    else
                    {
                        Console.Write("----------" + "\t");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("******* Evening Bookings *****\n");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (EveningShow[i][j] == mobile)
                    {
                        Console.Write("ur-booking" + "\t");
                    }
                    else
                    {
                        Console.Write("----------" + "\t");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("******* Night Bookings *****\n");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (NightShow[i][j] == mobile)
                    {
                        Console.Write("ur-booking" + "\t");
                    }
                    else
                    {
                        Console.Write("----------" + "\t");
                    }
                }
                Console.WriteLine();
            }
        }



    }
}
