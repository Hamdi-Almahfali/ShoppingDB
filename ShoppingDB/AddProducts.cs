using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ShoppingDB
{
    internal class AddProducts
    {
    //     private string _connectionString;

    //public AddProducts(string connectionString)
    //{
    //    _connectionString = connectionString;
    //}

    //public void AddProduct(string newCode, string newName, int newQuantity, DateTime newDate, int basePrice, int newSupplier)
    //{
    //    try
    //    {
    //        using (var connection = new NpgsqlConnection(_connectionString))
    //        {
    //            connection.Open();

    //            using (var cmd = new NpgsqlCommand("shop.add_product", connection))
    //            {
    //                cmd.CommandType = System.Data.CommandType.StoredProcedure;

    //                // Add parameters
    //                cmd.Parameters.AddWithValue("newcode", newCode);
    //                cmd.Parameters.AddWithValue("newname", newName);
    //                cmd.Parameters.AddWithValue("newquantity", newQuantity);
    //                cmd.Parameters.AddWithValue("newdate", newDate);
    //                cmd.Parameters.AddWithValue("baseprice", basePrice);
    //                cmd.Parameters.AddWithValue("newsupplier", newSupplier);

    //                // Execute the command
    //                cmd.ExecuteNonQuery();

    //                Console.WriteLine("Product added successfully.");
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("Error: " + ex.Message);
    //    }
    //}
    }
}
