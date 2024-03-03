using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
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
            bool IsInputCurrect = false;
            // create the Garage
            garage = new Ex03.GarageLogic.GarageLogic();

            Console.WriteLine("which option you want:");
            string input = getValidInputMenu(8);

            while (input != "8")
            {
                Console.WriteLine("--------------------------------------------------------------");
                directToWantedAction(input);

                Console.WriteLine("Ended action");
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine();

                printMenu();
                Console.WriteLine("which option you want:");
                input = getValidInputMenu(8);
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
            Console.WriteLine("2 - Show all the vehicles license number that are in the Garage"); //filter by condotion
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

        // -------- 1 - V
        private static void actionOneEnterANewVehicle()
        {
            Console.WriteLine("enter the License Number for the vehicle:");
            string licenseNumber = Console.ReadLine(); //getValidLicenseNumberInput();

            if (garage.VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                Console.WriteLine("vehicle exits, changeing condition to 'in repair'."); // del later
                // change condition to "in repair"
                //garage.VehiclesInGarage[licenseNumber].condition = "in repair";
                garage.VehiclesInGarage[licenseNumber].Condition = ConditionInGarage.InRepair;
            }
            else
            {
                Console.WriteLine("vehicle is not in the garage");
                Console.WriteLine("enter the stats of the new vehicle");
                Console.WriteLine(@"A garage can only handle vehicles with certain details.
To make it easier to enter details, say which of the following models is the same as your vehicle
Then enter the additional details that are specific to your vehicle, such as the owner's name");
                Console.WriteLine("here:");
                // print all the options
                foreach (string str in garage.ourGarageVehacleDisciption)
                {
                    Console.WriteLine(str);
                }

                // get input: the type he wants
                string inputReadyModalNumber = Console.ReadLine();

                // build the vehicle with just the info from GarageCanHandle
                garage.creattvehicle(licenseNumber, inputReadyModalNumber);

                // now we need to enter the rest ditails
                // ~~~ model name ~~~~~~~~~~~~~~~~~~~~~~~~
                Console.WriteLine("pleas enter your vehicle modle name:");
                string inputModalName = Console.ReadLine();
                garage.VehiclesInGarage[licenseNumber].ModelName = inputModalName;

                // ~~~ % of energy ~~~~~~~~~~~~~~~~~~~~~~~~
                string energytype;
                if (garage.VehiclesInGarage[licenseNumber].fuelInformation == null)
                {
                    energytype = "electricity in houres";
                }
                else
                {
                    energytype = "gaselin in liters";
                }
                bool canStartEnergyAmount = false;
                while (canStartEnergyAmount == false)
                {
                    Console.WriteLine("how much {0} does your vehicle have?", energytype);

                    string inputRestartEnergy = Console.ReadLine();
                    float energyAmountFloat;
                    float.TryParse(inputRestartEnergy, out energyAmountFloat);
                    try
                    {

                        garage.RestarteEnergyAmaunt(energyAmountFloat, licenseNumber);
                        canStartEnergyAmount = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message); //Console.WriteLine(ex.ToString());
                    }
                }



                // ~~~ get owners name ~~~~~~~~~~~~~~~~~~~~~~~~
                Console.WriteLine("pleas enter the owner's name:");
                string inputOwnerName = Console.ReadLine();
                garage.VehiclesInGarage[licenseNumber].ownersName = inputOwnerName;
                // ~~~ get owners phone ~~~~~~~~~~~~~~~~~~~~~~~~

                Console.WriteLine("pleas enter the owner's phone number:");
                string inputOwnerPhone = Console.ReadLine();
                garage.VehiclesInGarage[licenseNumber].ownersPhoneNumber = inputOwnerPhone;

                // ~~~ get uniqe info for new vehicle ~~~~~~~~~~~~~~~~~~~~~~~~
                askUniqueQ(licenseNumber, inputReadyModalNumber);

                // ~~~ every wheel ~~~~~~~~~~~~~~~~~~~~~~~~
                askEveryWheel(licenseNumber, inputReadyModalNumber);

            }
        }

        private static void askUniqueQ(string licenseNumber, string UsrerInput)
        {
            List<UniqueQuestion> vehicleq = garage.getInitOfQuestions(licenseNumber);
            string Answer;
            int AnswerNumber;
            List<string> Answers = new List<string>(); //"1" "bil" "2" "463543"

            foreach (UniqueQuestion question in vehicleq)
            {
                if (question.TypeAnswer == 1 || question.TypeAnswer == 2)
                { // input need to be in range from min to max, WHOLE Number [1,2,3,4...]
                    Console.WriteLine(question.Question);

                    Answer = Console.ReadLine();
                    int.TryParse(Answer, out AnswerNumber);

                    while (!int.TryParse(Answer, out AnswerNumber) || AnswerNumber > question.Max || AnswerNumber < question.Min)
                    {
                        Console.WriteLine(question.Question);
                        Answer = Console.ReadLine();
                        int.TryParse(Answer, out AnswerNumber);
                    }

                    Answers.Add(Answer);
                }
                else if (question.TypeAnswer == 2)
                { // input need to be in range from min to max, LINER Number [0, 0.5, 1, 1.4, ...., 5.7 ,... PositiveInfinity]
                    Answer = Console.ReadLine();
                    int.TryParse(Answer, out AnswerNumber);

                    while (AnswerNumber > question.Max || AnswerNumber < question.Min)
                    {
                        Console.WriteLine(question.Question);
                        Answer = Console.ReadLine();
                        //int.TryParse(Answer, out AnswerNumber);
                    }

                    Answers.Add(Answer);
                }
                else
                { //input is STRING
                    //try catch input
                    Console.WriteLine(question.Question);
                    Answer = Console.ReadLine();
                    Answers.Add(Answer);
                }
            }

            garage.SetUnqiue(licenseNumber, UsrerInput, Answers);
        }

        private static void askEveryWheel(string licenseNumber, string inputReadyModalNumber)
        {
            int numberOfWheels = garage.VehiclesInGarage[licenseNumber].NumberOfWheels;
            Console.WriteLine("you have {0} wheels", numberOfWheels.ToString());
            Console.WriteLine("You can enter the current wheel pressure once and it will be implied to all wheels, enter 1 to do so OR enter 2 to enter each wheel");
            string input = Console.ReadLine();
            int howManyWheelsToInput = 1;

            if (input == "2")
            {
                howManyWheelsToInput = numberOfWheels;
            }

            string inputWheelAirPressure;
            string inputWheelName;
            string[] menufactursnames = new string[numberOfWheels];
            float[] currentAirPressurs = new float[numberOfWheels];

            // going over every wheel
            for (int curentWheel = 0; curentWheel < howManyWheelsToInput; curentWheel++)
            {
                Console.WriteLine("for wheel {0}:", curentWheel + 1);
                Console.WriteLine("enter wheel menufacturs name:");
                inputWheelName = Console.ReadLine();
                menufactursnames[curentWheel] = inputWheelName;
                Console.WriteLine("enter wheel Air Pressure:");
                inputWheelAirPressure = Console.ReadLine();
                currentAirPressurs[curentWheel] = float.Parse(inputWheelAirPressure);
            }

            if (input == "1")
            {
                for (int curentWheel = 1; curentWheel < numberOfWheels; curentWheel++)
                {
                    menufactursnames[curentWheel] = menufactursnames[0];
                    currentAirPressurs[curentWheel] = currentAirPressurs[0];
                }
            }

            // get MaxCarWheelsAirPressure
            //float MaxCarWheelsAirPressure = garage.VehiclesInGarage[licenseNumber].GetMaxAirPressure();

            // send the list and make the wheels
            garage.GenaraitWheelsByCarType(licenseNumber, menufactursnames, currentAirPressurs, inputReadyModalNumber);
        }

        // -------- 2 - V
        private static void actionTwoShowAllVehiclesInGarage()
        {
            // need to fillter by condition
            Console.WriteLine("enter the condition: 1-in_repair 2-fixed 3-paid 4-no_filtter");
            string input = getValidInputMenu(4);
            ConditionInGarage conditionToFillterBy;

            switch (input) //["in repair", "fixed", "paid"]
            {
                case "1": // "in repair"
                    conditionToFillterBy = ConditionInGarage.InRepair;
                    break;
                case "2": // "fixed"
                    conditionToFillterBy = ConditionInGarage.Fixed;
                    break;
                case "3": // "paid"
                    conditionToFillterBy = ConditionInGarage.Paid;
                    break;
                default: // no filter
                    conditionToFillterBy = ConditionInGarage.None;
                    break;
            }
            Console.WriteLine("List of License Number:");
            foreach (string key in garage.VehiclesInGarage.Keys)
            {
                if (conditionToFillterBy is ConditionInGarage.None || garage.VehiclesInGarage[key].Condition == conditionToFillterBy)
                {
                    //Console.Write(key +", ");
                    Console.WriteLine(key);
                }
            }
            Console.WriteLine("end of list.");
        }

        // -------- 3 - V
        private static void actionThreeChangeVehicleConditione()
        {
            Console.WriteLine("enter the License Number for the vehicle:");
            string licenseNumber = Console.ReadLine(); //getValidLicenseNumberInput();
            string newCondition;

            if (garage.VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                Console.WriteLine("enter the new condition for the vehicle: 1-in_repair 2-fixed 3-paid:");
                newCondition = getValidInputMenu(3);//checkIfValidCondition
                ConditionInGarage conditionToFillterBy;

                switch (newCondition) //["in repair", "fixed", "paid"]
                {
                    case "1": // "in repair"
                        //conditionToFillterBy = "in repair";
                        conditionToFillterBy = ConditionInGarage.InRepair;
                        break;
                    case "2": // "fixed"
                        //conditionToFillterBy = "fixed";
                        conditionToFillterBy = ConditionInGarage.Fixed;
                        break;
                    case "3": // "paid"
                        //conditionToFillterBy = "paid";
                        conditionToFillterBy = ConditionInGarage.Paid;
                        break;
                    default:
                        //conditionToFillterBy = "in repair";
                        conditionToFillterBy = ConditionInGarage.InRepair;
                        break;
                }

                garage.VehiclesInGarage[licenseNumber].Condition = conditionToFillterBy;
                Console.WriteLine("Changed " + licenseNumber + " condition to " + conditionToFillterBy.ToString());
            }
            else
            {
                Console.WriteLine("vehicle is not in the garage, exiting to menu.");
            }
        }

        // -------- 4 - V
        private static void actionFourInflateWheelsToMax()
        {
            Console.WriteLine("enter the License Number for the vehicle:");
            string licenseNumber = Console.ReadLine();

            if (garage.VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                //Console.WriteLine("vehicle is in the garage"); // del later
                garage.VehiclesInGarage[licenseNumber].FillWheelsToMax();
                Console.WriteLine("Filled " + licenseNumber + " wheels to max.");
            }
            else
            {
                Console.WriteLine("vehicle is not in the garage, exiting to menu.");
            }
        }

        // -------- 5 - V
        private static void actionFiveFillFuel()
        {
            Console.WriteLine("enter the License Number for the vehicle:");
            string licenseNumber = Console.ReadLine();

            if (garage.VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                if (garage.VehiclesInGarage[licenseNumber].fuelInformation == null)
                {
                    Console.WriteLine("vehicle is electric can not accept fuel, exiting to menu.");
                }
                else
                {
                    bool fuelmatches = false;

                    while (fuelmatches == false)
                    {
                        Console.WriteLine(garage.VehiclesInGarage[licenseNumber].fuelInformation.typesOfFuel.Question);
                        string fuelTypeInput = Console.ReadLine();
                        int fuelTypeChoosen;
                        int.TryParse(fuelTypeInput, out fuelTypeChoosen);

                        try
                        {
                            garage.doesFuelMatches(licenseNumber, fuelTypeChoosen);
                            fuelmatches = true;
                            Console.WriteLine("how much wuld you like to fill?");
                            string amountOfFuel = Console.ReadLine();
                            try
                            {
                                garage.VehiclesInGarage[licenseNumber].fuelInformation.FillFuel(float.Parse(amountOfFuel));
                                Console.WriteLine("fuel has been filled , exiting to menu.");
                            }
                            catch (Exception ex)
                            {
                                //Console.WriteLine(ex.ToString());
                                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);

                        }
                    }

                }
            }
            else
            {
                Console.WriteLine("vehicle is not in the garage, exiting to menu.");
            }
        }

        // -------- 6 - V
        private static void actionSixChargeBattery()
        {
            Console.WriteLine("enter the License Number for the vehicle:");
            string licenseNumber = Console.ReadLine();

            if (garage.VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                if (garage.VehiclesInGarage[licenseNumber].ElectricInformation == null)
                {
                    Console.WriteLine("vehicle is fuel based can not accept electricty, exiting to menu.");
                }
                else
                {
                    Console.WriteLine("Enter how many min you want to charge the battry:");
                    string inputHowManyMinToCharge = Console.ReadLine();
                    try
                    {
                        garage.VehiclesInGarage[licenseNumber].ElectricInformation.CharageBattryWithAdditionalMin(float.Parse(inputHowManyMinToCharge));
                        Console.WriteLine("Battry has been charged , exiting to menu.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
                    }

                }
            }
            else
            {
                Console.WriteLine("vehicle is not in the garage, exiting to menu.");
            }
        }

        // -------- 7 - V
        private static void actionSevenShowFullStatsOfASpecificVehicle()
        {
            Console.WriteLine("enter the License Number for the vehicle:");
            string licenseNumber = Console.ReadLine();

            if (garage.VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                Console.WriteLine("licenseNumber: {0}", licenseNumber);
                Console.WriteLine("model name: {0}", garage.VehiclesInGarage[licenseNumber].ModelName);
                Console.WriteLine("owners name: {0}", garage.VehiclesInGarage[licenseNumber].ownersName);
                Console.WriteLine("owners phone number: {0}", garage.VehiclesInGarage[licenseNumber].ownersPhoneNumber);
                Console.WriteLine("condition: {0}", garage.VehiclesInGarage[licenseNumber].Condition.ToString());

                for (int i = 0; i < garage.VehiclesInGarage[licenseNumber].CollectionOfWheels.Length; i++)
                {
                    Console.WriteLine("wheel {0}:", i + 1);
                    Console.WriteLine("wheel pressure: {0}", garage.VehiclesInGarage[licenseNumber].CollectionOfWheels[i].CurrentAirPressure);
                    Console.WriteLine("menufacturere name: {0}", garage.VehiclesInGarage[licenseNumber].CollectionOfWheels[i].manufacturerName);
                }

                if (garage.VehiclesInGarage[licenseNumber].fuelInformation == null)
                {
                    Console.WriteLine("energy type:electricity");
                }
                else
                {
                    Console.WriteLine("energy type:{0} :{1}", garage.VehiclesInGarage[licenseNumber].TypeOfEnergy,
                        garage.VehiclesInGarage[licenseNumber].fuelInformation.TypeOfFuelForOurVehicle);
                    Console.WriteLine("amount of energy:{0}", garage.VehiclesInGarage[licenseNumber].fuelInformation.CorrentAmountOfFuel);

                }

                // CAR: Color, numberDoors
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

        private static string getValidInputMenu(int max)
        {
            string input = Console.ReadLine();
            bool isInputInValid = false;

            while (isInputInValid == false)
            {
                try
                {
                    garage.CheckInValueForMenu(input, 1, max);
                    isInputInValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
                    Console.WriteLine("enter the input again: ");
                    input = Console.ReadLine();
                }
            }

            return input;           
        }

        //public delegate bool CheckIsInputValid(string i_input, out string i_invalidmassege);

        //public static bool isValidInputForStartMenu(string i_input, out string i_invalidmassege)
        //{
        //    i_invalidmassege = "defult";
        //    bool result = false;

        //    if (int.TryParse(i_input, out int inputAsint))
        //    {
        //        if (inputAsint > 8 && inputAsint < 1)
        //        {
        //            i_invalidmassege = "can only enter a number from 1 to 8";
        //        }
        //        else
        //        {
        //            result = true;
        //            i_invalidmassege = "valid";
        //        }
        //    }
        //    else
        //    {
        //        i_invalidmassege = "not a number";

        //    }

        //    return result;
        //}

        //public static bool Temporary_NEED_TO_CHANGE(string LicenseNumber, out string invalidmassege)
        //{
        //    invalidmassege = "Temporary_NEED_TO_CHANGE";
        //    return true;
        //}

        //public static bool isValidInputForLicenseNumber(string i_input, out string i_invalidmassege)
        //{
        //    i_invalidmassege = "defult";
        //    bool result = false;

        //    if (int.TryParse(i_input, out int inputAsint))
        //    {
        //        if (inputAsint > 8 && inputAsint < 1)
        //        {
        //            i_invalidmassege = "can only enter a number from 1 to 8";
        //        }
        //        else
        //        {
        //            result = true;
        //            i_invalidmassege = "valid";
        //        }
        //    }
        //    else
        //    {
        //        i_invalidmassege = "not a number";
        //    }

        //    return result;
        //}

        //public static bool IsPercentageOfEnergyRemainingUpTo100(string PercentageOfEnergyRemaining, out string invalidmassege)
        //{
        //    bool PercentageOfEnergygood = false;
        //    invalidmassege = "this is to much precentege";
        //    int numberOfEnergy = int.Parse(PercentageOfEnergyRemaining);
        //    if (numberOfEnergy > 0 && numberOfEnergy <= 100)
        //    {
        //        PercentageOfEnergygood = true;
        //    }

        //    return PercentageOfEnergygood;
        //}

        //public static bool IsUpTo10Cherecters(string LicenseNumber, out string invalidmassege)
        //{
        //    bool liceenseNumberGood = false;
        //    invalidmassege = "too many cheracters";
        //    if (LicenseNumber.Length <= 10)
        //    {
        //        liceenseNumberGood = true;
        //    }
        //    return liceenseNumberGood;
        //}

        //private static string getValidLicenseNumberInput()
        //{
        //    Console.WriteLine("enter the License Number for the vehicle:");
        //    string input = getValidInput(Temporary_NEED_TO_CHANGE);//checkIfValidLicenseNumber
        //    return input;
        //}

    }
}
