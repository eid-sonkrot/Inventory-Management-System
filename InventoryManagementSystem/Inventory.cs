using System;
using System.Collections.Generic;

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