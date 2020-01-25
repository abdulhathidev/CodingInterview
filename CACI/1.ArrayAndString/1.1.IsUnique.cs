using System;

namespace CodingInterview.ArrayAndString
{
    public class IsUnique
    {
        public IsUnique()
        {
            string input = "abdulhathi";
            string input1 = "hathi";
            Console.WriteLine("1.1. {0} have the unique chars :{1}", input, IsUniqueCharInString(input));
            Console.WriteLine("1.1. {0} have the unique chars :{1}", input1, IsUniqueCheckByBitOperation(input1));
        }
        public bool IsUniqueCharInString(string input)
        {
            int[] hashTable = new int[128];
            for (int i = 0; i < input.Length; i++)
            {
                hashTable[input[i]]++;
                if (hashTable[input[i]] > 1)
                    return false;
            }
            return true;
        }
        public bool IsUniqueCheckByBitOperation(string input)
        {
            int h = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int x = 1 << (input[i] - 97);
                if ((x & h) > 0) return false;
                h = x | h;
            }
            return true;
        }
    }
}