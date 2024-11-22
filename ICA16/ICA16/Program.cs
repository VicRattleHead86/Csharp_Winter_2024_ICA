/*
 * Giezar Panaligan ICA16
 * 
 * Apr 6, 2024
 * CMPE1300 - ICA 16
 * 
 * Pseudo Code
 *      Display titles and Prompt the user to enter the following values
 *          Integer values
 *          Positive integer with minimum value
 *          Positive integer with minimum and maximum value
 *      Clear the drawer window and fill the array with zeros
 *      Input the number of squares, Randomly assign ones to unique locations in the array
 *      Ensure uniqueness, Assign one to the location
 *      Display the contents of the array to the drawer, 
 *      Program should generate the rectangle base from the input and the width and height of the drawer.
 *      Ask the user to invert the grid to emphasize the difference
 *      Invert the contents of the array
 *      Display the new contents of the array to the drawer
 *      Program should generate the rectangle invertedly
 *      Ask the user if they wish to create another grid or exit
 *      If the user enters 'q', exit the loop
 *      Clear the drawer for the next run
 *      Ask the user to run the program again
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


namespace ICA16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Constants variables
            const int iScale = 10;                                                                                                                     // Scaling factor for GDIDrawer and square size
            const int iWidth = 80;                                                                                                                     // Width of the drawer and array in terms of squares
            const int iHeight = 60;                                                                                                                    // Height of the drawer and array in terms of squares

            string sTitle = "Giezar Panaligan - ICA16";
            
            // Create a GDIDrawer window using WIDTH, HEIGHT, and SCALE
            CDrawer drawer = new CDrawer(iWidth * iScale, iHeight * iScale, false, true);

            bool continueRunning = true;

            DisplayTitle(sTitle);


            // Main Program
            do
            {
                // Clear the drawer window and fill the array with zeros
                drawer.Clear();
                int[,] grid = new int[iWidth, iHeight]; // 2D array for grid

                // Input the number of squares
                Console.Write($"\nEnter the number of squares to display (100 to {iWidth * iHeight}) :");
                int numSquares = GetValue(100, iWidth * iHeight);

                // Randomly assign ones to unique locations in the array
                Random rand = new Random();
                for (int i = 0; i < numSquares; i++)
                {
                    int x, y;
                    do
                    {
                        x = rand.Next(iWidth);
                        y = rand.Next(iHeight);
                    } while (grid[x, y] == 1); // Ensure uniqueness

                    grid[x, y] = 1; // Assign one to the location
                }

                // Display the contents of the array to the drawer
                DisplayGrid(drawer, grid, iWidth, iHeight, iScale);

                // Invert the contents of the array
                InvertGrid(grid, iWidth, iHeight);

                // Display the new contents of the array to the drawer
                Console.Write("Press any key to display the inverted grid: ");
                Console.ReadKey();
                DisplayGrid(drawer, grid, iWidth, iHeight, iScale);

                // Ask the user if they wish to create another grid or exit
                Console.Write("\nPress 'q' to quit or any other key to create another grid: ");
                var keyInfo = Console.ReadKey();

                // If the user enters 'q', exit the loop
                continueRunning = keyInfo.Key != ConsoleKey.Q;

                if (continueRunning)
                {
                    drawer.Clear(); // Clear the drawer for the next run
                }

            } while (continueRunning);
        }

        static void DisplayTitle(string sTitle)
        {
            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;
            Console.WriteLine(sTitle);
        }

        // methods to accept WIDTH, HEIGHT, and SCALE as parameters
        static void DisplayGrid(CDrawer drawer, int[,] grid, int width, int height, int scale)
        {
            drawer.Clear(); // Clear previous drawings

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    drawer.AddRectangle(i * scale, j * scale, scale, scale, grid[i, j] == 1 ? System.Drawing.Color.Yellow : System.Drawing.Color.Black);
                }
            }

            drawer.Render(); // Render the drawing
        }

        static void InvertGrid(int[,] grid, int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    grid[i, j] = grid[i, j] == 0 ? 1 : 0; // Invert the value
                }
            }
        }

        static int GetValue(int min, int max)
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            {
                Console.Write($"\nInvalid input. Please enter a number between {min} and {max}:");
            }
            return value;
        }
    }
}
