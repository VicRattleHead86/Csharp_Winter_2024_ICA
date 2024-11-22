/*
 * Giezar Panaligan ICA02
 * 
 * Jan 16, 2024
 * CMPE1300 - ICA 2
 * 
 * Pseudo Code
 *      Display titles
 *      prompt for name of the energy drink
 *      read the name of the energy drink
 *      prompt for cost of each pack and save costs
 *      prompt for the number of cans to purchase
 *      
 *      calculate how many of each pack using integer math
 *      calculate cost for the number of packs
 *      
 *      Display the total costs per pack, total cost.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ICA02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variable Declarations
            string sTitle = "Giezar Panaligan Assignment 02";                                               // Set the value of Assignment number
            string sEnergyDrinkName = "";                                                                   // Energy drink name
            double dCost12 = 0.0;                                                                           // Cost per dozen
            double dCost6 = 0.0;                                                                            // Cost per 6 pack
            double dCost1 = 0.0;                                                                            // Cost per single can
            int iNumberOfCans = 0;                                                                          // Number of cans needed
            int i12Cans = 0;                                                                                // How many 12 cans needed
            int i6Cans = 0;                                                                                 // Hom many 6 cans needed
            int i1Cans = 0;                                                                                 // How many single cans needed
            int iLeft = 0;                                                                                  // How many cans left over
            double dCost12Amount = 0.0;                                                                     // Cost of dozen of cans needed
            double dCost6Amount = 0.0;                                                                      // cost of 6 packs needed
            double dCostSingleAmount = 0.0;                                                                 // Cost of single pack needed
            double dTotal = 0.0;                                                                            // Total cost for all cans
            var builder = new StringBuilder();
            builder.AppendLine()
                   .Append('-', 62)
                   .AppendLine();


            // Main Program body
            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;                                 // display the title in the middle
            Console.WriteLine(sTitle + "\n\n");

            // Prompt user for name of energy drink
            Console.Write("Enter the name of the energy drink: ");
            sEnergyDrinkName = Console.ReadLine();                                                          // Read string of name of energy drink

            // Prompt user for the cost of a dozen of energy drink
            Console.Write($"Enter the cost of a dozen of {sEnergyDrinkName}: ");
            dCost12 = double.Parse( Console.ReadLine());                                                    // Read string cost per dozen and convert to double

            // Prompt user for the cost of a six pack of energy drink
            Console.Write($"Enter the cost of a six pack of {sEnergyDrinkName}: ");                         // Read string cost per six pack and convert to double
            dCost6 = double.Parse(Console.ReadLine());

            // Prompt user for the cost of a single can energy drink
            Console.Write($"Enter the cost of a single can of {sEnergyDrinkName}: ");                       // Read string cost per single can and convert to double
            dCost1 = double.Parse(Console.ReadLine());

            // Prompt user for the number of cans
            Console.Write($"Enter the number of {sEnergyDrinkName} cans to purchase: ");
            iNumberOfCans = int.Parse(Console.ReadLine());                                                  // Read string the number of can and convert to double

            // Calculate how many of each type of cans using Integer Math
            iLeft = iNumberOfCans;                                                                          // how many cans
            i12Cans = iLeft / 12;                                                                           // how many dozen
            iLeft %= 12;                                                                                    // how many left
            i6Cans = iLeft / 6;                                                                             // how many six packs
            iLeft %= 6;                                                                                     // how many left
            i1Cans = iLeft / 1;                                                                             // how many single can
            iLeft %= 1;                                                                                     // how many left

            if (iLeft > 0)                                                                                  // branch if there are left overs and add 1 to can
                i1Cans++;

            // Calculate how much for the different packs
            dCost12Amount = i12Cans * dCost12;
            dCost6Amount = i6Cans * dCost6;
            dCostSingleAmount = i1Cans * dCost1;
            dTotal = dCost12Amount + dCost6Amount + dCostSingleAmount;                                      // Calculate the total

            Console.WriteLine(builder);

            // Display Results
            Console.WriteLine($"Dozens to purchase: {i12Cans} @ {dCost12:C2} = {dCost12Amount:C2}");
            Console.WriteLine($"Six packs to purchase: {i6Cans} @ {dCost6:C2} = {dCost6Amount:C2}");
            Console.WriteLine($"Singles to purchase: {i1Cans} @ {dCost1:C2} = {dCostSingleAmount:C2}\n");
            Console.WriteLine($"Total cost: {dTotal:C2}");
            
            Console.WriteLine("\nPress any key to exit:");
            Console.ReadKey();
        }
    }
}
