using Npgsql;
using System;

public class ShoppingCart
{
    private readonly string connectionString; // Connection string for the database

    public ShoppingCart(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void AddProduct(string code, int quantity)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            // Check if the product exists and has sufficient quantity in the database
            string query = "SELECT name, quantity FROM shop.products WHERE code = @code";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("code", code);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string productName = reader.GetString(0);
                        int availableQuantity = reader.GetInt32(1);

                        if (quantity <= availableQuantity)
                        {
                            // Product can be added to the cart
                            // Perform necessary actions such as updating the database or simply adding to cart
                        }
                        else
                        {
                            Console.WriteLine($"Not enough quantity available for product: {productName}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Product with code {code} not found.");
                    }
                }
            }
        }
    }

    // Implement similar methods for other operations (e.g., RemoveProduct, ConfirmOrder, etc.)
}
