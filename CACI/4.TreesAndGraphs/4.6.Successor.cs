using System;

namespace CodingInterview.TreesAndGraphs
{
    public class Successor
    {
        public Successor()
        {
        }

        public TreeNode FindInOrderSuccessor(TreeNode node)
        {
            TreeNode successor = null;
            if (node.rightChild != null)
            {
                TreeNode p = node.rightChild.leftChild;
                while (p != null && p.leftChild != null)
                {
                    p = p.leftChild;
                }
                successor = p;
            }
            return successor;
        }
    }
}