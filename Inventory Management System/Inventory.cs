using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    internal class Inventory
    {
        //List of products in our System 
        private static List<Product> products;
        public Inventory()
        {
            products = new List<Product>();

        }
        //add Product to Products List
        public  static  void AddProduct( Product NewProduct)
        {
            if (!products.Exists(x => x.Name.Equals(NewProduct.Name)))
            {
                products.Add(NewProduct);
                Console.WriteLine("The product addition is complete.");
            }
            else
            {
                Console.WriteLine("The product you want to add already exists." +
                    " If you want to update the product information," +
                    " please select that option from the main list.");
            }
            System.Threading.Thread.Sleep(1000);

        }
        //Creat table Display All Products in Products List
        public static void DisplayProducts()
        {
             
            // Get the type of the Product class using reflection
            Type productType = typeof(Product);

            // Get all properties of the Product class
            PropertyInfo[] properties = productType.GetProperties();
            
            // Add the property names as table headers
            string[] Head=properties.Select(x => x.Name).ToArray();
            var dataTable = new ConsoleTable(Head);


            foreach (Product product in products)
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
        public static void FindProduct(string name)
        {
            if (products.Find(x => x.Name.Equals(name))!=null)
            {
                Product product=products.Find(x => x.Name.Equals(name));
                // Get the type of the Product class using reflection
                Type productType = typeof(Product);

                // Get all properties of the Product class
                PropertyInfo[] properties = productType.GetProperties();
                // Add the property names as table headers
                string[] Head = properties.Select(x => x.Name).ToArray();
                var dataTable = new ConsoleTable(Head);
                // Create an array to store the property values for the current product
                object[] propertyValues = new object[properties.Length];

                // Get the value of each property and add it to the array
                for (int i = 0; i < properties.Length; i++)
                {
                    propertyValues[i] = properties[i].GetValue(product);
                }

                // Add the array of property values as a row in the table
                dataTable.AddRow(propertyValues);
                // Print the table to the console
                dataTable.Write(Format.Alternative);
            }
            else
            {
                Console.WriteLine("The product you want is not exists." +
                    " If you want to add the product " +
                    " please select add option from the main list.");
            }
        }
    }
}
