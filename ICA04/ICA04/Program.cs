/*
 * Giezar Panaligan ICA04
 * 
 * Feb 2, 2024
 * CMPE1300 - ICA 4
 * 
 * Pseudo Code
 *      Display titles and choices Rock, Paper, Scissors
 *      prompt player to enter his choice
 *      assign a value on computer's random number picked
 *      read the value entered by player and assign a string value or tag as invalid
 *      
 *      if players input is valid perform a checking to know who wins the game
 *      print the outcome of the game and declare the winner
 *      prompt the end of program.
 *      else prompt the player that input is invalid and program will end.
 *      
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sTitle = "Giezar Panaligan Assignment 4";                                                                                    // Assign a title
            string sGameLabel1 = "\n Rock\n Paper\n Scissors\n\n";                                                                              // Game label var
            string sPlayerInput;                                                                                                                // delclare var for input
            string sComputerInputTag = "";                                                                                                      // var holder for to assign the string
            string sDraw;                                                                                                                       // var holder on the player and computers pick
            string sVerdict;                                                                                                                    // outcome of the game var
            int iComputerInput;                                                                                                                 // computers var holder for num
            bool bValidInput;                                                                                                                   // boolean for either valid or invalid
  
            Random rndComputerPick = new Random();                                                                                              // random num generator for computers pick
            iComputerInput = rndComputerPick.Next(1, 6);                                                                                        // Computer's pick at random 1 = rock, 2 = paper, 3 = scissor... And to make it more random 4 = paper, 5 = rock, 6 = scissors


            // Main program body
            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;                                                                     // Display title on the top middle
            Console.WriteLine(sTitle + "\n");                                                                                                   // Print the title

            // Prompt user to enter a value
            Console.Write("Please select your play from the following choices...\n");
            Console.Write(sGameLabel1);

            Console.Write("Your selection: ");
            sPlayerInput = Console.ReadLine().ToLower();

            // convert the computer's random generated number into either rock, paper, scissors
            switch (iComputerInput)
            {
                case 1:
                    sComputerInputTag = "rock";
                    break;
                case 2:
                    sComputerInputTag = "paper";
                    break;
                case 3:
                    sComputerInputTag = "scissors";
                    break;
                case 4:
                    sComputerInputTag = "paper";
                    break;
                case 5:
                    sComputerInputTag = "rock";
                    break;
                case 6:
                    sComputerInputTag = "scissors";
                    break;
                default:
                    Console.Write("Computer have entered an invalid input there must be an error program will exit");                                // Just in case there is a glitch that is unlikely to happen.
                    bValidInput = false;
                    break;
            }

            // check the validity of players input
            switch (sPlayerInput)
            {
                case "rock":
                    bValidInput = true;
                    break;
                case "paper":
                    bValidInput = true;
                    break;
                case "scissors":
                    bValidInput = true;
                    break;
                default:
                    bValidInput = false;
                    break;
            }

            // concat the player and computer's input to check the winner
            sDraw = $"{sComputerInputTag}-{sPlayerInput}";

            // Perform this switch if players input is valid
            switch (bValidInput)
            {
                case true:
                    // Computer pick - Playter pick
                    switch (sDraw)
                    {
                        case "rock-paper":
                            sVerdict = "Paper covers rock, you win.";
                            break;
                        case "rock-scissors":
                            sVerdict = "Rock crushes scissors, you lose.";
                            break;
                        case "paper-rock":
                            sVerdict = "Paper covers rock, you lose.";
                            break;
                        case "paper-scissors":
                            sVerdict = "Scissors cuts paper, you win.";
                            break;
                        case "scissors-rock":
                            sVerdict = "rock crushes scissors, you win.";
                            break;
                        case "scissors-paper":
                            sVerdict = "scissors cuts paper, you lose.";
                            break;
                        default:
                            sVerdict = "It's a draw.";
                            break;
                    }
                    // Display the outcome of the game and declare the winner.
                    Console.WriteLine($"\nComputer played {sComputerInputTag} and you played {sPlayerInput}.\n");
                    Console.WriteLine(sVerdict);
                    break;
                // Invalid input message prompt
                case false:
                    Console.Write("\nYou have entered an invalid input program will exit\n");
                    break;
            }
            Console.WriteLine();
            Console.Write("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
