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
        public static long Generator(long array, long Value_E, long N)
        {
            // If Value of E is 0
            //Array ^ 0 = 1
          if(Value_E == 0) 
          {
              return 1;
          }

            
            // If Value of E is odd
            //Array ^ 5 = a( a^4)--
          if (Value_E % 2 == 0 )
            {
                return ( (array * N) * (Generator(array,Value_E -1,N)));
            }

              // If Value of E is Even 
            //equally splits 
          else
            {
                long c;
                c=  Generator(array,Value_E/2,N);
                return ((c%N)*(c%N) % N);


            }
        }

    }
}
