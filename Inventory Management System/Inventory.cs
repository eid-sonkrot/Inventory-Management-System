using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InventoryManagementSystem
{
    public class Inventory
    {
        //List of products in our System 
        private List<Product> Products = new List<Product>();

        //add Product to Products List
        public    void AddProduct( Product NewProduct)
        {
            if (!this.Products.Exists(x => x.Name.Equals(NewProduct.Name)))
            {
                this.Products.Add(NewProduct);
                Console.WriteLine("The product addition is complete.");
            }
            else
            {
                Console.WriteLine(@"The product you want to add already exists.\n
                     If you want to update the product information,
                     please select that option from the main list.");
            }
            System.Threading.Thread.Sleep(1000);
        }
        //Creat Taple Display All Products in Products List
        public  void DisplayProducts()
        {
            // Get the type of the Product class using reflection
            Type productType = typeof(Product);
            // Get all properties of the Product class
            PropertyInfo[] properties = productType.GetProperties();
            // Add the property names as table headers
            string[] Head=properties.Select(x => x.Name).ToArray();
            var dataTable = new ConsoleTable(Head);
            foreach (Product product in Products)
            {
                // Create an array to store the property values for the current product
                object[] propertyValues = new object[properties.Length];
                // Get the value of each property and add it to the array
                for (int i = 0; i < properties.Length; i++)
                {
                    propertyValues[i] = properties[i].GetValue(product);
                }
                // Add the array of property values as a row in the table
                dataTable.AddRow(propertyValues);
            }
            // Print the table to the console
            dataTable.Write(Format.Alternative);
        }
    }
}
