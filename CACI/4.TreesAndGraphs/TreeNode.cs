using System;

namespace CodingInterview.TreesAndGraphs
{
    public class TreeNode
    {
        public TreeNode leftChild;
        public int data;
        public int height;
        public TreeNode rightChild;
        public TreeNode(int data, int height)
        {
            this.data = data;
            this.height = height;
        }
        public TreeNode(int data)
        {
            this.data = data;
        }
    }
    public class Node
    {
        public Node leftChild;
        public int data;
        public int height;
        public Node rightChild;
        public Node parent;
        public Node(int data, int height, Node parent, Node leftChild, Node rightChild)
        {
            this.data = data;
            this.height = height;
            this.parent = parent;
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }
        public Node(int data, int height, Node parent)
        {
            this.data = data;
            this.height = height;
            this.parent = parent;
        }
        public Node(int data, int height)
        {
            this.data = data;
            this.height = height;
        }
        public Node(int data)
        {
            this.data = data;
        }
    }
}