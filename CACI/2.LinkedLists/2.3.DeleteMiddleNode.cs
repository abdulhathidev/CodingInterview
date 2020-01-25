using System;

namespace CodingInterview.LinkedLists
{
    public class DeleteMiddleNode
    {
        public DeleteMiddleNode()
        {
            Node<char> root = LinkedList.RootCharNode();
            Console.WriteLine("2.3. Before delete : {0}", LinkedList.Display(root));
            Console.WriteLine("2.3. Delete the middle of the node : {0} ", DeleteMidNode(root));
        }

        public string DeleteMidNode(Node<char> node)
        {
            Node<char> t = null, p = node;
            while (p != null)
            {
                p = p.next;
                if (p != null)
                    p = p.next;
                if (p != null)
                    t = (t == null) ? node : t.next;
            }
            if (p == null)
            {
                t.next = t.next.next;
            }
            return LinkedList.Display(node);
        }
    }
}