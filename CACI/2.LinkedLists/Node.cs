using System;

namespace CodingInterview.LinkedLists
{
    public class Node<T>
    {
        public T data;
        public Node<T> next;
        public Node(T data)
        {
            this.data = data;
        }
    }
    public class LinkedList
    {
        public static string Display<T>(Node<T> node)
        {
            string result = "";
            while (node != null)
            {
                result += node.data + " -> ";
                node = node.next;
            }
            return result;
        }
        public static Node<int> RootNode()
        {
            Node<int> root = new Node<int>(3);
            root.next = new Node<int>(2);
            root.next.next = new Node<int>(8);
            root.next.next.next = new Node<int>(2);
            root.next.next.next.next = new Node<int>(6);
            root.next.next.next.next.next = new Node<int>(3);
            return root;
        }
        public static Node<char> RootCharNode()
        {
            Node<char> root = new Node<char>('a');
            root.next = new Node<char>('b');
            root.next.next = new Node<char>('c');
            root.next.next.next = new Node<char>('d');
            root.next.next.next.next = new Node<char>('e');
            root.next.next.next.next.next = new Node<char>('f');
            return root;
        }
        public static Node<int> PartitionRootNode()
        {
            Node<int> root = new Node<int>(3);
            root.next = new Node<int>(5);
            root.next.next = new Node<int>(8);
            root.next.next.next = new Node<int>(5);
            root.next.next.next.next = new Node<int>(10);
            root.next.next.next.next.next = new Node<int>(2);
            root.next.next.next.next.next.next = new Node<int>(1);
            return root;
        }
        public static Node<int> l1()
        {
            var n = new Node<int>(7);
            n.next = new Node<int>(1);
            n.next.next = new Node<int>(6);
            return n;
        }
        public static Node<int> l2()
        {
            var n = new Node<int>(5);
            n.next = new Node<int>(9);
            n.next.next = new Node<int>(2);
            return n;
        }

        public static Node<T> BuildNode<T>(T[] list)
        {
            Node<T> root = new Node<T>(list[0]);
            Node<T> temp = root;
            for (int i = 1; i < list.Length; i++)
            {
                temp.next = new Node<T>(list[i]);
                temp = temp.next;
            }
            return root;
        }
    }
}