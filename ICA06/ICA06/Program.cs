/*
 * Giezar Panaligan ICA06
 * 
 * Feb 12, 2024
 * CMPE1300 - ICA 6
 * 
 * Pseudo Code
 *      Display titles and Prompt the user to enter size and number of squares
 *      read the value entered by user and check for validity
 *      if an input is invalid to either one, prompt another question again repeat the task using loops
 *      
 *      if inputs are valid do the loop using the input and display the output based on the input.
 *      prompt the user to run the program again (y/*).
 *      Program will repeat if user typed y or Y
 *      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
using System.Threading;

namespace ICA06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variables
            string sTitle = "ICA06 Giezar Panaligan\n\n";
            string sIMessage1 = "Enter the size of the squares: ";
            string sIMessage2 = "Enter the number of squares to display: ";
            int iSquareSize = 0;                                                                                                                    // Variable for Square size
            int iNumOfSquare = 0;                                                                                                                   // Variable for number of square
            int iMinNumOfSquare = 0;                                                                                                                // Variable for Minimun number of Square
            int iMinSquareSize = 10;                                                                                                                // Varialble for Minimum square size
            int iMaxSquareSize = 200;                                                                                                               // Variable for Maximum square size
            int iXRange = 0;                                                                                                                        // Variable for measuring and referencing the X range
            int iYRange = 0;                                                                                                                        // Variable for measuring and referencing the Y range
            int iXPosition = 0;                                                                                                                     // Variable for X coordinate
            int iYPosition = 0;                                                                                                                     // Variable for Y coordinate
            int iScreenXSize = 800;                                                                                                                 // Var for the screen width
            int iScreenYSize = 600;                                                                                                                 // Var for the screen height
            Random random = new Random();                                                                                                           // to get the random number
            Point point = new Point();                                                                                                              // Create a new instance of Point method

            CDrawer Canvas = new CDrawer(iScreenXSize, iScreenYSize, true, true);                                                                   // Create instance of CDrawer method

            bool bValid = true;                                                                                                                     // Set the boolean var for validity checking
            char cRepeat = 'n';                                                                                                                     // Set the character for iteration checking

            // Main iteration
            do
            {
                // Perform clearing the console the the GDIDrawer
                Console.Clear();
                Canvas.Clear();

                // Main program body
                Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;
                Console.WriteLine(sTitle);
                
                int iSquareCtr = 0;                                                                                                                   // Initialize the counter for while loop iteration

                // Iteration for the size of the square
                do
                {
                    Console.Write(sIMessage1);
                    bValid = true;
                    // Check the validity of the input for size of the square
                    if (!int.TryParse(Console.ReadLine(), out iSquareSize))
                    {
                        Console.WriteLine("An invalid square size was entered. Please try again.");
                        bValid = false;
                    }
                    else if (iSquareSize < iMinSquareSize)
                    {
                        Console.WriteLine("The value entered is below the accepted range.");
                        bValid = false;
                    }
                    else if (iSquareSize > iMaxSquareSize)
                    {
                        Console.WriteLine("The value entered is above the accepted range.");
                        bValid = false;
                    }
                }
                while (!bValid);

                // Iteration for number of squares
                do
                {
                    Console.Write(sIMessage2);
                    bValid = true;
                    // Check the validity of the input for the number of square
                    if (!int.TryParse(Console.ReadLine(), out iNumOfSquare))
                    {
                        Console.WriteLine("An invalid input was entered. Please try again.");
                        bValid = false;
                    }
                    else if (iNumOfSquare <= iMinNumOfSquare)
                    {
                        Console.WriteLine("The value entered is below the accepted range.");
                        bValid = false;
                    }
                    else if (bValid == true)
                    {
                        // Iteration for displaying the square on GDIDrawer
                        while (iSquareCtr < iNumOfSquare)
                        {
                            // Set the X and Y coordinate
                            point.X = random.Next(0, iScreenXSize);
                            point.Y = random.Next(0, iScreenYSize);

                            // Set the values to make sure squares will follow the display requirements
                            iXRange = (iSquareSize - (iScreenXSize - point.X));
                            iXPosition = (point.X - iXRange);
                            iYRange = (iSquareSize - (iScreenYSize - point.Y));
                            iYPosition = (point.Y - iYRange);
                            point.X = (point.X + iSquareSize <= iScreenXSize) ? (point.X) : (point.X = iXPosition);
                            point.Y = (point.Y + iSquareSize <= iScreenYSize) ? (point.Y) : (point.Y = iYPosition);

                            // Performs the displaying of the squares.
                            Canvas.AddRectangle(point.X, point.Y, iSquareSize , iSquareSize, RandColor.GetColor());

                            // counter for while loop checking
                            iSquareCtr++;
                        }
                    }
                }
                while (!bValid);

                // Prompt asking to repeat the program or not.
                Console.Write("\nRun program again? (y): ");
                cRepeat = char.ToLower(Console.ReadKey().KeyChar);
            }
            // Condition set to check if program will be repeated.
            while (cRepeat == 'y');
        }
    }
}
