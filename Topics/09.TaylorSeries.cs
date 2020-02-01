using System;

namespace CodingInterview.Topics
{
    public class TaylorSeries
    {
        int p = 1, f = 1;
        public TaylorSeries()
        {
            Console.WriteLine("09. TaylorSeries_Recursive : {0}", TaylorSeries_Recursive(2, 3));
            Console.WriteLine("09. TaylorSeries_Iterative : {0}", TaylorSeries_Iterative(2, 3));
        }
        public int TaylorSeries_Recursive(int x, int n)
        {
            /*
                e(x,n) = 1 + x/1 + x^2/2! + x^3/3! + .... + n times.
            */
            if (n == 0)
                return 1;
            int result = TaylorSeries_Recursive(x, n - 1);
            p = p * x;
            f = f * n;
            return result + p / f;
        }
        public double TaylorSeries_Iterative(int x, int n)
        {
            double sum = 1, num = 1, den = 1;
            for (int i = 1; i <= n; i++)
            {
                num *= x;
                den *= i;
                sum += num / den;
            }
            return sum;
        }
    }
}