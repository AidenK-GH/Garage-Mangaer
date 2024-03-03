using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageLogic
    {
        // Dictionary < m_LicenseNumber , Vehicle > Vehicles in garage
        public Dictionary<string, Vehicle> m_VehiclesInGarage;

        public readonly List<string> r_OurGarageVehacleDisciption;

        public GarageLogic()
        {
            // where we store all the vehicles that are in the garage
            m_VehiclesInGarage = new Dictionary<string, Vehicle>();

            // adding vehicles to r_OurGarageVehacleDisciption
            r_OurGarageVehacleDisciption = new List<string>();
            r_OurGarageVehacleDisciption.Add("1: a motorcycle that works on Octan98 maximum of 5.8 liter, and have 2 wheels with max air pressure of 29");
            r_OurGarageVehacleDisciption.Add("2: an electric motorcycle with a bettary of 2.8 hours, and have 2 wheels with max air pressure of 29");
            r_OurGarageVehacleDisciption.Add("3: a car that works on Octan95, maximum of 58 liter, and have 5 wheels with max air pressure of 30");
            r_OurGarageVehacleDisciption.Add("4: an electric car with a bettary of 4.8 hours, and have 5 wheels with max air pressure of 30");
            r_OurGarageVehacleDisciption.Add("5: a truk that works on Soler maximum of 110 liter, and have 12 wheels with max air pressure of 28");
        }

        public void DoesFuelMatches(string i_LicenceNumber, string i_FuelChoice)
        {
            // [Soler ,Octan95 ,Octan96 ,Octan98]
            switch (i_FuelChoice)
            {
                case "1":
                    if (m_VehiclesInGarage[i_LicenceNumber].m_FuelInformation.m_TypeOfFuelForOurVehicle != TypeOfFuel.Soler)
                        throw new ArgumentException("fuel does not matches try again ");
                    break;
                case "2":
                    if (m_VehiclesInGarage[i_LicenceNumber].m_FuelInformation.m_TypeOfFuelForOurVehicle != TypeOfFuel.Octan95)
                        throw new ArgumentException("fuel does not matches try again ");
                    break;
                case "3":
                    if (m_VehiclesInGarage[i_LicenceNumber].m_FuelInformation.m_TypeOfFuelForOurVehicle != TypeOfFuel.Octan96)
                        throw new ArgumentException("fuel does not matches try again ");
                    break;
                case "4":
                    if (m_VehiclesInGarage[i_LicenceNumber].m_FuelInformation.m_TypeOfFuelForOurVehicle != TypeOfFuel.Octan98)
                        throw new ArgumentException("fuel does not matches try again ");
                    break;
            }
        }

        public void CreateVehicle(string i_LicenceNumber, string i_VehicleType)
        {
            switch (i_VehicleType)
            {
                case "1": // motrocycle fuel: wheel = 2, airPmax = 29, fuelType = Octan98, fuelTank = 5.8 liters
                    m_VehiclesInGarage.Add(i_LicenceNumber, new Motorcycle(i_LicenceNumber, 'f', 2, (float)29, TypeOfFuel.Octan98, (float)5.8));
                    break;
                case "2": // motrocycle electric: wheel = 2, airPmax = 29, battryMaxTime = 2.8 hours
                    m_VehiclesInGarage.Add(i_LicenceNumber, new Motorcycle(i_LicenceNumber, 'e', 2, (float)29, TypeOfFuel.None, (float)2.8));
                    break;
                case "3": // car fuell: wheel = 5, airPmax = 30, fuelType = Octan95, fuelTank = 58 liters
                    m_VehiclesInGarage.Add(i_LicenceNumber, new Car(i_LicenceNumber, 'f', 5, (float)30, TypeOfFuel.Octan95, (float)58));
                    break;
                case "4": // car electric: wheel = 5, airPmax = 30, battryMaxTime = 4.8 hours
                    m_VehiclesInGarage.Add(i_LicenceNumber, new Car(i_LicenceNumber, 'e', 5, (float)30, TypeOfFuel.None, (float)4.8));
                    break;
                case "5": // truck: wheel = 12, airPmax = 28, fuelType = Soler, fuelTank = 110 liters
                    m_VehiclesInGarage.Add(i_LicenceNumber, new Truck(i_LicenceNumber, 'f', 12, (float)28, TypeOfFuel.Soler, (float)110));
                    break;
            }
        }

        public void GenerateWheelsByCarType(string i_LicenceNumber, string[] i_Menufactursnames, float[] i_CurrentAirPressurs, string i_InputCarType)
        {
            switch (i_InputCarType)
            {
                case "1"://motocycle f
                case "2"://motocycle e
                    m_VehiclesInGarage[i_LicenceNumber].GenerateWheels(i_Menufactursnames, i_CurrentAirPressurs, (float)29, 2);
                    break;
                case "3": //car f
                case "4": //car e
                    m_VehiclesInGarage[i_LicenceNumber].GenerateWheels(i_Menufactursnames, i_CurrentAirPressurs, (float)30, 5);
                    break;
                case "5": //truck f
                    m_VehiclesInGarage[i_LicenceNumber].GenerateWheels(i_Menufactursnames, i_CurrentAirPressurs, (float)28, 12);
                    break;
            }
        }

        public void SetUnqiue(string i_LicenceNumber, string i_InputCarType, List<string> i_Answers)
        {
            switch (i_InputCarType)
            {
                case "1": // 1 motocycle f // 2 motocycle e
                case "2":
                    (m_VehiclesInGarage[i_LicenceNumber] as Motorcycle).SetMotorcycleLicenseType(i_Answers[0]);
                    (m_VehiclesInGarage[i_LicenceNumber] as Motorcycle).SetEngineVolumeInCC(i_Answers[1]);
                    break;

                case "3": // 3 car f // 4 car e
                case "4":
                    (m_VehiclesInGarage[i_LicenceNumber] as Car).SetCarColore(i_Answers[0]);
                    (m_VehiclesInGarage[i_LicenceNumber] as Car).SetCarNumberOfDoors(i_Answers[1]);
                    break;

                case "5"://truck
                    (m_VehiclesInGarage[i_LicenceNumber] as Truck).SetIsTransportingHazardousMaterials(i_Answers[0]);
                    (m_VehiclesInGarage[i_LicenceNumber] as Truck).SetCargoVolume(i_Answers[1]);// 5 truck f
                    break;
            }
        }

        // ---------------------------- v functions RestartEnergyAmount ... v --------------------------------------------------------

        public List<UniqueQuestion> GetInitOfQuestions(string i_LicenceNumber)
        {
            return m_VehiclesInGarage[i_LicenceNumber].m_Questions;
        }

        public void RestartEnergyAmount(string i_EnergyAmount, string i_LicenceNumber)
        {
            float energyAmountFloat;
            if (!float.TryParse(i_EnergyAmount, out energyAmountFloat))
            {
                throw new FormatException("input incurrect");
            }

            float.TryParse(i_EnergyAmount, out energyAmountFloat);
            m_VehiclesInGarage[i_LicenceNumber].SetAmountOfEnergy(energyAmountFloat);
        }

        public void AddEnergyAmount(string i_EnergyAmount, string i_LicenceNumber)
        {
            float energyAmountFloat;
            if (!float.TryParse(i_EnergyAmount, out energyAmountFloat))
            {
                throw new FormatException("input incurrect");
            }

            float.TryParse(i_EnergyAmount, out energyAmountFloat);
            m_VehiclesInGarage[i_LicenceNumber].FillEnergy(energyAmountFloat);
        }


        // -------------------- CHECK INPUTS -------------------------------------------------------------------
        // value just needs to be between nim and max, [min, 1.5, 3,...., max] can be float
        public void CheckIfValueInRange(float i_Value, float i_MinValue, float i_MaxValue)
        {
            if (i_Value < i_MinValue || i_Value > i_MaxValue)
            {
                throw new ValueOutOfRangeException(i_MinValue, i_MaxValue);
            }
        }

        // value needs to be a naturl number [1,2,3,...max] just int
        public void CheckInValueForMenu(string i_Value, float i_MinValue, float i_MaxValue)
        {
            // is int?
            int valueAsInt;
            if (!int.TryParse(i_Value, out valueAsInt))
            {
                throw new FormatException("input incurrect");
            }

            // is in range?
            float valueAsFloat;
            float.TryParse(i_Value, out valueAsFloat);
            CheckIfValueInRange(valueAsFloat, i_MinValue, i_MaxValue);
        }

        // value needs to be a naturl number [1,2,3,...max] just int
        public void CheckIsValueLinearAndInRange(string i_Value, float i_MinValue, float i_MaxValue)
        {
            // is float?
            float valueAsFloat;
            if (float.TryParse(i_Value, out valueAsFloat) == false)
            {
                throw new FormatException("input incurrect");
            }

            // is in range?
            CheckIfValueInRange(valueAsFloat, i_MinValue, i_MaxValue);
        }

        // value is string
        public void CheckStringValue(string i_InputToCheck)
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
