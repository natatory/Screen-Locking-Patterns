using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screen_Locking_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.CountPatternsFrom('B', 1));
            Console.WriteLine(Kata.CountPatternsFrom('C', 9));
            Console.ReadLine();
        }
    }
}
