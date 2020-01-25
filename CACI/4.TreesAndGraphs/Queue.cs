using System;

namespace CodingInterview.TreesAndGraphs
{
    public class QueueNode<T>
    {
        public T data;
        public QueueNode<T> next;
        public QueueNode(T data)
        {
            this.data = data;
        }
    }
    public class Queue<T>
    {
        QueueNode<T> front;
        QueueNode<T> rear;

        public void Enqueue(T item)
        {
            QueueNode<T> queueNode = new QueueNode<T>(item);
            if (queueNode == null) throw new Exception("Queue is Full !");
            if (front == null)
                front = rear = queueNode;
            else
            {
                rear.next = queueNode;
                rear = queueNode;
            }
        }
        public T Dequeue()
        {
            T data = front.data;
            front = front.next;
            if (front == null)
                front = rear = null;
            return data;
        }
        public T Peek()
        {
            if (front == null) throw new Exception("Queue is Empty !");
            return front.data;
        }
        public bool IsEmpty()
        {
            return front == null;
        }
    }
    public class QueueTest
    {
        public QueueTest()
        {
            try
            {
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(10);
                queue.Enqueue(12);
                queue.Enqueue(11);
                queue.Enqueue(14);

                while (!queue.IsEmpty())
                {
                    Console.WriteLine(queue.Dequeue());
                }
                queue.Peek();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}