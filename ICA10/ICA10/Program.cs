/*
 * Giezar Panaligan ICA10
 * 
 * Mar 13, 2024
 * CMPE1300 - ICA 10
 * 
 * Pseudo Code
 *      Display titles and Prompt the user to enter the following values
 *          Line length in pixels
 *          Angle of increment in degrees
 *          Spacing for the stars
 *          
 *      read the value entered by user by calling the following methods to check the validity
 *          GetDouble check line lenght pixel value then use as parameter to draw a stars
 *          Deg2Rad check the value and convert to radius then use as parameter to draw a stars
 *          GetInt check the value if valid then use as parameter to draw a stars
 *          
 *      if input checks are now valid call the method DrawStar and plug in the values to draw a star
 *      
 *      prompt the user to run the program again (y/*).
 *      Program will repeat if user typed y or Y
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
using System.Runtime.Remoting.Messaging;

namespace ICA10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sTitle = "ICA10 Giezar Panaligan\n";                                                                                         // String to hold the title value
            int iScreenXSize = 800;                                                                                                             // int for X and Y screensize
            int iScreenYSize = 600;                                                                                                             // int for X and Y screensize
            int iSpacingValues = 0;                                                                                                             // Var for spacing
            double dLineLength = 0.0;                                                                                                           // Var for line length
            double dAngleIncrement = 0.0;                                                                                                       // var for angle of increment
            double dLowLimit = 0.0;                                                                                                             // Set the low limit
            double dHighLimit = 20.0;                                                                                                           // Set the High limit
            char cRepeat = 'n';                                                                                                                 // Set the character for iteration checkin
            bool bValid = false;                                                                                                                // boolean for validity checking

            Point point = new Point();                                                                                                          // Call the point instance
            Random random = new Random();                                                                                                       // Call a random instance

            // Main code to call the functions
            using (CDrawer canvas = new CDrawer(iScreenXSize, iScreenYSize, true, true))
            {
                // main loop
                do
                {
                    Console.Clear();
                    DispTitle(sTitle);
                    dLineLength = GetDouble($"Enter the line length in pixels: ", dLowLimit);
                    dAngleIncrement = Deg2Rad($"Enter the angle increment in degrees: ", dLowLimit, dHighLimit);
                    iSpacingValues = GetInt($"Enter the spacing for the stars in pixels: ", (int)dLineLength);
                    DrawStar(canvas, iScreenXSize, iScreenYSize, dLineLength, dAngleIncrement, iSpacingValues);

                    // loop to program run checking
                    do
                    {
                        Console.Write("Run program again? (y/n): ");
                        cRepeat = char.ToLower(Console.ReadKey().KeyChar);

                        if (cRepeat != 'y' && cRepeat != 'n')
                        {
                            Console.WriteLine("Wrong syntax, please try again");
                        }
                    }
                    while (cRepeat != 'y' && cRepeat != 'n');
                }
                while (cRepeat == 'y');
            }
        }

        //Get Double method and validation checking
        static double GetDouble(string dMessage, double dLowLimit)
        {
            double dLineLght = 0.0;
            bool bValid = false;
            do
            {
                Console.Write(dMessage);
                bValid = double.TryParse(Console.ReadLine(), out dLineLght);

                if (!bValid)
                {
                    Console.WriteLine("Invalid number. Please enter a valid double number\n");
                }
                else if (bValid && dLineLght <= dLowLimit)
                {
                    Console.WriteLine($"The lenght is to low. Please enter a lenght higher than {dLowLimit}\n");
                    bValid = false;
                }
            }
            while (!bValid);

            return dLineLght;
        }

        //Display the stars method and passing of the parameters
        static void DrawStar(CDrawer canvas, int iScreenXSize, int iScreenYSize, double dLineLength, double dAngleIncrement, int iSpacing)
        {
            Point point = new Point();
            point.X = 0;
            point.Y = 0;
            Random randColor = new Random();

            canvas.Clear();
            // Loop to display stars
            for (int i = 0; i - dLineLength < iScreenYSize; i += iSpacing)
            {
                point.Y = i;

                for (int x = 0; x - dLineLength < iScreenXSize; x += iSpacing)
                {
                    point.X = x;
                    for (double j = 0; j < Math.PI * 2; j = j + dAngleIncrement)
                    {
                        canvas.AddLine(point, dLineLength, j, Color.FromArgb(randColor.Next()), 1);
                    }
                }
            }
            return;
        }

        //Degree to radius method and validation checking
        static double Deg2Rad(string dMessage, double dLowLimit, double dHighLimit)
        {
            bool bValid = false;
            double dDegree = 0.0;
            double dRadius = 0.0;
            do
            {
                Console.Write($"{dMessage}");
                bValid = double.TryParse(Console.ReadLine(), out dDegree);

                if (!bValid)
                {
                    Console.WriteLine("Invalid number. Please enter a valid double number\n");
                }
                else if (bValid && dDegree <= dLowLimit)
                {
                    Console.WriteLine($"The value is to low. Please enter a lenght higher than {dLowLimit}\n");
                    bValid = false;
                }
                else if (bValid && dDegree > dHighLimit)
                {
                    Console.WriteLine("The value is too low or high Please enter in 1 to 20 range\n");
                    bValid = false;
                }
                else
                {
                    dRadius = dDegree * Math.PI / 180;
                }
            }
            while (!bValid);

            return dRadius;
        }

        //Get Integer method and validation checking
        static int GetInt(string siMessage, int dLowLimit)
        {
            int iSpacingValues = 0;
            bool bValid = false;

            do
            {
                Console.Write($"{siMessage}");
                bValid = int.TryParse(Console.ReadLine(), out iSpacingValues);

                if (!bValid)
                {
                    Console.WriteLine("\"Invalid number. Please enter a valid integer number\n");
                }
                else if ((bValid && iSpacingValues < 2 * dLowLimit))
                {
                    Console.WriteLine("Stars cannot be displayed properly. Please enter a value twice as high as Line Length.\n");
                    bValid = false;
                }
            }
            while (!bValid);
            return iSpacingValues;
        }

        // Display the title method
        static void DispTitle(string sMessage)
        {
            Console.CursorLeft = (Console.WindowWidth - sMessage.Length) / 2;
            Console.WriteLine(sMessage);
            return;
        }
    }
}
