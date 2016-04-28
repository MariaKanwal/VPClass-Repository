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
        public static bool CoPrime_Checker(int input1, int input2)
        {
            // condtion executes if both are even numbers then they are not coprime 
            if (((input1 | input2) & 1) == 0)    
                return false;


            //if one of the orginal numbers is odd  
            while ((input1 & 1) == 0) 
                     input1 >>= 1;       

            // if one of the orginal numbers is coprime 
            if (input1 == 1)
                return true;

            do
            {
                // Elaminate all factors of 2 from "input2" 
                while ((input2 & 1) == 0) 
                       input2 >>= 1;


                // when one of the orginal input numbers is coprime 
                if (input2 == 1)
                    return true;


                //swapping done to ensure that input2 >= input1
                if (input1 > input2)
                {
                    int temp = input2;
                    input2 = input1;
                    input1 = temp;
                }


                //Done by the logic GCD(input1 , input2) = GCD(input1 , input2 - input1)
                input2 -= input1;

            }

            while (input2 != 0);

            //This will be executed when input2 has 0 in it along with GCD(input1 , input2) = input1 > 1
            return false;
        }




        // Function written to check weather user entered a prime number 
       // This function is manily used for Checking the Values in Prime No 1 and Prime No 2 Text box
        //A number is only prime if it is not divisible by other prime numbers that are up to the value of its square root
        public static bool Prime_Number_Checker(int input)
        {
            if ((input & 1) == 0)            //Check paramter is Prime or Not
            {

                if (input == 2)
                {
                    return true;            // prime

                }

                else
                {
                    return false;          //not prime
                }
            }

            for (int i = 3; (i*i) <= input; i += 2)
            {
                if (input % i == 0)
                {
                    return false;      
                }
            }

            return input != 1 ;
        }
    }
}
