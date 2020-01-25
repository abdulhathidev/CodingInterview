using System;

namespace CodingInterview.StacksAndQueues
{
    public class StackNode<T>
    {
        public T data;
        public T min;
        public StackNode<T> next;
        public StackNode(T data)
        {
            this.data = data;
        }
        public StackNode(T data, T min)
        {
            this.data = data;
            this.min = min;
        }
    }
    public class Stack<T>
    {
        private StackNode<T> top;

        public T Pop()
        {
            if (top == null) throw new Exception("Stack is Empty");
            T item = top.data;
            top = top.next;
            return item;
        }
        public void Push(T item)
        {
            StackNode<T> t = new StackNode<T>(item, item);
            t.next = top;
            top = t;
        }
        public T Peek()
        {
            if (top == null) throw new Exception("Stack is Empty");
            return top.data;
        }
        public bool IsEmpty()
        {
            return top == null;
        }
        public T Min()
        {
            return top == null ? default(T) : top.min;
        }
    }

   
}