using System;

namespace CodingInterview.Topics
{
    public class TreeRecursion
    {
        public TreeRecursion()
        {
            Console.Write("03. Tree Recursion : ");
            TreeRecursionByN(3);
            Console.WriteLine();
        }
        public void TreeRecursionByN(int n)
        {
            if (n > 0)
            {
                Console.Write("N : {0}, ", n);
                TreeRecursionByN(n - 1);
                TreeRecursionByN(n - 1);
            }
        }
    }
}