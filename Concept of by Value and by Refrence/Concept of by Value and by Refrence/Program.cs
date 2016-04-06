using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concept_of_by_Value_and_by_Refrence
{
    class Program
    {
        public static void qube(ref int num)
        {
            num = num * num * num;
        }

        public static void qube(int num)
        {
            num = num * num * num;
        }
        static void Main(string[] args)
        {
            int original;
            Console.WriteLine("Enter a Number");
            original = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("BY VALUE");
            Console.Write("\nCurrent value of Original is   {0}\t", original);
            Program.qube(original);
            Console.WriteLine("\nFunction called");
            Console.WriteLine("\nNow the current value of    Original is {0}\t", original);

            Console.WriteLine("\n\nBY REFRENCE");
            Console.Write("\nCurrent value of Original is               {0}\t", original);
            Program.qube(ref original);
            Console.WriteLine("\nFunction called");
            Console.WriteLine("\nNow the current value of               Original is {0}\t", original);

           
            Console.ReadLine();
        }
    }
}
