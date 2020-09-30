using Komodo_Insurance_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Komodo_Insurance_Console
{
    class ProgramUI
    {
        private Menu_Repository _menuRepo = new Menu_Repository();

        // Method that runs/starts the application
        public void Run()
        {
            SeedMealList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                //Display options to user
                Console.WriteLine("Select a menu option:\n" +
                        "1. Add Menu Item \n" +
                        "2. View Menu Items\n" +
                        //"3. View Menu Item by Meal Number \n" +      //for later use
                        "3. Remove Menu Item \n" +
                        "9.Exit \n");


                //Get user's input
                string input = Console.ReadLine();

                //evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Add Menu Item
                        AddMenuItem();
                        break;
                    case "2":
                        //View All Menu Options
                        DisplayMenuItems();
                        break;
                    //case "3":
                        //View Menu Item by Meal Number
                        //DisplayMenuItemByMealNumber();
                        //break;
                    case "3":
                        //Remove Menu Item
                        RemoveMenuItem();
                        break;
                    case "9":
                        //Exit
                        keepRunning = false;
                        Console.WriteLine("Goodbye.");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                } //Switch

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }//while keepRunning
        }//Menu method

        //Add menu item
        private void AddMenuItem()
        {
            Console.Clear();
            MenuItem newItem = new MenuItem();

            //Meal Number
            Console.WriteLine("Enter the meal number: ");
            string mealNumberAsString = Console.ReadLine();
            newItem.Meal_Number = int.Parse(mealNumberAsString);

            //Meal Name
            Console.WriteLine("Enter the meal name ");
            newItem.Meal_Name = Console.ReadLine();

            //Description
            Console.WriteLine("Enter the meal description: ");
            newItem.Description = Console.ReadLine();

            //Ingredients List
           
            string ingredient = "";
            
            while (ingredient != "end")
            {
               
                Console.WriteLine("Enter an ingrdient ('end' to complete list): ");
                ingredient = Console.ReadLine();
                if (ingredient != "end")
                {
                    newItem.IngredientsList.Add(ingredient);
                }

            }
            
            //Price
            Console.WriteLine("Enter the meal price: ");
            string priceAsString = Console.ReadLine();
            newItem.Price = double.Parse(priceAsString);

            _menuRepo.AddMenuItemToList(newItem);
        }

        //View menu items
        private void DisplayMenuItems()
        {
            List<MenuItem> listOfMItems = _menuRepo.GetMenuItemList();

            foreach(MenuItem item in listOfMItems)
            {
                Console.WriteLine("Meal #      : " + item.Meal_Number);
                Console.WriteLine("Meal        : " + item.Meal_Name);
                Console.WriteLine("Price       : " + item.Price);
                Console.WriteLine("Description : " + item.Description);
                Console.Write("Ingredients : ");
                List<string> ingredients = item.IngredientsList;
                foreach(string ingredient in ingredients)
                {
                    Console.Write(ingredient + "  ");
                }
                Console.WriteLine(" \n");
            }
        }

        //View menu item by meal number
        //private void DisplayMenuItemByMealNumber()
        //{
        //}

        //Remove menu item
        private void RemoveMenuItem()
        {
            Console.WriteLine("Please enter the number of the meal to remove:");
            string itemToRemoveString = Console.ReadLine();
            int itemToRemove = int.Parse(itemToRemoveString);

            _menuRepo.RemoveMenuItemFromList(itemToRemove);

        }

        public void SeedMealList()
        {
            MenuItem item = new MenuItem(1, "Burger Meal", "Burger Fries and a Drink", new List<string> { "burger", "fries", "drink" }, 3.99);
            MenuItem item2 = new MenuItem(2, "Potato Meal", "Baked Potato and a Drink", new List<string> { "Packed Spud", "drink" }, 2.99);
            _menuRepo.AddMenuItemToList(item);
            _menuRepo.AddMenuItemToList(item2);
        }

    }
}
