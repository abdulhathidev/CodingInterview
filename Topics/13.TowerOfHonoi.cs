using System;

namespace CodingInterview.Topics
{
    public class TowerOfHonoi
    {
        public TowerOfHonoi()
        {
            Console.Write("13. Tower of Honoi : ");
            TowerOfHonoi_Recursive(3, 1, 2, 3);
            Console.WriteLine();
        }

        public void TowerOfHonoi_Recursive(int n, int a, int b, int c)
        {
            if (n > 0)
            {
                TowerOfHonoi_Recursive(n - 1, a, c, b);
                Console.Write("T {0}-{1} | ", a, c);
                TowerOfHonoi_Recursive(n - 1, b, a, c);
            }
        }
    }
}