/*
 * Giezar Panaligan ICA12
 * 
 * Mar 20, 2024
 * CMPE1300 - ICA 12
 * 
 * Pseudo Code
 *      Display titles and Prompt the user to enter the following values
 *          Integer values
 *          Positive integer with minimum value
 *          Positive integer with minimum and maximum value
 *          a double value
 *          a Positive double with minimum value
 *          a Positive double with minimum and maximum value
 *          validate the above input to make sure it complies with requirements as valid values
 *          
 *      read the value entered by user by calling the following methods declared as public static to check the validity
 *          GetValue that has an overload of string and integer value
 *          GetValue that has an overload of string integer, and minimum value
 *          GetValue that has an overload of string integer, maximum  and minimum value
 *          GetValue that has an overload of string and double value
 *          GetValue that has an overload of string and double with minimum value
 *          GetValue that has an overload of string and double with minimum and maximum value
 *          AddTrack process the input and add on the previous tracks
 *          Display the valid value that has been entered
 *      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ICA12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sTitle = "Giezar Panaligan - ICA12\n";                                                                                                           // string variable for the title
            int iTest = 0;                                                                                                                                          // integer variable for integer method
            double dTest;                                                                                                                                           // double variable for double method

            // call method to display title
            DiplayTitle(sTitle);

            // call the static method to prompt, validate and display an integer value
            CUtilities.GetValue(out iTest, "Enter an integer: ");
            Console.WriteLine("iTest = {0}", iTest);
            Console.WriteLine();

            // call the static method to prompt, validate and display an integer with minimum value
            CUtilities.GetValue(out iTest, "Enter a positive integer: ", 0);
            Console.WriteLine("iTest = {0}", iTest);
            Console.WriteLine();

            // call the static method to prompt, validate and display an integer with minimum and maximum value
            CUtilities.GetValue(out iTest, "Enter an integer from 0 to 100: ", 0, 100);
            Console.WriteLine("iTest = {0}", iTest);
            Console.WriteLine();

            // call the static method to prompt, validate and display double value
            CUtilities.GetValue(out dTest, "Enter a double: ");
            Console.WriteLine("dTest = {0}", dTest);
            Console.WriteLine();

            // call the static method to prompt, validate and display double with a minimum value
            CUtilities.GetValue(out dTest, "Enter a positive double: ", 0.0);
            Console.WriteLine("dTest = {0}", dTest);
            Console.WriteLine();

            // call the static method to prompt, validate and display double with a minimum and maximum value
            CUtilities.GetValue(out dTest, "Enter a double from 0.0 to 100.0: ", 0, 100);
            Console.WriteLine("dTest = {0}", dTest);
            Console.WriteLine();

            Console.Read();
        }

        //Get the hardcoded string and display as title
        static void DiplayTitle(string sTitle)
        {
            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;
            Console.WriteLine(sTitle);
        } // DiplayTitle


        // Original methods with a comment block

        static public int GetValue(out int iTest, string sPrompt)
        {
            bool bValid = false;
            do
            {
                Console.Write(sPrompt);
                bValid = int.TryParse(Console.ReadLine(), out iTest);
        
                if (!bValid)
                {
                    Console.WriteLine("An invalid number was entered. Please try again.");
                    bValid = false;
                }
                else
                {
                    bValid = true;
                }
            }
            while (!bValid);
        
            return iTest;
        }
        
         static public int GetValue(out int iTest, string sPrompt, int iMin)
         {
             bool bValid = false;
             do
             {
                 Console.Write(sPrompt);
                 bValid = int.TryParse(Console.ReadLine(), out iTest);
        
                 if (!bValid)
                 {
                     Console.WriteLine("An invalid number was entered. Please try again.");
                     bValid = false;
                 }
                 else if (bValid == true && iTest < iMin)
                 {
                     Console.WriteLine("The value entered is below the minimum accepted.");
                     bValid = false;
                 }
                 else
                 {
                     bValid= true;
                 }
             }
             while (!bValid);
        
             return iTest;
         }
        
         static public int GetValue(out int iTest, string sPrompt, int iMin, int iMax)
         {
             bool bValid = false;
             do
             {
                 Console.Write(sPrompt);
                 bValid = int.TryParse(Console.ReadLine(), out iTest);
        
                 if (!bValid)
                 {
                     Console.WriteLine("An invalid number was entered. Please try again.");
                     bValid = false;
                 }
                 else if (bValid == true && (iTest < iMin || iTest > iMax))
                 {
                     Console.WriteLine("The value entered is outside the range accepted.");
                     bValid = false;
                 }
                 else
                 {
                     bValid = true;
                 }
             }
             while (!bValid);
        
             return iTest;
         }
        
         static public double GetValue(out double dTest, string sPrompt)
         {
             bool bValid = false;
             do
             {
                 Console.Write(sPrompt);
                 bValid = double.TryParse(Console.ReadLine(), out dTest);
        
                 if (!bValid)
                 {
                     Console.WriteLine("An invalid number was entered. Please try again.");
                     bValid = false;
                 }
                 else
                 {
                     bValid = true;
                 }
             }
             while (!bValid);
        
             return dTest;
         }
        
         static public double GetValue(out double dTest, string sPrompt, double dMin)
         {
             bool bValid = false;
             do
             {
                 Console.Write(sPrompt);
                 bValid = double.TryParse(Console.ReadLine(), out dTest);
        
                 if (!bValid)
                 {
                     Console.WriteLine("An invalid number was entered. Please try again.");
                     bValid = false;
                 }
                 else if (bValid == true && dTest < dMin)
                 {
                     Console.WriteLine("The value entered is below the minimum accepted.");
                     bValid = false;
                 }
                 else
                 {
                     bValid = true;
                 }
             }
             while (!bValid);
        
             return dTest;
         }
        
         static public double GetValue(out double dTest, string sPrompt, double dMin, double dMax)
         {
             bool bValid = false;
             do
             {
                 Console.Write(sPrompt);
                 bValid = double.TryParse(Console.ReadLine(), out dTest);
        
                 if (!bValid)
                 {
                     Console.WriteLine("An invalid number was entered. Please try again.");
                     bValid = false;
                 }
                 else if (bValid == true && (dTest < dMin || dTest > dMax))
                 {
                     Console.WriteLine("The value entered is outside the range accepted.");
                     bValid = false;
                 }
                 else
                 {
                     bValid = true;
                 }
             }
             while (!bValid);
        
             return dTest;
         }

    }
}
