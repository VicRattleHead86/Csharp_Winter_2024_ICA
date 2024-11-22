/*
 * Giezar Panaligan ICA01
 * 
 * Jan 15, 2024
 * CMPE1300 - ICA 1
 * 
 * Pseudo Code
 *      Display titles
 *      prompt for number of cans
 *      read number of can
 *      prompt for cost per can
 *      
 *      calculate the gst cost
 *      calculate the totalcost
 *      
 *      Display the calculated GST
 *      Display the total cost, and total with GST
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variable Declarations
            string sTitle = "ICA01 - Giezar Panaligan";                                                 // Set the value of Assignment number
            int inumOfCans = 0;                                                                         // Set a default value for number of cans to zero
            double dcostPerCan = 0;                                                                     // Set a default value for the cost to zero
            double dgstCost = 0;                                                                        // Set dgstCost to zero 
            double dtotalCost = 0;                                                                      // Set dtotalCost to zero


            // Main program body
            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;                             // display the title in the middle
            Console.WriteLine(sTitle + "\n");

            // Prompt user for number of cans
            Console.Write("Enter the number of cans of pop to purchase: ");
            inumOfCans = int.Parse(Console.ReadLine());                                                 // Read string of number of cans convert to int

            // Prompt user for cost per can
            Console.Write("Enter the cost per can: ");
            dcostPerCan = Convert.ToDouble(Console.ReadLine());                                         // read in cost per can

            // calculate for GST cost and total cost
            dgstCost = (inumOfCans * dcostPerCan) * 0.05;                                                // calculate for GST cost
            dtotalCost = (inumOfCans * dcostPerCan) + dgstCost;                                          // calculate for total cost

            // Display GST cost
            Console.WriteLine("\n");
            Console.Write($"The GST is {dgstCost:C2}");

            // Display total cost
            Console.WriteLine("\n");
            Console.Write($"The total cost is {dtotalCost:C2}");

            Console.WriteLine("\n");
            Console.Write("Press the <enter> key to exit: ");
            Console.ReadLine();
        }
    }
}
