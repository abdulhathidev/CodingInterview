using System;

namespace CodingInterview.StacksAndQueues
{
    public class StackMin
    {
        public StackMin()
        {
            Stack<int> st = new Stack<int>();
            st.Push(10);
            st.Push(20);
            st.Push(90);
            st.Push(80);
            st.Push(50);
            Console.Write("3.2. Stack with Min() ");
            while (!st.IsEmpty())
            {
                Console.Write(st.Pop() + " ");
                Console.Write("Min : " + st.Min() + " ");
            }
            Console.WriteLine();
        }
    }
}