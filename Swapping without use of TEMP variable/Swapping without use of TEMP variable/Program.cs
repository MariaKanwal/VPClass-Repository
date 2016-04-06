using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapping_without_use_of_TEMP_variable
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;

            Console.WriteLine("Enter Value for Value A");
            a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Value for Value B");
            b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Value of a and b before sawapping");
            Console.WriteLine();
            Console.WriteLine("a=" + " " + a);
            Console.WriteLine("b=" + " " + b);

            a = a + b;
            b = a - b;
            a = a - b;

            Console.WriteLine("Value of a and b after sawapping");
            Console.WriteLine();
            Console.WriteLine("a=" + " " + a);
            Console.WriteLine("b=" + " " + b);
            Console.ReadLine();  
        }
    }
}
