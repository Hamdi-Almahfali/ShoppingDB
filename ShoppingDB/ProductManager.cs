using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ShoppingDB
//{
//    class ProductManager
//    {
//        public void ManageProducts()
//        {
//            // Implement product management functionality (e.g., add, update, delete products)
//            Console.WriteLine("Product management.");

//            Console.WriteLine("");
//        }
//    }

//    class SupplierManager
//    {
//        public void ManageSuppliers()
//        {
//            // Implement supplier management functionality (e.g., add, update, delete suppliers)
//            Console.WriteLine("Supplier management.\n");

//            List<Supplier> suppliers = new List<Supplier>
//            {
//                 new Supplier("NetOnNet", "079 23123 285" , "Triangel", "Malmö", "Sweden"),
//                 new Supplier("Elgiganten", "071 63486 342" ,"Möllan", "Malmö", "Sweden"),
//                 new Supplier("Samsung", "078 12875 496" , "Mobillia", "Malmö", "Sweden")
//            };

//            // Print information about each supplier
//            //foreach (Supplier supplier in suppliers)
//            //{
//            //    Console.WriteLine($"Supplier: {supplier.Name}");
//            //    Console.WriteLine($"PhoneNumber: {supplier.PhoneNumber}");
//            //    Console.WriteLine($"Address: {supplier.Address}");
//            //    Console.WriteLine($"City: {supplier.City}");
//            //    Console.WriteLine($"Country: {supplier.Country}");              
//            //    Console.WriteLine();
//            //}

//            PrintSuppliers(suppliers);

//            // Ask the admin how many new suppliers they want to add
//            Console.Write("\nHow many new suppliers do you want to add? ");
//            int count = int.Parse(Console.ReadLine());

//            // Add the specified number of new suppliers
//            for (int i = 0; i < count; i++)
//            {
//                AddSupplier(suppliers);
//            }

//            // Wait for user input before exiting
//            Console.WriteLine("\nPress any key to continue...");
//            Console.ReadKey();
//        }

//        static void AddSupplier(List<Supplier> suppliers)
//        {
//            Console.WriteLine("\nAdding a New Supplier:");
//            Console.Write("Enter supplier name: ");
//            string name = Console.ReadLine();

//            Console.Write("Enter supplier phone number: ");
//            string phoneNumb = Console.ReadLine();

//            Console.Write("Enter supplier address: ");
//            string address = Console.ReadLine();

//            Console.Write("Enter supplier city: ");
//            string city = Console.ReadLine();

//            Console.Write("Enter supplier country: ");
//            string country = Console.ReadLine();

//            // Create a new supplier object and add it to the list
//            suppliers.Add(new Supplier(name, phoneNumb, address, city, country));

//            Console.WriteLine("New supplier added successfully.");

//            // Print information about each supplier after adding the new supplier
//            PrintSuppliers(suppliers);
//        }

//        static void PrintSuppliers(List<Supplier> suppliers)
//        {
//            Console.WriteLine("List of Suppliers:\n");
//            foreach (Supplier supplier in suppliers)
//            {
//                Console.WriteLine($"Supplier: {supplier.Name}");
//                Console.WriteLine($"PhoneNumber: {supplier.PhoneNumber}");
//                Console.WriteLine($"Address: {supplier.Address}");
//                Console.WriteLine($"City: {supplier.City}");
//                Console.WriteLine($"Country: {supplier.Country}");
//                Console.WriteLine();
//            }
//        }
//    }
//}

//    class OrderManager
//    {
//        public void PlaceOrder()
//        {
//            // Implement order placement functionality
//            Console.WriteLine("Order placement functionality is not implemented yet.");
//        }
//    }

