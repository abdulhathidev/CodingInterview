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

            // { 1,2,null,3,null,4,null,5}
            TreeNode levelOrder = new TreeNode(1);
            levelOrder.left = new TreeNode(2);
            levelOrder.left.left = new TreeNode(3);
            levelOrder.left.left.left = new TreeNode(4);
            levelOrder.left.left.left.left = new TreeNode(5);

            //[3,9,20,null,null,15,7]
            TreeNode l = new TreeNode(3);
            l.left = new TreeNode(9);
            l.right = new TreeNode(20);
            l.right.left = new TreeNode(15);
            l.right.right = new TreeNode(7);
            LevelOrderDisplay(l);

            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            var result = SumOfLeft(root);
            var count = Count(root);
            var log = Math.Log(count + 1);
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

        //107. Binary Tree Level Order Traversal II
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            Stack<List<int>> stack = new Stack<List<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            stack.Push(new List<int>() { root.val });
            List<int> l = new List<int>();
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node != root) l.Add(node.val);
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
                if (l.Count == 2)
                {
                    stack.Push(l);
                    l = new List<int>();
                }
            }
            if (l.Count > 0)
                stack.Push(l);
            while (stack.Count > 0)
            {
                result.Add(stack.Pop());
            }
            return result;
        }

        public IList<IList<int>> LevelOrderDisplay(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Stack<List<int>> stack = new Stack<List<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            Console.Write("Root:" + root.val + " ");
            stack.Push(new List<int>() { root.val });
            List<int> l;
            while (queue.Count > 0)
            {
                l = new List<int>();
                TreeNode node = queue.Dequeue();
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                    //Console.Write("Left:" + node.left.val + " ");
                    l.Add(node.left.val);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                    //Console.Write("Right:" + node.right.val + " ");
                    l.Add(node.right.val);
                }
                if (l.Count > 0)
                    stack.Push(l);
            }
            //Console.WriteLine();
            while (stack.Count > 0)
            {
                result.Add(stack.Pop());
            }
            return result;
        }

        public int SumOfLeft(TreeNode root)
        {
            if (root == null)
                return 0;
            int result = 0;
            if (root.left != null && root.left.left == null && root.left.right == null)
                result += root.left.val;
            return result + SumOfLeft(root.left) + SumOfLeft(root.right);
        }

        public int Count(TreeNode root)
        {
            //return root != null ? Count(root.left) + Count(root.right) + 1 : 0;
            int result = 0;
            if (root != null)
            {
                result = 1;
                if (root.left != null)
                    result += Count(root.left);
                if (root.right != null)
                    result += Count(root.right);
            }
            return result;
        }
    }
}