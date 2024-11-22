/*
 * Giezar Panaligan ICA11
 * 
 * Mar 18, 2024
 * CMPE1300 - ICA 11
 * 
 * Pseudo Code
 *      Display titles and Prompt the user to enter the following values for each single track of song
 *          Minutes and seconds
 *          validate the above input to make sure it complies with requirements as valid minutes and seconds
 *          minute input should be a valid minute and has to be normalized
 *          seconds input should be a valid seconds make sure does not exceed 60
 *          
 *      read the value entered by user by calling the following methods to check the validity
 *          GetInt process the input from user
 *          AddTrack process the input and add on the previous tracks
 *          DisplayTotal displays the total tracks (mins/sec)
 *          check if the totals tracks already exceeded the time if not ask user to repeat (yes/no)
 *          exit the program if no
 *      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ICA11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sTitle = "Giezar Panaligan - ICA11\n";
            int iMinInput;                                                                                                                                  //track Minutes input by user
            int iSecInput;                                                                                                                                  //track Seconds input by user
            int iMinTotal = 0;                                                                                                                              //Total music minutes
            int iSecTotal = 0;                                                                                                                              //Total music seconds
            bool bExit = false;                                                                                                                             //flag for CD is Full
            string sRepeat = null;                                                                                                                          // flag to repeat or exit the program


            //repeat until user is done or CD is full
            do
            {
                Console.Clear();
                // Displays the title
                DiplayTitle(sTitle);


                // get the time for a single track
                GetInt(out iMinInput, out iSecInput);


                //add the track to the current music total time
                AddTrack(iMinInput, iSecInput, ref iMinTotal, ref iSecTotal);


                //display the total time
                DisplayTotal(iMinTotal, iSecTotal);


                //Check for the CD being full at about 76 min
                if (SecTotal(iMinTotal, iSecTotal) > 76 * 60)
                {
                    Console.WriteLine("The CD is full, Exiting...");
                    Console.ReadKey();
                    bExit = true;
                }
            }
            while ((YesNo("Add another track") == "yes") && !bExit);
        } // Main program


        //Get the hardcoded string and display as title
        static void DiplayTitle(string sTitle)
        {
            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;
            Console.WriteLine(sTitle);
        } // DiplayTitle

        // Display the calculated total of tracks
        static void DisplayTotal(int iMinTotal, int iSectotal)
        {
            Console.WriteLine($"Current Total = {iMinTotal:D2}:{iSectotal:D2}");
            return;
        } // DisplayTotal

        // Calculated the added tracks and nomalized to make it readable as minutes and seconds
        static void AddTrack(int iMinInput, int iSecInput, ref int iMinTotal, ref int iSectotal)
        {
            iMinTotal += iMinInput;
            iSectotal += iSecInput;

            while ((iSectotal / 60) > 0)
            {
                iMinTotal += 1;
                iSectotal = iSectotal % 60;
            }
        } // AddTrack


        // Yes and No prompt for user to continue adding tracks
        static string YesNo(string sRepeat)
        {
            do
            {
                Console.Write("\nAdd another track? ");
                sRepeat = Console.ReadLine().ToLower();

                if (sRepeat != "yes" && sRepeat != "no")
                {
                    Console.WriteLine("\nYou must answer yes or no.");
                }
                else if (sRepeat == "no")
                {
                    Console.WriteLine("\nBye!");
                }
            }
            while (sRepeat != "yes" && sRepeat != "no");

            return sRepeat;
        } // YesNo


        // Get all the integer for processing
        static void GetInt(out int iMinInput, out int iSecInput)
        {
            bool bValid = false;
            do
            {
                Console.Write("\nEnter the minutes: ");
                bValid = int.TryParse(Console.ReadLine(), out iMinInput);

                if (!bValid)
                {
                    Console.WriteLine("\nAn invalid number was entered, please try again.");
                }
                else if (iMinInput < 0 || iMinInput >= 60)
                {
                    Console.WriteLine("\nThat value is out of range.");
                    bValid = false;
                }
                else if (iMinInput < 0 || iMinInput >= 20)
                {
                    Console.WriteLine("\nThat value too big for a song.");
                    bValid = false;
                }
                else if (iMinInput == 0)
                {
                    Console.WriteLine("\nEnter a higher value.");
                    bValid = false;
                }

            }
            while (!bValid);

            bValid = false;

            do
            {
                Console.Write("Enter the seconds: ");
                bValid = int.TryParse(Console.ReadLine(), out iSecInput);

                if (!bValid)
                {
                    Console.WriteLine("\nAn invalid number was entered, please try again.");
                }
                else if (iSecInput < 0 || iSecInput >= 60)
                {
                    Console.WriteLine("\nThat value is out of range.");
                    bValid = false;
                }
            }
            while (!bValid);
            return;
        } // GetInt

        // passed a minute and seconds value
        static int SecTotal(int iMinTotal, int iSecTotal)
        {
            iMinTotal *= 60;
            iSecTotal += iMinTotal;
            return iSecTotal;
        } // SecTotal
    }
}
