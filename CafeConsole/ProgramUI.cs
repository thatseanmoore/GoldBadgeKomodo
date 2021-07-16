using CafeRepo;
using System;
using System.Collections.Generic;

namespace CafeConsole
{
    class ProgramUI
    {
        private readonly MenuContentRepo _menuRepo = new MenuContentRepo();

        public void RunCafe()
        {
            SeedMenu();
            ManagerMenu();
        }
        private void ManagerMenu()
        {
            bool runMenu = true;
            while (runMenu)
            {
                Console.WriteLine("Please Select an Option:\n" +
                    "1. Create New Menu Item\n" +
                    "2. View All Menu Items\n" +
                    "3. View Menu Item by Meal Number\n" +
                    "4. Delete Menu Item by Meal Number\n" +
                    "5. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        DisplayAllMenuItems();
                        break;
                    case "3":
                        DisplayMenuItemsByNumber();
                        break;
                    case "4":
                        DeleteMenuItem();
                        break;
                    case "5":
                        Console.WriteLine("Program closing goodbye!");
                        runMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a choice 1-5.");
                        break;

                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Create new item
        private void CreateNewMenuItem()
        {
            Console.Clear();
            MenuContent newContent = new MenuContent();
            Console.WriteLine("Please enter new meal number");
            newContent.MealNumber = (MealNumber)int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter new meal name:");
            newContent.MealName = Console.ReadLine();
            Console.WriteLine("Please enter meal description:");
            newContent.MealDescription = Console.ReadLine();
            Console.WriteLine("Please enter meal ingredients:");
            newContent.MealIngredients = Console.ReadLine();
            Console.WriteLine("Please set meal price:");
            newContent.MealPrice = Console.ReadLine();
            _menuRepo.AddMenuContentToList(newContent);
        }
        private void DisplayAllMenuItems()
        {
            List<MenuContent> listOfContent = _menuRepo.GetMenuContentList();
            foreach(MenuContent content in listOfContent)
            {
                Console.WriteLine($"Number: {content.MealNumber}\n" +
                    $"Name: {content.MealName}\n" +
                    $"Description: {content.MealDescription}\n" +
                    $"Ingredients: {content.MealIngredients}\n" +
                    $"Price: {content.MealPrice}\n");
            }
        }
        private void DisplayMenuItemsByNumber()
        {
            Console.WriteLine("Enter the meal number you want want to see:");
            string mealNumber = Console.ReadLine();
            MenuContent content = _menuRepo.GetContentByMealNumber((MealNumber)int.Parse(mealNumber));
            if(content != null)
            {
                Console.WriteLine($"Number: {content.MealNumber}\n" +
                    $"Name: {content.MealName}\n" +
                    $"Description: {content.MealDescription}\n" +
                    $"Ingredients: {content.MealIngredients}\n" +
                    $"Price: {content.MealPrice}\n");
            }
            else
            {
                Console.WriteLine("Please enter valid meal number");
            }
        }
        private void DeleteMenuItem()
        {
            DisplayAllMenuItems();
            Console.WriteLine("Enter meal number you want to delete");
            string input = Console.ReadLine();
            bool wasDeleted = _menuRepo.RemoveMenuContentFromList((MealNumber)int.Parse(input));
            if (wasDeleted)
            {
                Console.WriteLine("Meal Number Successfully Deleted.");
            }
            else
            {
                Console.WriteLine("Error. Menu Item was not deleted.");
            }
        }
        private void SeedMenu()
        {
            MenuContent one = new MenuContent(MealNumber.One, "Number One", "Chicken Tendies & Fries", "Thick Solid Full Chicken Tendie, Ketchup, French Fries",
                "$11");
            _menuRepo.AddMenuContentToList(one);
        }

    }
}
