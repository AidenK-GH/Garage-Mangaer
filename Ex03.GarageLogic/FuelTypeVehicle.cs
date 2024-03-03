using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelTypeVehicle
    {

        public TypeOfFuel TypeOfFuelForOurVehicle; //turn to enum [Soler ,Octan95 ,Octan96 ,Octan98]
        public UniqueQuestion typesOfFuel; // [Soler ,Octan95 ,Octan96 ,Octan98]

        public float CorrentAmountOfFuel; // in liters
        public float MaxAmountOfFuel; // in liters

        public FuelTypeVehicle(TypeOfFuel TypeOfFuel, float MaxAmountOfFuel)
        {
            this.TypeOfFuelForOurVehicle = TypeOfFuel;
            this.MaxAmountOfFuel = MaxAmountOfFuel;
            typesOfFuel = new UniqueQuestion("choose a fuel type: 1-Soler 2-Octan95 3-Octan96 4-Octan98", 1, 4, 1);
            //this.CorrentAmountOfFuel= CorrentAmountOfFuel;
        }

        public void SetFuel(float StartingFuel)
        {
            if (StartingFuel > MaxAmountOfFuel)
            {
                throw new ValueOutOfRangeException(0, MaxAmountOfFuel); //Exception("too much fuel try again ");
            }//אולי יש אופציה להורדה הבדיקת אינפוט תקין תקבל מינימום ומקסימום אפשריים 
            CorrentAmountOfFuel = StartingFuel;
        }

        public void FillFuelToMax()
        {
            CorrentAmountOfFuel = MaxAmountOfFuel;
        }

        public void FillFuel(float AdditionalFual)
        {
            if (AdditionalFual + CorrentAmountOfFuel > MaxAmountOfFuel)
            {
                throw new ValueOutOfRangeException(0, MaxAmountOfFuel); //Exception("too much fuel can't fill");
            }
            CorrentAmountOfFuel = CorrentAmountOfFuel + AdditionalFual;
        }

    }
}