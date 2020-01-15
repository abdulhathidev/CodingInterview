using System;

namespace CodingInterview.CodingInterview
{
    public class SortedMerge
    {
        public class Node
        {
            public Node prev;
            public int data;
            public Node next;
            public Node(int data, Node next)
            {
                this.data = data;
                this.next = next;
            }
            public Node(int data, Node root, Node next)
            {
                this.data = data;
                if (root != null)
                {
                    if (root.next == null && root.prev == null)
                    {
                        root.next = root.prev = this;
                        this.prev = root;
                    }
                    else
                    {
                        this.prev = root.prev;
                        this.prev.next = this;
                        root.prev = this;
                    }
                }
            }
        }
        public SortedMerge()
        {
            var result = MergeTwoSortedArray(new int[6] { 2, 4, 6, -1, -1, -1 }, new int[] { 5, 10, 11 });
            //{ 4, 5, 6, -1, -1, -1 }, new int[] { 1, 2, 3 });
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public int[] MergeTwoSortedArray(int[] arrA, int[] arrB)
        {
            int lindexA = (arrA.Length - arrB.Length) - 1;
            int lindexB = arrB.Length - 1;
            int mergedIndex = lindexA + lindexB + 1;
            while (lindexB >= 0)
            {
                if (arrA[lindexA] > arrB[lindexB])
                {
                    arrA[mergedIndex] = arrA[lindexA];
                    arrA[lindexA] = arrB[lindexB];
                    lindexA--; lindexB--;
                }
                else
                {
                    arrA[mergedIndex] = arrB[lindexB];
                    lindexB--;
                }
                mergedIndex--;
            }
            return arrA;
        }
    }
}