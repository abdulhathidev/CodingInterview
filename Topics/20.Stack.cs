using System;

namespace CodingInterview.Models.Topics
{
    public class Node
    {
        public int data;
        public Node next;
    }
    public class Stack
    {
        /*
            Last In First Out (LIFO)

                | 9 |
                | 8 |
                | 7 |
                | 5 |
                | 4 |
                | 2 |
                |___|   

        */
        public Node top;
        public Stack()
        {

        }
        public void Push(Node node)
        {
            if (top == null)
            {
                top = node;
            }
            else
            {
                node.next = top;
                top = node;
            }
        }
        public Node Pop()
        {
            Node node = null;
            if (top == null)
                Console.WriteLine("Stack is Empty !");
            else
            {
                node = top;
                top = top.next;
            }
            return node;
        }
        public Node Peek()
        {
            return top;
        }
        public bool IsEmpty()
        {
            return top == null;
        }
    }
}