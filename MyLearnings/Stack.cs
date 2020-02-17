using System;

namespace CodingInterview.MyLearnings
{
    public class Stack<T>
    {
        int top;
        T[] array;
        public void Enqueue(T item)
        {
            array[top++] = item;
        }
        public T Dequeue()
        {
            return array[top--];
        }
    }
}