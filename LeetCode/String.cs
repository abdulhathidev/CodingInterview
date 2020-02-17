using System;

namespace CodingInterview.LeetCode
{
    public class String
    {
        public String()
        {
            FreqAlphabets("10#11#12");
        }
        public string FreqAlphabets(string s)
        {
            string result = string.Empty;
            int i = 0;
            while (i < s.Length)
            {
                if (i + 2 < s.Length && s[i + 2] == '#')
                {
                    int k = (s[i] - '0') * 10 + (s[i + 1] - '0');
                    result += (char)(k + 96);
                    i += 3;
                }
                else
                {
                    result += (char)((s[i] - '0') + 96);
                    i++;
                }
            }
            return result;
        }
    }
}