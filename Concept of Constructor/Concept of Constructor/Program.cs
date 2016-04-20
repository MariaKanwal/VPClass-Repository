using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concept_of_Constructor
{
    class Program
    {
        private double length;   
        public Program(double len)  
        {
            Console.WriteLine("Object is being created, length = {0}", len);
            length = len;
        }

        public void setLength(double len)
        {
            length = len;
        }

        public double getLength()
        {
            return length;
        }

        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("enter a number");
            num = Convert.ToInt32(Console.ReadLine());
            Program line = new Program(num);
            Console.WriteLine("Length of line : {0}", line.getLength());

          
            line.setLength(6.0);
            Console.WriteLine("Length of line : {0}", line.getLength());
            Console.ReadKey();
        }
    }
}

