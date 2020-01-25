using System;
using System.Collections.Generic;

namespace CodingInterview.TreesAndGraphs
{
    public class ValidateBST
    {
        public class Node
        {
            public int data;
            public Node next;
            public Node(int data)
            {
                this.data = data;
            }
        }
        TreeNode root;
        Stack<int> st = new Stack<int>();
        public ValidateBST()
        {
            int[] arr = new int[] { 4, 2, 6, 1, 3, 5, 7, 8 };
            //int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            for (int i = 0; i < arr.Length; i++)
            {
                if (root == null)
                    root = BuildBinaryTree(root, arr[i]);
                else BuildBinaryTree(root, arr[i]);
            }
            int bf = BalanceFactor(root);
            if (bf >= -1 && bf <= 1)
            {
                InOrderDisplay(root);
                Console.WriteLine("4.5. {0}", IsValidBST());
            }
            else
                Console.WriteLine("4.5. BST is not valid");
        }

        private string IsValidBST()
        {
            int pVal = int.MaxValue, val;
            while (st.Count > 0)
            {
                val = st.Pop();
                if (val > pVal)
                {
                    return "BST is not valid";
                }
            }
            return "BST is valid";
        }

        public void InOrderDisplay(TreeNode node)
        {
            if (node != null)
            {
                InOrderDisplay(node.leftChild);
                //Console.Write(node.data + " ");
                st.Push(node.data);
                InOrderDisplay(node.rightChild);
            }
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

        public int NodeHeight(TreeNode node)
        {
            int lh = (node != null && node.leftChild != null) ? node.leftChild.height : 0;
            int rh = (node != null && node.rightChild != null) ? node.rightChild.height : 0;
            return lh > rh ? lh + 1 : rh + 1;
        }
        public int BalanceFactor(TreeNode node)
        {
            int lh = (node != null && node.leftChild != null) ? node.leftChild.height : 0;
            int rh = (node != null && node.rightChild != null) ? node.rightChild.height : 0;
            return lh - rh;
        }
    }
}