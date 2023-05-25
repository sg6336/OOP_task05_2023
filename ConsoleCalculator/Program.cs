using System;
using System.IO;
using LibraryCalculator;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Perform calculations from console input");
                Console.WriteLine("2. Perform calculations from file");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice (1-3): ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine();
                    PerformConsoleCalculations();
                    Console.WriteLine();
                }
                else if (choice == "2")
                {
                    Console.WriteLine();
                    PerformFileCalculations();
                    Console.WriteLine("Calculations completed. Check the output file for results.");
                    Console.WriteLine();
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                }
            }
        }

        static void PerformConsoleCalculations()
        {
            while (true)
            {
                Console.Write("Enter an expression (or 'e' to Exit): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "e")
                    break;

                string result = Calculator.Calculate(input);
                Console.WriteLine($"Result: {result}");
                Console.WriteLine();
            }
        }

        static void PerformFileCalculations()
        {
            Console.Write("Enter the input file path: ");
            string inputFilePath = Console.ReadLine();

            Console.Write("Enter the output file path: ");
            string outputFilePath = Console.ReadLine();

            try
            {
                using (StreamReader reader = new StreamReader(inputFilePath))
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string expression = line.Trim();
                        string result = Calculator.Calculate(expression);
                        writer.WriteLine($"{expression} = {result}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}