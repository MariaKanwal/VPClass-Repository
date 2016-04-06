using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concept_of_CLASS
{
    public class MyCustomClass
    {
        
        public int Number
        { 
            get;
            set; 
        }

        public int Multiply(int num)
        {
            return num * Number;
        }

        public MyCustomClass()
        {
            Number = 0;
        }
    }
  
    class Program
    {
        static void Main(string[] args)
        {
            MyCustomClass myClass = new MyCustomClass();
            int num;
            Console.WriteLine("Enter Number");
            num = Convert.ToInt32(Console.ReadLine());

            myClass.Number = num;

            int mul;
            Console.WriteLine("\nEnter Number to multiply with ");
            mul = Convert.ToInt32(Console.ReadLine());
            int result = myClass.Multiply(mul);

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}

