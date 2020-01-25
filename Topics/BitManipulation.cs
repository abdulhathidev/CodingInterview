using System;

namespace CodingInterview.Topics
{
    public class BitManipulation
    {
        public BitManipulation()
        {
            Console.WriteLine("{0} ANDING {1}       : {2}", 10, 6, 10 & 6);
            Console.WriteLine("{0} ORING {1}        : {2}", 10, 6, 10 | 6);
            Console.WriteLine("{0} LEFT SHIFT {1}   : {2}", 1, 0, 1 << 0);

            Console.WriteLine("{0} ANDING {1}       : {2}", 1, 0, 1 & 0);
            Console.WriteLine("{0} ORING {1}        : {2}", 1, 0, 1 | 0);
        }
    }
}