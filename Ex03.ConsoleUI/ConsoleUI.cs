using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Ex03.ConsoleUI
{
    class ConsoleUI
    {
        // everywhere the UI will need this obj, so making it global
        public static Ex03.GarageLogic.GarageLogic garage;

        public static void Main()
        {
            Console.WriteLine("Welcome to Ex03 - Garage Manager");
            PrintCoolTitle();
            PrintMenu();
           
            // create the Garage
            garage = new Ex03.GarageLogic.GarageLogic();

            Console.WriteLine("Which option you want:");
            string input = getValidInputMenu(8);

            while (input != "8")
            {
                Console.WriteLine("--------------------------------------------------------------");
                directToWantedAction(input);

                Console.WriteLine("Action Ended.");
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine();

                PrintMenu();
                Console.WriteLine("Which option you want:");
                input = getValidInputMenu(8);
            }

            Console.WriteLine("Press 'Enter' to close the window.");
            Console.ReadLine();
        }

        private static void PrintCoolTitle()
        {
            Console.WriteLine(@"
  _______      ___      .______          ___       _______  _______    .___  ___.      ___      .__   __.      ___       _______  _______ .______      
 /  _____|    /   \     |   _  \        /   \     /  _____||   ____|   |   \/   |     /   \     |  \ |  |     /   \     /  _____||   ____||   _  \     
|  |  __     /  ^  \    |  |_)  |      /  ^  \   |  |  __  |  |__      |  \  /  |    /  ^  \    |   \|  |    /  ^  \   |  |  __  |  |__   |  |_)  |    
|  | |_ |   /  /_\  \   |      /      /  /_\  \  |  | |_ | |   __|     |  |\/|  |   /  /_\  \   |  . `  |   /  /_\  \  |  | |_ | |   __|  |      /     
|  |__| |  /  _____  \  |  |\  \----./  _____  \ |  |__| | |  |____    |  |  |  |  /  _____  \  |  |\   |  /  _____  \ |  |__| | |  |____ |  |\  \----.
 \______| /__/     \__\ | _| `._____/__/     \__\ \______| |_______|   |__|  |__| /__/     \__\ |__| \__| /__/     \__\ \______| |_______|| _| `._____|
                                                                                                                                                        ");
        }

        private static void PrintMenu()
        {
            Console.WriteLine("1 - Enter a new vehicle");
            Console.WriteLine("2 - Show all the vehicles license number that are in the Garage"); //filter by condotion
            Console.WriteLine("3 - Change a specific vehicle condition");
            Console.WriteLine("4 - Inflate wheels to max of a specific vehicle");
            Console.WriteLine("5 - Fill fuel for a specific vehicle");
            Console.WriteLine("6 - Charge battery for a specific vehicle");
            Console.WriteLine("7 - Show full stats of a specific vehicle");
            Console.WriteLine("8 - Exit Garage Manager");
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
                    Console.WriteLine("Exiting Garage Manager");
                    break;
            }
        }

        // -------- 1 - V
        private static void actionOneEnterANewVehicle()
        {
            Console.WriteLine("Enter the license number for the vehicle:");
            string licenseNumber = getValidInputString();// Console.ReadLine();

            if (garage.m_VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                Console.WriteLine("Vehicle exits, changed condition to 'In Repair'.");
                // change condition to "in repair"
                garage.m_VehiclesInGarage[licenseNumber].m_Condition = ConditionInGarage.InRepair;
            }
            else
            {
                Console.WriteLine("Vehicle is not in the garage.");
                Console.WriteLine("Enter the stats of the new vehicle.");
                // ~~~ get basic info from vehicles garage can handle, will save us the truble to get 4 values as inputs ~~~~~~~~~~~
                Console.WriteLine(@"A garage can only handle vehicles with certain details.
To make it easier to enter details, say which of the following models is the same as your vehicle
Then enter the additional details that are specific to your vehicle, such as the owner's name");
                Console.WriteLine("here:");
                // print all the options
                foreach (string str in garage.r_OurGarageVehacleDisciption)
                {
                    Console.WriteLine(str);
                }
                // get input: the type he wants
                bool isInputValid = false;
                string inputReadyModalNumber = Console.ReadLine();
                while (isInputValid == false)
                {
                    try
                    {
                        garage.CheckInValueForMenu(inputReadyModalNumber, 1, garage.r_OurGarageVehacleDisciption.Count);
                        isInputValid = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
                        inputReadyModalNumber = Console.ReadLine();
                    }
                }
                // build the vehicle with just the info from Garage Can Handle
                garage.CreateVehicle(licenseNumber, inputReadyModalNumber);

                // now we need to enter the rest ditails
                // ~~~ model name ~~~~~~~~~~~~~~~~~~~~~~~~
                Console.WriteLine("Please enter your vehicle modle name:");
                string inputModalName = getValidInputString(); //Console.ReadLine();
                garage.m_VehiclesInGarage[licenseNumber].m_ModelName = inputModalName;

                // ~~~ % of energy ~~~~~~~~~~~~~~~~~~~~~~~~
                string energytype;
                if (garage.m_VehiclesInGarage[licenseNumber].m_FuelInformation == null)
                {
                    energytype = "electricity in hours";
                }
                else
                {
                    energytype = "gaselin in liters";
                }

                bool canStartEnergyAmount = false;
                while (canStartEnergyAmount == false)
                {
                    Console.WriteLine("How much {0} does your vehicle have?", energytype);
                    try
                    {
                        string inputRestartEnergy = Console.ReadLine();

                        try
                        {
                            garage.RestartEnergyAmount(inputRestartEnergy, licenseNumber);
                            canStartEnergyAmount = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message); //Console.WriteLine(ex.ToString());
                        }
                    }
                    catch (Exception ex)
                    { 
                        Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
                    }
                }

                // ~~~ get owners name ~~~~~~~~~~~~~~~~~~~~~~~~
                Console.WriteLine("Please enter the owner's name:");
                string inputOwnerName = getValidInputString(); //Console.ReadLine();
                garage.m_VehiclesInGarage[licenseNumber].m_OwnersName = inputOwnerName;

                // ~~~ get owners phone ~~~~~~~~~~~~~~~~~~~~~~~~
                Console.WriteLine("Please enter the owner's phone number:");
                string inputOwnerPhone = getValidInputString(); //Console.ReadLine();
                garage.m_VehiclesInGarage[licenseNumber].m_OwnersPhoneNumber = inputOwnerPhone;

                // ~~~ get uniqe info for new vehicle ~~~~~~~~~~~~~~~~~~~~~~~~
                askUniqueQ(licenseNumber, inputReadyModalNumber);

                // ~~~ every wheel ~~~~~~~~~~~~~~~~~~~~~~~~
                askEveryWheel(licenseNumber, inputReadyModalNumber);

            }
        }

        private static void askUniqueQ(string i_LicenseNumber, string i_UserInput)
        {
            List<UniqueQuestion> vehicleq = garage.GetInitOfQuestions(i_LicenseNumber);
            string Answer;
            int AnswerNumber;
            float AnswerLiner;
            List<string> Answers = new List<string>(); //"1" "bil" "2" "463543"

            foreach (UniqueQuestion question in vehicleq)
            {
                Console.WriteLine(question.Question);

                if (question.TypeAnswer == 1)
                { 
                    // input need to be in range from min to max, WHOLE Number [1,2,3,4...]
                    Answer = Console.ReadLine();
                    //int.TryParse(Answer, out AnswerNumber);

                    while (!int.TryParse(Answer, out AnswerNumber) || AnswerNumber > question.Max || AnswerNumber < question.Min)
                    {
                        Console.WriteLine("Invalid input, try again.");
                        Console.WriteLine(question.Question);
                        Answer = Console.ReadLine();
                        int.TryParse(Answer, out AnswerNumber);
                    }

                    Answers.Add(Answer);
                }
                else if (question.TypeAnswer == 2)
                { 
                    // input need to be in range from min to max, LINER Number [0, 0.5, 1, 1.4,5.7 ,... PositiveInfinity]
                    Answer = getValidLinerInput(question.Max);
                    float.TryParse(Answer, out AnswerLiner);

                    while (AnswerLiner >= question.Max || AnswerLiner <= question.Min)
                    {
                        Console.WriteLine("Invalid input, try again.");
                        Console.WriteLine(question.Question);
                        Answer = getValidLinerInput(question.Max);
                        float.TryParse(Answer, out AnswerLiner);
                    }

                    Answers.Add(Answer);
                }
                else
                { 
                    //input is STRING
                    Answer = getValidInputString(); //Console.ReadLine();
                    Answers.Add(Answer);
                }
            }

            garage.SetUnqiue(i_LicenseNumber, i_UserInput, Answers);
        }

        private static void askEveryWheel(string i_LicenseNumber, string i_InputReadyModalNumber)
        {
            int numberOfWheels = garage.m_VehiclesInGarage[i_LicenseNumber].m_NumberOfWheels;
            Console.WriteLine("You have {0} wheels", numberOfWheels.ToString());

            Console.WriteLine("You can enter the current wheel once and it will be implied to the all wheels, enter 1 to do so OR enter 2 to enter each wheel");
            string input = getValidInputMenu(2);
            int howManyWheelsToInput = 1;

            if (input == "2")
            {
                howManyWheelsToInput = numberOfWheels;
            }

            string inputWheelAirPressure;
            string inputWheelName;
            string[] menufactursnames = new string[numberOfWheels];
            float[] currentAirPressurs = new float[numberOfWheels];
            float MaxAirPressure = garage.m_VehiclesInGarage[i_LicenseNumber].m_CollectionOfWheels[0].m_MaxAirPressure;

            // going over every wheel
            for (int curentWheel = 0; curentWheel < howManyWheelsToInput; curentWheel++)
            {
                Console.WriteLine("For wheel {0}:", curentWheel + 1);

                Console.WriteLine("Enter wheel menufacturs name:");
                inputWheelName = Console.ReadLine();
                menufactursnames[curentWheel] = inputWheelName;

                Console.WriteLine("Enter wheel Air Pressure:");
                inputWheelAirPressure = getValidLinerInput(MaxAirPressure); //Console.ReadLine();
                currentAirPressurs[curentWheel] = float.Parse(inputWheelAirPressure);
            }

            // if we enter only 1 wheel and the rest are the same, we still need to fill the arrays[]
            if (input == "1")
            {
                for (int curentWheel = 1; curentWheel < numberOfWheels; curentWheel++)
                {
                    menufactursnames[curentWheel] = menufactursnames[0];
                    currentAirPressurs[curentWheel] = currentAirPressurs[0];
                }
            }

            // send the list and make the wheels
            garage.GenerateWheelsByCarType(i_LicenseNumber, menufactursnames, currentAirPressurs, i_InputReadyModalNumber);
        }

        // -------- 2 - V
        private static void actionTwoShowAllVehiclesInGarage()
        {
            // need to fillter by condition
            Console.WriteLine("Enter the condition: 1-In_Repair 2-Fixed 3-Paid 4-No_Filtter");
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
            foreach (string key in garage.m_VehiclesInGarage.Keys)
            {
                if (conditionToFillterBy is ConditionInGarage.None || garage.m_VehiclesInGarage[key].m_Condition == conditionToFillterBy)
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
            Console.WriteLine("Enter the License Number for the vehicle:");
            string licenseNumber = getValidInputString(); //Console.ReadLine();
            string newCondition;

            if (garage.m_VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                Console.WriteLine("Enter the new condition for the vehicle: 1-in_repair 2-fixed 3-paid:");
                newCondition = getValidInputMenu(3);
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

                garage.m_VehiclesInGarage[licenseNumber].m_Condition = conditionToFillterBy;
                Console.WriteLine("Changed " + licenseNumber + " condition to " + conditionToFillterBy.ToString());
            }
            else
            {
                Console.WriteLine("Vehicle is not in the garage, exiting to menu.");
            }
        }

        // -------- 4 - V
        private static void actionFourInflateWheelsToMax()
        {
            Console.WriteLine("Enter the License Number for the vehicle:");
            string licenseNumber = getValidInputString(); //Console.ReadLine();

            if (garage.m_VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                garage.m_VehiclesInGarage[licenseNumber].FillWheelsToMax();
                Console.WriteLine("Filled licenseNumber: " + licenseNumber + ", wheels to max.");
            }
            else
            {
                Console.WriteLine("Vehicle is not in the garage, exiting to menu.");
            }
        }

        // -------- 5 - V
        private static void actionFiveFillFuel()
        {
            Console.WriteLine("Enter the License Number for the vehicle:");
            string licenseNumber = getValidInputString(); //Console.ReadLine();

            if (garage.m_VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                if (garage.m_VehiclesInGarage[licenseNumber].m_FuelInformation == null)
                {
                    Console.WriteLine("Vehicle is electric can not accept fuel, exiting to menu.");
                }
                else
                {
                    bool fuelmatches = false;

                    while (fuelmatches == false)
                    {
                        Console.WriteLine(garage.m_VehiclesInGarage[licenseNumber].m_FuelInformation.m_TypesOfFuel.Question);
                        string fuelTypeInput = getValidInputMenu(4);// Console.ReadLine();
                        
                        try
                        {
                            garage.DoesFuelMatches(licenseNumber, fuelTypeInput);

                            fuelmatches = true;
                            Console.WriteLine("How much would you like to fill? in liters");
                            string amountOfFuel = Console.ReadLine();
                            try
                            {
                                //garage.m_VehiclesInGarage[licenseNumber].m_FuelInformation.FillFuel(float.Parse(amountOfFuel));
                                garage.AddEnergyAmount(amountOfFuel, licenseNumber);
                                Console.WriteLine("Fuel tank has been filled , exiting to menu.");
                            }
                            catch (Exception ex)
                            {
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
                Console.WriteLine("Vehicle is not in the garage, exiting to menu.");
            }
        }

        // -------- 6 - V
        private static void actionSixChargeBattery()
        {
            Console.WriteLine("Enter the License Number for the vehicle:");
            string licenseNumber = getValidInputString(); //Console.ReadLine();

            if (garage.m_VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                if (garage.m_VehiclesInGarage[licenseNumber].m_ElectricInformation == null)
                {
                    Console.WriteLine("Vehicle is fuel based can not accept electricty, exiting to menu.");
                }
                else
                {
                    Console.WriteLine("Enter how many min you want to charge the battry:");
                    string inputHowManyMinToCharge = Console.ReadLine();
                    try
                    {
                        //garage.RestartEnergyAmount(inputHowManyMinToCharge, licenseNumber);
                        garage.AddEnergyAmount(inputHowManyMinToCharge, licenseNumber);
                        //garage.m_VehiclesInGarage[licenseNumber].m_ElectricInformation.CharageBattryWithAdditionalMin(float.Parse(inputHowManyMinToCharge));
                        Console.WriteLine("Battry has been charged, exiting to menu.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
                    }

                }
            }
            else
            {
                Console.WriteLine("Vehicle is not in the garage, exiting to menu.");
            }
        }

        // -------- 7 - V
        private static void actionSevenShowFullStatsOfASpecificVehicle()
        {
            Console.WriteLine("Enter the License Number for the vehicle:");
            string licenseNumber = getValidInputString(); //Console.ReadLine();

            if (garage.m_VehiclesInGarage.ContainsKey(licenseNumber))
            {
                // Vehicle exists
                // base info
                Console.WriteLine("licenseNumber: {0}", licenseNumber);
                Console.WriteLine("model name: {0}", garage.m_VehiclesInGarage[licenseNumber].m_ModelName);
                // garage info
                Console.WriteLine("owners name: {0}", garage.m_VehiclesInGarage[licenseNumber].m_OwnersName);
                Console.WriteLine("owners phone number: {0}", garage.m_VehiclesInGarage[licenseNumber].m_OwnersPhoneNumber);
                Console.WriteLine("condition: {0}", garage.m_VehiclesInGarage[licenseNumber].m_Condition.ToString());

                // wheels
                for (int i = 0; i < garage.m_VehiclesInGarage[licenseNumber].m_CollectionOfWheels.Length; i++)
                {
                    Console.WriteLine("wheel {0}:", i + 1);
                    Console.WriteLine("wheel pressure: {0}", garage.m_VehiclesInGarage[licenseNumber].m_CollectionOfWheels[i].m_CurrentAirPressure);
                    Console.WriteLine("menufacturere name: {0}", garage.m_VehiclesInGarage[licenseNumber].m_CollectionOfWheels[i].m_ManufacturerName);
                }

                // energy
                if (garage.m_VehiclesInGarage[licenseNumber].m_FuelInformation == null)
                {
                    Console.WriteLine("energy type: electricity");
                    Console.WriteLine("amount of energy: {0} hours", garage.m_VehiclesInGarage[licenseNumber].m_ElectricInformation.m_CorrentAmountOfBattry);
                }
                else
                {
                    Console.WriteLine("energy type: {0} : {1}", garage.m_VehiclesInGarage[licenseNumber].m_TypeOfEnergy,
                        garage.m_VehiclesInGarage[licenseNumber].m_FuelInformation.m_TypeOfFuelForOurVehicle);
                    Console.WriteLine("amount of energy: {0} liters", garage.m_VehiclesInGarage[licenseNumber].m_FuelInformation.m_CorrentAmountOfFuel);
                }

                // m_UniqueInformation - CAR: m_Color, numberDoors
                foreach (var atr in garage.m_VehiclesInGarage[licenseNumber].m_UniqueInformation)
                {
                    Console.WriteLine(atr.Key + atr.Value);
                }

            }
            else
            {
                Console.WriteLine("Vehicle is not in the garage, exiting to menu.");
            }
        }

        // ---------------------------- CHECK INPUT ----------------------------------------------------------------------------

        private static string getValidInputMenu(int i_Max)
        {
            string input = Console.ReadLine();
            bool isInputInValid = false;

            while (isInputInValid == false)
            {
                try
                {
                    garage.CheckInValueForMenu(input, 1, i_Max);
                    isInputInValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
                    Console.WriteLine("Enter an input again: ");
                    input = Console.ReadLine();
                }
            }

            return input;
        }

        private static string getValidLinerInput(float i_Max)
        {
            string input = Console.ReadLine();
            bool isInputInValid = false;

            while (isInputInValid == false)
            {
                try
                {
                    garage.CheckIsValueLinearAndInRange(input, 0, i_Max);
                    isInputInValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
                    Console.WriteLine("Enter an input again: ");
                    input = Console.ReadLine();
                }
            }

            return input;
        }

        private static string getValidInputString()
        {
            string input = Console.ReadLine();
            bool isInputInValid = false;

            while (isInputInValid == false)
            {
                try
                {
                    garage.CheckStringValue(input); //for now does nothing, check Note in the function in GarageLogic
                    isInputInValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
                    Console.WriteLine("Enter an input again: ");
                    input = Console.ReadLine();
                }
            }

            return input;
        }

    }
}
