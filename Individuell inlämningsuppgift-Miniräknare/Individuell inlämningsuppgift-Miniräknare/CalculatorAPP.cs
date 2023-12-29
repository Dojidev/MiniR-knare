using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuell_inlämningsuppgift_Miniräknare
{
    internal class CalculatorAPP
    {
        public static void DisplayMainMenu()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("   Welcome to My Calculator App");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("1. Calculator");
            Console.WriteLine("2. Temperature Converter");
            Console.WriteLine("3. Show Previous Results");
            Console.WriteLine("4. Exit Program");
            Console.WriteLine("====================================");
            Console.Write("Choose one alternative: ");
        }

        public static void DisplayTempMenu()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("         Temperature Converter      ");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Convert °C to Fahrenheit & Kelvin");
            Console.WriteLine("2. Convert °F to Celsius & Kelvin");
            Console.WriteLine("3. Convert °K to Celsius & Fahrenheit");
            Console.WriteLine("4. Back To Main Menu");
            Console.WriteLine("===================================");
            Console.Write("Choose one alternative: ");

        }

        public static void ExitProgram()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*********************************************");
            Console.WriteLine("*   Thank you for using my Calculator App   *");
            Console.WriteLine("*********************************************");
            Console.ForegroundColor = ConsoleColor.White;
        }


    }
}
    