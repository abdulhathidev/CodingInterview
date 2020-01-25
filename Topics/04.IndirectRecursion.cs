using System;

namespace CodingInterview.Topics
{
    public class IndirectRecursion
    {
        public IndirectRecursion()
        {
            Console.Write("04. Indirect Recursion : ");
            funA(11);
            Console.WriteLine();
        }
        public void funA(int n)
        {
            if (n > 0)
            {
                Console.Write("fA : {0}, ", n);
                funB(n - 1);
            }
        }
        public void funB(int n)
        {
            if (n > 0)
            {
                Console.Write("fB : {0}, ", n);
                funA(n / 2);
            }
        }
    }
}