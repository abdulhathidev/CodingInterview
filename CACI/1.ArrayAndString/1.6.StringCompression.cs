using System;

namespace CodingInterview.ArrayAndString
{
    public class StringCompression
    {
        public StringCompression()
        {
            Console.WriteLine("1.6. Compressed String : {0}", CompressString("aabcccccaaa".ToCharArray()));
        }

        public string CompressString(char[] input)
        {
            char tailChar = '\0';
            string result = ""; int charCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (tailChar != input[i])
                {
                    if (tailChar != '\0')
                    {
                        result += tailChar + ((charCount > 0) ? charCount.ToString() : "");
                        charCount = 0;
                    }
                    tailChar = input[i];
                    charCount++;
                }
                else
                {
                    charCount++;
                }
            }
            result += tailChar + ((charCount > 0) ? charCount.ToString() : "");
            if (result.Length <= input.Length)
                return result;
            return Program.DisplayChar(input);
        }
    }
}