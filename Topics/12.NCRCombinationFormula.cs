using System;

namespace CodingInterview.Topics
{
    public class NCRCombinationFormula
    {
        /*
            NCr - Combination Formual =  n!/r!(n-r)!
            Pascal's Triangle
                            1                                   0C0              
                        1       1                           1C0     1C1     
                    1       2       1                   2C0     2C1     2C2
                1       3       3       1           3C0     3C1     3C2     3C3
            1       4       6       4       1   4C0     4C1     4C2     4C3     4C4

            4C2 = 3C1 + 3C2;
            NCR = (n-1)C(r-1) + (n-1)Cr;
        */
        public NCRCombinationFormula()
        {
            Console.WriteLine("12. NCR by factorial method : {0}", NCRByFactorial(4, 2));
            Console.WriteLine("12. NCR by Pascal's Triangle method : {0}", NCRByPascalTriangle_Recursive(4, 2));
        }
        public int Factorial(int n)
        {
            int sum = 1;
            for (int i = 1; i < n; i++)
            {
                sum *= i;
            }
            return sum;
        }
        public int NCRByFactorial(int n, int r)
        {
            int nfact = Factorial(n);
            int rfact = Factorial(r);
            int nminusrfact = Factorial(n - r);
            return nfact / rfact * nminusrfact;
        }
        public int NCRByPascalTriangle_Recursive(int n, int r)
        {
            if (r == 0 || n == r)
                return 1;
            else
            {
                return NCRByPascalTriangle_Recursive(n - 1, r - 1) + NCRByPascalTriangle_Recursive(n - 1, r);
            }
        }
    }
}