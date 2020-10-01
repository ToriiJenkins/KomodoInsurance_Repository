using _02_Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Console
{
    class ProgramUI
    {
        private Claim_Repository _claimRepo = new Claim_Repository();

        public void Run()
        {
            SeedClaimsQueue();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                //Display options to user
                Console.WriteLine("Select a menu option:\n" +
                        "1. See all claims \n" +
                        "2. Take care of next claim \n" +
                        "3. Enter New Claim \n" +
                        "9. Exit \n");


                //Get user's input
                string input = Console.ReadLine();

                //evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //See all claims
                        DisplayClaims();
                        break;
                    case "2":
                        //Take care of next claim
                        HandleClaim();
                        break;
                    case "3":
                        //Enter new claim
                        EnterNewClaim();
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

        private void EnterNewClaim()
        {

            Console.Clear();
            Claim newClaim = new Claim();

            //Claim ID 
            Console.WriteLine("Enter the claim ID Number: ");
            string claimIDAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(claimIDAsString);

            //Claim Type
            /*  Car = 1,
                Home,
                Theft */

            Console.WriteLine("Enter the Claim Type Number \n" +
                "1. Car \n" +
                "2. Home \n" +
                "3. Theft \n");

            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newClaim.TypeOfClaim = (Claim.ClaimType)claimTypeAsInt;

            //Description
            Console.WriteLine("Enter the claim description: ");
            newClaim.Description = Console.ReadLine();

            //Claim Amount
            Console.WriteLine("Enter the Claim AMount: ");
            string amountAsString = Console.ReadLine();
            newClaim.ClaimAmount = double.Parse(amountAsString);

            //Date of Incident
            Console.WriteLine("Enter Date of Incident:");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Year (ex: 2009) : ");
            string yearAsString = Console.ReadLine();
            int yearAsInt = int.Parse(yearAsString);
            Console.WriteLine("Month (01-12) : ");
            string monthAsString = Console.ReadLine();
            int monthAsInt = int.Parse(monthAsString);
            Console.WriteLine("Day(01-31) : ");
            string dayAsString = Console.ReadLine();
            int dayAsInt = int.Parse(dayAsString);
            DateTime dayAndTime = new DateTime(yearAsInt, monthAsInt, dayAsInt);
            DateTime dateOnly = dayAndTime.Date;
            newClaim.DateOfIncident = dateOnly;

            //Date of Claim
            Console.WriteLine("Enter Date of Claim:");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Year (ex: 2009) : ");
            string claimYearAsString = Console.ReadLine();
            int claimYearAsInt = int.Parse(claimYearAsString);
            Console.WriteLine("Month (01-12) : ");
            string claimMonthAsString = Console.ReadLine();
            int claimMonthAsInt = int.Parse(claimMonthAsString);
            Console.WriteLine("Day(01-31) : ");
            string claimDayAsString = Console.ReadLine();
            int claimDayAsInt = int.Parse(claimDayAsString);
            dayAndTime = new DateTime(claimYearAsInt, claimMonthAsInt, claimDayAsInt);
            dateOnly = dayAndTime.Date;
            newClaim.DateOfClaim = dateOnly;

            //IsValid
            if((newClaim.DateOfClaim - newClaim.DateOfIncident).TotalDays <= 30)
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            _claimRepo.AddClaimToList(newClaim);

        }//end of Enter New Claim

        private void HandleClaim()
        {
            Queue<Claim> queueOfClaims = _claimRepo.GetClaimList();
            Claim nextClaim = queueOfClaims.Peek();

            Console.WriteLine("Here are the details for the next claim to be handled:");
            Console.WriteLine("Claim ID         : " + nextClaim.ClaimID);
            Console.WriteLine("Type             : " + nextClaim.TypeOfClaim);
            Console.WriteLine("Amount           : " + nextClaim.ClaimAmount);
            Console.WriteLine("Description      : " + nextClaim.Description);
            Console.WriteLine("Date of Incident : " + nextClaim.DateOfIncident);
            Console.WriteLine("Date of Claim    : " + nextClaim.DateOfClaim);
            Console.WriteLine("Is Valid ?       : " + nextClaim.IsValid);

            Console.Write("Do you want to deal with this claim now(y/n)? ");
            string reply = Console.ReadLine().ToLower();
            if (reply == "y")
            {
                Console.WriteLine("Thank you. The claim will be removed from the queue.");
                Console.WriteLine(" ");
                _claimRepo.RemoveClaimFromQueue(nextClaim.ClaimID);

            }
            else if(reply == "n")
            {
                Console.WriteLine("The claim will remian in the queue.");
                Console.WriteLine(" ");
            }
        }

        private void DisplayClaims()
        {
            Queue<Claim> queueOfClaims = _claimRepo.GetClaimList();

            Console.WriteLine("{0,-10} {1,-10} {2,-40} {3,-15} {4,-17} {5,-15} \n", "Claim ID", "Type", "Description", "Amount", "DateOfIncident", "DateOfClaim");

            foreach (Claim claim in queueOfClaims)
            {
                string inciDateOnly = claim.DateOfIncident.ToString("MM/dd/yyyy");
                string claimDateOnly = claim.DateOfIncident.ToString("MM/dd/yyyy");
                Console.WriteLine("{0,-10} {1,-10} {2,-40} {3,-15} {4,-17} {5,-20} \n", claim.ClaimID, claim.TypeOfClaim, claim.Description, claim.ClaimAmount,
                    inciDateOnly, claimDateOnly);
             
            }
        }

        public void SeedClaimsQueue()
        {
            Claim claim1 = new Claim(16678, Claim.ClaimType.Car, "Client sideswiped non-client", 2334.99, new DateTime(2019, 05, 24).Date, new DateTime(2019, 05, 27).Date, true);
            Claim claim2 = new Claim(15113, Claim.ClaimType.Theft, "Theft from auto at residence", 760.00, new DateTime(2020, 06, 01).Date, new DateTime(2020, 06, 07).Date, true);

            _claimRepo.AddClaimToList(claim1);
            _claimRepo.AddClaimToList(claim2);
        }


}//end of ProgramUI
}//end of namespace
