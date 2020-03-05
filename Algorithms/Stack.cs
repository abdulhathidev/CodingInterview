using System;
using System.Collections.Generic;

namespace CodingInterview.Algorithms
{
    public class Evaluate
    {
        public Evaluate()
        {
            DijkstrasTwoStackAlgo("(1+((2+3)*(4*5)))".ToCharArray());
        }
        public void DijkstrasTwoStackAlgo(char[] args)
        {
            Stack<char> operations = new Stack<char>();
            Stack<double> values = new Stack<double>();
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case '(':
                        break;
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        operations.Push(args[i]);
                        break;
                    case ')':
                        var ops = operations.Pop();
                        var val = values.Pop();
                        if (ops == '+') val = values.Pop() + val;
                        else if (ops == '-') val = values.Pop() - val;
                        else if (ops == '*') val = values.Pop() * val;
                        else if (ops == '/') val = values.Pop() / val;
                        values.Push(val);
                        break;
                    default:
                        values.Push(Convert.ToDouble(args[i].ToString()));
                        break;
                }
            }
            Console.WriteLine(values.Pop());
        }
    }
}