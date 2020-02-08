using System;

namespace CodingInterview.InterviewCake
{
    public class LinkedListNode
    {
        public int Value { get; set; }

        public LinkedListNode Next { get; set; }

        public LinkedListNode(int value)
        {
            Value = value;
        }
    }


    public class DeleteNodeInSLL
    {
        public DeleteNodeInSLL()
        {
            var head = new LinkedListNode(1);
            AppendToList(head, 2);
            AppendToList(head, 3);
            AppendToList(head, 4);
            DeleteNode(head);
            Console.WriteLine("Empty Class");
        }
        public static void DeleteNode(LinkedListNode nodeToDelete)
        {
            // Delete the input node from the linked list
            if (nodeToDelete != null)
            {
                nodeToDelete = nodeToDelete.Next;
            }
        }
        private static LinkedListNode AppendToList(LinkedListNode head, int value)
        {
            var current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new LinkedListNode(value);
            return current.Next;
        }
    }
}