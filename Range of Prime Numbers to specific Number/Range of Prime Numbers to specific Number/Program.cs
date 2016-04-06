using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range_of_Prime_Numbers_to_specific_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum, endNum;
            int found = 0, count = 0;

            Console.WriteLine("Enter Number for starting :  ");
            startNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Number for ending:");
            endNum = Convert.ToInt32(Console.ReadLine());

            for (int i = startNum; i <= endNum; i++)
            {
                for (int j = 2; j <= Math.Pow(i, 2); j++)
                {
                    if (i % j == 0)
                        count++;
                }

                if (count == 0 && i != 1)
                {
                    found++;
                    Console.WriteLine("Prime Number {0}", i);
                    count = 0;
                }

                count = 0;
            }
            Console.WriteLine("Total Prime Number Between Range {0} to {1} are", startNum, found);
            //return 1;

            Console.ReadLine();

        }
    }
}
