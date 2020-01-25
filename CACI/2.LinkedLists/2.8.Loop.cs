using System;

namespace CodingInterview.LinkedLists
{
    public class Loop
    {
        public Loop()
        {
            var root = LinkedList.BuildNode(new char[] { 'A', 'B', 'C', 'D', 'E' });
            var nodeC = root.next.next;
            var temp = root;
            while (temp != null)
            {
                if (temp.next == null)
                {
                    temp.next = nodeC;
                    break;
                }
                temp = temp.next;
            }
            Console.WriteLine("2.8. Loop node on the linked list is : {0}", DetectLoop(root));
        }
        public char DetectLoop(Node<char> node)
        {
            Node<char> p = node, q = node;
            while (p != null)
            {
                if (p != node && (p == q || p.next == q))
                {
                    return q.data;
                }
                q = q.next;
                p = (p.next != null) ? p.next.next : p.next;
            }
            return ' ';
        }
    }
}