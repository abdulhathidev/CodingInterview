using System;

namespace CodingInterview.Topics
{
    public class NestedRecursion
    {
        public NestedRecursion()
        {
            Console.WriteLine("05. Nested Recursion : {0}", Nested_Recursion(99));
        }
        public int Nested_Recursion(int n)
        {
            /*
                
            */
            //Console.WriteLine(n);
            if (n > 100)
                return n - 10;
            return Nested_Recursion(Nested_Recursion(n + 11));
        }
    }
}