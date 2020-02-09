using System;
using System.Collections.Generic;

namespace CodingInterview.CTCI
{
    public class ArraysAndStrings
    {
        public ArraysAndStrings()
        {
            Console.WriteLine("01. Arrays And Strings : ");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("01. Check is Unique char by Bit Vector   : {0}", IsUniqueBitVector("abdulhathi".ToCharArray()));
            Console.WriteLine("01. Check is Unique char by Hash table   : {0}", IsUniqueCharByHashtable("abdulhathi".ToCharArray()));
            Console.WriteLine("02. Check Permutation of two strings     : {0}", CheckPermutation("medical".ToCharArray(),"decimal".ToCharArray()));
            Console.WriteLine("02. Check Permutation of two strings     : {0}", CheckPermutationInSpecialCase("?Abc".ToCharArray(),"b  ac?".ToCharArray()));
            Console.WriteLine("03. URL ify                              : {0}", URLify("Mr John Smith   ".ToCharArray(), 13));
        }

        public char UpperToLower(char c)
        {
            return (c >= 65 && c <= 90) ? (char)(c + 32) : c;
        }
        public bool IsUniqueBitVector(char[] str)
        {
            int x = 0,h = 0;
            for(int i = 0; i < str.Length; i++)
            {
                x = 1 << (UpperToLower(str[i]) - 97);
                if((x&h) > 0) return false; 
                h = x|h;
            }
            return true;
        }
        public bool IsUniqueCharByHashtable(char[] str)
        {
            int[] hashTable = new int[26];
            for(int i = 0; i < str.Length; i++)
            {
                int c = UpperToLower(str[i]) - 97;
                hashTable[c]++;
                if(hashTable[c] > 1)
                    return false;
            }
            return true;
        }
        //This method for Same length, only charecters and no empty spaces.
        public bool CheckPermutation(char[] str1,char[] str2)
        {
            if(str1.Length != str2.Length) return false;
            int[] hashTable = new int[26];
            int counter = 0;
            for(int i = 0; i< str1.Length; i++)
            {
                int c1 = UpperToLower(str1[i]) - 97;
                int c2 = UpperToLower(str2[i]) - 97;
                hashTable[c1]++;
                hashTable[c2]++;
                if(hashTable[c1] > 1)
                    counter++;
                if(hashTable[c2] > 1 && c1 != c2)
                    counter++;
            }
            return counter == str1.Length;
        }
        //This method allow empty spaces and special charters and lower and upper cases also
        public bool CheckPermutationInSpecialCase(char[] str1, char[] str2)
        {
            int[] hashTable = new int[128];
            int m = str1.Length, n = str2.Length, length = (m > n) ? m : n;
            int counter = 0;
            int s1 = 0, s2 = 0;
            for (int i = 0; i < length; i++)
            {
                if (i < m && str1[i] != ' ')
                {
                    int c1 = UpperToLower(str1[i]);
                    hashTable[c1] += hashTable[c1] > 0 ? -1 : 1;
                    counter = (hashTable[c1] == 0) ? counter + 1 : counter;
                    s1++;
                }
                if (i < n && str2[i] != ' ')
                {
                    int c2 = UpperToLower(str2[i]);
                    hashTable[c2] += hashTable[c2] > 0 ? -1 : 1;
                    counter = (hashTable[c2] == 0) ? counter + 1 : counter;
                    s2++;
                }
            }
            return (s1 == s2 && counter == s1);
        }

        public string URLify(char[] str, int length)
        {
            List<char> result = new List<char>();
            for (int i = 0; i < length; i++)
            {
                if (str[i] == ' ' && str[i-1] != ' ')
                {
                    result.Add('%');
                    result.Add('2');
                    result.Add('0');
                }
                else
                    result.Add(str[i]);
            }
            return Display(result.ToArray());
        }
        public string Display(char[] str)
        {
            string result = "";
            for (int i = 0; i < str.Length;i++)
                result += str[i];
            return result;
        }
    }
}