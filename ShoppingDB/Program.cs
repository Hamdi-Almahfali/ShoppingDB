namespace ShoppingDB
{
    using System;
    using System.Collections.Generic;

    class Program
    {

        class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public bool IsAdmin { get; set; }
            public bool IsSupplier { get; set; }

        }

        static Dictionary<string, User> userCredentials = new Dictionary<string, User>();

        static void Main(string[] args)
        {
            // Initialize users

            userCredentials.Add("User", new User { Username = "User Menu", Password = "123", IsAdmin = false, IsSupplier = false });
            userCredentials.Add("Admin", new User { Username = "admin", Password = "1234", IsAdmin = true, IsSupplier = false });
            userCredentials.Add("Supplier", new User { Username = "supplier", Password = "12345", IsAdmin = false, IsSupplier = true });
            // Call the login function
            Login();

            string connectionString = "Your PostgreSQL connection string";
            //ProductService productService = new ProductService(connectionString);
            //List<Product> products = productService.GetProductsMaxOrdersPerMonth();

            // Output the results
            //Console.WriteLine("Products with Maximum Orders Each Month:");
            //foreach (var product in products)
            //{
            //    Console.WriteLine($"{product.Name} ({product.Code}) - {product.MonthYear.ToString("MMMM yyyy")}: {product.MaxOrders} orders");
            //}

            // Replace with your actual PostgreSQL connection details
            //string host = "localhost";
            //int port = 5432;
            //string database = "your_database_name";
            //string username = "your_username";
            //string password = "your_password";

            //DatabaseService databaseService = new DatabaseService(host, port, database, username, password);
            //List<DiscountHistory> discounts = databaseService.GetDiscountHistory();

            // Output the results
            //Console.WriteLine("Discount History:");
            //foreach (var discount in discounts)
            //{
            //    Console.WriteLine($"Product: {discount.ProductName} ({discount.ProductCode})");
            //    Console.WriteLine($"Discount Start Date: {discount.DiscountStartDate}");
            //    Console.WriteLine($"Discount End Date: {discount.DiscountEndDate}");
            //    Console.WriteLine($"Discount Percent: {discount.DiscountPercent}%");
            //    Console.WriteLine($"Final Price After Discount: ${discount.FinalPriceAfterDiscount}");
            //    Console.WriteLine();

            //}
       
            //AddProducts addProducts = new AddProducts(connectionString);

            //// Sample product data
            //string newCode = "ABC123";
            //string newName = "Product XYZ";
            //int newQuantity = 10;
            //DateTime newDate = DateTime.Now;
            //int basePrice = 100;
            //int newSupplier = 1;

            //// Call the method to add the product
            //addProducts.AddProduct(newCode, newName, newQuantity, newDate, basePrice, newSupplier);


            static void Login()
            {
                Console.WriteLine("Welcome to Login System");

                Console.Write("Enter your username: ");
                string username = Console.ReadLine();

                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                // Check if the entered credentials are valid
                // May change to switch cases
                if (ValidateLogin(username, password))
                {
                    if (userCredentials[username].IsAdmin)
                    {
                        Console.WriteLine("Admin login successful. Welcome, " + username + "!");
                        // Perform admin-specific actions here

                        AdminMenu adminMenu = new AdminMenu();
                        adminMenu.Run();


                    }
                    else if (userCredentials[username].IsSupplier)
                    {
                        Console.WriteLine("Supplier login successful. Welcome, " + username + "!");
                       // suppMenu.Run();
                    }
                    else
                    {
                        Console.WriteLine("Login successful. Welcome, " + username + "!");
                        UserMenu userMenu = new UserMenu();
                     
                       userMenu.UserUI();
                       
                    }
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }
            }

            static bool ValidateLogin(string username, string password)
            {
                // Check if the username exists
                if (userCredentials.ContainsKey(username))
                {
                    // Check if the entered password matches the stored password
                    if (userCredentials[username].Password == password)
                    {
                        return true; // Login successful
                    }
                }

                return false; // Login failed
            }
        }
    }
}



