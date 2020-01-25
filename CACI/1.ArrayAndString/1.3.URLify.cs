using System;

namespace CodingInterview.ArrayAndString
{
    public class URLify
    {
        public URLify()
        {
            string input = "Mr John Smith    ";
            Console.Write("1.3. Replace the spaces with %20         : {0}\n", ReplaceTheSpaces(input.ToCharArray()));
            Console.Write("1.3. Replace the spaces Backwards %20    : {0}\n", ReplaceBackwards(input.ToCharArray(), 13));
        }

        public string ReplaceTheSpaces(char[] input)
        {
            char[] result = new char[input.Length];
            for (int i = 0, j = 0; j < input.Length; i++)
            {
                if (input[i] != ' ')
                    result[j++] = input[i];
                else
                {
                    result[j++] = '%';
                    result[j++] = '2';
                    result[j++] = '0';
                }
            }
            return Program.DisplayChar(result);
        }
        public string ReplaceBackwards(char[] input, int trueLength)
        {
            int strIndex = input.Length - 1;
            for (int i = trueLength - 1; i >= 0; i--)
            {
                if (input[i] == ' ')
                {
                    input[strIndex--] = '%';
                    input[strIndex--] = '2';
                    input[strIndex--] = '0';
                }
                else
                {
                    input[strIndex--] = input[i];
                }
            }
            return Program.DisplayChar(input);
        }
    }
}