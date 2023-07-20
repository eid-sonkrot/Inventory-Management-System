using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inventory_Management_System
{
    internal class UserInterface
    {
        static void Main(string[] args)
        {

            Inventory inventory = new Inventory();
            while (true)
            {
                Console.WriteLine("Welcome to the Inventory Management System!");
                DisplayMenu();
                int choice = GetChoiceFromUser();
                switch (choice)
                {
                    case 1:
                        //  add a product to the inventorys
                        {
                            Product product = new Product();
                            product.Input();
                            Inventory.AddProduct( product);
                        }
                        
                        break;
                    case 2:
                        // display all products in the inventory
                        Inventory.DisplayProducts();
                        Console.WriteLine("Press any key to Back to Main Menu...");
                        Console.ReadKey(); // Waits for the user to press any key
                        break;
                    case 3:
                        // edit an existing product in the inventory
                        
                        break;
                    case 4:
                        //  remove a product from the inventory
                        break;
                    case 5:
                        //search for a product in the inventory
                        string name;
                        Console.WriteLine("Please enter the name of the product you want to search for:");
                        name = Console.ReadLine();
                        Inventory.FindProduct(name);
                        Console.WriteLine("Press any key to Back to Main Menu...");
                        Console.ReadKey(); // Waits for the user to press any key
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Exiting the Inventory Management System. Goodbye!");
                        System.Threading.Thread.Sleep(1000);
                        return;
                    
                        
                }
                Console.Clear();
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Add a product");
            Console.WriteLine("2. View all products");
            Console.WriteLine("3. Edit a product");
            Console.WriteLine("4. Delete a product");
            Console.WriteLine("5. Search for a product");
            Console.WriteLine("6. Exit");
        }

        static int GetChoiceFromUser()
        {
            Console.Write("Enter your choice (1-6): ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Inventory Management System!");
                DisplayMenu();
                Console.Write("Invalid input. Enter a valid choice (1-6): ");
                System.Threading.Thread.Sleep(1000);

            }
            return choice;
        }


    }
    
}
