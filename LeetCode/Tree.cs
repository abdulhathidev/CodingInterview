using System;
using System.Collections.Generic;

namespace CodingInterview.LeetCode
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public class Tree
    {
        public Tree()
        {
            TreeNode p = new TreeNode(10);
            p.left = new TreeNode(5);
            p.right = new TreeNode(15);

            TreeNode q = new TreeNode(10);
            q.left = new TreeNode(5);
            q.right = new TreeNode(15);
            Console.WriteLine("{0}", IsSameTree(p, q));

            TreeNode n = new TreeNode(1);
            n.right = new TreeNode(2); n.right.left = new TreeNode(3);
            InorderTraversal(n);
        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q != null)
                return false;
            else if (p != null && q == null)
                return false;
            else if (p != null && q != null)
            {
                if (p.val != q.val)
                    return false;
                // var pLeft = p.left == null ? "null" : p.left.val.ToString();
                // var qLeft = q.left == null ? "null" : q.left.val.ToString();
                // Console.WriteLine("{0} {1} : {2}", pLeft, qLeft, IsSameTree(p.left, q.left));
                // var pRight = p.right == null ? "null" : p.right.val.ToString();
                // var qRight = q.right == null ? "null" : q.right.val.ToString();
                // Console.WriteLine("{0} {1} : {2}", pRight, qRight, IsSameTree(p.right, q.right));
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }
            return true;
        }
        public IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> list = new List<int>();
            Inorder(root, list);
            return list;
        }
        public void Inorder(TreeNode root, IList<int> list)
        {
            if (root != null)
            {
                Inorder(root.left, list);
                list.Add(root.val);
                Inorder(root.right, list);
            }
        }
    }
}