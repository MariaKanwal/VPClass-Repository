using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premutation__Show_all_combinations_
{
    class Program
    {
        static void Main(string[] args)
        {

            string input;
            Console.WriteLine("Enter input to see all possible combinations");
            input = Console.ReadLine();

            Console.WriteLine("Outputs\n\n\n");
            Shifting(input);
            Console.ReadLine();
        }
        
        public static void Shifting (string input)
        {
            Logic("", input);
        }
        private static void Logic(string temp, string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine(temp);
                return;
            }

            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    string store= input.Substring(0, i);
                    string store2=input.Substring(i + 1);
                    string remaining = store + store2;

                    Logic(temp + input[i], remaining);
                }
            }
        }
    }
}
