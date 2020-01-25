using System;

namespace CodingInterview.TreesAndGraphs
{
    public class CheckBSTBalance
    {
        TreeNode root;
        public CheckBSTBalance()
        {
            // for (int i = 0; i < 7; i++)
            // {
            //     if (root == null)
            //         root = BuildBinaryTree(root, i);
            //     else BuildBinaryTree(root, i);
            // }
            int[] arr = new int[] { 4, 2, 6, 1, 3, 5, 7, 8 };
            for (int i = 0; i < arr.Length; i++)
            {
                if (root == null)
                    root = BuildBinaryTree(root, arr[i]);
                else BuildBinaryTree(root, arr[i]);
            }
            Console.WriteLine("4.4. Check this BST is balanced {0}", IsBalanced(root));
        }

        public TreeNode BuildBinaryTree(TreeNode node, int val)
        {
            if (node == null)
                node = new TreeNode(val, 1);
            else if (val < node.data)
                node.leftChild = BuildBinaryTree(node.leftChild, val);
            else
                node.rightChild = BuildBinaryTree(node.rightChild, val);
            node.height = NodeHeight(node);
            return node;
        }
        public bool IsBalanced(TreeNode node)
        {
            int bf = BalanceFactor(node);
            if (bf < -1 || bf > 1)
                return false;
            return true;
        }
        public int BalanceFactor(TreeNode node)
        {
            int lh = (node != null && node.leftChild != null) ? node.leftChild.height : 0;
            int rh = (node != null && node.rightChild != null) ? node.rightChild.height : 0;
            return lh - rh;
        }

        public int NodeHeight(TreeNode node)
        {
            int lh = (node != null && node.leftChild != null) ? node.leftChild.height : 0;
            int rh = (node != null && node.rightChild != null) ? node.rightChild.height : 0;
            return lh > rh ? lh + 1 : rh + 1;
        }
    }
}