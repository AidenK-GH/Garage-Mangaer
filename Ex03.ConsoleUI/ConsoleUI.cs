using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class ConsoleUI
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Ex03 - Garage Manger");
            PrintMenu();
            Console.WriteLine("press 'Enter' to close the window.");
            Console.ReadLine();
        }
        private static void PrintMenu()
        {
            Console.WriteLine("1 - Enter a new vehicle");
            Console.WriteLine("2 - Show all the vehicles that are in the Garage");
            Console.WriteLine("3 - Change a specific vehicle condition");
            Console.WriteLine("4 - Inflate wheels to max of a specific vehicle");
            Console.WriteLine("5 - Fill fuel for a specific vehicle");
            Console.WriteLine("6 - Charge battery for a specific vehicle");
            Console.WriteLine("7 - Show full stats of a specific vehicle");
            Console.WriteLine("8 - Exit Garage Manger");
        }
    }
}
