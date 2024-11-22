/*
 * Giezar Panaligan ICA15
 * 
 * Apr 1, 2024
 * CMPE1300 - ICA 15
 * 
 * Pseudo Code
 *      Display titles and Prompt the user to enter the size of an array
 *      value entered will be validated criteria are the following
 *          not alpha numeric
 *          lenght should be 4 - 10
 *      Once value has been validated it will be passed to another method MakeRecords
 *          MakeRecords will create an array based on the input given
 *          it will generate a random names with the size of 5 - 12
 *          it will generate a random grades from 0.0 - 100.0
 *          it will get the average grade and display on the screen
 *          the a label of the names and marks will be displyed
 *          the list of all students togethere with the grades will be displyed.
 *          the student that got the average grade will also be displayed with grades
 *      The program will display another list this time tha students that got the failing grades    
 *      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA15
{
    internal class Program
    {
        // Main program
        static void Main(string[] args)
        {
            string sTitle = "Giezar Panaligan - ICA15\n";                                                                                        // String for title
            char cRepeat = 'n';                                                                                                                  // Set the character for iteration checkin
            int iLowLimit = 4;                                                                                                                   // Set the lowest limit                                                                                                              
            int iHighLimit = 10;                                                                                                                 // Set the highest limit


            do
            {

                Console.Clear();

                DispTitle(sTitle);
            
                GetValue(out int iArrayLenght, "Enter the number of students in class: ", iLowLimit, iHighLimit);

                MakeRecords(iArrayLenght);

                // loop to program run checking
                do
                {
                    Console.Write("\nRun program again? (y/n): ");
                    cRepeat = char.ToLower(Console.ReadKey().KeyChar);

                    if (cRepeat != 'y' && cRepeat != 'n')
                    {
                        Console.WriteLine("\nInvalid response, please try again");
                    }
                }
                while (cRepeat != 'y' && cRepeat != 'n');
            }
            while (cRepeat == 'y');
        }
        
        // Generate the random name
        private static string GenerateRandomName(Random random, int length)
        {
            // Generate the first character (capital letter)
            char firstChar = (char)random.Next(65, 91); // 'A' to 'Z'
            string name = firstChar.ToString();

            // Generate the rest of the characters (lowercase letters)
            for (int j = 1; j < length; j++)
            {
                char nextChar = (char)random.Next(97, 123); // 'a' to 'z'
                name += nextChar;
            }

            return name;
        }

        // process input from user
        static public int GetValue(out int iALenght, string sPrompt, double dMin, double dMax)
        {
            bool bValid = false;
            do
            {
                Console.Write(sPrompt);
                bValid = int.TryParse(Console.ReadLine(), out iALenght);

                if (!bValid)
                {
                    Console.WriteLine("An invalid number was entered. Please try again.");
                    bValid = false;
                }
                else if (bValid == true && (iALenght < dMin || iALenght > dMax))
                {
                    Console.WriteLine("The value entered is outside the range accepted.");
                    bValid = false;
                }
                else
                {
                    bValid = true;
                }
            }
            while (!bValid);

            return iALenght;
        }

        static void MakeRecords(int iALenght)
        {
            // Initialize the random number generator
            Random random = new Random();

            // Specify the number of student names you want to generate
            int iNumberOfStudents = iALenght;

            // Create arrays to hold the student names and their random marks
            string[] studentNames = new string[iNumberOfStudents];
            double[] marks = new double[iNumberOfStudents];

            // Header for the output
            Console.WriteLine();
            Console.WriteLine("Name            | Mark");
            Console.WriteLine("----------------|------");

            for (int i = 0; i < iNumberOfStudents; i++)
            {
                // Generate a random length for the student name, between 5 and 12
                int iNameLength = random.Next(5, 13);

                // Start building the student name
                string studentName = GenerateRandomName(random, iNameLength);
                studentNames[i] = studentName;

                // Generate a random mark
                double randomMark = random.NextDouble() * 100;
                marks[i] = randomMark;

                // Print the name and the mark
                Console.WriteLine($"{studentName.PadRight(16)}: {randomMark,5:F1}");
            }

            // Calculate the average of the marks
            double average = marks.Average();

            // Find the name that is closest to the average
            double closestDifference = marks.Min(mark => Math.Abs(mark - average));
            string closestName = studentNames[Array.IndexOf(marks, marks.First(mark => Math.Abs(mark - average) == closestDifference))];

            // Print the average and the closest name
            Console.WriteLine($"\nThe average of the marks is {average:F1} percent.");
            Console.WriteLine($"{closestName} with {marks[Array.IndexOf(studentNames, closestName)]:F1} is closest to the average.");

            // Identify failing students (assuming a failing mark is below 50.0)
            Console.WriteLine("\nHere is a list of failing students...\n");

            // Header for failing students output
            Console.WriteLine("Name            | Mark");
            Console.WriteLine("----------------|------");

            for (int i = 0; i < iNumberOfStudents; i++)
            {
                if (marks[i] < 50.0)
                {
                    // Print the name and the mark of failing students
                    Console.WriteLine($"{studentNames[i].PadRight(16)}: {marks[i],5:F1}");
                }
            }
        }
        // Displays the tile on top
        static void DispTitle(string sTitle)
        {
            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;
            Console.WriteLine(sTitle);
        }
    }
}
