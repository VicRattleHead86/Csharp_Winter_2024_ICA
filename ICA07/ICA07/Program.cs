/*
 * Giezar Panaligan ICA06
 * 
 * Feb 26, 2024
 * CMPE1300 - ICA 7
 * 
 * Pseudo Code
 *      Display titles and Prompt the user to enter size and number of squares
 *      read the value entered by user and check for validity
 *      if input is valid proceed with generating random grades
 *      if not prompt a message error and ask user to enter input again
 *      display average based on the randomized double number
 *      
 *      Once the output has been displayed ask user if wants to run the program again
 *      if user choose to run again again it will repeat from the first step and prompt question again.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variable declarations
            string sTitle = "ICA07 Giezar Panaligan";                                                                                       // string to store title
            int iNumOfGrades;                                                                                                               // var to store num of grades
            int iFailed;                                                                                                                    // var to store num of failed grades
            double min = 0.0;                                                                                                               // set min val for grades
            double max = 100.0;                                                                                                             // set max val for grades
            double dRandoGrade;                                                                                                             // var for random grades
            double dAveGrade = 0.0;                                                                                                         // var to store avarage
            int iNumOfGradesCalc;                                                                                                           // var to store the calculation of grade
            bool bValid;                                                                                                                    // bool var to validity checking
            char cRepeat = 'n';                                                                                                             // Set the character for iteration checking

            Random rndGrades = new Random();                                                                                                // create an instance of of random

            // Do while loop to repeat or not repeat the program
            do
            {
                // set or reset all the variables
                Console.Clear();
                Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;
                Console.WriteLine(sTitle);
                iFailed = 0;
                iNumOfGrades = 0;
                dRandoGrade = 0.0;
                dAveGrade = 0.0;

                // do while loop for prompt questions to user and for generating an error message
                do
                {
                    Console.Write("Enter the number of grades to generate: ");
                    bValid = true;

                    // Branching to check the validity of the input
                    if (!int.TryParse(Console.ReadLine(), out iNumOfGrades))
                    {
                        Console.WriteLine("You have entered an invalid number.");
                        bValid = false;
                    }
                    else if (iNumOfGrades <= 4)
                    {
                        Console.WriteLine("You have entered a value that is too low.");
                        bValid = false;
                    }
                    else if (iNumOfGrades > 10)
                    {
                        Console.WriteLine("You have entered a value that is too high.");
                        bValid = false;
                    }
                    else if (bValid) 
                    {
                        Console.WriteLine("\nHere are the generated grades...\n");
                        iNumOfGradesCalc = iNumOfGrades;
                        // Do while to capture every single grades generated in random
                        do
                        {
                            // setting the random number's min and max and summing all the numbers
                            dRandoGrade = rndGrades.NextDouble() * ((min - max) + min) * -1;
                            Console.Write($"{dRandoGrade:F1} ");
                            iNumOfGrades--;
                            dAveGrade += dRandoGrade;

                            // capture failure grades
                            if (dRandoGrade < 50.0)
                            {
                                iFailed++;
                            }
                        }
                        while (iNumOfGrades >= 1);
                        // displayingk the average grade
                        Console.WriteLine($"\n\nThe average grade was {dAveGrade / (double)iNumOfGradesCalc:F1}%.");
                        // Branch to check if there is a failure and display
                        if (iFailed > 0)
                        {
                            Console.WriteLine($"There were {iFailed} failures.");
                        }
                    }
                }
                // do while pair for validity checking
                while (bValid == false);
            
                Console.Write("\nRun the program again? (y/n): ");
                cRepeat = char.ToLower(Console.ReadKey().KeyChar);
            }
            // do while pair to repeat or not repeat the program
            while (cRepeat == 'y');
        }
    }
}
