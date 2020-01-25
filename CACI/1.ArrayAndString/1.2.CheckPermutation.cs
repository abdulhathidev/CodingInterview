using System;

namespace CodingInterview.ArrayAndString
{
    public class CheckPermutation
    {
        public CheckPermutation()
        {
            string str1 = "ABC", str2 = "BCA";
            Console.WriteLine("1.2. The first string '{0}' is {2}the permutation of the other '{1}'", str1, str2,
            CheckPermGivenTwoString(str1.ToCharArray(), str2.ToCharArray()) ? "" : "not ");
        }

        public bool CheckPermGivenTwoString(char[] str1, char[] str2)
        {
            int[] hashTable = new int[128];
            for (int i = 0; i < str1.Length; i++)
                hashTable[str1[i]]++;
            for (int i = 0; i < str2.Length; i++)
            {
                hashTable[str2[i]]--;
                if (hashTable[str2[i]] <= -1)
                    return false;
            }
            return true;
        }
    }
}