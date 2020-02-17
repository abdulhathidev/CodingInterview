using System;
using System.Collections.Generic;

namespace CodingInterview.MyLearnings
{
    public class TreeNode<T>
    {
        public TreeNode<T> left;
        public T data;
        public TreeNode<T> right;
        public TreeNode(T data)
        {
            this.data = data;
        }
    }
    public class BinarySearchTree
    {
        public void PrintLN()
        {
            Console.WriteLine();
        }
        public BinarySearchTree()
        {
            int[] nodes = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine("Binary Search Tree (BST)");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("01. Create minimal binary search tree");
            TreeNode<int> bst = BuildMinimalBST(nodes, 0, nodes.Length - 1);
            Console.Write("02. Pre order display for the BST    : "); PreOrderDisplay(bst); PrintLN();
            Console.Write("03. In order display for the BST     : "); InOrderDisplay(bst); PrintLN();
            Console.Write("04. Post order display for the BST   : "); PostOrderDisplay(bst); PrintLN();
            Console.Write("05. Level order display for the BST  : "); LevelOrderDisplay(bst); PrintLN();
            Console.Write("06. Print the hight of the BST       : {0}", PrintBSTHeight(bst)); PrintLN();
            Console.Write("07. In order predecessor BST         : {0}", InOrderPredecessor(bst.left)); PrintLN();
            Console.Write("08. In order successor BST           : {0}", InOrderSuccessor(bst.right)); PrintLN();
            Console.WriteLine();
        }
        public TreeNode<int> BuildMinimalBST(int[] nodes, int low, int high)
        {
            if (low > high) return null;
            int mid = (low + high) / 2;
            TreeNode<int> binarySearchTree = new TreeNode<int>(nodes[mid]);
            binarySearchTree.left = BuildMinimalBST(nodes, low, mid - 1);
            binarySearchTree.right = BuildMinimalBST(nodes, mid + 1, high);
            return binarySearchTree;
        }
        public void PreOrderDisplay(TreeNode<int> treeNode)
        {
            if (treeNode != null)
            {
                Console.Write(treeNode.data + "->");
                PreOrderDisplay(treeNode.left);
                PreOrderDisplay(treeNode.right);
            }
        }
        public void InOrderDisplay(TreeNode<int> treeNode)
        {
            if (treeNode != null)
            {
                InOrderDisplay(treeNode.left);
                Console.Write(treeNode.data + "->");
                InOrderDisplay(treeNode.right);
            }
        }
        public void PostOrderDisplay(TreeNode<int> treeNode)
        {
            if (treeNode != null)
            {
                PostOrderDisplay(treeNode.left);
                PostOrderDisplay(treeNode.right);
                Console.Write(treeNode.data + "->");
            }
        }
        public void LevelOrderDisplay(TreeNode<int> treeNode)
        {
            Queue<TreeNode<int>> queue = new Queue<TreeNode<int>>();
            queue.Enqueue(treeNode);
            Console.Write(treeNode.data + "->");
            while (queue.Count > 0)
            {
                TreeNode<int> node = queue.Dequeue();
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                    Console.Write(node.left.data + "->");
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                    Console.Write(node.right.data + "->");
                }
            }
        }
        public int PrintBSTHeight(TreeNode<int> treeNode)
        {
            int x = treeNode.left != null ? PrintBSTHeight(treeNode.left) : 0;
            int y = treeNode.right != null ? PrintBSTHeight(treeNode.right) : 0;
            return x > y ? x + 1 : y + 1;
        }
        public int InOrderPredecessor(TreeNode<int> treeNode)
        {
            while (treeNode != null && treeNode.right != null)
                treeNode = treeNode.right;
            return treeNode.data;
        }
        public int InOrderSuccessor(TreeNode<int> treeNode)
        {
            while (treeNode != null && treeNode.left != null)
                treeNode = treeNode.left;
            return treeNode.data;
        }
    }
}