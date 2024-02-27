using System;
using System.Text;


namespace Ex03.ConsoleUI
{
    class ConsoleUI
    {
        // everywhere the UI will need this obj, so making it global
        public static Ex03.GarageLogic.GarageLogic garage;

        public static void Main()
        {
            Console.WriteLine("Welcome to Ex03 - Garage Manger");
            printCoolTitle();
            printMenu();

            // create the Garage
            garage = new Ex03.GarageLogic.GarageLogic();

            Console.WriteLine("which option you want:");
            string input = getValidInput(isValidInputForStartMenu);

            while (input != "8")
            {
                directToWantedAction(input);

                Console.WriteLine("Ended action");
                Console.WriteLine();

                printMenu();
                Console.WriteLine("which option you want:");

                input = getValidInput(isValidInputForStartMenu);
            }

            Console.WriteLine("press 'Enter' to close the window.");
            Console.ReadLine();
        }

        private static void printCoolTitle()
        {
            Console.WriteLine(@"
      ________                                        _____                                      
     /  _____/_____ ____________     ____   ____     /     \ _____    ____    ____   ___________ 
    /   \  ___\__  \\_  __ \__  \   / ___\_/ __ \   /  \ /  \\__  \  /    \  / ___\_/ __ \_  __ \
    \    \_\  \/ __ \|  | \// __ \_/ /_/  >  ___/  /    Y    \/ __ \|   |  \/ /_/  >  ___/|  | \/
     \______  (____  /__|  (____  /\___  / \___  > \____|__  (____  /___|  /\___  / \___  >__|   
            \/     \/           \//_____/      \/          \/     \/     \//_____/      \/       
            ");
        }

        private static void printMenu()
        {
            Console.WriteLine("1 - Enter a new vehicle");
            Console.WriteLine("2 - Show all the vehicles that are in the Garage"); //filter by condotion
            Console.WriteLine("3 - Change a specific vehicle condition");
            Console.WriteLine("4 - Inflate wheels to max of a specific vehicle");
            Console.WriteLine("5 - Fill fuel for a specific vehicle");
            Console.WriteLine("6 - Charge battery for a specific vehicle");
            Console.WriteLine("7 - Show full stats of a specific vehicle");
            Console.WriteLine("8 - Exit Garage Manger");
        }

        // --------------------------------------- ACTIONS ----------------------------------------------------------------------

        private static void directToWantedAction(string i_WantedAction)
        {
            switch (i_WantedAction)
            {
                case "1": // Enter a new vehicle
                    actionOneEnterANewVehicle();
                    break;

                case "2": // Show all the vehicles that are in the Garage
                    actionTwoShowAllVehiclesInGarage();
                    break;

                case "3": // Change a specific vehicle condition
                    actionThreeChangeVehicleConditione();
                    break;

                case "4": // Inflate wheels to max of a specific vehicle
                    actionFourInflateWheelsToMax();
                    break;

                case "5": // Fill fuel for a specific vehicle
                    actionFiveFillFuel();
                    break;

                case "6": // Charge battery for a specific vehicle
                    actionSixChargeBattery();
                    break;

                case "7": // Show full stats of a specific vehicle
                    actionSevenShowFullStatsOfASpecificVehicle();
                    break;

                default: // "8"
                    break;
            }
        }

        private static string getValidLicenseNumberInput()
        {
            Console.WriteLine("enter the License Number for the vehicle:");
            string input = getValidInput(Temporary_NEED_TO_CHANGE);//checkIfValidLicenseNumber
            return input;
        }

        // -------- 1
        private static void actionOneEnterANewVehicle()
        {
            string licenseNumber = getValidLicenseNumberInput();

            if (garage.VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                Console.WriteLine("vehicle exits, changeing condition to 'in repair'."); // del later
                // change condition to "in repair"
                garage.VehiclesInGarage[licenseNumber].condition = "in repair";
            }
            else
            {
                Console.WriteLine("vehicle is not in the garage");
                // make new vehicle
                Console.WriteLine("enter the stats of the new vehicle");
                Console.WriteLine(@"
A garage can only handle vehicles with certain details.
To make it easier to enter details, say which of the following models is the same as your car
Then enter the additional details that are specific to your vehicle, such as the owner's name");
                Console.WriteLine("here:");
                foreach (string str in garage.ourgaragevehacledisciption)
                {
                    Console.WriteLine(str);
                }
                //PrintDictionaryVehiclesTheGarageCanHandle();

                string inputModalName = Console.ReadLine();
                //garage.VehiclesTheGarageCanHandle[inputModalName];

                //get rest of info for new vehicle

            }
        }

        private static void PrintDictionaryVehiclesTheGarageCanHandle()
        {
            StringBuilder singleVehicle = new StringBuilder();

            foreach (string inputModalName in garage.VehiclesTheGarageCanHandle.Keys)
            {
                singleVehicle.Append("Vehicle type: " + garage.VehiclesTheGarageCanHandle[inputModalName].ModelName);
                singleVehicle.Append(", NumberOfWheels: " + garage.VehiclesTheGarageCanHandle[inputModalName].NumberOfWheels);
                singleVehicle.Append(", airPmax: " + garage.VehiclesTheGarageCanHandle[inputModalName].GetMaxAirPressure());
                singleVehicle.Append(", fuelType: / battryMaxTime: " + garage.VehiclesTheGarageCanHandle[inputModalName].NumberOfWheels);
                singleVehicle.Append(", fuelTank: / non: " + garage.VehiclesTheGarageCanHandle[inputModalName].NumberOfWheels);

                Console.WriteLine(singleVehicle.ToString());
                singleVehicle.Clear();
            }
        }

        // -------- 2
        private static void actionTwoShowAllVehiclesInGarage()
        {
            // need to fillter by condition
            Console.WriteLine("enter the condition");
            string input = getValidInput(Temporary_NEED_TO_CHANGE);

            foreach (string key in garage.VehiclesInGarage.Keys)
            {
                if (garage.VehiclesInGarage[key].condition == input)
                {
                    Console.WriteLine(key);
                }
                //Console.WriteLine(key);
            }
        }

        // -------- 3
        private static void actionThreeChangeVehicleConditione()
        {
            string licenseNumber = getValidLicenseNumberInput();
            string newCondition;

            if (garage.VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                Console.WriteLine("enter the new condition for the vehicle:");
                newCondition = getValidInput(Temporary_NEED_TO_CHANGE);//checkIfValidCondition
                garage.VehiclesInGarage[licenseNumber].condition = newCondition;
            }
            else
            {
                Console.WriteLine("vehicle is not in the garage, exiting to menu.");
            }
        }

        // -------- 4
        private static void actionFourInflateWheelsToMax()
        {
            string licenseNumber = getValidLicenseNumberInput();

            if (garage.VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                Console.WriteLine("vehicle is in the garage"); // del later
                garage.VehiclesInGarage[licenseNumber].FillWheelsToMax();
            }
            else
            {
                Console.WriteLine("vehicle is not in the garage, exiting to menu.");
            }
        }

        // -------- 5
        private static void actionFiveFillFuel()
        {
            string licenseNumber = getValidLicenseNumberInput();

            if (garage.VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                Console.WriteLine("vehicle is in the garage"); // del later
                /*
                string enrgeyType = garage.VehiclesInGarage[licenseNumber].whichEnergyType();
                if(enrgeyType == "fuel")
                {
                    garage.VehiclesInGarage[licenseNumber].fillFuel();
                }
                else
                {
                    Console.WriteLine("vehicle is battry type and can not be filled with fuel, exiting to menu.");
                }
                */
            }
            else
            {
                Console.WriteLine("vehicle is not in the garage, exiting to menu.");
            }
        }

        // -------- 6
        private static void actionSixChargeBattery()
        {
            string licenseNumber = getValidLicenseNumberInput();

            if (garage.VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                Console.WriteLine("vehicle is in the garage"); // del later
                /*
                string enrgeyType = garage.VehiclesInGarage[licenseNumber].whichEnergyType();
                if(enrgeyType == "fuel")
                {
                    Console.WriteLine("vehicle is fuel type and can not be charged, exiting to menu.");
                }
                else
                {
                    garage.VehiclesInGarage[licenseNumber].charge();
                }
                */
            }
            else
            {
                Console.WriteLine("vehicle is not in the garage, exiting to menu.");
            }
        }

        // -------- 7
        private static void actionSevenShowFullStatsOfASpecificVehicle()
        {
            string licenseNumber = getValidLicenseNumberInput();

            if (garage.VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                Console.WriteLine("vehicle is in the garage"); // del later

                Console.WriteLine("licenseNumber:{0}", licenseNumber);
                Console.WriteLine("model name:{0}", garage.VehiclesInGarage[licenseNumber].ModelName);
                Console.WriteLine("owners name:{0}", garage.VehiclesInGarage[licenseNumber].ownersName);
                Console.WriteLine("status:{0}", garage.VehiclesInGarage[licenseNumber].condition);

                for (int i = 0; i < garage.VehiclesInGarage[licenseNumber].CollectionOfWheels.Length; i++)
                {
                    Console.WriteLine("wheel {1}:");
                    Console.WriteLine("wheel pressure:{0}", garage.VehiclesInGarage[licenseNumber].CollectionOfWheels[i].CurrentAirPressure);
                    Console.WriteLine("menufacturere name:{0}", garage.VehiclesInGarage[licenseNumber].CollectionOfWheels[i].manufacturerName);
                }
                Console.WriteLine("energy type:needs to creat the enum");
                Console.WriteLine("amount of energy:enum");

                foreach (var atr in garage.VehiclesInGarage[licenseNumber].uniqinformation)
                {

                    Console.WriteLine(atr.Key + atr.Value);
                }

            }
            else
            {
                Console.WriteLine("vehicle is not in the garage, exiting to menu.");
            }
        }

        // ---------------------------- CHECK INPUT ----------------------------------------------------------------------------
        // Exception
        // FormatException
        //     throw when the input is invalid on a 'prising' level, like input = 'a' when it need to be a number.
        // ArgumentException
        //     throw when the input is invalid on a logic level, like entering the worng fuel type.
        // ValueOutOfRangeException
        //     throw when the input is invalid on a range level, like input > maxAirPressure

        public delegate bool CheckIsInputValid(string i_input, out string i_invalidmassege);

        private static string getValidInput(CheckIsInputValid checkFunction)
        {
            string input = Console.ReadLine();
            string inValidMassage = "defult";

            while (checkFunction(input, out inValidMassage))
            {
                Console.WriteLine("invalid input - " + inValidMassage);
                Console.WriteLine("enter the input again: ");
                input = Console.ReadLine();
            }

            return input;
        }

        public static bool isValidInputForStartMenu(string i_input, out string i_invalidmassege)
        {
            i_invalidmassege = "defult";
            bool result = false;

            if (int.TryParse(i_input, out int inputAsint))
            {
                if (inputAsint > 8 && inputAsint < 1)
                {
                    i_invalidmassege = "can only enter a number from 1 to 8";
                }
                else
                {
                    result = true;
                    i_invalidmassege = "valid";
                }
            }
            else
            {
                i_invalidmassege = "not a number";
            }

            return result;
        }

        public static bool isValidInputForLicenseNumber(string i_input, out string i_invalidmassege)
        {
            i_invalidmassege = "defult";
            bool result = false;

            if (int.TryParse(i_input, out int inputAsint))
            {
                if (inputAsint > 8 && inputAsint < 1)
                {
                    i_invalidmassege = "can only enter a number from 1 to 8";
                }
                else
                {
                    result = true;
                    i_invalidmassege = "valid";
                }
            }
            else
            {
                i_invalidmassege = "not a number";
            }

            return result;
        }

        public static bool IsPercentageOfEnergyRemainingUpTo100(string PercentageOfEnergyRemaining, out string invalidmassege)
        {
            bool PercentageOfEnergygood = false;
            invalidmassege = "this is to much precentege";
            int numberOfEnergy = int.Parse(PercentageOfEnergyRemaining);
            if (numberOfEnergy > 0 && numberOfEnergy <= 100)
            {
                PercentageOfEnergygood = true;
            }

            return PercentageOfEnergygood;
        }

        public static bool IsUpTo10Cherecters(string LicenseNumber, out string invalidmassege)
        {
            bool liceenseNumberGood = false;
            invalidmassege = "too many cheracters";
            if (LicenseNumber.Length <= 10)
            {
                liceenseNumberGood = true;
            }
            return liceenseNumberGood;
        }

        public static bool Temporary_NEED_TO_CHANGE(string LicenseNumber, out string invalidmassege)
        {
            invalidmassege = "Temporary_NEED_TO_CHANGE";
            return true;
        }

    }
}
