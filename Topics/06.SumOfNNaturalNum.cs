using System;

namespace CodingInterview.Topics
{
    public class SumOfNNaturalNum
    {
        public SumOfNNaturalNum()
        {
            Console.WriteLine("06. Sum Of N Natural Number Recursive : {0}", SumOfNNaturalNumber_Recursive(3));
            Console.WriteLine("06. Sum Of N Natural Number Iterative : {0}", SumOfNNaturalNumber_Iterative(3));
        }
        public int SumOfNNaturalNumber_Recursive(int n)
        {
            if (n == 0) return 0;
            return SumOfNNaturalNumber_Recursive(n - 1) + n;
        }
        public int SumOfNNaturalNumber_Iterative(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
}