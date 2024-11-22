/*
 * Giezar Panaligan ICA13
 * 
 * Mar 26, 2024
 * CMPE1300 - ICA 13
 * 
 * Pseudo Code
 *      Display titles and Prompt the user to enter the size of array below are the requirement for the value
 *          4 to 10 is a valid number
 *          cannot be alpha numeric
 *          
 *      read the value entered by user by calling the following methods to check the validity
 *          GetValue() will the value from user and perform validation
 *          MakeArray() create an array based on the user input value
 *          Show() display the value on the screen
 *          Average() perform calculation to get the average.
 *      
 *      prompt the user to run the program again (y/*).
 *      Program will repeat if user typed y or Y
 *      
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA13
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string Prompt1 = "Enter the size of the array: ";                                                   // prompt string
            string sTitle = "Giezar Panaligan - ICA13";                                                         // string for title
            char cRepeat = 'n';                                                                                 // Set the character for iteration checkin

            do
            {
                Console.Clear();

                // Call some of the methods
                DispTitle(sTitle);                                                                              
                GetValue(out int iArraySize, Prompt1);
                MakeArray(iArraySize, out int[] intArray);

                // loop to program run checking
                do
                {
                    Console.Write("Run again? (y/n): ");
                    cRepeat = char.ToLower(Console.ReadKey().KeyChar);

                    if (cRepeat != 'y' && cRepeat != 'n')
                    {
                        Console.WriteLine("Type y or n, please try again");
                    }
                }
                while (cRepeat != 'y' && cRepeat != 'n');
            }
            while (cRepeat == 'y');
        }

        // method for getting the input and perform calculation
        static void GetValue(out int iArraySize, string Prompt1)
        {
            iArraySize = 0;
            bool bValid = false;

            do
            {
                Console.Write(Prompt1);
                bValid = int.TryParse(Console.ReadLine(), out iArraySize );

                if (!bValid)
                {
                    Console.Write("Enter a valid value.\n");
                }
                else if (iArraySize <= 3 || iArraySize > 10)
                {
                    Console.Write("Value is out of range, Please range from 4 - 10.\n");
                    bValid = false;
                }
            }
            while (!bValid);
            return;
        }

        // Method that generate an array this method is also calling some of the methods
        static int[] MakeArray(int iArraySizeCreate, out int[] intArray) 
        {
            Random random = new Random();
                                                                                                    // create array

            intArray = new int[iArraySizeCreate];                                                   // initialize Array of size iSizeArray

            for (int i = 0; i < iArraySizeCreate; i++)
            {
                intArray[i] = random.Next(0,101);                                                  // get random number between 0-100
            }

            Show(ref intArray);
            ShowReverse(ref intArray);
            Average(ref intArray);

            return intArray;
        }

        // Method that display the output on the screen
        static public void Show(ref int[] intArray)
        {

            int ctr = intArray.Length;
            Console.Write("\nThe array contents...\n");

            for (int i = 0; ctr > 0; i++)
            {
                Console.Write($"array[{i}] = {intArray[i]}\n");

                ctr--;
            }

            return;
        }

        // perform the reversing of the array output
        static public void ShowReverse(ref int[] intArray)
        {

            int ctr = intArray.Length - 1;
            Console.Write("\nThe array in reverse...\n");

            for (int i = 0; ctr >= 0; i++)
            {
                Console.Write($"array[{ctr}] = {intArray[ctr]}\n");

                ctr--;
            }

            return;
        }

        // Display the title block
        static void DispTitle(string sTitle)
        {

            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;
            Console.WriteLine(sTitle);
            Console.WriteLine();

            return;
        }

        // Perform calculcation of average.
        static void Average(ref int[] intArray)
        {
            double dAverage = 0;
            int iTotal = 0;
            int iMax = -1;
            int iArrayIndex = -1;

            int ctr = intArray.Length;
            for (int i = 0; ctr > 0; i++)
            {
                ctr--;
                dAverage += intArray[i];

                if (iMax < intArray[i])
                {
                    iMax = intArray[i];
                    iArrayIndex = i;
                }
            }

            Console.WriteLine($"\nThe average is {dAverage / intArray.Length:F1}\n");
            Console.WriteLine($"The largest values is {iMax} at location {iArrayIndex}\n");

            return;
        }
    }
}
