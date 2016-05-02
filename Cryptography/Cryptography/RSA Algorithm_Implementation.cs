using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    class RSA_Algorithm_Implementation
    {

        // To calculate Product of both Prime Numbers and Show it in a Value "N"
        public static int Value_of_N_Calculator(int Prime_NO_1 , int Prime_NO_2)
        {
            return((Prime_NO_1) * ( Prime_NO_2));
        }




       
        // Incomplete 
        public static double Generator(double array, double Value_E, double N)
        {
            double temp;
            if( Value_E % 2 == 0)
            {
                temp = (Generator(array, Value_E,N));
                return temp;
            }
            else
            {
                return (array % N);
            }
        }

    }
}
