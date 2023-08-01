using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleTables;

namespace InventoryManagementSystem
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        private string ValidName= @"^[A-Za-z]+$";


        public Product(string Name,double Price, int Quantity)
        {
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
        }
        public Product()
        {

        }
        public void Input()
        {   //Validating the input to ensure its correctness
            var IsValid = false;    
            
           
            do
            {
                var Name=(string)null;
                // Inform the user to enter the product's name
                Console.Write("Enter the product's name: ");
                Name = Console.ReadLine();
                if(Regex.IsMatch(Name,this.ValidName))
                {
                    IsValid = true;
                    this.Name = Name;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a Name contain Alpapitic character");
                }
            } while (!IsValid);
            IsValid = false;
            do
            {
                var Price=0.0;
                // Inform the user to enter the product's price
                Console.Write("Enter the product's price: ");
                if (double.TryParse(Console.ReadLine(), out Price))
                {
                    IsValid = true;
                    this.Price = Price;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a name containing only alphabetical characters.");
                }
            } while (!IsValid);
            IsValid = false;
            do
            {
                var Quantity=0;
                // Inform the user to enter the product's quantity
                Console.Write("Enter the product's quantity: ");
                if (int.TryParse(Console.ReadLine(), out Quantity))
                {
                    IsValid = true;
                    this.Quantity = Quantity;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an intger number.");
                }
            } while (!IsValid);
        }
    }
}
