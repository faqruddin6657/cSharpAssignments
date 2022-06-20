using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace EmailAssignment
{
    internal class EmailSend
    {
        public void SendMail(string frmemail, string password, string touser)
        {
           /* MimeMessage message = new MimeMessage();//creating a message object to fill in the information
            message.From.Add(new MailboxAddress("shaikh faqruddin", "shaikhfaqru786@gmail.com")); //adding sender to  message object
            message.To.Add(MailboxAddress.Parse("shaikhfaqru786@gmail.com"));//adding receiver addres to  message object
            message.Subject = "huge gratitude"; // adding subject
            message.Body = new TextPart("plain") { Text =  //adding text
                @" Hello "+username+" thanks for registering with us "
                };
            
            SmtpClient client = new SmtpClient();
           */

            try
            {
                var fromAddress = new MailAddress(frmemail, "Shaikh faqruddin");
                var toAddress = new MailAddress(touser, "shaikh faqruddin");
                const string fromPassword = "gnvdetdlymnboire";
                const string subject = "huge gratitude ";
                const string body = "Welcome ";

                var smtp = new System.Net.Mail.SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                /* Console.WriteLine("sending the message");
                 client.Connect("smtp.gmail.com",587,true);
                 client.Authenticate(username,password);
                 client.Send(message);
                 Console.WriteLine("message sent");
                */

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
               // client.Disconnect(true);
                //client.Dispose();

            }
        }

        
    }

    internal class ItemMaster
    {
        
        public static string dbconn = @"Data Source=FAQRUDDIN\SQLEXPRESS;Initial Catalog=EmailProject;Integrated Security=True";
        public void AddItem()
        {
            int price=0,qty=0;
            Console.WriteLine("enter item name");
            string item = Console.ReadLine();
            if (item == "")
            {
                Console.WriteLine("item name can't be empty");
                return;
            }
            Console.WriteLine("enter price");
            try
            {
                price = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("price cant be empty");
                return;
            }

            Console.WriteLine("enter quantity");
            try
            {
                qty = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("qty can't be empty");
                return;
            }
         
            SqlConnection sq = new SqlConnection(dbconn);
            SqlCommand cmd = new SqlCommand("insertintoitems '"+item+"',"+price+","+qty+"",sq);
            try
            {
                sq.Open();
                int res =cmd.ExecuteNonQuery();
                sq.Close();

           
                if (res > 0)
                {
                    Console.WriteLine("successfully added the item");
                }

            }
            catch(Exception e)
            {
                Console.WriteLine("the item is already present in the item list");
            }
            
           

        }

        public void RemoveItem()
        {
            Console.WriteLine("enter item name");
            string item = Console.ReadLine();
            if(item=="")
            {
                Console.WriteLine("can't be empty");
                return;
            }
            SqlConnection sq = new SqlConnection(dbconn);
            SqlCommand cmd = new SqlCommand("spdeleteitems '"+item+"'", sq);
            sq.Open();
            int res = cmd.ExecuteNonQuery();
            sq.Close();

            try
            {
                if (res > 0)
                {
                    Console.WriteLine("successfully removed the item");
                }
                else
                {
                    Console.WriteLine("no such item is present");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("no such item exists");
            }
        }

        public void ShowItems()
        {
            Console.WriteLine("the following are the items in the list");
            Console.WriteLine("item\t\t\tprice\t\t\tqty");
            DataTable dt = new DataTable();
         
            SqlConnection sq = new SqlConnection(dbconn);
            SqlCommand cmd = new SqlCommand("spgetitems", sq);
            sq.Open();
            SqlDataReader dr= cmd.ExecuteReader();
            dt.Load(dr);
            sq.Close();

            for(int i=0;i<dt.Rows.Count;i++)
            {
                for(int j=0;j<dt.Columns.Count;j++)
                {
                    Console.Write(dt.Rows[i][j]+"\t\t\t");
                }
                Console.WriteLine();    
            }


        }

        public void UpdateItem()
        {
            int quan;
            Console.WriteLine("enter item name");
            string itemname = Console.ReadLine();
            if(itemname=="")
            {
                Console.WriteLine("can't be empty");
                return;
            }
            Console.WriteLine("enter quantity");
            try
            {
                int quantity = Convert.ToInt32(Console.ReadLine());
                quan = quantity;
            }
            catch
            {
                Console.WriteLine("this field cant be empty");
                return;
            }
          
            SqlConnection sq = new SqlConnection(dbconn);
            SqlCommand cmd = new SqlCommand("spupdateitems '"+itemname+"',"+quan+"", sq);
            try
            {
                sq.Open();
            int res = cmd.ExecuteNonQuery();
            sq.Close();

            
                if (res > 0)
                {
                    Console.WriteLine("successfully updated  the qty");
                }
                else
                {
                    Console.WriteLine("no such item is present");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("no such item exists");
            }
        }
    }

    internal class CustomerMaster
    {
        private void Handle()
        {
            ItemMaster itemMaster = new ItemMaster();

            while (true)
            {


                Console.WriteLine("press 1 to add item");
                Console.WriteLine("press 2 to remove item");
                Console.WriteLine("press 3 to show items");
                Console.WriteLine("press 4 to update item quantity");
                Console.WriteLine("press 5 to show customers");
                Console.WriteLine("press 6 to remove your account");
                Console.WriteLine("press 7 to update mobile number");
                Console.WriteLine("pres 8 for logout");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:itemMaster.AddItem();break;
                    case 2: itemMaster.RemoveItem(); break;
                    case 3: itemMaster.ShowItems(); break;
                    case 4: itemMaster.UpdateItem(); break;
                    case 5: ShowCustomers(); break;
                    case 6: RemoveCustomer(); break;
                    case 7: UpdateCustomer(); break;
                    case 8: return; break;
                    default:Console.WriteLine("enter a vaild iput");break;
                }

            }
        }
        public static string dbconn = @"Data Source=FAQRUDDIN\SQLEXPRESS;Initial Catalog=EmailProject;Integrated Security=True";
        public void Login()
        {
            DataTable dt = new DataTable(); 
            Console.WriteLine("enter email");
            string email = Console.ReadLine();
            if(email=="")
            {
                Console.WriteLine("this field can't be empty");
                return;
            }
            Console.WriteLine("enter mobile number ");
            string mobile = Console.ReadLine();
            if (mobile == "")
            {
                Console.WriteLine("this field can't be empty");
                return;
            }

            SqlConnection sq = new SqlConnection(dbconn);
            SqlDataAdapter ada = new SqlDataAdapter("select * from customers where email='"+email+"' and phone='"+mobile+"'", sq);
            ada.Fill(dt);
           
           
            if(dt.Rows.Count== 1)
            {
                Console.WriteLine("Welcome " +dt.Rows[0][0]+" "+ dt.Rows[0][1]);
                Handle();
            }
            else
            {
                Console.WriteLine("no such user is found");
                return;
            }
            

        }

        public void Register()
        {
            string EMAIL_REGEX = "^[a-zA-z0-9]+[@]+[a-z]+[.]+[a-z]";
            string MOBILE_REGEX = "^[6-9]{1}[0-9]{9}$";
            string NAME_REGEX = "^[a-z]";
            
            Console.WriteLine("enter first name");
            string fname = Console.ReadLine();
            if(!Regex.IsMatch(fname, NAME_REGEX))
            {
                Console.WriteLine("this field can't be empty or numerical ");
                return;
            }

            Console.WriteLine("enter last name");
            string lname = Console.ReadLine();
            if (!Regex.IsMatch(lname, NAME_REGEX))
            {
                Console.WriteLine("this field can't be empty");
                return;
            }
            Console.WriteLine("enter mobile number");
            string mno = Console.ReadLine();
            if (!Regex.IsMatch(mno, MOBILE_REGEX))
            {
                Console.WriteLine(Regex.IsMatch(mno, MOBILE_REGEX));
                Console.WriteLine("this field can't be empty  or it should be of 10 Characters and starts with 6,7,8,9");
                return;
            }
            Console.WriteLine("enter email");
            string email = Console.ReadLine();
            if (!Regex.IsMatch(email, EMAIL_REGEX))
            {
                Console.WriteLine("this field can't be empty or email must contain @ ...\n and should not contain special character before @");
                return;
            }
            SqlConnection sq = new SqlConnection(dbconn);
            SqlCommand cmd = new SqlCommand("insertintocustomer '"+fname+ "','" + lname + "','" + mno + "','" + email + "'", sq);
            try
            {
                sq.Open();
                int res = cmd.ExecuteNonQuery();
                sq.Close();


                if (res > 0)
                {
                    Console.WriteLine("successfully added the item");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("the item is already present in the item list");
            }
        }
        public void UpdateCustomer()
        {
            Console.WriteLine("enter mobile number");
            string mno = Console.ReadLine();
            if (mno == "")
            {
                Console.WriteLine("this field can't be empty");
                return;
            }
            Console.WriteLine("enter email");
            string email = Console.ReadLine();
            if (email == "")
            {
                Console.WriteLine("this field can't be empty");
                return;
            }
            SqlConnection sq = new SqlConnection(dbconn);
            SqlCommand cmd = new SqlCommand("spupdatecustomer '" + email + "', '" + mno + "'", sq);
            try
            {
                sq.Open();
                int res = cmd.ExecuteNonQuery();
                sq.Close();


                if (res > 0)
                {
                    Console.WriteLine("successfully updated customer mobile no");
                }
                else
                {
                    Console.WriteLine("either mobile or email is wrong");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("either mobile or email is wrong");
            }
        }

        public void ShowCustomers()
        {
            DataTable dt = new DataTable();
            SqlConnection sq = new SqlConnection(dbconn);
            SqlDataAdapter ada = new SqlDataAdapter("spgetcustomers", sq);
            ada.Fill(dt);
            Console.WriteLine("firstname\t\tlastname\t\tmobile\t\temail");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j] + "\t\t");
                }
                Console.WriteLine();
            }
        }
        
        public void RemoveCustomer()
        {
            Console.WriteLine("enter email");
            string email = Console.ReadLine();

            SqlConnection sq = new SqlConnection(dbconn);
            SqlCommand cmd = new SqlCommand("spdeletecustomer '"+email+"'", sq);
            sq.Open();
            int res=cmd.ExecuteNonQuery();
            sq.Close();
            if(res > 0)
            {
                Console.WriteLine("successfully removed the customer");
            }
            else
            {
                Console.WriteLine("no such customer is found");
            }
        }
        
    }


}
