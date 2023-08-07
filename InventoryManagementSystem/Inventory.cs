using System;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
    public class Inventory
    {
        //List of products in our System 
        private List<Product> Products = new List<Product>();
       
        //add Product to Products List
        public void AddProduct( Product NewProduct)
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