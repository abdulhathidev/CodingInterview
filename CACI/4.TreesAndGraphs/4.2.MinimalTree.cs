using System;

namespace CodingInterview.TreesAndGraphs
{
    public class MinimalTree
    {
        TreeNode root;
        public MinimalTree()
        {
            root = CreateMinimalBST(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 0, 7);
            Console.Write("4.2. Create Minimal Binary Search Tree ");
            PreOrder(root, "R");
            Console.WriteLine();
        }

        public void PreOrder(TreeNode node, string name)
        {
            if (node != null)
            {
                Console.Write("{0} : {1} ", name, node.data);
                PreOrder(node.leftChild, "L");
                PreOrder(node.rightChild, "R");
            }
        }

        public TreeNode CreateMinimalBST(int[] arr, int l, int r)
        {
            if (r < l) return null;

            int mid = (l + r) / 2;
            TreeNode node = new TreeNode(arr[mid], 0);
            node.leftChild = CreateMinimalBST(arr, l, mid - 1);
            node.rightChild = CreateMinimalBST(arr, mid + 1, r);
            return node;
        }

        public int NodeHieght(TreeNode node)
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
        public TreeNode BuildAVLTree(TreeNode node, int val)
        {
            if (node == null)
                node = new TreeNode(val, 1);
            else if (val < node.data)
                node.leftChild = BuildAVLTree(node.leftChild, val);
            else
                node.rightChild = BuildAVLTree(node.rightChild, val);
            node.height = NodeHieght(node);
            if (BalanceFactor(node) == 2)
            {
                if (BalanceFactor(node.leftChild) == 1) return LLBalance(node);
                else if (BalanceFactor(node.rightChild) == -1) return LRBalance(node);
            }
            else if (BalanceFactor(node) == -2)
            {
                if (BalanceFactor(node.rightChild) == -1) return RRBalance(node);
                else if (BalanceFactor(node.rightChild) == 1) return RLBalance(node);
            }
            return node;
        }

        private TreeNode RLBalance(TreeNode node)
        {
            throw new NotImplementedException();
        }

        private TreeNode RRBalance(TreeNode node)
        {
            TreeNode rc = node.rightChild;
            TreeNode rcl = node.rightChild.leftChild;

            rc.leftChild = node;
            node.rightChild = rcl;

            rc.height = NodeHieght(rc);
            node.height = NodeHieght(node);

            if (root == node)
                root = rc;
            return rc;
        }

        private TreeNode LRBalance(TreeNode node)
        {
            throw new NotImplementedException();
        }

        private TreeNode LLBalance(TreeNode node)
        {
            TreeNode lc = node.leftChild;
            TreeNode lcr = node.leftChild.rightChild;

            lc.rightChild = node;
            node.leftChild = lcr;

            lc.height = NodeHieght(lc);
            node.height = NodeHieght(node);

            if (root == node)
                root = lc;
            return lc;
        }
    }
}