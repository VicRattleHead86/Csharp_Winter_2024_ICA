/*
 * Giezar Panaligan ICA14
 * 
 * Mar 29, 2024
 * CMPE1300 - ICA 14
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Security.Policy;

namespace ICA14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iScreenXSize = 800;                                                                     // Set Width size of GDIDrawer   160       
            int iScreenYSize = 600;                                                                     // Set Height size of GDIDrawer  120
            bool bNotContinous = true;                                                                  // Set var for Canvas to load the window                                      
            bool bNotLogging = true;                                                                    // Set var for Canvas for logging
            int iScale = 20;
            int iScaledWidth = iScreenXSize / iScale;
            int iScaledHeight = iScreenYSize / iScale;

            CDrawer Canvas = new CDrawer(iScreenXSize, iScreenYSize, bNotContinous, bNotLogging);        // Create a GIDDrawer window
            Canvas.Scale = 20;


            DisplayTitle("Giezar Panaligan - ICA13");
            CreateArray(out int[] iArray);
            Draw(ref Canvas);
            //DisplayCanvasText("iArray1, Original Contents", ref Canvas);

            Console.Read();
        }

        static public int[] CreateArray(out int[] iArray)
        {
            iArray = new int[20];
            Random random = new Random();
            int inum = random.Next(1, 29);
            int iArrayLenght = iArray.Length;


            for (int i = 0; i < iArrayLenght; i++ )
            {
                iArray[i] = random.Next(1, 29);

                //Console.WriteLine(iArray[i]);
            }
            return iArray;
        }

        static public void Draw(ref CDrawer canvas)
        {
            int[] iArray1 = CreateArray(out int[] iArray);
            int iColBar = 0;
            int iColBar2 = 0;
            int iColBar3 = 0;
            int iColBarClr = 0;
            int iColBarSort = 0;

            int iScreenXSize = 800;                                                                     // Set Width size of GDIDrawer   160       
            int iScreenYSize = 600;                                                                     // Set Height size of GDIDrawer  120
            bool bNotContinous = true;                                                                  // Set var for Canvas to load the window                                      
            bool bNotLogging = true;                                                                    // Set var for Canvas for logging
            int iScale = 20;
            int iScaledWidth = iScreenXSize / iScale;
            int iScaledHeight = iScreenYSize / iScale;

            canvas.Scale = 20;

            foreach (int iArrayVal in iArray1)
            {
                int iBar = iArrayVal;
        
                for (int i2 = 0; i2 <= iBar; i2++)
                {

                    canvas.AddLine(iColBar, i2, iColBar, iBar, Color.Yellow, 10);


                }
                iColBar += 1;
            }

            DisplayCanvasText("iArray1, Original Contents", ref canvas);

            CDrawer Canvas = new CDrawer(iScreenXSize, iScreenYSize, bNotContinous, bNotLogging);        // Create a GIDDrawer window
            Canvas.Scale = 20;

            int[] iArray2 = (int[])iArray1.Clone();
            iArray2[1] = 0;

            foreach (int iArrayVal2 in iArray2)
            {
                int iBar = iArrayVal2;

                for (int i2 = 0; i2 <= iBar; i2++)
                {

                    Canvas.AddLine(iColBar2, i2, iColBar2, iBar, Color.Yellow, 10);


                }
                iColBar2++;
            }

            DisplayCanvasText("iArray2", ref Canvas);


            int[] iArray3 = (int[])iArray1.Clone();

            CDrawer Canvas2 = new CDrawer(iScreenXSize, iScreenYSize, bNotContinous, bNotLogging);        // Create a GIDDrawer window
            Canvas2.Scale = 20;

            foreach (int iArrayVal3 in iArray3)
            {
                int iBar = iArrayVal3;

                for (int i2 = 0; i2 <= iBar; i2++)
                {

                    Canvas2.AddLine(iColBar3, i2, iColBar3, iBar, Color.Yellow, 10);

                }
                iColBar3+=1;
            }

            DisplayCanvasText("iArray1", ref Canvas2);


            int[] iArrayClr = (int[])iArray1.Clone();

            // Array.Clear(iArrayClr, 10, iArrayClr.Length);

            CDrawer CanvasClr = new CDrawer(iScreenXSize, iScreenYSize, bNotContinous, bNotLogging);        // Create a GIDDrawer window
            CanvasClr.Scale = 20;

            foreach (int iArrayValClr in iArrayClr)
            {
                int iBar = iArrayValClr;

                for (int i2 = 0; i2 <= iBar; i2++)
                {

                    CanvasClr.AddLine(iColBarClr, i2, iColBarClr, iBar, Color.Yellow, 10);

                }
                iColBarClr += 1;
            }

            DisplayCanvasText("iArray 2 Cleared", ref CanvasClr);

            int[] iArraySort = (int[])iArray1.Clone();

            // Array.Clear(iArrayClr, 10, iArrayClr.Length);

            Array.Sort(iArraySort);

            CDrawer CanvasSort = new CDrawer(iScreenXSize, iScreenYSize, bNotContinous, bNotLogging);        // Create a GIDDrawer window
            CanvasSort.Scale = 20;

            foreach (int iArrayValSort in iArraySort)
            {
                int iBar = iArrayValSort;

                for (int i2 = 0; i2 <= iBar; i2++)
                {

                    CanvasSort.AddLine(iColBarSort, i2, iColBarSort, iBar, Color.Yellow, 10);

                }
                iColBarSort += 1;
            }

            DisplayCanvasText("Sorted Array1", ref CanvasSort);

            return;
        }

        static void DisplayTitle(string sTitle)
        {
            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;
            Console.WriteLine(sTitle);
            Console.WriteLine();

            return;
        }

        static void DisplayCanvasText(string sCanvasText, ref CDrawer canvas)
        {
            canvas.AddText(sCanvasText, 24, Color.Gray);

            return;
        }
    }
}
