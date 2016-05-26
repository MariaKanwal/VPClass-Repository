using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{

    class Handler
    {
        // Function Written To manage the "-" sign that was included in the Encrytion Of Image to increase Readability
        public static byte[] SIGN_HANDLER(string input_text)
        {

            //SPLIT function used to separate based on "  - "Sign 
            String[] Arr = input_text.Split('-');

            // Byte Object Made to Take the Value becuase we are dealing in byte data 
            byte[] byte_object = new byte[Arr.Length];


            for (int i = 0; i < Arr.Length; i++)
                byte_object[i] = Convert.ToByte(Arr[i], 16);

            //returning the value
            return byte_object;
        }
    }
}
