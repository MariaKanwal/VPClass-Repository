using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counting__a_letters_occurance_in_a_string
{
    class CharacterCount
    {
        public static SortedDictionary<char, ulong> Count(string input)
        {
            SortedDictionary<char, ulong> Count = new SortedDictionary<char, ulong>();

            foreach (var character in input)
            {
                if (!Count.ContainsKey(character))
                {
                    Count.Add(character, 1);
                }
                else
                {
                    Count[character]++;
                }
            }

            return Count;
        }
    }
}

