using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    class Checker
    {
        // this function is written to check weather user entered a coprime number for the value of Encryption Exponent 
        //Co Prime or Relative Prime Means that the prime numbers and Encrytion Exponent share no common divisor other than 1.
        public static bool CoPrime_Checker(long input1, long input2)
        {

            if (((input1 | input2) & 1) == 0)
                return false;

            while ((input1 & input2) == 0) input1 >>= 1;
            if (input1 == 1)
                return true;

            do
            {
                while ((input2 & 1) == 0) input2 >>= 1;
                if (input2 == 1)
                    return true;

                if (input2 > input1)
                {
                    long temp = input2;
                    input2 = input1;
                    input1 = temp;
                }

                input2 -= input1;

            }

            while (input2 != 0);
            return false;
        }


        // Function written to check weather user entered a prime number in our test Box

        //something is wrong with the function 
        public static bool Prime_Number_Checker(int input)
        {
            if ((input & 1) == 0)
            {

                if (input < 2)
                {
                    return true;

                }

                else
                {
                    return false;
                }
            }

            for (int i = 3; i <= input; i += 2)
            {
                if (input % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
