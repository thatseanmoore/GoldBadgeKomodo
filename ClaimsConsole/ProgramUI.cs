using ClaimsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsConsole
{
    class ProgramUI
    {
        private ClaimsContentRepo _claimsContentRepo = new ClaimsContentRepo();

        public void RunClaims()
        {
            SeedContent();
            ClaimsMenu();
        }
        private void ClaimsMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please Select an Option:\n" +
                    "1. Show all claims\n" +
                    "2. Begin next claim\n+" +
                    "3. Enter new claim\n" +
                    "4. Exit Program");

                string input = Console.ReadLine();
                
                switch (input)
                {
                    case "1":
                        DisplayAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Application closing. Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter an option 1-4.");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }

        }
        private void DisplayAllClaims()
        {
            Console.Clear();
            List<ClaimsContent> listofClaimsContent = _claimsContentRepo.GetClaimsContentsList();
            foreach (ClaimsContent content in listofClaimsContent)
            {
                Console.WriteLine($"ClaimID: {content.ClaimID}\n" +
                    $"Type: {content.TypeOfClaim}\n" +
                    $"Description: {content.ClaimDescription}\n" +
                    $"Amount: {content.ClaimAmount}\n" +
                    $"Incident date: {content.DateOfIncident}\n" +
                    $"Claim date: {content.DateOfClaim}\n" +
                    $"Claim is valid: {content.IsValid}\n" +
                    $"Claim is done: {content.ClaimIsComplete}\n");
            }
        }
        private void NextClaim()
        {
            Console.Clear();
            Console.WriteLine("Please enter the next claim you wish to complete");
            string nextClaim = Console.ReadLine();
            ClaimsContent content = _claimsContentRepo.GetClaimsContentByClaimID(nextClaim);
            Console.WriteLine($"ClaimID: {content.ClaimID}\n" +
                        $"Type: {content.TypeOfClaim}\n" +
                        $"Description: {content.ClaimDescription}\n" +
                        $"Amount: {content.ClaimAmount}\n" +
                        $"Incident date: {content.DateOfIncident}\n" +
                        $"Claim date: {content.DateOfClaim}\n" +
                        $"Claim is valid: {content.IsValid}\n" +
                        $"Claim is done: {content.ClaimIsComplete}\n");
            Console.WriteLine("Handle Claim Now? (Y/N)");
            string response = Console.ReadLine();
            response.ToLower();
            if(response == "y")
            {
                bool removeFromQueue = _claimsContentRepo.RemoveClaimContentFromList(nextClaim);
                if(removeFromQueue)
                {
                    Console.WriteLine("Claim removed from Queue.");
                }
                else
                {
                    Console.WriteLine("Error removing claim please try again");
                }
            }
            else if (response == "n")
            {
                ClaimsMenu();
            }
            else
            {
                Console.WriteLine("Please write Y or N:");
                string respond = Console.ReadLine();
                respond.ToLower();
                if (respond == "y")
                {
                    bool removeFromQueue = _claimsContentRepo.RemoveClaimContentFromList(nextClaim);
                    if (removeFromQueue)
                    {
                        Console.WriteLine("Claim removed from Queue.");
                    }
                    else
                    {
                        Console.WriteLine("Error removing claim please try again");
                    }
                }
                else if (respond == "n")
                {
                    ClaimsMenu();
                }
            }
        }
        private void NewClaim()
        {
            Console.Clear();
            ClaimsContent newContent = new ClaimsContent();

            Console.WriteLine("Please enter new claim ID number");
            newContent.ClaimID = Console.ReadLine();

            Console.WriteLine("Please enter claim type: 1 = car, 2 = home, 3 = theft");
            newContent.TypeOfClaim = (ClaimType)int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter claim description:");
            newContent.ClaimDescription = Console.ReadLine();

            Console.WriteLine("Enter claim amount:");
            newContent.ClaimAmount = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of the incident:");
            newContent.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of the claim:");
            newContent.DateOfClaim = DateTime.Parse(Console.ReadLine());

            ClaimsContent four = new ClaimsContent("4", newContent.TypeOfClaim, newContent.ClaimDescription, newContent.ClaimAmount, newContent.DateOfIncident,
                newContent.DateOfClaim, false, false);

            four.IsValid = IsClaimValid(four);

            _claimsContentRepo.AddClaimsContentToList(four);
        }

        private bool IsClaimValid(ClaimsContent content)
        {
            {
                int dateDiff = (content.DateOfClaim.Date - content.DateOfIncident.Date).Days;
                if (dateDiff <= 30)
                {
                    return true;
                }
            }
            return false;
        }
        private void SeedContent()
        {
            ClaimsContent one = new ClaimsContent("1", ClaimType.Car, "Accident on 465.", 400,
                DateTime.Parse("4 / 25 / 18"), DateTime.Parse("4 / 27 / 18"), false, false);
            ClaimsContent two = new ClaimsContent("2", ClaimType.Home, "House fire in kitchen.", 4000,
                DateTime.Parse("4 / 11 / 18"), DateTime.Parse("4 / 12 / 18"), false, false);
            ClaimsContent three = new ClaimsContent("3", ClaimType.Theft, "Stolen pancakes.", 4,
                DateTime.Parse("4 / 27 / 18"), DateTime.Parse("6 / 01 / 18"), false, true);

            one.IsValid = IsClaimValid(one);
            two.IsValid = IsClaimValid(two);
            three.IsValid = IsClaimValid(three);

            _claimsContentRepo.AddClaimsContentToList(one);
            _claimsContentRepo.AddClaimsContentToList(two);
            _claimsContentRepo.AddClaimsContentToList(three);

        }














    }
}
