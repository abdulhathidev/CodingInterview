using System;

namespace CodingInterview.LinkedLists
{
    public class Partition
    {
        public Partition()
        {
            Node<int> root = LinkedList.PartitionRootNode();
            Console.WriteLine("2.4. Partition result : {0}", LinkedList.Display(PartitionNode(root, 5)));
        }

        public Node<int> PartitionNode(Node<int> node, int x)
        {
            Node<int> head = null, tail = null, p = null, q = null;
            while (node != null)
            {
                Node<int> n = new Node<int>(node.data);
                if (node.data < x)
                {
                    if (head == null)
                    {
                        head = n;
                        p = head;
                    }
                    else
                    {
                        p.next = n;
                        p = p.next;
                    }
                    //Console.WriteLine("head : " + node.data);
                }
                else
                {
                    if (tail == null)
                    {
                        tail = n;
                        q = tail;
                    }
                    else
                    {
                        q.next = n;
                        q = q.next;
                    }
                    //Console.WriteLine("tail : " + node.data);
                }
                node = node.next;
            }
            p.next = tail;
            return head;
        }

        public Node<int> PartitionList(Node<int> node, int x)
        {
            Node<int> head = node, tail = node;
            while (node != null)
            {
                Node<int> next = node.next;
                if (node.data < x)
                {
                    node.next = head;
                    head = node;
                }
                else
                {
                    tail.next = node;
                    tail = node;
                }
                node = next;
            }
            tail.next = null;
            return head;
        }
    }
}