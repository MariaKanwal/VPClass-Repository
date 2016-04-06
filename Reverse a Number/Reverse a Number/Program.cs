using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_a_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num, reverse=0;
            Console.WriteLine("Enter number");
            num = Convert.ToInt32(Console.ReadLine());

            for(;num!=0;)
            {
                reverse = reverse * 10;
                reverse = reverse + num% 10;
                num = num / 10;

            }
            Console.WriteLine("Reversed Number is {0}",reverse);
            Console.ReadLine();
        }
    }
}
