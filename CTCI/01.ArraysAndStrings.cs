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
            Console.WriteLine("04. This is Permuation of Palindrome     : {0}",IsPermuationOfPalindrome("abca")); //PrintPermutation("Tact Coa".ToCharArray(), 0, 7);
            //BitVector();
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

        public void PrintPermutation(char[] str, int left, int right)
        { 
            if(left == right) Console.WriteLine(str);
            else
            {
                for (int i = left; i <= right; i++)
                {
                    Swap(ref str[i], ref str[left]);
                    PrintPermutation(str, left + 1, right);
                    Swap(ref str[i], ref str[left]);
                }
            }
        }
        public void Swap(ref char x, ref char y)
        {
            char t = x; x = y; y = t;
        }

        public int GetCharNumber(char c)
        {
            if (c >= 65 && c <= 90)
                return (c + 32) - 97;
            else if (c >= 97 && c <= 122)
                return c - 97;
            else
                return -1;
        }
        public bool PermutationOfPalindrome(char[] str)
        {
            int[] hashTable = new int[26];
            int x, count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                x = GetCharNumber(str[i]);
                if (x != -1)
                {
                    hashTable[x]++;
                    if (hashTable[x] % 2 == 1)
                        count++;
                    else
                        count--;
                }
            }
            return count <= 1;
        }

        public void BitVector()
        {
            int x = 0;
            x = 1 << 4;
            Console.WriteLine(Convert.ToString(10, 2));
            Console.WriteLine(Convert.ToString(x, 2));
            Console.WriteLine(Convert.ToString(x-1, 2));
            Console.WriteLine(1&0);
            Console.WriteLine(1|0);
            Console.WriteLine(1^0);
            sbyte i = -6;
            Console.WriteLine(Convert.ToInt32("11111111",2));
            Console.WriteLine(Convert.ToString(i, 2));
            //Console.WriteLine(Convert.ToInt32("11101110", 2));
        }
        public bool IsPermuationOfPalindrome(string str)
        {
            int bitVector = 0;
            for(int i =0;i<str.Length;i++)
            {
                int c = GetCharNumber(str[i]);
                bitVector = Toggle(bitVector,c);
                
            }
            //Console.WriteLine(Convert.ToString((bitVector -1),2));
            return (bitVector == 0 || ((bitVector & (bitVector -1)) == 0));
        }

        public int Toggle(int bitVector,int index)
        {
            if(index < 0) return bitVector;
            int mask = 1 << index;
            //Console.WriteLine("mask {0} - {1}",index, Convert.ToString(mask,2));
            if((bitVector & mask) == 0)
            {
                //Console.WriteLine("bitVector : {0} | Mask : {1} = {2}",Convert.ToString(bitVector,2), Convert.ToString(mask,2),
                //Convert.ToString((bitVector | mask),2));
                bitVector |= mask;
            }
            else
            {
                //Console.WriteLine("bitVector {0} & ~{1} = {2}",Convert.ToString(bitVector,2), Convert.ToString(~mask,2),
                //Convert.ToString((bitVector & ~mask),2));
                bitVector &= ~mask;
            }
            //Console.WriteLine();
            return bitVector;
        }
    
    }
}