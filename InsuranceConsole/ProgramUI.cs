using InsuranceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceConsole
{
    class ProgramUI
    {
        private InsuranceContentRepo _badgesRepo = new InsuranceContentRepo();

        public void RunInsurance()
        {
            EmployeeAccess();
            AdminMenu();
        }
        private void AdminMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine($"Please select an option: \n" +
                        $"1. Add a badge\n" +
                        $"2. Edit a badge\n" +
                        $"3. List all badge\n" +
                        $"4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Application closing. Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number...");
                        break;
                }

                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddBadge()
        {
            Console.Clear();
            InsuranceContent badge = new InsuranceContent();

            Console.WriteLine("Enter the badge number you wish to create:\n ");
            badge.BadgeID = int.Parse(Console.ReadLine());
            string userInput = "n";

            badge.DoorNames = new List<string>();
            do
            {
                Console.WriteLine("Enter the door number you wish to grant badge user access to:\n ");
                badge.DoorNames.Add(Console.ReadLine());

                Console.WriteLine("Add additional door access? (y/n)\n");
                userInput = Console.ReadLine().ToLower();
            }

            while (userInput.Equals("y"));
            _badgesRepo.AddBadge(badge);
        }
        private void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("Enter the badge number you wish to update:\n ");
            int badgeNum = int.Parse(Console.ReadLine());

            List<string> door = _badgesRepo.GetDoorList(badgeNum);

            if (door.Count > 0)
            {
                Console.WriteLine(badgeNum + " has access to " + string.Join("&", door));
            }
            else
            {
                Console.WriteLine(badgeNum + " no longer has access");
            }
            Console.WriteLine("Please select an option: \n" +
                "1. Remove door\n" +
                "2. Add door\n");
            string input = Console.ReadLine();

            if (input == "1")
            {
                if (door.Count > 0)
                {
                    Console.WriteLine("What door do you wish to remove? ");

                    string doorInput = Console.ReadLine().ToUpper();

                    _badgesRepo.RemoveDoorAccess(badgeNum, doorInput);

                    Console.WriteLine("Door access removed\n");
                    if (door.Count > 0)
                    {
                        Console.WriteLine(badgeNum + " has access to " + string.Join("&", door));
                    }
                    else
                    {
                        Console.WriteLine(badgeNum + " no longer has access");
                    }
                }

                else
                {
                    Console.WriteLine(badgeNum + " no longer has access");

                }
            }
            else if (input == "2")
            {
                Console.WriteLine("What door do you wish to remove?\n ");
                string doorInput = Console.ReadLine();

                _badgesRepo.AddDoorAccess(badgeNum, doorInput);
                Console.WriteLine("Door access has been added.\n");
                Console.WriteLine(badgeNum + " has access to " + string.Join(" & ", door));
            }
        }
        private void ListAllBadges()
        {
            Console.Clear();

            Dictionary<int, List<string>> listOfBadges = _badgesRepo.GetListOfBadges();
            Console.WriteLine("Badge #\t Access To");
            foreach (KeyValuePair<int, List<string>> entry in listOfBadges)
            {
                Console.WriteLine(entry.Key + "\t" + string.Join(",", entry.Value));
            }
        }
        private void EmployeeAccess()
        {
            InsuranceContent cafeManager = new InsuranceContent(75429, "A1".Split(',').ToList<string>(), "Cafe Manager");
            InsuranceContent claimsAgent = new InsuranceContent(54264, "B1, C3, A4".Split(',').ToList<string>(), "Claims Agent");
            InsuranceContent insuranceManager = new InsuranceContent(12576, "A1, B1, C3, A4, C5".Split(',').ToList<string>(), "Insurance Manager");

            _badgesRepo.AddBadge(cafeManager);
            _badgesRepo.AddBadge(claimsAgent);
            _badgesRepo.AddBadge(insuranceManager);
        }
    }
}
