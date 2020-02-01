using System;

namespace CodingInterview.Topics
{
    public class String
    {
        char[] name = "ABDULhathi".ToCharArray();
        string name1 = "ABDUL hathi  mohamed   hussain";
        string palindrome = "maDam";
        string duplicate = "abdulhathi";
        string anagram1 = "medical";
        string anagram2 = "decimalq";
        string permutationString = "ABC";
        public String()
        {
            Console.WriteLine("15. String ---------------------------");
            Console.WriteLine("01. Toggle charecte case : {0}", ToggleCharCase(name));
            Console.WriteLine("02. {0} '{1}'", CountingTheWords(name1.ToCharArray()), name1);
            Console.WriteLine("03. Reverse a string : {0}", ReverseAString(name));
            Console.WriteLine("04. {1} Is valid palindrome : {0}", IsPalindrome(palindrome.ToCharArray()), palindrome);
            Console.WriteLine("05. Duplidate charecters in the string {1} ? {0}", IsDuplicateCharInString(duplicate.ToCharArray()), duplicate);
            Console.WriteLine("06. Find duplidate charecters by bitwise in string {1} ? {0}", FindDuplicateCharByBitWise(duplicate.ToCharArray()), duplicate);
            Console.WriteLine("07. Is two are Anagram {1} & {2} ? {0}", IsTwoAreAnagram(anagram1.ToCharArray(), anagram2.ToCharArray()), anagram1, anagram2);
            Console.Write("07. Permutation : "); PrintPermutation(permutationString.ToCharArray(), 0, permutationString.Length - 1); Console.WriteLine();
        }
        public string Display(char[] input)
        {
            string result = "";
            for (int i = 0; i < input.Length; i++)
                result += input[i];
            return result;
        }
        public string ToggleCharCase(char[] input)
        {
            for (int i = 0; i < input.Length; i++)
                if (input[i] >= 65 && input[i] <= 90)
                    input[i] = (char)(input[i] + 32);
                else if (input[i] >= 97 && input[i] <= 122)
                    input[i] = (char)(input[i] - 32);
            return Display(input);
        }
        public string CountingTheWords(char[] input)
        {
            int count = 1;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == ' ' && input[i - 1] != ' ')
                    count++;
            }
            return count + " number or words in this string";
        }
        public string ReverseAString(char[] input)
        {
            for (int i = 0, j = input.Length - 1; i < j; i++, j--)
            {
                Swap(ref input[i], ref input[j]);
            }
            return Display(input);
        }
        public void Swap(ref char x, ref char y)
        {
            char t = x; x = y; y = t;
        }
        public char UpperToLower(char c)
        {
            return (c >= 65 && c <= 90) ? (char)(c + 32) : c;
        }
        public bool IsPalindrome(char[] input)
        {
            int[] hashTable = new int[26];
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int c = UpperToLower(input[i]) - 97;
                hashTable[c]++; count++;
                if (hashTable[c] > 1)
                {
                    hashTable[c] -= 2;
                    count -= 2;
                }
            }
            return count <= 1;
        }
        public bool IsDuplicateCharInString(char[] input)
        {
            int[] hashTable = new int[26];
            for (int i = 0; i < input.Length; i++)
            {
                int c = UpperToLower(input[i]) - 97;
                hashTable[c]++;
                if (hashTable[c] > 1)
                    return true;
            }
            return false;
        }
        public bool FindDuplicateCharByBitWise(char[] input)
        {
            int x = 0, h = 0;
            for (int i = 0; i < input.Length; i++)
            {
                x = 1 << (input[i] - 97);
                if ((x & h) > 0) return true;
                // Console.WriteLine("x    : " + Convert.ToString(x, 2));
                // Console.WriteLine("h    : " + Convert.ToString(h, 2));
                // Console.WriteLine("x&h  : " + Convert.ToString(x & h, 2));
                h = x | h;
                // Console.WriteLine("x|h  : " + Convert.ToString(h, 2));
            }
            return false;
        }
        public bool IsTwoAreAnagram(char[] str1, char[] str2)
        {
            if (str1.Length != str2.Length)
                return false;
            int[] hashTable = new int[26];
            int counter = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                int c1 = UpperToLower(str1[i]) - 97;
                hashTable[c1]++; counter++;
                int c2 = UpperToLower(str2[i]) - 97;
                hashTable[c2]++; counter++;
                if (hashTable[c1] > 1)
                {
                    hashTable[c1] -= 2;
                    counter -= 2;
                }
                if (hashTable[c2] > 1)
                {
                    hashTable[c2] -= 2;
                    counter -= 2;
                }
            }
            return counter == 0;
        }
        public void PrintPermutation(char[] input, int left, int right)
        {
            /*
                                     ABC                                 
                        ABC          BAC          CBA         
                    ABC     ACB  BAC     BCA  CBA     CAB 
            */
            if (left == right)
            {
                Console.Write(Display(input) + ", ");
            }
            else
            {
                for (int i = left; i < input.Length; i++)
                {
                    Swap(ref input[i], ref input[left]);
                    PrintPermutation(input, left + 1, right);
                    Swap(ref input[i], ref input[left]);
                }
            }
        }
    }
}