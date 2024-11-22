/*
 * Giezar Panaligan ICA01
 * 
 * Mar 12, 2024
 * CMPE1300 - ICA 9
 * 
 * Pseudo Code
 *      Display titles
 *      prompt for the valid password
 *      read the password entered and check for validity (contains space, tab, or null)
 *      check each characters of the password given if contains the following
 *          contaisn at least 1 uppercase
 *          contains at least 1 lowercase
 *          there must be at least 1 special character
 *          no space or tab
 *          at least 2 numbers that is not repeated
 *
 *          if the above requirements has not been met prompt an error and ask the user to type in a new password
 *      
 *      Once a valid password has been given program will ask user if program will run again (y/n)
 *      if y program will prompt a to provide password again and do the checking again
 *      if n program will immediately close
 *      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variable declarations
            string sTitle = "ICA09 - Giezar Panaligan";                                                                                            // Title string
            string sPassword;                                                                                                                      // password container
            bool bValid = false;                                                                                                                   // flag for validation checking
            int iLower = 0;                                                                                                                        // lower case letter flag
            int iUpper = 0;                                                                                                                        // upper case letter flag
            int iSymbol = 0;                                                                                                                       // special character flag
            int iNumber = 0;                                                                                                                       // number flag
            char cRepeat = 'n';                                                                                                                    // Set the character for iteration checking

            // Main program body

            // Main loop
            do
            {
                // reset the values
                Console.Clear();
                Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;                             // display the title in the middle
                Console.Write(sTitle + "\n\n");

                // sub iteration
                do
                {
                    // reset all the flags
                    iLower = 0;
                    iUpper = 0;
                    iSymbol = 0;
                    iNumber = 0;
                    char sNumInPassword = ' ';

                    // prompt a password
                    Console.Write("Valid password should be\n * Min 8 char at least 1 upper and lowercase letter\n * At least 1 special char\n * Should not contain spaces and tabs\n * At least 2 unique numbers\n");
                    Console.Write("Enter a valid password : ");
                    sPassword = Console.ReadLine();


                    // initial checking if valid password
                    if (sPassword.Contains(" ") || String.IsNullOrWhiteSpace(sPassword)
                                                || sPassword.Contains('\t')
                                                || sPassword.Length < 8)
                    {
                        Console.Write("\nInvalid password.\n\n");
                        bValid = false;
                    }
                    else
                    {
                        // do an iteration checking to check each characters contans the requirement for password
                        foreach (char ch in sPassword)
                        {
                            if (char.IsUpper(ch))
                            {
                                iUpper++;
                            }

                            if (char.IsLower(ch))
                            {
                                iLower++;
                            }

                            if (!char.IsNumber(ch) && !char.IsLetter(ch))
                            {
                                iSymbol++;
                            }

                            if (char.IsNumber(ch))
                            {
                                if (iNumber == 0)
                                {
                                    sNumInPassword = ch;
                                    iNumber++;
                                }
                                else if (iNumber == 1)
                                {
                                    iNumber = (sNumInPassword != ch) ? 2 : 0;
                                }
                            }
                        }
                        
                        // Condition that catchers all the flag for password validity
                        if (iUpper >= 1 && iLower >= 1 && iSymbol >= 1 && iNumber >= 2)
                        {
                            bValid = true;
                            Console.Write("\nValid password. \n\n");
                        }
                        else
                        {
                            Console.Write($"\nInvalid password.\n\n");
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
