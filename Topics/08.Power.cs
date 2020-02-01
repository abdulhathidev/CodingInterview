using System;

namespace CodingInterview.Topics
{
    public class Power
    {
        public Power()
        {
            Console.WriteLine("08. Power Recursive : {0}", Power_Recursive(2, 4));
            Console.WriteLine("08. Power Iterative : {0}", Power_Iterative(2, 4));
        }
        public int Power_Recursive(int m, int n)
        {
            /*
                m to the power of n : m^n
            */
            if (n == 1)
                return m;
            return Power_Recursive(m, n - 1) * m;
        }
        public int Power_Iterative(int m, int n)
        {
            int sum = 1;
            for (int i = 0; i < n; i++)
            {
                sum *= m;
            }
            return sum;
        }
    }
}