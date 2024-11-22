using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary
{
    public class Utility
    {
        static public void Pause()
        {
            Console.Write("Press any key to continue: ");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
