using System;

namespace CodingInterview.ArrayAndString
{
    public class PalindromePermutation
    {
        public PalindromePermutation()
        {
            string input = "Tact Coa";
            Console.WriteLine("1.4. '{0}' Palindrome Permutation of : {1}", input, GeneratePalindromePermutations(input.ToCharArray()));
        }

        public string GeneratePalindromePermutations(char[] input)
        {
            int[] hashTable = new int[128];
            int uniqueCharLength = 0;
            int l = input.Length;
            char[] result = new char[l];
            for (int i = 0; i < l; i++)
            {
                if (input[i] != ' ')
                {
                    ToggleUpperToLower(ref input[i]);
                    uniqueCharLength++;
                    hashTable[input[i]]++;
                    if (hashTable[input[i]] > 1)
                        uniqueCharLength -= 2;
                }
            }
            if (uniqueCharLength != 1)
                return "The permuation of the string won't generate palindrome";
            else
            {
                for (int i = 0, j = 0; i < l; i++)
                {
                    if (input[i] == ' ')
                    {
                        result[i] = ' ';
                    }
                    else
                    {
                        if (hashTable[input[i]] == 2)
                        {
                            result[j] = input[i]; result[l - 1 - j] = input[i];
                            hashTable[input[i]] -= 2;
                            j++;
                        }
                        else if (hashTable[input[i]] == 1)
                            result[j++] = input[i];
                    }
                }
                return Program.DisplayChar(result);
            }
        }
        public void ToggleUpperToLower(ref char c)
        {
            if (c >= 65 && c <= 90)
                c = (char)(c + 32);
        }
    }
}