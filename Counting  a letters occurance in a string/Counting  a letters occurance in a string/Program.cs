using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counting__a_letters_occurance_in_a_string
{
    class Program
    {
        static void Main(string[] args)
        {

            string input;
            Console.WriteLine("Enter Text for checking occurence of each letter in that string");
            input = Console.ReadLine();

            Console.WriteLine("Output");
            var count = CharacterCount.Count(input);

            foreach (var character in count)
            {
                Console.WriteLine("{0} is occuring {1} times", character.Key, character.Value);
            }
            Console.ReadLine();
        }
    }
}