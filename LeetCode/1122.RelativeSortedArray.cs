using System;

namespace CodingInterview.LeetCode
{
    public class RelativeSortedArray
    {
        public class Node
        {
            public Node prev;
            public int data;
            public Node next;
            public Node(int data, Node root)
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
                        root.prev = root.prev.next = this;
                    }
                }
            }
        }
        public RelativeSortedArray()
        {
            var r = RelativeSortArray1(new int[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 }, new int[] { 2, 1, 4, 3, 9, 6 });
            Display(r);
        }
        public void Display(int[] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }
            Console.WriteLine();
        }

        public int[] RelativeSortArray1(int[] arr1, int[] arr2)
        {
            int max = int.MinValue;
            for (int i = 0; i < arr1.Length; i++)
                if (max < arr1[i]) max = arr1[i];
            int[] rArray = new int[max + 1];
            for (int i = 0; i < arr1.Length; i++)
            {
                rArray[arr1[i]]++;
            }
            int j = 0;
            for (int i = 0; i < arr2.Length; i++)
            {
                while (rArray[arr2[i]]-- > 0)
                    arr1[j++] = arr2[i];
            }
            for (int i = 0; i < rArray.Length; i++)
                while (rArray[i]-- > 0)
                    arr1[j++] = i;
            return arr1;
        }
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            int max = int.MinValue;
            for (int i = 0; i < arr1.Length; i++)
                if (max < arr1[i]) max = arr1[i];
            Node[] rArray = new Node[10];
            int digitCount = 1, k;
            while (max > 0)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    k = (arr1[i] / digitCount) % 10;
                    Node t = new Node(arr1[i], rArray[k]);
                    rArray[k] = rArray[k] != null ? rArray[k] : t;
                }
                max /= 10;
                digitCount = digitCount * 10;
                if (max > 0)
                {
                    for (int i = 0, m = 0; i < rArray.Length; i++)
                    {
                        while (rArray[i] != null)
                        {
                            arr1[m++] = rArray[i].data;
                            rArray[i] = rArray[i].next;
                        }
                    }
                }
            }
            int j = 0;
            for (int i = 0; i < arr2.Length; i++)
            {
                int d = arr2[i] / 10;
                while (rArray[d] != null && rArray[d].data == arr2[i])
                {
                    arr1[j++] = rArray[arr2[i]].data;
                    rArray[arr2[i]] = rArray[arr2[i]].next;
                }
            }
            for (int i = 0; i < rArray.Length; i++)
            {
                while (rArray[i] != null)
                {
                    arr1[j++] = rArray[i].data;
                    rArray[i] = rArray[i].next;
                }
            }
            return arr1;
        }
    }
}