/*
 * Giezar Panaligan ICA03
 * 
 * Jan 25, 2024
 * CMPE1300 - ICA 3
 * 
 * Pseudo Code
 *      Display titles
 *      prompt for the value of the radius of a circle or a sphere
 *      read the value of the radius
 *      check the validity of the radius, prompt exit of the program if invalid
 *      
 *      If the radius is valid prompt for the desired calculation (area or volume)
 *      read the value of the desired calculation
 *      check the validity of the desired calculation value, or prompt the exit of the program if invalid
 *      
 *      if both radius and desired calculation are valid perform calculation
 *      Display the calculated area or volume together with the provided radius otherwise prompt the exit of the program if invalid
 *      prompt exit of the program.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variable Declarations
            string sTitle = "Giezar Panaligan Assignment 3";                                                                // Set the value of Assignment title
            double dRadiusOrSphere = 0.0;                                                                                   // Set the value of the Radius
            double dCalcAreaOfCircle = 0.0;                                                                                 // Set the value of Calculated Area of a circle
            double dAreaOrVolume = 0.0;                                                                                     // Set the value of calculated volume
            string sDesiredCalc = "";                                                                                       // Set the value of desired calculation
            bool bValid = false;                                                                                            // Set the boolean value to for checking

            // Main program body
            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;                                                 // display the title in the middle
            Console.WriteLine(sTitle + "\n");

            // Prompt user to enter the radius of a circle
            Console.Write("Enter the radius of a circle or a sphere: ");                                                    
            bValid = double.TryParse(Console.ReadLine(), out dRadiusOrSphere);                                              // Read the radius value

            if (bValid == true && dRadiusOrSphere > 0)                                                                      // A condition to check for valid radius value
            {
                Console.Write("Please enter the desired calculation ('area' or 'volume'): ");                               // Prompt user to enter desired calculation
                sDesiredCalc = Console.ReadLine().ToLower();

                if (sDesiredCalc == "area")                                                                                 // A condition to check area calculation
                {
                    dCalcAreaOfCircle = Math.PI * (Math.Pow(dRadiusOrSphere, 2));                                                                                   // Area calculation
                    Console.Write($"\nThe area the of a circle with radius of {dRadiusOrSphere:N1} cm is {dCalcAreaOfCircle:N1} square cm.\n");                    // Display the value of the radius and the calculated area
                    Console.Write("\nPress any key to exit: ");
                    Console.ReadKey();
                }
                else if (sDesiredCalc == "volume")
                {
                    dAreaOrVolume = (4.0 / 3.0) * Math.PI * (Math.Pow(dRadiusOrSphere, 3));                                                                               // Volume calculation
                    Console.Write($"\nThe volume the of a circle with radius of {dRadiusOrSphere:N1} cm is {dAreaOrVolume:N1} square cm.\n");                      // Display the value of the radius and the calculated volume
                    Console.Write("\nPress any key to exit: ");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\nYou have entered an invalid desired calculation. The program will exit.\n");                                               // Prompt the user for invalid input
                    Console.Write("Press any key to exit: ");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Write("\nYou have entered an invalid radius value. The program will exit.\n");                                                              // Prompt the user for invalid input
                Console.Write("\nPress any key to exit: ");                                                                                                         // Prompt to press any key
                Console.ReadKey();
            }
        }
    }
}
