using System;

namespace CodingInterview.Topics
{
    public class KMPAlgorithm
    {
        public KMPAlgorithm()
        {
            string str = "ababcabcabababd";
            string pattern = "ababd";
            Console.WriteLine("KMP Algo : String '{0}' match with this pattern '{1}' : {2}",
            str, pattern, KMPPatternMatchingAlgo(str, pattern));
        }

        public bool KMPPatternMatchingAlgo(string str, string pattern)
        {
            int[] piTable = PreparePITable(pattern);
            int i = 0, j = -1;
            while (i < str.Length)
            {
                if (j < pattern.Length && str[i] != pattern[j + 1])
                {
                    if (j > -1)
                        j = piTable[j] - 1;
                    else
                        i++;
                }
                else
                {
                    j++; i++;
                    if (j + 1 == pattern.Length - 1)
                        return true;
                }

            }
            return false;
        }
        public int[] PreparePITable(string pattern)
        {
            int[] piTable = new int[pattern.Length];
            int[] hashTable = new int[26];
            for (int i = 0; i < pattern.Length; i++)
            {
                int c = UpperToLower(pattern[i]);
                hashTable[c]++;
            }
            for (int i = pattern.Length - 1; i >= 0; i--)
            {
                int c = UpperToLower(pattern[i]);
                piTable[i] = hashTable[c] > 1 ? c + 1 : 0;
                hashTable[c]--;
            }
            return piTable;
        }
        public int UpperToLower(char c)
        {
            return (c >= 65 && c <= 90) ? (c - 32) - 97 : (c - 97);
        }
    }
}