using System;
using System.Text.RegularExpressions;

namespace InventoryManagementSystem
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        private string ValidName= @"^[A-Za-z]+$";

        public Product(string Name,double price, int quantity)
        {
            this.Name = Name;
            this.Price = price;
            this.Quantity = quantity;
        }
        public void Input()
        {   //Validating the input to ensure its correctness
            bool IsValid = false;    
            do
            {
                string Name;
                // Inform the user to enter the product's name
                Console.Write("Enter the product's name: ");
                Name = Console.ReadLine();
                if(Regex.IsMatch(Name,this.ValidName))
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
                Double Price;
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
                int Quantity;
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
