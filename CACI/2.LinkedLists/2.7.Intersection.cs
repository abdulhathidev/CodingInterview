using System;
using System.Collections;

namespace CodingInterview.LinkedLists
{
    public class Intersection
    {
        public Intersection()
        {
            /*
                1 -> 9  
                        -> 4 -> 5 -> 6 -> 7 -> 8
                2 -> 3
            */
            Node<int> first = LinkedList.BuildNode(new int[] { 1, 9, 4, 5, 6, 7, 8 });
            Node<int> second = LinkedList.BuildNode(new int[] { 2, 3 });
            second.next.next = first.next.next;
            var result = FindIntersection(first, second);
            Console.WriteLine("2.7. Intersecting Node : {0}", LinkedList.Display(result));
        }

        public Node<int> FindIntersection(Node<int> node1, Node<int> node2)
        {
            Stack st1 = new Stack(), st2 = new Stack();
            Node<int> intersection = null;
            while (node1 != null)
            {
                st1.Push(node1);
                node1 = node1.next;
            }
            while (node2 != null)
            {
                st2.Push(node2);
                node2 = node2.next;
            }
            while (st1.Count > 0)
            {
                intersection = st2.Pop() as Node<int>;
                if (st1.Pop() != intersection)
                    break;
            }
            return intersection.next;
        }
    }
}