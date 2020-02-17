using System;

namespace CodingInterview.Topics
{
    public class ASCII
    {
        public ASCII()
        {
            int n = (int)'0';

            Console.WriteLine((int)('0') - n);

            Console.WriteLine((int)('1') - n);

            Console.WriteLine((int)('2') - n);

            char c = '1';
            int k = c - n;
             Console.WriteLine(k);
        }
    }
}