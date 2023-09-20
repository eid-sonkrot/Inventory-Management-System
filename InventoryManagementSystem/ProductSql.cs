using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace InventoryManagementSystem
{
    public class ProductSql : IProductRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        public ProductSql()
        {
            if (!DatabaseExists())
                CreateDatabase();
        }
        public bool DatabaseExists()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }
        public void CreateDatabase()
        {
            var databaseName = "Products";
            var createDatabaseSql = $"CREATE DATABASE {databaseName}";
            var createTableSql = $@"
        USE {databaseName};
        CREATE TABLE Products
        (
            Name NVARCHAR(255),
            Price FLOAT,
            Quantity INT
        );";

            connectionString = connectionString.Split(new String[] { "Database="}, System.StringSplitOptions.None).First();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(createDatabaseSql, connection))
                {
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error creating database: " + ex.Message);
                        return; // Exit method if database creation fails
                    }
                }
                using (var command = new SqlCommand(createTableSql, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error creating table: " + ex.Message);
                    }
                }
            }
        }
        public void DeleteProduct(string name)
        {
            var deleteSql = "DELETE FROM Products WHERE Name = @Name";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(deleteSql, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }

        public Product GetProduct(string name)
        {
            var selectSql = "SELECT * FROM Products WHERE Name = @Name";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(selectSql, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Product
                                {
                                    Name = reader["Name"].ToString(),
                                    Price = Convert.ToDouble(reader["Price"]),
                                    Quantity = Convert.ToInt32(reader["Quantity"])
                                };
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return null; // Product not found
        }

        public void InsertProduct(Product product)
        {
            var insertSql = "INSERT INTO Products (Name, Price,Quantity) VALUES (@Name, @Price,@Quantity)";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }

        public void UpdateProduct(Product product,string name)
        {
            var updateSql = "UPDATE Products SET Name = @Name, Price = @Price, Quantity = @Quantity WHERE Name = @currentName";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(updateSql, connection))
                {
                    command.Parameters.AddWithValue("@CurrentName", name);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
        public List<Product> SelectAllProducts()
        {
            var products = new List<Product>();
            var selectSql = "SELECT * FROM Products";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(selectSql, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var product = new Product
                                {
                                    Name = reader["Name"].ToString(),
                                    Price = Convert.ToDouble(reader["Price"]),
                                    Quantity = Convert.ToInt32(reader["Quantity"])
                                };
                                products.Add(product);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return products;
        }
    }
}