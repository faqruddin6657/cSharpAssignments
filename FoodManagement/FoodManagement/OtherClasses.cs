using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FoodManagement
{
    internal class Customer
    {
        private int currentcustomerid { get; set; }
        public static string dbconn = @"Data Source=FAQRUDDIN\SQLEXPRESS;Initial Catalog=foodmanagement;Integrated Security=True";
        public void Login()
        {
            
            DataTable dt = new DataTable();
            Console.WriteLine("enter name");
            string name = Console.ReadLine();
            Console.WriteLine("enter mobile");
            string mobile = Console.ReadLine();
            SqlConnection conn = new SqlConnection(dbconn);
            SqlCommand cmd = new SqlCommand("select * from customer where cname='"+name+"' and mobile='"+mobile+"'", conn);
            conn.Open();
            SqlDataReader dr =cmd.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            if(dt.Rows.Count == 1)
            {
                currentcustomerid = (int)dt.Rows[0][0];
                
               

                Console.WriteLine("Welcome " + dt.Rows[0][1]);
                Menu();
            }
            else
            {
                Console.WriteLine("no such user is found");
            }

        }
        private void Menu()
        {
            while (true)
            {
                Console.WriteLine("enter 1 to view menu");
                Console.WriteLine("enter 2 for order");
                Console.WriteLine("enter 3 to see the bill");
                Console.WriteLine("enter 4 to logout");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: ShowMenu(); break;
                    case 2: OrderFood(); break;
                    case 3: ShowBill(); break;
                    case 4: return; break;
                    default: Console.WriteLine("enter a valid input"); break;
                }
            }
        }
        public void Register()
        {
            Console.WriteLine("enter name");
            string name =Console.ReadLine();
            Console.WriteLine("enter mobile");
            string mobile= Console.ReadLine(); 
            SqlConnection conn = new SqlConnection(dbconn);
            SqlCommand cmd =  new SqlCommand("insert into customer values('"+name+"','"+mobile+"')",conn);
            conn.Open();
            int res =cmd.ExecuteNonQuery();
            conn.Close();
            if(res> 0)
            {
                Console.WriteLine("successfully registered");
            }

            

        }
        public void ShowMenu()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(dbconn);
            SqlCommand cmd = new SqlCommand("select * from menu", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            Console.WriteLine("no\t\tfood\t\tprice\t\t");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j] + "\t\t");
                }
                Console.WriteLine();
            }

        }
        public void HandleCustomer()
        {
            Console.WriteLine("enter 1 for login");
            Console.WriteLine("enter 2 for registeration");
            int choice = Convert.ToInt32(Console.ReadLine());
            if(choice == 1)
            {
                Login();
            }
            else if(choice ==2)
            {
                Register();
            }
            else
            {
                Console.WriteLine("enter a valid input");
            }
        }

        public void OrderFood()
        {
            Console.WriteLine("enter food item number");
            int choice = Convert.ToInt32(Console.ReadLine());
            SqlConnection sq = new SqlConnection(dbconn);
            try
            {

                
                SqlCommand cmd = new SqlCommand("insert into customerfoodchoice values(" + currentcustomerid + "," + choice + ")", sq);
                sq.Open();
                int res = cmd.ExecuteNonQuery();
                sq.Close();

                if (res > 0)
                {
                    Console.WriteLine("your order has been taken");
                }
                else
                {
                    Console.WriteLine("there is some issue");
                }
            }
            catch
            {
                Console.WriteLine("sorry your order has not been taken");
            }

        }
        public void ShowBill()
        {
            int total = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(dbconn);
            SqlCommand cmd = new SqlCommand("select foodname,price from menu,customer,customerfoodchoice where cid='" + currentcustomerid + "' and cid =fcid and fcfid=fid", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            Console.WriteLine("food\t\tprice\t\t");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j] + "\t\t");
                    total += (int)dt.Rows[i][1];
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nthe total price : " + total/2 +"\n");


        }
    }

    internal class Admin
    {
        public static string dbconn = @"Data Source=FAQRUDDIN\SQLEXPRESS;Initial Catalog=foodmanagement;Integrated Security=True";
        public void AdminLogin()
        {
            DataTable dt = new DataTable();
            Console.WriteLine("username");
            string uname = Console.ReadLine();
            Console.WriteLine("password");
            string pass = Console.ReadLine();
            SqlConnection conn = new SqlConnection(dbconn);
            SqlCommand cmd = new SqlCommand("select * from admin where username='" + uname + "' and password='" + pass + "'", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            if (dt.Rows.Count == 1)
            {
                Console.WriteLine("Welcome " + dt.Rows[0][1]);
                Menu();
            }
            else
            {
                Console.WriteLine("no such user is found");
            }

        }
        private void Menu()
        {
            while (true)
            {
                Console.WriteLine("enter 1 to view menu");
                Console.WriteLine("enter 2 to add items to the menu");
                Console.WriteLine("enter 3 to logout");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1: ShowItems(); break;
                    case 2: AddItems(); break;
                    case 3: return; break;
                    default: Console.WriteLine("enter a valid input"); break;
                }
            }
        }
        public void AddItems()
        {
            Console.WriteLine("enter food name");
            string uname = Console.ReadLine();
            Console.WriteLine("enter price");
            int price = Convert.ToInt32(Console.ReadLine());
            SqlConnection conn = new SqlConnection(dbconn);
            SqlCommand cmd = new SqlCommand("insert into menu values('"+uname+"',"+price+")", conn);
            conn.Open();
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res>0)
            {
                Console.WriteLine("successfully inserted in the menu");
            }
            else
            {
                Console.WriteLine("there is some issue");
            }
        }
        public void ShowItems()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(dbconn);
            SqlCommand cmd = new SqlCommand("select * from menu", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            Console.WriteLine("no\t\tfood\t\tprice\t\t");
            for(int i=0;i<dt.Rows.Count;i++)
            {
                for(int j=0;j<dt.Columns.Count;j++)
                {
                    Console.Write(dt.Rows[i][j]+"\t\t");    
                }
                Console.WriteLine();
            }

        }

    }
}
