using System;

namespace CodingInterview.Topics
{
    public class Fibonacci
    {
        /*   0  1  2  3  4  5  6  7 
            [0][1][1][2][3][5][8][13]

            fib(n) = fib(n-2)+fib(n-1)
        */
        public Fibonacci()
        {
            Console.WriteLine("11. Fibonacci Iterative : {0}", Fibonacci_Iterative(7));
            Console.WriteLine("11. Fibonacci Recursive : {0}", Fibonacci_Recursive(7));
            Console.WriteLine("11. Fibonacci Recursive Memoization : {0}", Fibonacci_RecursiveByMemoization(7));
        }
        public int Fibonacci_Iterative(int n)
        {
            int sum = 0, f0 = 0, f1 = 1;
            if (n <= 1) return n;
            for (int i = 1; i < n; i++)
            {
                sum = f0 + f1;
                f0 = f1;
                f1 = sum;
            }
            return sum;
        }

        public int Fibonacci_Recursive(int n)
        {
            if (n <= 1) return n;
            return Fibonacci_Recursive(n - 2) + Fibonacci_Recursive(n - 1);
        }

        int[] fibArray;
        public int Fibonacci_RecursiveByMemoization(int n)
        {
            if (fibArray == null) fibArray = new int[n + 1];
            if (n <= 1)
            {
                fibArray[n] = n;
                return n;
            }
            else
            {
                if (fibArray[n - 1] == 0) fibArray[n - 1] = Fibonacci_RecursiveByMemoization(n - 1);
                if (fibArray[n - 2] == 0) fibArray[n - 2] = Fibonacci_RecursiveByMemoization(n - 2);
                return fibArray[n - 2] + fibArray[n - 1];
            }
        }
    }
}