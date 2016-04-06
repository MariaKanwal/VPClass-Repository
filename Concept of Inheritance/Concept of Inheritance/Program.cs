using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concept_of_Inheritance
{
    class inheritance : vehicle
    {
        public void Noise()
        {
            Console.WriteLine("All Vehicles Creates Noise !! ");
        }

        static void Main(string[] args)
        {
            inheritance obj = new inheritance();
            obj.mode();
            obj.feature();
            obj.Noise();
            Console.Read();
        }
    }
    class Mode
    {
        public void mode()
        {
            Console.WriteLine("There are Many Modes of Transport !!");
        }
    }
    class vehicle : Mode
    {
        public void feature()
        {
            Console.WriteLine("They Mainly Help in Travelling !!");
        }
    }
}

