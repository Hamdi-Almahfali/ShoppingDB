using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDB
{
    internal class UserMenu
    {
        string tempCs = "Host=pgserver.mau.se;Username=ao7105;Password=b67n4gzv;Database=ao7105";

        public void UserUI()
        {
            
            
            Console.WriteLine("\nUser Menu:");

            Console.WriteLine("1. Sign In");


            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            if (choice != 1) choice = 1;
            Console.Clear();


            switch (choice)
            {
                case 1:


                    Console.Write("Enter Phone Number: ");
                    int numb = int.Parse(Console.ReadLine());

                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();

                    LogIn(numb, password);
                  
                    CheckIfCustomerExist(numb);
                   
                break;

                case 2:
                
                    
                break;
            }

        }


        public void Run()
        {

            while (true)
            {
                Console.WriteLine("\nUser Menu:");
                Console.WriteLine("1. See Available Products");
                Console.WriteLine("2. Add Suppliers");
                Console.WriteLine("3. Uppdate Product Quantity");
                Console.WriteLine("4. Delete Product");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();


                switch (choice)
                {
                    case 1:
                        AdminPanel viewInfo = new AdminPanel();

                        Console.Write("Enter Product CODE: ");
                        string code = Console.ReadLine();

                        viewInfo.SearchProductByCode(code);
                     

                        Console.ReadKey();
                        break;
                    case 2:
                       
                        Console.WriteLine("Exiting...");
                        Console.ReadKey();
                        break;

                    case 3:
                        

                        Console.WriteLine("Exiting...");
                        Console.ReadKey();
                        break;
                    case 4:
                        

                        break;


                    case 5:
                      
                        Console.ReadKey();
                        break;



                }






            }

        }

        public void SignUp(int newNr, string newFName, string newLName, string newEmail, string newAddress, string newCity, string newCountry, string newPassword)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(tempCs))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("shop.sign_up", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("newnr", newNr);
                    command.Parameters.AddWithValue("newfname", newFName);
                    command.Parameters.AddWithValue("newlname", newLName);
                    command.Parameters.AddWithValue("newemail", newEmail);
                    command.Parameters.AddWithValue("newaddress", newAddress);
                    command.Parameters.AddWithValue("newcity", newCity);
                    command.Parameters.AddWithValue("newcountry", newCountry);
                    command.Parameters.AddWithValue("newpassword", newPassword);

                    try
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Sign up successful.");
                    }
                    catch (NpgsqlException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                connection.Close();
            }
        }

        public void LogIn(int phoneNumber, string Password)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(tempCs))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("shop.sign_up", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameters
                    
                    command.Parameters.AddWithValue("phoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("password", Password);

                    try
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Sign up successful.");
                    }
                    catch (NpgsqlException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                connection.Close();
            }
        }

        public void CheckIfCustomerExist(int existNr)
        {
            // Check if the customer already exists based on phone number
            if (CustomerExists(existNr))
            {
                Console.WriteLine("Customer already exists");
                Run();
                return; // Exit the method without signing up the customer
               
            }
            else
            {
                Console.WriteLine("Customer needs to sign up");
                NewCustomer();
            }
        


        }
        private bool CustomerExists(int phoneNumber)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(tempCs))
            {
                connection.Open();
                string sql = "SELECT COUNT(*) FROM shop.customers WHERE phonenr = @phonenr";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@phonenr", phoneNumber);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public void NewCustomer()
        {
            Console.Write("Enter Phone number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Enter Firstname: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Lastname: ");
            string lastName = Console.ReadLine();


            Console.Write("Enter Email: ");
            string eMail = Console.ReadLine();


            Console.Write("Enter Address: ");
            string address = Console.ReadLine();


            Console.Write("Enter City: ");
            string city = Console.ReadLine();


            Console.Write("Enter Country name: ");
            string country = Console.ReadLine();


            Console.Write("Enter Password: ");
            string newPassword = Console.ReadLine();

            SignUp(number, firstName, lastName, eMail, address, city, country, newPassword);

        }

    }
}
