using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricTypeVehicle // : EnergyStorage
    {
        public float CorrentAmountOfBattry; // in hours
        public float MaxAmountOfBattry; // in hours

        public ElectricTypeVehicle(float MaxAmountOfBattry)
        {
            this.MaxAmountOfBattry = MaxAmountOfBattry;
            //this.CorrentAmountOfBattry = CorrentAmountOfBattry;
        }

        public void CharageBattryToMax()
        {
            CorrentAmountOfBattry = MaxAmountOfBattry;
        }

        public void CharageBattryWithAdditionalMin(float AdditionalEnergy)
        {
            // note AdditionalEnergy is in min, need to change to hours
            float additionalEnergyInHours = AdditionalEnergy / 60f; // change to hours

            // check if AdditionalEnergy is too much
            // throw exception
            if (additionalEnergyInHours + CorrentAmountOfBattry > MaxAmountOfBattry)
            {
                throw new ValueOutOfRangeException("Exsids the maximum battry limit.");
            }

            CorrentAmountOfBattry += additionalEnergyInHours;
        }

        // SET CorrentAmountOfBattry
        public void SetCorrentAmountOfBattry(float correntAmountOfBattry)
        {
            if (correntAmountOfBattry > MaxAmountOfBattry)
            {
                throw new Exception("Exsids the maximum battry limit, can't set.");
            }
            this.CorrentAmountOfBattry = correntAmountOfBattry;
        }


    }
}