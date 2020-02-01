using System;

namespace CodingInterview.Topics
{
    public class Factorial
    {
        public Factorial()
        {
            Console.WriteLine("07. Factorial Recursive : {0}", Factorial_Recursive(4));
            Console.WriteLine("07. Factorial Iterative : {0}", Factorial_Iterative(4));
        }
        public int Factorial_Recursive(int n)
        {
            if (n == 1)
                return 1;
            return Factorial_Recursive(n - 1) * n;
        }
        public int Factorial_Iterative(int n)
        {
            int sum = 1;
            for (int i = 1; i <= n; i++)
            {
                sum *= i;
            }
            return sum;
        }
    }
}