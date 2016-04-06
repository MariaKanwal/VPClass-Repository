using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            int number, count = 0;
            Console.WriteLine("ENTER NUMBER TO CHECK I IS PRIME OR NOT ");
            number = Convert.ToInt32(Console.ReadLine());

            for (int a = 1; a <= number; a++)
            {
                if (number % a == 0)
                {
                    count++;
                }
            }

            if (count == 2)
            {
                Console.WriteLine("\"{0}\" is a PRIME NUMBER \n", number);
            }
            else
            {
                Console.WriteLine("\"{0}\" is  NOT A PRIME NUMBER \n", number);
            }
            Console.ReadKey();
        }
    }
}