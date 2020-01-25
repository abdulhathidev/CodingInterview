using System;
using System.Collections.Generic;

namespace CodingInterview.LinkedLists
{
    public class RemoveDups
    {
        public RemoveDups()
        {
            Node<int> root = LinkedList.RootNode();
            Console.WriteLine("2.1. Before removing duplicates      : {0} ", Display(root));
            //Console.WriteLine("2.1. After duplicates removed by Hash: {0} ", RemoveDuplicateByHash(root));
            Console.WriteLine("2.1. After duplicates removed        : {0} ", RemoveDuplicate(root));
        }
        public string Display(Node<int> node)
        {
            string result = "";
            while (node != null)
            {
                result += node.data + " -> ";
                node = node.next;
            }
            return result;
        }
        public string RemoveDuplicateByHash(Node<int> node)
        {
            HashSet<int> hashSet = new HashSet<int>();
            Node<int> t = null, p = node;
            while (p != null)
            {
                if (hashSet.Contains(p.data))
                {
                    t.next = p.next;
                    p = t;
                }
                else
                {
                    hashSet.Add(p.data);
                }
                t = p;
                p = p.next;
            }
            return Display(node);
        }

        public string RemoveDuplicate(Node<int> node)
        {
            Node<int> p = node;
            while (p != null)
            {
                Node<int> p1 = p.next, t = null;
                while (p1 != null)
                {
                    if (p1.data == p.data)
                    {
                        t.next = p1.next;
                        p1 = t;
                    }
                    t = p1;
                    p1 = p1.next;
                }
                p = p.next;
            }
            return Display(node);
        }
    }
}