using System;

namespace CodingInterview.Topics
{
    public class StaticVsGlobalVarRecursion
    {
        static int x = 0;
        int y = 0;
        public StaticVsGlobalVarRecursion()
        {
            Console.WriteLine("02. Static Variable : {0}", StaticVariablRecursion(3));
            Console.WriteLine("02. Global Variable : {0}", GlobalVariableRecursion(3));
        }
        public int StaticVariablRecursion(int n)
        {
            if (n > 0)
            {
                x++;
                //Console.WriteLine("{0} {1}", x, n - 1);
                return StaticVariablRecursion(n - 1) + x;
            }
            return 0;
        }
        public int GlobalVariableRecursion(int n)
        {
            if (n > 0)
            {
                y++;
                //Console.WriteLine("{0} {1} {2}", y, n - 1, x);
                return GlobalVariableRecursion(n - 1) + y + x;
            }
            return 0;
        }
    }
}