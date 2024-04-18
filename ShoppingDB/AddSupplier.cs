using Npgsql;
using System;
using System.Data;


namespace ShoppingDB
{
    public partial class AdminPanel // Admin commands
    {
        string tempCs = "Host=pgserver.mau.se;Username=ao7105;Password=b67n4gzv;Database=ao7105";

        // string ' ' 
        public void AddSupplier(int newNR, int newID, string newAddress, string newName, string newcity, string newcountry)
        {
            using var con = new NpgsqlConnection(tempCs);
            con.Open();

            string sql = $"INSERT INTO shop.supplier VALUES ({newNR}, {newID}, {newAddress}, {newName}, {newcity}, {newcountry});";

            using var cmd = new NpgsqlCommand(sql, con);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        // string 
        public void AddProduct(string newcode, string newname, int newquantity, int baseprice, int newsupplier)
        {
            using var con = new NpgsqlConnection(tempCs);
            con.Open();

            string sql = $"INSERT INTO shop.products (code, name, quantity, baseprice, supplierID) VALUES ('{newcode}', '{newname}', '{newquantity}', '{baseprice}', '{newsupplier}');";

            using var cmd = new NpgsqlCommand(sql, con);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        //public void AddProductToOrder(string code)
        //{
        //    using var con = new NpgsqlConnection(tempCs);
        //    con.Open();

        //    string sql = $""
        //}

        public void UpdateProductQuantity(int productCode, int newQuantity)
        {
            using var con = new NpgsqlConnection(tempCs);
            con.Open();

            string sql = $"UPDATE shop.products SET quantity = {newQuantity}";
            using var cmd = new NpgsqlCommand(sql, con);
            con.Close();
        }

        public void DeleteProduct(string itemcode)
        {
            using var con = new NpgsqlConnection(tempCs);
            con.Open();

            string sqlDelete = $"DELETE FROM shop.products WHERE shop.products.code = {itemcode};";
            using var cmdDelete = new NpgsqlCommand(sqlDelete, con);

            cmdDelete.ExecuteNonQuery();
            con.Close();
        }


        public void CancelOrder(int newOrderId)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(tempCs))
            {
                connection.Open();

                using (NpgsqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "shop.cancelorder";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("neworderid", newOrderId);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void ConfirmOrder(int neworderid)
        {
            using var con = new NpgsqlConnection(tempCs);
            con.Open();

            string sqlDelete = $"UPDATE shop.orders SET confirmed = TRUE WHERE orderid = {neworderid}";
            using var cmd = new NpgsqlCommand(sqlDelete, con);

            con.Close();
        }
        public void SearchProductByCode(string itemcode)
        {
            using var con = new NpgsqlConnection(tempCs);
            con.Open();
            string sql = $"SELECT * FROM shop.products WHERE code = {itemcode}";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("----------------------------------");           
                Console.WriteLine("code: " + rdr.GetString(0));
                Console.WriteLine("name: " + rdr.GetString(1));
                Console.WriteLine("baseprice: " + rdr.GetInt32(2));
                Console.WriteLine("supplier: " + rdr.GetInt32(4));
                Console.WriteLine("discountpercent : " + rdr.GetInt32(5));
            }
            con.Close();
        }
        public void SearchProductByName(string prodname)
        {
            using var con = new NpgsqlConnection(tempCs);
            con.Open();
            string sql = $"SELECT * FROM shop.products WHERE code = {prodname}";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Name: " + rdr.GetInt32(0));
            }
            con.Close();
        }

        public void SearchProductBySupplier(string suppname)
        {
            using var con = new NpgsqlConnection(tempCs);
            con.Open();
            string sql = $"SELECT * FROM shop.supplier right join shop.products on shop.supplier.id = shop.products.supplierID = {suppname}";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Name: " + rdr.GetInt32(0));
            }
            con.Close();
        }

     
        public DataTable ViewOrder(short newOrderId)
        {
        DataTable table = new DataTable();

        using (NpgsqlConnection connection = new NpgsqlConnection(tempCs))
        {
            connection.Open();

            using (NpgsqlCommand command = new NpgsqlCommand("shop.vieworder", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters
                command.Parameters.AddWithValue("neworderid", newOrderId);

                try
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        return table;
        }

        public void PrintAllProductsInfo()
        {
            using (var con = new NpgsqlConnection(tempCs))
            {
                con.Open();
                string sql = "SELECT * FROM shop.products";
                using (var cmd = new NpgsqlCommand(sql, con))
                using (NpgsqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("code: " + rdr.GetString(0)); // Assuming code is a string
                        Console.WriteLine("name: " + rdr.GetString(1));
                        Console.WriteLine("supplier: " + rdr.GetInt32(4));
                    }
                    con.Close();
                }
            }
        }


        public void PrintAllProducts()
        {
            using var con = new NpgsqlConnection(tempCs);
            con.Open();
            string sql = "SELECT * FROM shop.products";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("code: " + rdr.GetString(0));
                Console.WriteLine("name: " + rdr.GetString(1));
                Console.WriteLine("baseprice: " + rdr.GetInt32(2));
                Console.WriteLine("supplier: " + rdr.GetInt32(4));
              //  Console.WriteLine("discountpercent : " + rdr.GetInt32(4));
            }
            con.Close();
        }

        public void NewOrders()
        {
            using var con = new NpgsqlConnection(tempCs);
            con.Open();
            string sql = "SELECT * FROM shop.orders o right join shop.ordereditems  oi on o.orderid = oi.orderid";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Order: " + rdr.GetInt32(0));
            }
            con.Close();
        }




       



    }
}

