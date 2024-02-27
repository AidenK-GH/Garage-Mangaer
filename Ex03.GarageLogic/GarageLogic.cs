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
        public Dictionary<string, Vehicle> VehiclesTheGarageCanHandle;
        public List<string> ourgaragevehacledisciption;
        public GarageLogic()
        {
            VehiclesInGarage = new Dictionary<string, Vehicle>();

            VehiclesTheGarageCanHandle = new Dictionary<string, Vehicle>();

            ourgaragevehacledisciption = new List<string>();
            ourgaragevehacledisciption.Add("1:a motorcycle  that works on Octan98 maximum of 5.8 liter ,and have 2 wheels  with air presur of 29");
            ourgaragevehacledisciption.Add("2:an electric motorcycle with a bettary of 2.8 houres , and have 2 wheels  with air presur of 29");
            ourgaragevehacledisciption.Add("3:a car  that works on Octan95, maximum of 58 liter ,and have 5 wheels  with air presur of 30");
            ourgaragevehacledisciption.Add("4:an electric car  with a bettary of 4.8 houres , and have 5 wheels  with air presur of 30");
            ourgaragevehacledisciption.Add("5:a truk  that works on soler maximum of 110 liter , and have 12 wheels  with air presur of 28");



            //VehiclesTheGarageCanHandle.Add("motorcycle", "a motorcycle that works on Octan98");

            //// motorcycle fuel: wheel = 2, airPmax = 29, fuelType = Octan98, fuelTank = 5.8 liters
            //VehiclesTheGarageCanHandle.Add("motorcycle fuel",
            //    new Vehicle("99999", 0, "placeHolder", 2));
            //// motorcycle battry: wheel = 2, airPmax = 29, battryMaxTime = 2.8 hours
            //VehiclesTheGarageCanHandle.Add("motorcycle battry",
            //    new Vehicle("99999", 0, "placeHolder", 2));

            // CAR fuel: wheel = 5, airPmax = 30, fuelType = Octan98, fuelTank = 5.8 liters
            VehiclesTheGarageCanHandle.Add("car fuel", 
                new Vehicle("99999", 0, "placeHolder", 5));
            // car battry: wheel = 5, airPmax = 30, battryMaxTime = 4.8 hours
            VehiclesTheGarageCanHandle.Add("car battry",
                new Vehicle("99999", 0, "placeHolder", 5));

            //// truck: wheel = 12, airPmax = 28, fuelType = Soler, fuelTank = 110 liters
            //VehiclesTheGarageCanHandle.Add("truck",
            //    new Vehicle("99999", 0, "placeHolder", 12));
        }

        // ---------------------------- v builders / constractors v --------------------------------------------------------
        
        //public newCar(CarColor thisCarColor, string electricOrGas) : base(thisCarColor, electricOrGas)
        //{
        //    return new Car(CarColor thisCarColor, string electricOrGas) : base(thisCarColor, electricOrGas);
        //}

        // ---------------------------- v search in Dictionarys v --------------------------------------------------------

        public void SearchVehiclesTheGarageCanHandleByVehicleType(string i_VehicleType)
        {
            if (VehiclesTheGarageCanHandle.ContainsKey(i_VehicleType))
            {
                Console.WriteLine(VehiclesTheGarageCanHandle[i_VehicleType]);
            }
            else
            {
                Console.WriteLine("not in Dictionary");
            }
        }

        //public void SearchVehicleInGarageByLicenseNumber(string i_LicenseNumber)
        //{
        //    if (VehiclesInGarage.ContainsKey(i_LicenseNumber))
        //    {
        //        Console.WriteLine(VehiclesInGarage[i_LicenseNumber]);
        //    }
        //    else
        //    {
        //        Console.WriteLine("not in Dictionary");
        //    }
        //}
        ////public void GetVehucleStats(string licenseNumber)
        ////{
        ////    Console.WriteLine("licenseNumber:{0}", licenseNumber);
        ////    Console.WriteLine("model name:{0}", VehiclesInGarage[licenseNumber].ModelName);
        ////    Console.WriteLine("owners name:{0}",VehiclesInGarage[licenseNumber].ownersName);
        ////    Console.WriteLine("status:{0}", VehiclesInGarage[licenseNumber].condition);

        ////}




        



    }
}
