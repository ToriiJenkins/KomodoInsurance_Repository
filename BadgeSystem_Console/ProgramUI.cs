using BadgeSystem_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeSystem_Console
{
   class ProgramUI
    {
        private Badge_Repository _badgeRepo = new Badge_Repository();

        public void Run()
        {
            SeedBadgeDitionary();
            Menu();

        }

        private void Menu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                //Display options to user
                Console.WriteLine("Komodo Insurance Security Admin");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Select menu option:\n" +
                        "1. Add a Badge      \n" +
                        "2. Edit a Badge     \n" +
                        "3. List all Badges  \n" +
                        "9. Exit \n");


                //Get user's input
                string input = Console.ReadLine();

                //evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Add a Badge
                        AddBadgeToDictionary();
                        break;
                    case "2":
                        //Edit Badge
                        EditBadge();
                        break;
                    case "3":
                        //List all Badges
                        DisplayAllBadges();
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
        }//Menue method

        private void AddBadgeToDictionary()
        {

            Console.Clear();
            Badge newBadge = new Badge();
            //List<string> doorList = new List<string>();
            newBadge.DoorList = new List<string>();
           

            //Badge ID 
            Console.WriteLine("Enter the Badge ID Number: ");
            string badgeIDAsString = Console.ReadLine();
            newBadge.BadgeID = int.Parse(badgeIDAsString);

            bool addAnotherDoor = true;
            int doorCount = 0;

            while (addAnotherDoor)
            {
                Console.Write("Grant badge# " + newBadge.BadgeID + " access to door: ");
                string input1 = Console.ReadLine();
                newBadge.DoorList.Add(input1);
                doorCount++;
                Console.Write("Add a door?(y or n): ");
                string input2 = Console.ReadLine();
                if (input2 == "y")
                {
                    addAnotherDoor = true;
                }
                else if (input2 == "n")
                {
                    addAnotherDoor = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid character.");
                    break;
                }
            }

            _badgeRepo.AddBadgeToDictionary(newBadge);

        }//end of Add Badge

        private void DisplayAllBadges()
        {
            Dictionary<int, Badge> _badgesList = _badgeRepo.GetBadgesList();
            Console.WriteLine("Badge #    Door Access");
            Console.WriteLine("-------------------------");
        
            foreach(KeyValuePair<int, Badge> badgePair in _badgesList)
            {
                
                Console.Write("{0,-15} ", badgePair.Key);
                for(int i=0; i < badgePair.Value.DoorList.Count; i++)
                {
                    Console.Write("    " + badgePair.Value.DoorList[i]);
                }
                Console.WriteLine("");
            }
        }

        private void EditBadge()
        {

            Dictionary<int, Badge> _badgesList = _badgeRepo.GetBadgesList();
            Badge_Repository _repo = _badgeRepo;

            Console.WriteLine("What is the badge number to be updated?: ");
            string input1AsString = Console.ReadLine();
            int badgeToUpdateID = int.Parse(input1AsString);

           

            if (_badgesList.ContainsKey(badgeToUpdateID))
            {
                Badge badgeToUpdate = _repo.GetBadgeByID(badgeToUpdateID);

                Console.WriteLine("Badge # " + badgeToUpdateID + " has acces to doors :");
                for (int i = 0; i < badgeToUpdate.DoorList.Count; i++)
                {
                    Console.Write("    " + badgeToUpdate.DoorList[i]);
                }
                Console.WriteLine("");
                Console.WriteLine("Please pick an option:");
                Console.WriteLine("1. Remove a door");
                Console.WriteLine("2. Add a door");
                string input2AsString = Console.ReadLine();
                int input2 = int.Parse(input2AsString);
                if (input2 == 1)
                {
                    Console.Write("Which door would you like to remove?   ");
                    string doorToRemove = Console.ReadLine();
                    //foreach()

                }


            }

            


        }
            

        public void SeedBadgeDitionary()
        {
            List<string> doorList1 = new List<string>() { "A1", "A3", "B7" };
            Badge badge1 = new Badge(1, doorList1, "John Dow");
            _badgeRepo.AddBadgeToDictionary(badge1);

            List<string> doorList2 = new List<string>() { "C5", "D7" };
            Badge badge2 = new Badge(2, doorList2, "Jill Fern");
            _badgeRepo.AddBadgeToDictionary(badge2);
        }

    }//end ProgramUI class
}// end namespace
