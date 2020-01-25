using System;

namespace CodingInterview.LinkedLists
{
    public class ReturnKthToLast
    {
        public ReturnKthToLast()
        {
            Node<int> root = LinkedList.RootNode();
            Console.Write("2.2. From last to {0}th element data is for recursive : ", 3); KthToLast(root, 3);
            //Console.WriteLine("2.2. {0}th to last : {1}", 3, PrintKthToLast(root, 3));
            Console.Write("2.2. From last to {0}th element data is for iterative : {1}\n", 4, kthToLast_Iterative(root, 4));
        }
        public int KthToLast(Node<int> node, int kthData)
        {
            if (node == null)
                return 0;
            int index = KthToLast(node.next, kthData) + 1;
            if (index == kthData)
                Console.WriteLine("{0}", node.data);
            return index;
        }

        public int kthToLast_Iterative(Node<int> node, int kthIndex)
        {
            Node<int> t = null; int k = kthIndex;
            while (node != null)
            {
                if (k >= 0)
                {
                    if (t == null) t = node;
                    k--;
                }
                if (k < 0)
                {
                    t = t.next;
                }
                node = node.next;
            }
            return t.data;
        }

        public int PrintKthToLast(Node<int> node, int k)
        {
            if (node == null) return 0;
            int index = PrintKthToLast(node.next, k) + 1;
            if (index == k)
                Console.WriteLine(k + "th to last node is " + node.data);
            return index;
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
    }
}