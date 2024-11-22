

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
using System.Threading;

namespace ICA10___Methods
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            //Local Variables
            string sTitile = "ICA10 - Huy Ngo";
            int iSpacing = 0;
            double dLineLength = 0.0;
            double dAngleIncre=0.0;
            bool bValid = false;
            string sAgain = "";
            int iNum = 0;
            int iScreenX = 800;
            int iScreenY = 600;
            double dLow = 0.0;
            double dHigh = 20.0;



            //Call Methods here
            using (CDrawer canvas = new CDrawer(iScreenX, iScreenY, true, true))
            {
                do
                {
                    Console.Clear();
                    DispTitle(sTitile);
                    dLineLength = GetDouble($"Enter the line length in pixels: ", dLow, dHigh);
                    dAngleIncre = Deg2Rad($"Enter the angle increment in degrees: ", dLow, dHigh);
                    iSpacing = GetInt($"Enter the spacing for the stars in pixels: ", (int)dLineLength);
                    DrawStar(canvas, iScreenX, iScreenY ,dLineLength, dAngleIncre, iSpacing);

                    do
                    {
                        Console.Write("Run program again? (y/n): ");
                        sAgain = Console.ReadLine().ToLower();
                        if (sAgain != "y" && sAgain != "n")
                        {
                            Console.WriteLine("Wrong syntax, please try again");
                        }

                    }
                    while (sAgain != "y" && sAgain != "n");

                }
                while (sAgain == "y");
            }

            

           
        }

        //Write Methods here

        //DispTitle
        static void DispTitle(string sMessage)
        {
            Console.CursorLeft = (Console.WindowWidth - sMessage.Length) / 2;
            Console.WriteLine($"{sMessage}\n");
            return;
        }

        //GetDouble
        static double GetDouble(string dMessage, double dLow, double dHigh)
        {
            double dLineLength = 0.0;
            bool bValid = false;
            do
            {
                Console.Write(dMessage);
                bValid = double.TryParse(Console.ReadLine(), out dLineLength);

                if (!bValid)
                {
                    Console.WriteLine("You have entered an invalid number. Try again with an double value!\n");
                }
                else if (bValid && dLineLength <= dLow)
                {
                    Console.WriteLine("The line lenth has to be a positive value. Please try again!\n");
                    bValid = false;
                }
            }
            while (!bValid); 
            
            return dLineLength;
        }

        //Deg2Rad

        static double Deg2Rad(string dMessage, double dLow, double dHigh)
        {
            double dRad = 0.0;
            double dDegree = 0.0;
            bool bValid = false;


            do
            {
                Console.Write($"{dMessage}");
                bValid = double.TryParse(Console.ReadLine(), out dDegree);

                if (!bValid)
                {
                    Console.WriteLine("You have entered an invalid number. Try again with an double value!\n");
                }
                else if (bValid && dDegree <= dLow)
                {
                    Console.WriteLine("Angle increment must be a positive value. Please try again!\n");
                    bValid= false;
                }
                else if (bValid && dDegree > dHigh)
                {
                    Console.WriteLine("The angle increment in a range 1 - 20 to ensure the star is display clearly. Please try again! !\n");
                    bValid = false;
                }
                else
                {
                    dRad = dDegree * Math.PI / 180;
                }
            }
            while (!bValid);

            return dRad;
        }


        //GetInt
        static int GetInt(string siMessage, int iLowValue)
        {
            int iSpacing = 0;
            bool bValid = false;

            do
            {
                Console.Write($"{siMessage}");
                bValid = int.TryParse(Console.ReadLine(), out iSpacing);

                if (!bValid)
                {
                    Console.WriteLine("You have entered an invalid number. Try again with an integer value!\n");
                }
                else if((bValid && iSpacing < 2* iLowValue))
                {
                    Console.WriteLine("The stars are stacked on each other. Please try with a value higher than 2 TIMES of Line Length.\n");
                    bValid = false;
                }
            }
            while (!bValid);
            return iSpacing;
        }

        //DrawStar
        static void DrawStar(CDrawer canvas, int iScreenX, int iScreenY, double dLineLength, double dAngleIncre, int iSpacing)
        {
            Point point = new Point();
            point.X = 0;
            point.Y = 0;
            
            Random randColor = new Random();


            canvas.Clear();   

            for (int y = 0; y - dLineLength < iScreenY; y += iSpacing)
            {
                point.Y = y;

                for (int x = 0; x - dLineLength < iScreenX; x += iSpacing)
                {
                    point.X = x;
                    for (double j = 0; j < Math.PI * 2; j = j + dAngleIncre)
                    {


                        canvas.AddLine(point, dLineLength, j, Color.FromArgb(randColor.Next()), 1);

                    }

                }

                
            }

            return;
        }

       
        
    }
}
