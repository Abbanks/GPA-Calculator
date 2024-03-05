using System;
using System.Text.RegularExpressions;

namespace GPA_Calculator
{
    class Program()
    {
        public static void Main(string[] args)
        {

            CenterTitle("GPA CALCULATOR");
            Console.WriteLine("This program computes your GPA \n");

            string stdName = GetValidName();
            
            GPACalculator calc = new GPACalculator();

            calc.InputCourseData();

            Console.WriteLine($"\t \t Result for {stdName}");
            calc.PrintResult();
        }

        public static void CenterTitle(string text)
        {
            int consoleWidth = Console.WindowWidth;
            int leftPadding = (consoleWidth - text.Length) / 2;

            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            Console.WriteLine(text);
        }

        public static string GetValidName()
        {
            string name;
            bool isValid = false;
 
            string pattern = @"^[A-Za-z\s\-]+$";

            do
            {
                Console.Write("Enter your name: ");
                name = Console.ReadLine();

                // Perform validation using regular expression
                isValid = Regex.IsMatch(name, pattern);

                if (!isValid)
                {
                    Console.WriteLine("Invalid name. Please enter only letters, spaces, and hyphens.");
                }
            } while (!isValid);

            return name;
        }

    }
}