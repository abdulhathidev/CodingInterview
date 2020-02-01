using System;

namespace CodingInterview.Topics
{
    public class Node
    {
        public int data;
        public Node next;
    }
    public class Queue
    {
        Node front;
        Node rear;
        public Queue()
        {

        }
        public void Enqueue(Node node)
        {
            if (front == null)
            {
                front = rear = node;
            }
            else
            {
                rear.next = node;
                rear = rear.next;
            }
        }
        public Node Dequeue()
        {
            Node node = null;
            if (front == null)
                Console.WriteLine("Queue is empty");
            else
            {
                node = front;
                front = front.next;
            }
            return node;
        }
        public bool IsEmpty()
        {
            return front == null;
        }
        public Node Peek()
        {
            return front;
        }
    }
}