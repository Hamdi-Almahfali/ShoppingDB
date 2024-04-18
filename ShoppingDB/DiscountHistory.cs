//using System;
//using System.Collections.Generic;
//using Npgsql;

//public class DiscountHistory
//{
//    public string ProductCode { get; set; }
//    public string ProductName { get; set; }
//    public DateTime DiscountStartDate { get; set; }
//    public DateTime DiscountEndDate { get; set; }
//    public decimal DiscountPercent { get; set; }
//    public decimal FinalPriceAfterDiscount { get; set; }
//}

//public class DatabaseService
//{
//    private readonly string _connectionString;

//    public DatabaseService(string host, int port, string database, string username, string password)
//    {
//        _connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password}";
//    }

//    public List<DiscountHistory> GetDiscountHistory()
//    {
//        List<DiscountHistory> discountHistory = new List<DiscountHistory>();

//        using (var connection = new NpgsqlConnection(_connectionString))
//        {
//            connection.Open();

//            using (var command = new NpgsqlCommand())
//            {
//                command.Connection = connection;
//                command.CommandText = @"
//                    SELECT p.code, p.name, dp.discountstartdate, dp.discountenddate, d.discountpercent,
//                           CASE 
//                               WHEN dp.discountenddate >= current_date AND dp.discountstartdate <= current_date THEN p.baseprice * (1 - d.discountpercent / 100)
//                               ELSE p.baseprice
//                           END as finalpriceafterdiscount
//                    FROM shop.products p
//                    JOIN shop.discountedproducts dp ON p.code = dp.discountedproductid
//                    JOIN shop.discounts d ON dp.discountid = d.discount_code
//                ";

//                using (var reader = command.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        var discount = new DiscountHistory
//                        {
//                            ProductCode = reader.GetString(0),
//                            ProductName = reader.GetString(1),
//                            DiscountStartDate = reader.GetDateTime(2),
//                            DiscountEndDate = reader.GetDateTime(3),
//                            DiscountPercent = reader.GetDecimal(4),
//                            FinalPriceAfterDiscount = reader.GetDecimal(5)
//                        };
//                        discountHistory.Add(discount);
//                    }
//                }
//            }
//        }

//        return discountHistory;
//    }
//}
