using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapping_with_TEMP_variable
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;

            Console.WriteLine("Enter Value for Value A");
            a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Value for Value B");
            b= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Value of a and b before sawapping");
            Console.WriteLine();
            Console.WriteLine("a=" + " " + a);
            Console.WriteLine("b=" + " " + b);

            int TEMP;
            TEMP = a;
            a = b;
            b = TEMP;
           
            Console.WriteLine("Value of a and b after sawapping");
            Console.WriteLine();
            Console.WriteLine("a=" + " " + a);
            Console.WriteLine("b=" + " " + b);
            Console.ReadLine();  
        }
    }
}
