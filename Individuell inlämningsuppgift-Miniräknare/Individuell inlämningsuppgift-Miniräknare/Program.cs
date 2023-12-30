

using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using Individuell_inlämningsuppgift_Miniräknare;

namespace Calculator_ConsoleApp
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
           
                MainProgram();                    
            
        }

        //----------------------Main Menu/program ---------------------------------------//
        
        static void MainProgram()
        {
            while (true)
            {


                CalculatorAPP.DisplayMainMenu(); //user chooses between 1-4 
                var answer = Console.ReadLine();

                switch (answer) 
                {
                    case "1":
                        Calculator();
                        break;

                    case "2":
                        TempConverter();
                        break;

                    case "3":
                        ShowPreviousResults();
                        break;

                    case "4":
                        // Exit the program
                        CalculatorAPP.ExitProgram();
                        return;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        HandleInputError("Invalid input! Please enter a valid number (1-4).");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        break;

                }

            }
        }
        //---------------------------------------Start ------------------------------------//
        //------------------------------------ Calculator ---------------------------------//
        static void Calculator()
        {
            Console.Clear();
            while (true)
            {
                

                string expression = CheckForTypedExpression("Enter a mathematical expression (Exp: 20+20): ");

                string[] elements = expression.Split(new char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);

                if (elements.Length == 2 &&
                    decimal.TryParse(elements[0], out decimal num1) &&
                    decimal.TryParse(elements[1], out decimal num2))
                {
                    char operatorSymbol = expression[elements[0].Length];
                    decimal result = PerformCalculation(num1, num2, operatorSymbol);
                    resultHistory.Add(result);

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($" {num1} {operatorSymbol} {num2} = {result}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();

                    Console.WriteLine("Do you want to perform another calculation? " +
                        "(Press any key to continue or 'N' to exit): ");
                    string continueInput = Console.ReadLine().ToLower();
                    if (continueInput == "n")
                    {
                        return;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    HandleInputError("Invalid expression format or numbers.");
                    Console.ForegroundColor = ConsoleColor.White;
                   
                }
            }
        }


        //----------------------------- Handles Error ---------------------------------------------//
        static string CheckForTypedExpression(string message)
        {
            while (true)
            {
                Console.Write(message);
                string expression = Console.ReadLine();
                return expression;
            }
        }

        
     
     
        //----------------------------- Handles Error ---------------------------------------------//
        static void HandleInputError(string errorMessage)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage);
                Console.ForegroundColor = ConsoleColor.White;
            }



        //-------------------------------Show previus Result -------------------------------------//
        private static List<decimal> resultHistory = new List<decimal>(); //for storing results
        static void ShowPreviousResults()
        {
            Console.Clear();
            if (resultHistory.Count != 0) //loops and shows the previus result
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Your Results are:");
                for (int i = 0; i < resultHistory.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {resultHistory[i]}");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("****************************************");
                Console.WriteLine("*  No calculations have been done yet  *");
                Console.WriteLine("****************************************");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //-------------------------------- Perform Calculation -----------------------------------//
        static decimal PerformCalculation
            (decimal num1, decimal num2, char operatorSymbol)
        {
            switch (operatorSymbol)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    if (num2 != 0)
                    {
                        return num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Invalid! Cannot divide by zero.");
                        return 0;
                    }
                default:
                    Console.WriteLine("Invalid operator!");
                    return 0;
            }
        }
        //---------------------------------Calculator Ends-----------------------------------------//
        //-----------------------------------------------------------------------------------------//



        //------------------------------ Temprature Converter Start-------------------------------//
        //----------------------------- Menu for tempConvertor------------------------------------//
        static void TempConverter()
        {
            
            Console.Clear();
            while (true)
            {
                
                CalculatorAPP.DisplayTempMenu(); //user chooses between 1-4 

                var inputAnswer = Console.ReadLine();

                switch (inputAnswer)
                {
                    case "1":
                        Console.Clear();
                        ConvertCelsiusToFahrenheitAndKelvin();
                        break;
                    case "2":
                        Console.Clear();
                        ConvertFahrenheitToCelsiusAndKelvin();
                        break;
                    case "3":
                        Console.Clear();
                        ConvertKelvinToFahrenheitAndCelcius();
                        break;
                    case "4":
                        // Exit the program
                        Console.Clear();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        HandleInputError("Invalid input! Please enter a valid number (1-3).");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                }

            }

        }
        //--------------------- Method for converting from Celcius -------------------------------//
        static void ConvertCelsiusToFahrenheitAndKelvin()  //
        {
            double celsius = CheckForNumber("Enter temperature in Celsius: ");


            double cToF = (celsius * 9 / 5) + 32;     // to celcius to fahrenheit 
            double cToK = celsius + 273.15;           // to celcius to Kelvin
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Kelvin: {cToK}, Fahrenheit: {cToF}"); //show the rsult in cosole 
            Console.WriteLine("-------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //----------------------- method for converting from Fahrenheit---------------------------//
        static void ConvertFahrenheitToCelsiusAndKelvin() 
        {
            double fahrenheit = CheckForNumber("Enter temperature in Fahrenheit: ");
            double fToK = (fahrenheit - 32) * 5 / 9 + 273.15;  
            double fToC = (fahrenheit - 32) * 5 / 9;       
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Kelvin: {fToK}, Celcius: {fToC}");
            Console.WriteLine("-------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

        }
        //-----------------------//Method for converting from Kelvin------------------------------//
        static void ConvertKelvinToFahrenheitAndCelcius() 
        {
            double kelvin = CheckForNumber("Enter temperature in Kelvin: ");
            double kToF = (kelvin - 273.15) * 5 / 9 + 32; 
            double kToC = kelvin - 273.15;             

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Fahrenheit: {kToF}, Celcius: {kToC}");
            Console.WriteLine("-------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

        }

        //-------------------------Method for checking if input is correct------------------------//
        static double CheckForNumber(string inputTemprature)
        {
            while (true)
            {
                Console.Write(inputTemprature);
                if (double.TryParse(Console.ReadLine(), out double temperature))
                {
                    return temperature;
                }

                HandleInputError("Invalid input! Please enter a in numbers.");
            }
        }
        //-------------------------- Temprature Converter End ------------------------------------//
        //----------------------------------------------------------------------------------------//


    }
}
