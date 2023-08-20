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

        private var Products = new List<Product>();
       
        //add Product to Products List
        public void AddProduct( Product newProduct)
        {
            if (!this.Products.Exists(x => x.Name.Equals(newProduct.Name)))
            {
                this.Products.Add(newProduct);
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
            var dataTable =ConsoleTable.From(this.Products);
            // Print the table to the console
            dataTable.Write(Format.Alternative);
        }
    }
}
