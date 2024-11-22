using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class CUtilities
    {
        //static public int GetValue(out int iTest, string sPrompt)
        //{
        //    bool bValid = false;
        //    do
        //    {
        //        Console.Write(sPrompt);
        //        bValid = int.TryParse(Console.ReadLine(), out iTest);
        //
        //        if (!bValid)
        //        {
        //            Console.WriteLine("An invalid number was entered. Please try again.");
        //            bValid = false;
        //        }
        //        else
        //        {
        //            bValid = true;
        //        }
        //    }
        //    while (!bValid);
        //
        //    return iTest;
        //}
        //
        // static public int GetValue(out int iTest, string sPrompt, int iMin)
        // {
        //     bool bValid = false;
        //     do
        //     {
        //         Console.Write(sPrompt);
        //         bValid = int.TryParse(Console.ReadLine(), out iTest);
        //
        //         if (!bValid)
        //         {
        //             Console.WriteLine("An invalid number was entered. Please try again.");
        //             bValid = false;
        //         }
        //         else if (bValid == true && iTest < iMin)
        //         {
        //             Console.WriteLine("The value entered is below the minimum accepted.");
        //             bValid = false;
        //         }
        //         else
        //         {
        //             bValid= true;
        //         }
        //     }
        //     while (!bValid);
        //
        //     return iTest;
        // }
        //
        // static public int GetValue(out int iTest, string sPrompt, int iMin, int iMax)
        // {
        //     bool bValid = false;
        //     do
        //     {
        //         Console.Write(sPrompt);
        //         bValid = int.TryParse(Console.ReadLine(), out iTest);
        //
        //         if (!bValid)
        //         {
        //             Console.WriteLine("An invalid number was entered. Please try again.");
        //             bValid = false;
        //         }
        //         else if (bValid == true && (iTest < iMin || iTest > iMax))
        //         {
        //             Console.WriteLine("The value entered is outside the range accepted.");
        //             bValid = false;
        //         }
        //         else
        //         {
        //             bValid = true;
        //         }
        //     }
        //     while (!bValid);
        //
        //     return iTest;
        // }
        //
        // static public double GetValue(out double dTest, string sPrompt)
        // {
        //     bool bValid = false;
        //     do
        //     {
        //         Console.Write(sPrompt);
        //         bValid = double.TryParse(Console.ReadLine(), out dTest);
        //
        //         if (!bValid)
        //         {
        //             Console.WriteLine("An invalid number was entered. Please try again.");
        //             bValid = false;
        //         }
        //         else
        //         {
        //             bValid = true;
        //         }
        //     }
        //     while (!bValid);
        //
        //     return dTest;
        // }
        //
        // static public double GetValue(out double dTest, string sPrompt, double dMin)
        // {
        //     bool bValid = false;
        //     do
        //     {
        //         Console.Write(sPrompt);
        //         bValid = double.TryParse(Console.ReadLine(), out dTest);
        //
        //         if (!bValid)
        //         {
        //             Console.WriteLine("An invalid number was entered. Please try again.");
        //             bValid = false;
        //         }
        //         else if (bValid == true && dTest < dMin)
        //         {
        //             Console.WriteLine("The value entered is below the minimum accepted.");
        //             bValid = false;
        //         }
        //         else
        //         {
        //             bValid = true;
        //         }
        //     }
        //     while (!bValid);
        //
        //     return dTest;
        // }
        //
        // static public double GetValue(out double dTest, string sPrompt, double dMin, double dMax)
        // {
        //     bool bValid = false;
        //     do
        //     {
        //         Console.Write(sPrompt);
        //         bValid = double.TryParse(Console.ReadLine(), out dTest);
        //
        //         if (!bValid)
        //         {
        //             Console.WriteLine("An invalid number was entered. Please try again.");
        //             bValid = false;
        //         }
        //         else if (bValid == true && (dTest < dMin || dTest > dMax))
        //         {
        //             Console.WriteLine("The value entered is outside the range accepted.");
        //             bValid = false;
        //         }
        //         else
        //         {
        //             bValid = true;
        //         }
        //     }
        //     while (!bValid);
        //
        //     return dTest;
        // }
    }
}
