using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        //internal Car(string LicenseNumber, float PercentageOfEnergyRemaining, string ModelName, int numberOfWheels, CarColor CarColor, string electricOrGas)
        //    : base(LicenseNumber, PercentageOfEnergyRemaining, ModelName, 5)
        //{
        //    this.Color = CarColor;
        //    //if(electricOrGas)
        //}


        public Dictionary<string, string> uniqinformation;



        internal Car(string LicenseNumber) :base( LicenseNumber,5)
        {
            this.LicenseNumber = LicenseNumber;

            uniqinformation.Add("CarColor", "CarColor");
            uniqinformation.Add("number of doors", "5");
        }
        public CarColor Color; //turn to enum
        float PercentageOfEnergyRemaining;
        public string carType;
        public int NumberOfDoors;
        public string ModelName;

        public void Generatewheelsforcar(string[] menufactursnames, int[] currentAirPressurs)
        {
            for (int i = 0; i < 5; i++)
            {
                CollectionOfWheels[i].CurrentAirPressure = 0;
                CollectionOfWheels[i].MaxAirPressure = 30;
                CollectionOfWheels[i].manufacturerName= menufactursnames[i];
            }
            
        }

        public Dictionary<string, string> getuniqinformation()
        {
            return uniqinformation;
        }


    }
}