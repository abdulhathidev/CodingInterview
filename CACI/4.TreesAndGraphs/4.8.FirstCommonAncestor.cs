using System;

namespace CodingInterview.TreesAndGraphs
{
    public class FirstCommonAncestor
    {
        /*
                            15
                    7               20
                5       12     18        25
        */
        Node root;
        public FirstCommonAncestor()
        {
            //var input = new int[] { 4, 2, 3, 1, 7, 6 };
            root = new Node(2, 1);
            root.leftChild = new Node(1, 1, root);
            root.rightChild = new Node(3, 1, root);
            root.rightChild.leftChild = new Node(4, 1, root.rightChild);
            root.rightChild.rightChild = new Node(5, 1, root.rightChild);
            root.rightChild.rightChild.rightChild = new Node(6, 1, root.rightChild.rightChild);

            root.rightChild.rightChild.height = NodeHeight(root.rightChild.rightChild);
            root.rightChild.leftChild.height = NodeHeight(root.rightChild.leftChild);
            root.rightChild.height = NodeHeight(root.rightChild);
            root.leftChild.height = NodeHeight(root.leftChild);
            root.height = NodeHeight(root);
            FindCommonAncestor(root.rightChild.rightChild, root.rightChild.rightChild.rightChild);
        }
        public int NodeHeight(Node node)
        {
            int lh = (node != null && node.leftChild != null) ? node.leftChild.height : 0;
            int rh = (node != null && node.rightChild != null) ? node.rightChild.height : 0;
            return lh > rh ? lh + 1 : rh + 1;
        }

        public void FindCommonAncestor(Node node1, Node node2)
        {
            if (node1.height > node2.height && node2.parent != node1)
                Console.WriteLine(node2.parent.data);
            else if (node2.height > node1.height && node1.parent != node2)
                Console.WriteLine(node1.parent.data);
            else
                Console.WriteLine(node2.height > node1.height ? node2.parent.data : node1.parent.data);

        }
    }
}