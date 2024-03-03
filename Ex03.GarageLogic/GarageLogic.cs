using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageLogic
    {
        // Dictionary < LicenseNumber , Vehicle > Vehicles in garage
        public Dictionary<string, Vehicle> VehiclesInGarage;

        // Dictionary < string "CAR" "EL CAR" , Vehicle > Vehicles the garage can handle
        //public readonly Dictionary<string, Vehicle> VehiclesTheGarageCanHandle;
        public readonly List<string> ourGarageVehacleDisciption;

        public GarageLogic()
        {
            // where we store all the vehicles that are in the garage
            VehiclesInGarage = new Dictionary<string, Vehicle>();

            // adding vehicles to ourGarageVehacleDisciption
            ourGarageVehacleDisciption = new List<string>();
            ourGarageVehacleDisciption.Add("1: a motorcycle that works on Octan98 maximum of 5.8 liter, and have 2 wheels with max air pressure of 29");
            ourGarageVehacleDisciption.Add("2: an electric motorcycle with a bettary of 2.8 hours, and have 2 wheels with max air pressure of 29");
            ourGarageVehacleDisciption.Add("3: a car that works on Octan95, maximum of 58 liter, and have 5 wheels with max air pressure of 30");
            ourGarageVehacleDisciption.Add("4: an electric car with a bettary of 4.8 hours, and have 5 wheels with max air pressure of 30");
            ourGarageVehacleDisciption.Add("5: a truk that works on Soler maximum of 110 liter, and have 12 wheels with max air pressure of 28");

            /*
            // adding vehicles to VehiclesTheGarageCanHandle
            VehiclesTheGarageCanHandle = new Dictionary<string, Vehicle>();

            Car carExemple = new Car("3", 'f', 5, 30, TypeOfFuelForOurVehicle.Octan95, (float)58); //wheel = 5, (later)airPmax = 30, fuelType = Octan98, fuelTank = 5.8 liters
            VehiclesTheGarageCanHandle.Add("3", carExemple);

            Car ElectricCarExemple = new Car("4", 'e', 5, 30, TypeOfFuelForOurVehicle.None, (float)58); //wheel = 5, airPmax = 30, battryMaxTime = 4.8 hours
            VehiclesTheGarageCanHandle.Add("4", ElectricCarExemple);
            
            //VehiclesTheGarageCanHandle.Add("motorcycle", "a motorcycle that works on Octan98");

            //// motorcycle fuel: wheel = 2, airPmax = 29, fuelType = Octan98, fuelTank = 5.8 liters
            //VehiclesTheGarageCanHandle.Add("motorcycle fuel", new Vehicle("99999", 0, "placeHolder", 2));

            //// motorcycle battry: wheel = 2, airPmax = 29, battryMaxTime = 2.8 hours
            //VehiclesTheGarageCanHandle.Add("motorcycle battry", new Vehicle("99999", 0, "placeHolder", 2));

            // CAR fuel: wheel = 5, airPmax = 30, fuelType = Octan98, fuelTank = 5.8 liters
            //VehiclesTheGarageCanHandle.Add("car fuel", new Vehicle("99999", 0, "placeHolder", 5));

            // car battry: wheel = 5, airPmax = 30, battryMaxTime = 4.8 hours
            //VehiclesTheGarageCanHandle.Add("car battry", new Vehicle("99999", 0, "placeHolder", 5));

            //// truck: wheel = 12, airPmax = 28, fuelType = Soler, fuelTank = 110 liters
            //VehiclesTheGarageCanHandle.Add("truck", new Vehicle("99999", 0, "placeHolder", 12));
            */
        }

        public void doesFuelMatches(string llicenceNumber, string FuelChoice)
        {
            // [Soler ,Octan95 ,Octan96 ,Octan98]
            //bool canFillFuel=false;
            switch (FuelChoice)
            {
                case "1":
                    if (VehiclesInGarage[llicenceNumber].fuelInformation.TypeOfFuelForOurVehicle != TypeOfFuel.Soler)
                        throw new ArgumentException("fuel does not matches try again ");
                    break;
                case "2":
                    if (VehiclesInGarage[llicenceNumber].fuelInformation.TypeOfFuelForOurVehicle != TypeOfFuel.Octan95)
                        throw new ArgumentException("fuel does not matches try again ");
                    break;
                case "3":
                    if (VehiclesInGarage[llicenceNumber].fuelInformation.TypeOfFuelForOurVehicle != TypeOfFuel.Octan96)
                        throw new ArgumentException("fuel does not matches try again ");
                    break;
                case "4":
                    if (VehiclesInGarage[llicenceNumber].fuelInformation.TypeOfFuelForOurVehicle != TypeOfFuel.Octan98)
                        throw new ArgumentException("fuel does not matches try again ");
                    break;

            }
            //return canFillFuel;
        }

        public void creattvehicle(string licenceNumber, string i_vehicleType)
        {
            switch (i_vehicleType)
            {
                case "1": // motrocycle fuel: wheel = 2, airPmax = 29, fuelType = Octan98, fuelTank = 5.8 liters
                    VehiclesInGarage.Add(licenceNumber, new Car(licenceNumber, 'f', 2, (float)29, TypeOfFuel.Octan98, (float)5.8));
                    break;
                case "2": // motrocycle electric: wheel = 2, airPmax = 29, battryMaxTime = 2.8 hours
                    VehiclesInGarage.Add(licenceNumber, new Car(licenceNumber, 'e', 2, (float)29, TypeOfFuel.None, (float)2.8));
                    break;
                case "3": // car fuell: wheel = 5, airPmax = 30, fuelType = Octan95, fuelTank = 58 liters
                    VehiclesInGarage.Add(licenceNumber, new Car(licenceNumber, 'f', 5, (float)30, TypeOfFuel.Octan95, (float)58));
                    break;
                case "4": // car electric: wheel = 5, airPmax = 30, battryMaxTime = 4.8 hours
                    VehiclesInGarage.Add(licenceNumber, new Car(licenceNumber, 'e', 5, (float)30, TypeOfFuel.None, (float)4.8));
                    break;
                case "5": // truck: wheel = 12, airPmax = 28, fuelType = Soler, fuelTank = 110 liters
                    VehiclesInGarage.Add(licenceNumber, new Car(licenceNumber, 'f', 12, (float)28, TypeOfFuel.Soler, (float)110));
                    break;
            }
        }

        public void GenaraitWheelsByCarType(string licenseNumber, string[] menufactursnames, float[] currentAirPressurs, string inputCarType)
        {
            switch (inputCarType)
            {
                case "1":
                    //motocycle f
                    break;
                case "2": //motocycle e
                    break;
                case "3": //car f
                    VehiclesInGarage[licenseNumber].GenerateWheels(menufactursnames, currentAirPressurs, (float)30, 5);
                    break;
                case "4": //car e
                    VehiclesInGarage[licenseNumber].GenerateWheels(menufactursnames, currentAirPressurs, (float)30, 5);
                    break;
                case "5": //truck f
                    break;
            }
        }

        // adds dummy cars in VehiclesInGarage, for testing
        //public void TEMP_makeDummyCarsForTesting()
        //{
        //    // v CAR 1 v --------------------------
        //    // base
        //    Car tempCar = new Car("TEMPlicenseNumber", 'e', 5, 30, TypeOfFuelForOurVehicle.None, (float)58);

        //    // wheels
        //    string[] menufactursnames = new string[5];
        //    float[] currentAirPressurs = new float[5];
        //    for (int curentWheel = 0; curentWheel < 5; curentWheel++)
        //    {
        //        menufactursnames[curentWheel] = "tempMenufactursName";
        //        currentAirPressurs[curentWheel] = 25f;
        //    }
        //    tempCar.GenerateWheelsWithoutMaxAirPressure(menufactursnames, currentAirPressurs, 5);

        //    // garage info
        //    tempCar.ownersName = "TEMPownersName";
        //    tempCar.ownersPhoneNumber = "TEMPownersPhoneNum";

        //    // uniqe
        //    tempCar.Color = CarColor.Blue;
        //    tempCar.NumberOfDoors = 4;

        //    // Add
        //    VehiclesInGarage.Add("1234", tempCar);
        //    // v CAR 2 v --------------------------
        //}

        public void SetUnqiue(string licenceNumber, string inputCarType, List<string> answers)
        {
            switch (inputCarType)
            {
                case "1": // 1 motocycle f // 2 motocycle e
                case "2":
                    (VehiclesInGarage[licenceNumber] as Motorcycle).SetMotorcycleLicenseType(answers[0]);
                    (VehiclesInGarage[licenceNumber] as Motorcycle).SetEngineVolumeInCC(answers[1]);
                break;

                case "3": // 3 car f // 4 car e
                case "4":
                    (VehiclesInGarage[licenceNumber] as Car).SetCarColore(answers[0]);
                    (VehiclesInGarage[licenceNumber] as Car).SetCarNumberOfDoors(answers[1]);
                    break;

                case "5":
                    (VehiclesInGarage[licenceNumber] as Truck).SetIsTransportingHazardousMaterials(answers[0]);
                    (VehiclesInGarage[licenceNumber] as Truck).SetCargoVolume(answers[1]);// 5 truck f
                    break;
            }
        }

        // ---------------------------- v functions RestarteEnergyAmaunt ... v --------------------------------------------------------

        public List<UniqueQuestion> getInitOfQuestions(string licenceNumber)
        {
            return VehiclesInGarage[licenceNumber].Questions;
        }

        public void RestarteEnergyAmaunt(string energyAmount, string licenseNumber)
        {
            float energyAmountFloat;
            if (!float.TryParse(energyAmount, out energyAmountFloat))
            {
                throw new FormatException("input incurrect");
            }

            float.TryParse(energyAmount, out energyAmountFloat);
            VehiclesInGarage[licenseNumber].SetAmountOfEnergy(energyAmountFloat);
        }

        
        // -------------------- CHECK INPUTS -------------------------------------------------------------------
        // value just needs to be between nim and max, [min, 1.5, 3,...., max] can be float
        public void CheckValueInRange(float value, float minValue, float maxValue)
        {
            if (value < minValue || value > maxValue)
            {
                throw new ValueOutOfRangeException(minValue, maxValue);
            }
        }

        // value needs to be a naturl number [1,2,3,...max] just int
        public void CheckInValueForMenu(string value, float minValue, float maxValue)
        {
            // is int?
            int temp;
            if (!int.TryParse(value, out temp))
            {
                throw new FormatException("input incurrect");
            }

            // is in range?
            float valuetmp;
            float.TryParse(value, out valuetmp);
            CheckValueInRange(valuetmp, minValue, maxValue);
        }

        // value needs to be a naturl number [1,2,3,...max] just int
        public void CheckIsValueLinerAndInRange(string value, float minValue, float maxValue)
        {
            // is float?
            float temp;
            if (float.TryParse(value, out temp) == false)
            {
                throw new FormatException("input incurrect");
            }

            // is in range?
            CheckValueInRange(temp, minValue, maxValue);
        }

        // value is string
        public void CheckStringValue(string inputToCheck)
        {
            /*
            there are no known conditions for string values

            like OwnerName or ModalName
            and with licenseNumber it can be anything, in Israel its only numbers but in other places it can be "IH8TPPL"(yes it's real, got the name from google)

            SO this function is incase in the future there will be conditions, and it will be easy to add.
            */
        }
    }
}
