using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1300_ICA11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iMinInput;      //track Minutes input by user
            int iSecInput;      //track Seconds input by user
            int iMinTotal = 0;  //Total music minutes
            int iSecTotal = 0;  //Total music seconds
            bool bExit = false; //flag for CD is Full
            string sRepeat = "";
            string sTitle = "ICA11 - Huy Ngo";

            //repeat until user is done or CD is full
            do
            {   
                Console.Clear();
                Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;
                Console.WriteLine(sTitle);

                // get the time for a single track
                GetTrack(out iMinInput, out iSecInput);

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
            while (!bExit && YesNo(sRepeat) == "yes");//(YesNo("Add another track") == "yes") && !bExit);
        }

        // Your Methods go here

        static void GetTrack(out int iMinInput, out int iSecInput)
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

            }
            while (!bValid);

            bValid = false;

            do
            {
                Console.Write("\nEnter the seconds: ");
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

        }


        

        static void DisplayTotal(int iMinTotal, int iSectotal)
        {
            Console.WriteLine($"\nCurrent Total = {iMinTotal:D2}:{iSectotal:D2}");
            return;
        }

        static void AddTrack(int iMinInput, int iSecInput, ref int iMinTotal, ref int iSectotal)
        {
            iMinTotal += iMinInput;
            iSectotal += iSecInput;

            while((iSectotal / 60) > 0)
            {
                iMinTotal += 1;
                iSectotal = iSectotal % 60;
               
            }
        }


        static int SecTotal(int iMinTotal, int iSecTotal)
        {
            iMinTotal *= 60;
            iSecTotal += iMinTotal;
            return iSecTotal;
        } 

        static string YesNo(string sRepeat)
        {
             
            do
            {   
                
                Console.Write("\nAdd another track?");
                sRepeat = Console.ReadLine().ToLower();

                if(sRepeat != "yes" && sRepeat != "no")
                {
                    Console.WriteLine("\nYou must answer yes or no.");

                }
                else if(sRepeat == "no")
                {
                    Console.WriteLine("\nBye!");
                }
                
            }
            while (sRepeat != "yes" && sRepeat!="no");

            return sRepeat;
        }


    }
}
