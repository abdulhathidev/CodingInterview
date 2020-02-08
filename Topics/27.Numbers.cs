using System;

namespace CodingInterview.Topics
{
    public class Numbers
    {
        public Numbers()
        {
            Console.WriteLine("27. Numbers");
            int n = 169;
            Console.WriteLine("01. {0} Is Prime number ? {1} \n", n, IsPrime(n));
            int f = 4;
            Console.WriteLine("02. Factorial of {0} is {1} \n", f, Factorial(f));
            string str = "abc";
            Permutation(str, "");
            Console.WriteLine("03. Permutation of {0} \n", str);
            int pof2 = 4;
            Console.WriteLine("03. Power of 2 for {0} is {1} \n", 4, PowersOf2(pof2));
        }

        public bool IsPrime(int n)
        {
            for (int i = 2; i * i <= n; i++)
            {
                Console.WriteLine("Square root of N : {0} & i : {1}", Math.Sqrt(n), i);
                if (n % i == 0) return false;
            }
            return true;
        }
        public int Factorial(int n)
        {
            Console.WriteLine("Factorial {0}", n);
            if (n < 0) return -1;
            else if (n == 0) return 1;
            else
                return n * Factorial(n - 1);
        }
        public void Permutation(string str, string perfix)
        {
            if (str.Length == 0) Console.WriteLine(perfix);
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    string rem = str.Substring(0, i) + str.Substring(i + 1);
                    Permutation(rem, perfix + str[i]);
                }
            }
        }
        public int PowersOf2(int n)
        {
            if (n <= 1)
            {
                Console.WriteLine(n);
                return n;
            }
            else
            {
                int prev = PowersOf2(n / 2);
                int curr = prev * 2;
                Console.WriteLine(curr);
                return curr;
            }
        }
    }
}