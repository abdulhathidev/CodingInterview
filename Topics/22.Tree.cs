using System;
using System.Collections.Generic;

namespace CodingInterview.Topics
{
    public class TreeNode
    {
        public int data;
        public TreeNode left;
        public TreeNode right;
        public int height;
        public TreeNode(int data)
        {
            this.data = data;
        }
        public TreeNode(int data, int height)
        {
            this.data = data;
            this.height = height;
        }
    }

    public class Tree
    {
        public TreeNode root;
        public TreeNode AVLRoot;
        int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] arr1 = new int[] { 10, 12, 14, 15, 17, 19 };
        public Tree()
        {
            Console.WriteLine("22. Binary Tree -------------------");
            Console.WriteLine("01. Create Minimal BST ");
            root = CreateMinimalBST(arr, 0, arr.Length - 1);
            Console.Write("02. Pre order Dispay             : "); PreOrder(root); Console.WriteLine();
            Console.Write("03. In order Dispay              : "); InOrder(root); Console.WriteLine();
            Console.Write("04. Post order Dispay            : "); PostOrder(root); Console.WriteLine();
            Console.Write("05. Level order Dispay           : "); LevelOrder(root); Console.WriteLine();
            Console.Write("06. Build AVL tree from array    : \n"); BuildAVLTreeByArray(arr1);
            Console.Write("07. Display AVL tree in order    : "); LevelOrder(AVLRoot); Console.WriteLine();
        }

        public TreeNode CreateMinimalBST(int[] arr, int left, int right)
        {
            if (right < left)
                return null;
            int mid = (left + right) / 2;
            TreeNode node = new TreeNode(arr[mid]);
            node.left = CreateMinimalBST(arr, left, mid - 1);
            node.right = CreateMinimalBST(arr, mid + 1, right);
            return node;
        }
        public void PreOrder(TreeNode node)
        {
            if (node != null)
            {
                Console.Write(node.data + " ");
                PreOrder(node.left);
                PreOrder(node.right);
            }
        }
        public void InOrder(TreeNode node)
        {
            if (node != null)
            {
                InOrder(node.left);
                Console.Write(node.data + " ");
                InOrder(node.right);
            }
        }
        public void PostOrder(TreeNode node)
        {
            if (node != null)
            {
                PostOrder(node.left);
                PostOrder(node.right);
                Console.Write(node.data + " ");
            }
        }
        public void LevelOrder(TreeNode node)
        {
            TreeNode t;
            Queue<TreeNode> treeQueue = new Queue<TreeNode>();
            treeQueue.Enqueue(node);
            Console.Write(node.data + " ");
            while (treeQueue.Count > 0)
            {
                t = treeQueue.Dequeue();
                if (t.left != null)
                {
                    treeQueue.Enqueue(t.left);
                    Console.Write(t.left.data + " ");
                }
                if (t.right != null)
                {
                    treeQueue.Enqueue(t.right);
                    Console.Write(t.right.data + " ");
                }
            }
        }
        public TreeNode BuildAVLTreeByArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                if (AVLRoot == null) AVLRoot = BuildAVLTree(AVLRoot, arr[i]);
                else BuildAVLTree(AVLRoot, arr[i]);
            return AVLRoot;
        }
        public TreeNode BuildAVLTree(TreeNode node, int val)
        {
            if (node == null)
                node = new TreeNode(val, 1);
            else if (val < node.data)
                node.left = BuildAVLTree(node.left, val);
            else
                node.right = BuildAVLTree(node.right, val);
            node.height = NodeHeight(node);
            if (BalanceFactor(node) == 2)
            {
                if (BalanceFactor(node.left) == 1)
                    return LLBalance(node);
                else if (BalanceFactor(node.left) == -1)
                    return LRBalance(node);
            }
            else if (BalanceFactor(node) == -2)
            {
                if (BalanceFactor(node.right) == 1)
                    return RLBalance(node);
                else if (BalanceFactor(node.right) == -1)
                    return RRBalance(node);
            }
            return node;
        }
        public int NodeHeight(TreeNode node)
        {
            int lh = (node != null && node.left != null) ? node.left.height : 0;
            int rh = (node != null && node.right != null) ? node.right.height : 0;
            return lh > rh ? lh + 1 : rh + 1;
        }
        public int BalanceFactor(TreeNode node)
        {
            int lh = (node != null && node.left != null) ? node.left.height : 0;
            int rh = (node != null && node.right != null) ? node.right.height : 0;
            return lh - rh;
        }
        // private TreeNode RLBalance(TreeNode p)
        // {
        //     TreeNode pr = p.right;
        //     TreeNode prl = pr.left;

        //     pr.left = prl.right;
        //     p.right = prl.left;

        //     prl.left = p;
        //     prl.right = pr;
        //     p.height = NodeHeight(p);
        //     prl.height = NodeHeight(prl);
        //     pr.height = NodeHeight(pr);
        //     if (AVLRoot == p)
        //         AVLRoot = prl;
        //     return prl;
        // }
        // private TreeNode RRBalance(TreeNode p)
        // {
        //     TreeNode pr = p.right;
        //     TreeNode prl = p.right.left;

        //     pr.left = p;
        //     p.right = prl;
        //     p.height = NodeHeight(p);
        //     pr.height = NodeHeight(pr);
        //     if (AVLRoot == p)
        //         AVLRoot = pr;
        //     return pr;
        // }
        // private TreeNode LLBalance(TreeNode node)
        // {
        //     Console.WriteLine("LL Balance performed");
        //     TreeNode pl = node.left;
        //     TreeNode plr = pl.right;

        //     pl.right = node;
        //     node.left = plr;
        //     node.height = NodeHeight(node);
        //     pl.height = NodeHeight(pl);
        //     if (AVLRoot == node)
        //         AVLRoot = pl;
        //     return pl;
        // }
        // private TreeNode LRBalance(TreeNode node)
        // {
        //     Console.WriteLine("LR Balance performed");
        //     TreeNode pl = node.left;
        //     TreeNode plr = pl.right;

        //     pl.right = plr.left;
        //     node.left = plr.right;
        //     plr.left = pl;
        //     plr.right = node;
        //     pl.height = NodeHeight(pl);
        //     node.height = NodeHeight(node);
        //     plr.height = NodeHeight(plr);

        //     if (AVLRoot == node)
        //         AVLRoot = plr;
        //     return plr;
        // }

        public TreeNode LLBalance(TreeNode node)
        {
            TreeNode pl = node.left, plr = node.left.right;
            pl.right = node; node.left = plr;
            pl.height = NodeHeight(pl); node.height = NodeHeight(node);
            if (AVLRoot == node) AVLRoot = pl;
            return pl;
        }
        private TreeNode LRBalance(TreeNode node)
        {
            /*
                        (8)                   (6)
                       /   \                 /   \ 
                    (4)     (9)           (4)     (8)
                      \                      \    /  \   
                      (6)                    (5) (7)  (9)
                     /   \
                   (5)    (7)
            */
            TreeNode plr = node.left.right, pl = node.left;
            node.left.right = plr.left;
            node.left = plr.right;
            plr.left = node.left; plr.right = node;
            plr.left.height = NodeHeight(plr.left);
            plr.right.height = NodeHeight(plr.right);
            plr.height = NodeHeight(plr);
            if (AVLRoot == node) AVLRoot = plr;
            return plr;
        }
        private TreeNode RRBalance(TreeNode node)
        {
            TreeNode pr = node.right, prl = node.right.left;
            pr.left = node; node.right = prl;
            pr.height = NodeHeight(pr); node.height = NodeHeight(node);
            if (AVLRoot == node) AVLRoot = pr;
            return pr;
        }
        private TreeNode RLBalance(TreeNode node)
        {
            /*
                        (4)                 (4)             (6)
                       /   \                   \           /   \
                     (3)   (8)                 (6)      (4)     (8)
                           /                   /        /  \    /
                         (6)                 (8)     (3)   (5) (7)
                         / \
                       (5)  (7)  
            */
            TreeNode pr = node.right, prl = node.right.left;
            node.right = prl.left; node.right.left = prl.right;
            prl.left = node; prl.right = pr;
            prl.left.height = NodeHeight(prl.left);
            prl.right.height = NodeHeight(prl.right);
            prl.height = NodeHeight(prl);
            if (AVLRoot == node) AVLRoot = prl;
            return prl;
        }

    }
}