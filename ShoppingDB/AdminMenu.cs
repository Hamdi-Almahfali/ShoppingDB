using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDB
{
    internal class AdminMenu
    {

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\nAdmin Menu:");
                Console.WriteLine("1. Add Products");
                Console.WriteLine("2. Add Suppliers");
                Console.WriteLine("3. Uppdate Product Quantity");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. See list of all products and their information");
                Console.WriteLine("6. See list of new orders");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        //ProductManager productManager = new ProductManager();
                        //productManager.ManageProducts();
                        AdminPanel adminAddProduct = new AdminPanel();
                        bool addMoreProducts = true;
                        // adminAddProduct.AddProduct("1324", "Ipad", 20, DateTime.Now, 3000, 1);

                        while (addMoreProducts)
                        {
                            Console.Write("Enter product code: ");
                            string code = Console.ReadLine();

                            Console.Write("Enter product name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter product quantity: ");
                            int quantity = int.Parse(Console.ReadLine());

                            Console.Write("Enter product base price: ");
                            int basePrice = int.Parse(Console.ReadLine());

                            Console.Write("Enter supplier ID: ");
                            int supplierID = int.Parse(Console.ReadLine());

                            adminAddProduct.AddProduct(code, name, quantity, basePrice, supplierID);

                            Console.WriteLine("Product added successfully!");

                            Console.Write("Do you want to add another product? (yes/no): ");
                            string addAnotherProduct = Console.ReadLine().Trim().ToLower();

                            addMoreProducts = (addAnotherProduct == "yes");
                        }

                        Console.WriteLine("Exiting...");
                        Console.ReadKey();
                        break;
                    case 2:                 
                        AdminPanel adminAddSupplier = new AdminPanel();
                        bool addMoreSuppliers = true;

                        while (addMoreSuppliers)
                        {                          

                            Console.Write("Enter supplier number: ");
                            int number = int.Parse(Console.ReadLine());

                            Console.Write("Enter supplier ID: ");
                            int id = int.Parse(Console.ReadLine());

                            Console.Write("Enter supplier address: ");
                            string address = Console.ReadLine();

                            Console.Write("Enter supplier name: ");
                            string supName = Console.ReadLine();

                            Console.Write("Enter supplier city: ");
                            string city = Console.ReadLine();

                            Console.Write("Enter supplier country: ");
                            string country = Console.ReadLine();

                            adminAddSupplier.AddSupplier(number, id, address, supName, city, country);

                            Console.WriteLine("Supplier added successfully!");

                            Console.Write("Do you want to add another supplier? (yes/no): ");
                            string addAnotherSupplier = Console.ReadLine().Trim().ToLower();

                            addMoreSuppliers = (addAnotherSupplier == "yes");
                        }

                        Console.WriteLine("Exiting...");
                        Console.ReadKey();
                        break;

                    case 3:
                        AdminPanel adminUpdateProductQuantity = new AdminPanel();
                        bool adminUpdateProductQuantities = true;

                        while (adminUpdateProductQuantities)
                        {
                            Console.Write("Enter Product CODE: ");
                            int code = int.Parse(Console.ReadLine());

                            Console.Write("Enter New Product number: ");
                            int newQuantity = int.Parse(Console.ReadLine());

                            adminUpdateProductQuantity.UpdateProductQuantity(code, newQuantity);

                            Console.WriteLine("New Product Quantity added successfully!");

                            Console.Write("Do you want to add another supplier? (yes/no): ");
                            string updateProductQ = Console.ReadLine().Trim().ToLower();

                            adminUpdateProductQuantities = (updateProductQ == "yes");
                        }

                        Console.WriteLine("Exiting...");
                        Console.ReadKey();
                        break;
                    case 4:
                        AdminPanel deleteProduct = new AdminPanel();
                        bool deleteProductQuantities = true;

                        while (deleteProductQuantities)
                        {
                            Console.Write("Enter Product CODE: ");
                            string code = Console.ReadLine();


                            deleteProduct.DeleteProduct(code);

                            Console.WriteLine("Deleted successfully!");

                            Console.Write("Do you want to delete another product? (yes/no): ");
                            string deleteProducts = Console.ReadLine().Trim().ToLower();

                            deleteProductQuantities = (deleteProducts == "yes");
                        }


                        break;


                    case 5:
                        AdminPanel viewInfo = new AdminPanel();
                       
                        viewInfo.PrintAllProductsInfo(); // Print the DataTable
                        Console.ReadKey();
                        break;

                    case 6:

                        AdminPanel viewNewOrders = new AdminPanel();
                        viewNewOrders.NewOrders();
                        Console.ReadKey();
                        break;

                                            
                      
                }
            }
        }

      







    }

}




