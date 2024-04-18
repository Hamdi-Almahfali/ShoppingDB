//using System;
//using System.Collections.Generic;
//using Npgsql;

//public class Product
//{
//    public string Code { get; set; }
//    public string Name { get; set; }
//    public int MaxOrders { get; set; }
//    public DateTime MonthYear { get; set; }
//}

//public class ProductService
//{
//    private readonly string _connectionString;

//    public ProductService(string connectionString)
//    {
//        _connectionString = connectionString;
//    }

//    public List<Product> GetProductsMaxOrdersPerMonth()
//    {
//        List<Product> products = new List<Product>();

//        using (var connection = new NpgsqlConnection(_connectionString))
//        {
//            connection.Open();

//            using (var command = new NpgsqlCommand())
//            {
//                command.Connection = connection;
//                command.CommandText = @"
//                    SELECT p.code, p.name, COUNT(oi.orderid) as maxorders, date_trunc('month', o.orderdate) as monthyear
//                    FROM shop.products p
//                    JOIN shop.ordereditems oi ON p.code = oi.productid
//                    JOIN shop.orders o ON oi.orderid = o.orderid
//                    GROUP BY p.code, p.name, monthyear
//                    ORDER BY monthyear, maxorders DESC
//                ";

//                using (var reader = command.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        var product = new Product
//                        {
//                            Code = reader.GetString(0),
//                            Name = reader.GetString(1),
//                            MaxOrders = reader.GetInt32(2),
//                            MonthYear = reader.GetDateTime(3)
//                        };
//                        products.Add(product);
//                    }
//                }
//            }
//        }

//        return products;
//    }
//}
