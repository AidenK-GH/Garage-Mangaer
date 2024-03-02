using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public struct UniqueQuestion
    {
        string m_Question;
        int m_Min;
        int m_Max;

        // 1- number from min to max. LIKE: (enum)carColor 1-blue 2-red, OR (bool)TruckIsTransportingHazardousMaterials 1-yes 2-no.
        // 2- liner number from min to max BUT float like MotoEngineVolumeInCC 0 to float.PositiveInfinity
        // 3- string without conditions. LIKE: (string)the name of the doll on your dasboard.
        int m_TypeAnswer; 

        //  ---------------- GET SET ----------------         
        public string Question
        {
            get => m_Question; 
            set => m_Question = value;
        }
        public int Min
        { 
            get => m_Min; 
            set => m_Min = value; 
        }
        public int Max 
        { 
            get => m_Max; 
            set => m_Max = value; 
        }
        public int TypeAnswer
        {
            get => m_TypeAnswer;
            set => m_TypeAnswer = value;
        }

        //  ---------------- Constructor ----------------
        public UniqueQuestion(string question, int min, int max, int TypeAnswer)
        {
            m_Question = question;
            m_Min = min;
            m_Max = max;
            m_TypeAnswer = TypeAnswer;
        }

    }
}