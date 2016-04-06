using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {

        static int Fact(int n)
        {
            if (n <= 1)
                return 1;
            return n * Fact(n - 1);
        }


        static void Main(string[] args)
        {
            Console.Write("Enter a Number to find factorial: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int r = Fact(n);
            Console.WriteLine(n + " FACTORIAL IS " + r);

            Console.ReadLine();
        }
    }
}