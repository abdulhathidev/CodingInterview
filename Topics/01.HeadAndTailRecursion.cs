using System;

namespace CodingInterview.Topics
{
    public class HeadAndTailRecursion
    {
        public HeadAndTailRecursion()
        {
            Console.Write("01. Head Recursion : ");
            HeadRecursion(3);
            Console.WriteLine();
            Console.Write("01. Tail Recursion : ");
            TailRecursion(3);
            Console.WriteLine();
        }
        public void HeadRecursion(int n)
        {
            if (n > 0)
            {
                HeadRecursion(n - 1);
                Console.Write(n + " ");
            }
        }
        public void TailRecursion(int n)
        {
            if (n > 0)
            {
                Console.Write(n + " ");
                TailRecursion(n - 1);
            }
        }
    }
}