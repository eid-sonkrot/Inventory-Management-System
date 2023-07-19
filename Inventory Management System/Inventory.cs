using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
