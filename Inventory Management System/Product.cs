using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleTables;

namespace Inventory_Management_System
{
    internal class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Product()
        {
            this.Name = null;
            this.Price = 0;
            this.Quantity = 0;
        }
        
        public void Input()
        {   //Validating the input to ensure its correctness
            bool IsValid = false;
            string Name;
            Double Price;
            int Quantity;
            do
            {
                
                // Inform the user to enter the product's name
                Console.Write("Enter the product's name: ");
                Name = Console.ReadLine();
                if(Regex.IsMatch(Name, @"^[A-Za-z]+$"))
                {
                    IsValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a Name contain Alpapitic character");
                }
            } while (!IsValid);
            this.Name = Name;
            IsValid = false;
            do
            {
                
                // Inform the user to enter the product's price
                Console.Write("Enter the product's price: ");

                if (double.TryParse(Console.ReadLine(), out Price))
                {
                    IsValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a name containing only alphabetical characters.");
                    
                }
            } while (!IsValid);


            this.Price = Price;
            
            IsValid = false;
            do
            {
                
                // Inform the user to enter the product's quantity
                Console.Write("Enter the product's quantity: ");

                if (int.TryParse(Console.ReadLine(), out Quantity))
                {
                    IsValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an intger number.");
                    
                }
            } while (!IsValid);
            this.Quantity = Quantity;
        }

    }
}
