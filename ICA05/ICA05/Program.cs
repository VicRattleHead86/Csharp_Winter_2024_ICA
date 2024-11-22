/*
 * Giezar Panaligan ICA05
 * 
 * Feb 12, 2024
 * CMPE1300 - ICA 5
 * 
 * Pseudo Code
 *      Display title and prompt the user to enter the diameter of the circle, and X and Y coordinate
 *      read the value entered by user and check the validity of the inputs
 *      if output is invalid prompt for exit of the program.
 *      
 *      if players input is valid perform the calculation to make the diameter of the circle within the range
 *      if the input is out of range set the default value using conditional statement
 *      Display the circle if the output match the criteria regardless of the range as it can be set by conditional statement.
 *      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
using System.Threading;


namespace ICA05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iScreenXSize = 300;                                                                                                                                         // Set the screen width
            int iScreenYSize = 300;                                                                                                                                         // Set the screen height
            string sTitle = "Giezar Panaligan Assignment 5";                                                                                                                // Set the title
            int iDiameter = 0;                                                                                                                                              // set the circle diameter
            int iDiameterX = 0;                                                                                                                                             // variable to be used for setting and referencing X coordinate
            int iDiameterY = 0;                                                                                                                                             // variable to be used for setting and referencing Y coordinate
            bool isValidWidth;                                                                                                                                              // Set boolean variable for valid witdh checking
            bool isiDiameterX;                                                                                                                                              // Set boolean variable for valid diameter X checking
            bool isiDiameterY;                                                                                                                                              // Set boolean variable for valid diameter Y checking

            CDrawer Canvas = new CDrawer(iScreenXSize, iScreenYSize, true, true);                                                                                           // Create instance of CDrawer method for creating a canvas for display
            Point point = new Point();                                                                                                                                      // Create a new instance of Point method

            // Main program body
            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;                                                                                                 // to display title on the center
            Console.WriteLine(sTitle);                                                                                                                                      // display title

            // Prompt user to enter width of the circle
            Console.Write("\nEnter the diameter of the Circle: ");
            isValidWidth = int.TryParse(Console.ReadLine(), out iDiameter);
            
            // Check the validity of diameter
            if (isValidWidth)
            {
                // Prompt user to enter height of the circle
                Console.Write("Enter the X coordinate: ");
                isiDiameterX = int.TryParse(Console.ReadLine(), out iDiameterX);

                // Check the validity of X coordinate
                if (isiDiameterX)
                {
                    Console.Write("Enter the Y coordinate: ");
                    isiDiameterY = int.TryParse(Console.ReadLine(), out iDiameterY);

                    // Check the validity of Y coordinate
                    if (isiDiameterY)
                    {
                        // Perform the checking and the setting of the value for diameter
                        iDiameter = (iDiameter < 10) ? 10 : iDiameter;
                        iDiameter = (iDiameter > 100) ? 100 : iDiameter;

                        // Perform the checking and the setting of the X and Y coordinates
                        iDiameterX = (iDiameterX < 300) ? iDiameterX : 300;
                        iDiameterX = (iDiameterX > 300) ? 300 : iDiameterX;

                        // Calcualate the X and Y coordinate to fit the cricle within the range.
                        point.X = (iDiameterX - iDiameter / 2 < 0) ? (iDiameter / 2) : ((iDiameterX + iDiameter / 2 > iScreenXSize) ? (iScreenXSize - iDiameter / 2) : (iDiameterX));
                        point.Y = (iDiameterY - iDiameter / 2 < 0) ? (iDiameter / 2) : ((iDiameterY + iDiameter / 2 > iScreenXSize) ? (iScreenXSize - iDiameter / 2) : (iDiameterY));

                        // Call the function to display the circle with input variables as parameters
                        Canvas.AddCenteredEllipse(point, iDiameter, iDiameter, Color.Red);
                    }
                    else
                    {
                        Console.WriteLine("\nPlease enter a valid integer input for Y coordinate");
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease enter a valid integer input for X coordinate");
                }
            }
            else
            {
                Console.WriteLine("\nPlease enter a valid integer input for diameter");
            }
            Console.Write("Press any key to quit ");
            Console.ReadKey();
        }
    }
}
