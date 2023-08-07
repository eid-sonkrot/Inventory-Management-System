using System;

namespace InventoryManagementSystem
{
    public class UserInterface
    {
        static void Main(string[] args)
        {
            var userInterface = new UserInterface();
            
            while (true)
            {
                Console.WriteLine("Welcome to the Inventory Management System!");
                userInterface.DisplayMenu();
                var choice = userInterface.GetChoiceFromUser();
                userInterface.HandleInventoryAction(choice);
                Console.Clear();
            }
        }
        public void DisplayMenu()
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Add a product");
            Console.WriteLine("2. View all products");
            Console.WriteLine("3. Edit a product");
            Console.WriteLine("4. Delete a product");
            Console.WriteLine("5. Search for a product");
            Console.WriteLine("6. Exit");
        }
        public int GetChoiceFromUser()
        {
            Console.Write("Enter your choice (1-6): ");
            var choice =0;
            var isValidInput = int.TryParse(Console.ReadLine(), out  choice);
            while (!isValidInput || choice < 1 || choice > 6)
            {
                Console.Clear();
                Console.WriteLine("Invalid Input plz chose a number from (1-6)");
                Console.WriteLine("Welcome to the Inventory Management System!");
                DisplayMenu();
                Console.Write("Enter your choice (1-6): ");
                isValidInput = int.TryParse(Console.ReadLine(), out choice);
            }
            return choice;
        }
        public void HandleInventoryAction(int choice)
        {
            var inventory = new Inventory();

            switch (choice)
            {
                case 1:
                    //  add a product to the inventory
                    var product = new Product();
                    product.Input();
                    Inventory.AddProduct(product);
                    break;
                case 2:
                    // display all products in the inventory
                    break;
                case 3:
                    // edit an existing product in the inventory
                    break;
                case 4:
                    //  remove a product from the inventory
                    break;
                case 5:
                    //search for a product in the inventory
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("Exiting the Inventory Management System. Goodbye!");
                    System.Threading.Thread.Sleep(1000);
                    return;
            }
        }
    }
}