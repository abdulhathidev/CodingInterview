using System;

namespace CodingInterview.Topics
{
    public class TaylorSeriesByHornersRule
    {
        public TaylorSeriesByHornersRule()
        {
            Console.WriteLine("10. TaylorSeriesUsing Horners Rule Iterative : {0}", TaylorSeriesUsingHornersRule_Iterative(2, 3));
            Console.WriteLine("10. TaylorSeriesUsing Horners Rule Recursive : {0}", TaylorSeriesUsingHornersRule_Recursive(2, 10));
        }

        public double TaylorSeriesUsingHornersRule_Iterative(int x, int n)
        {
            /*
                =1 + x/1 + x²/1*2 + x³/1*2*3 + x⁴/1*2*3*4
                =1 + x/1[x/2 + x²/2*3 + x³/2*3*4]
                =1 + x/1[1 + x/2[1 + x/3 + x²/3*4]]
                =1 + x/1[1 + x/2[1 + x/3[1 + x/4]]]
            */

            double sum = 1.00;
            for (; n > 0; n--)
                sum = (1 + x * sum / n);
            return sum;
        }
        double sum = 1.00;
        public double TaylorSeriesUsingHornersRule_Recursive(int x, int n)
        {
            if (n == 0) return sum;
            sum = (1 + x * sum / n);
            return TaylorSeriesUsingHornersRule_Recursive(x, n - 1);
        }
    }
}