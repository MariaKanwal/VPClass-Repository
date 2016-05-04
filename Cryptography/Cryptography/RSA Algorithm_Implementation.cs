using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    class RSA_Algorithm_Implementation
    {


        //To calculate Product of both Prime Numbers and Show it is in a Value "N"
        public static int Value_Of_N_Calculator(int prime1, int prime2)
        {
            return (prime1 * prime2);
        }






            public static long Generator(long array, long Value_E, long N) 
            {
                //If Value of E is 0
                // Array ^ 0 = 1
                if (Value_E == 0)
                {
                    return 1;
                }
                    

                    //If Value of E is odd
                // Array ^ 5 = a(a ^4)--
                else if (Value_E % 2 == 0)
                {
                   return ((Generator(array, Value_E / 2, N))*(Generator(array, Value_E / 2, N))) % N;
                }
                    

                    //If Value of E is Even
                    //equally splits
                else
                {
                   return ((array % N) * Generator(array, Value_E - 1, N)) % N;
                }


                   
            }

        }
    }
