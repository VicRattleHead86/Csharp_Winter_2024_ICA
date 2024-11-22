/*
 * Giezar Panaligan ICA08
 * 
 * March 5, 2024
 * CMPE1300 - ICA 8
 * 
 * Pseudo Code
 *      Display titles and Prompt the user to enter size and number of squares
 *      read the value entered by user and check for validity
 *      Prompt an error message depending on the value that user has entered
 *          Prompt error will be processed by looping statement
 *          Prompt question will be processed by looping statement
 *      
 *      if inputs are valid do the loop using the input and display the output based on the input.
 *          Either print an asterisk (*) in a line, square or triangle
 *      prompt the user to run the program again (y/n).
 *      Program will repeat if user typed y or Y
 *      
 */

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ICA08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variables
            string sTitle = "Giezar Panaligan Assignment 8\n\n";                                                                                            // Set the string for title
            string sQuestion1 = "Enter the shape size: ";                                                                                                   // Set the var for initial question
            int iShapeSize;                                                                                                                                 // initialized the var for the shapre
            char cRepeat = 'n';                                                                                                                             // flag to repea the game or not

            // Main program body

            // Main iteration
            do
            {
                Console.Clear();                                                                                                                            // Clear the console
                bool bValid = true;                                                                                                                         // initilized the valid flag to true
                string sShapeType;
                Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;
                Console.WriteLine(sTitle);                                                                                                                  // Display title at the center
                
                // Main iteration for the prompt question
                do
                {
                    Console.Write(sQuestion1);
                    // Check the validity of the input for size of the square
                    if (!int.TryParse(Console.ReadLine(), out iShapeSize))                                                                                  // Captures invalid input
                    {
                        Console.Write("You have entered an invalid number.");
                        sQuestion1 = "\nEnter the shape size as a whole number: ";
                        bValid = false;
                    }
                    else if (iShapeSize < 5)                                                                                                                // Captures too low input
                    {
                        Console.Write("The shape size is too small.");
                        sQuestion1 = "\nEnter the shape size: ";
                        bValid = false;
                    }
                    else if (iShapeSize > 25)                                                                                                               // Captures too high input
                    {
                        Console.Write("The shape size is too large: ");
                        sQuestion1 = "\nEnter the shape size: ";
                        bValid = false;
                    }
                    else if (iShapeSize >= 5 && iShapeSize <= 25)                                                                                           // Captures the input that is in range
                    {
                        // Sub iteration for shapes choice
                        do
                        {
                            Console.Write("Enter desired shape: 'line', 'square', or 'triangle': ");
                            sShapeType = Console.ReadLine();

                            // Line for loop displays line
                            if (sShapeType == "line")
                            {
                                for (int i1 = 0; iShapeSize > i1; i1++)
                                {
                                    for (int i2 = 0; i1 > i2; i2++)
                                    {
                                        if (i1 > 0)
                                        {
                                            Console.Write($" ");
                                        }
                                    }
                                    Console.Write($"*\n");
                                }
                                bValid = true;
                            }

                            // Square for loop displays the square
                            else if (sShapeType == "square")
                            {
                                for (int i1 = 0; iShapeSize > i1; i1++)
                                {
                                    for (int i2 = 1; iShapeSize > i2; i2++)
                                    {
                                        Console.Write($"*");
                                    }
                                    Console.Write($"*\n");
                                }
                                bValid = true;
                            }
                            // triangle for loop displays the triangle
                            else if (sShapeType == "triangle")
                            {
                                for (int i1 = 0; iShapeSize > i1; i1++)
                                {
                                    for (int i2 = 0; i1 > i2; i2++)
                                    {
                                        if (i1 > 0)
                                        {
                                            Console.Write($"*");
                                        }
                                    }
                                    Console.Write($"*\n");
                                }
                                bValid = true;
                            }
                            else
                            {
                                Console.Write("You have entered an invalid shape.\n");
                                bValid = false;
                            }
                        }
                        while (!bValid);
                    }
                }

                while (!bValid);

                // Prompt asking to repeat the program or not.
                Console.Write("Run the program again? y/n: ");
                cRepeat = char.ToLower(Console.ReadKey().KeyChar);
            }
            // Condition set to check if program will be repeated.
            while (cRepeat == 'y');
        }
    }
}
