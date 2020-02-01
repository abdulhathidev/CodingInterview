using System;

namespace CodingInterview.Topics
{
    public class RadixNode
    {
        public int data;
        public RadixNode previous;
        public RadixNode next;
        public RadixNode(int data)
        {
            this.data = data;
        }
        public RadixNode(int data, RadixNode root)
        {
            this.data = data;
            if (root != null)
            {
                if (root.next == null && root.previous == null)
                {
                    root.next = root.previous = this; this.previous = root;
                }
                else
                {
                    this.previous = root.previous;
                    root.previous = root.previous.next = this;
                }
            }
        }
    }
    public class Sorting
    {
        int[] array = new int[] { 3, 2, 8, 7, 5 };
        public Sorting()
        {
            Console.WriteLine("23. Sorting");
            Console.WriteLine("23. -------------------");
            Console.WriteLine("01. Bubble Sort      : {0}", BubbleSort(new int[] { 3, 2, 8, 7, 5 }));
            Console.WriteLine("02. Insertion Sort   : {0}", InsertionSort(new int[] { 3, 2, 8, 7, 5 }));
            Console.WriteLine("03. Selection Sort   : {0}", SelectionSort(new int[] { 3, 2, 8, 7, 5 }));
            Console.WriteLine("04. Quick Sort       : {0}", QuickSort(new int[] { 11, 13, 7, 12, 16, 9, 24, 5, 10, 3 }, 0, 10));
            Console.WriteLine("05. Merge Sort       : {0}", MergeSort(new int[] { 11, 13, 7, 12, 16, 9, 24, 5, 10, 3 }, 0, 9));
            Console.WriteLine("06. Count Sort       : {0}", CountSort(new int[] { 11, 13, 7, 12, 16, 9, 24, 5, 10, 3 }));
            Console.WriteLine("07. Radix Sort       : {0}", RadixSort(new int[] { 11, 13, 7, 12, 16, 9, 24, 5, 10, 3 }));
            Console.WriteLine("08. Shell Sort       : {0}", ShellSort(new int[] { 11, 13, 7, 12, 16, 9, 24, 5, 10, 3 }));
        }
        public string Display(int[] arr)
        {
            string result = "";
            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i] + " ";
            }
            return result;
        }
        public void Swap(ref int x, ref int y)
        {
            int t = x; x = y; y = t;
        }
        public string BubbleSort(int[] arr)
        {
            // 0  1  2  3
            //[3][2][7][5]
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = 0; j < arr.Length - i - 1; j++)
                    if (arr[j] > arr[j + 1]) Swap(ref arr[j], ref arr[j + 1]);
            return Display(arr);
        }
        public string InsertionSort(int[] arr)
        {
            // 0  1   2  3
            //[3][ ]|[7][5]
            int i, j, x;
            for (i = 1; i < arr.Length; i++)
            {
                j = i - 1;
                x = arr[i];
                while (j > -1 && arr[j] > x)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = x;
            }
            return Display(arr);
        }
        public string SelectionSort(int[] arr)
        {
            // i,j,k
            // ik    j
            // 0  1  2  3
            //[3][2][7][5]
            int i, j, k;
            for (i = 0; i < arr.Length; i++)
            {
                j = k = i;
                while (j < arr.Length)
                {
                    if (arr[j] < arr[k])
                        Swap(ref arr[j], ref arr[k]);
                    j++;
                }
            }
            return Display(arr);
        }
        public string QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = Partition(arr, left, right);
                QuickSort(arr, left, mid);
                QuickSort(arr, mid + 1, right);

            }
            return Display(arr);
        }
        public int Partition(int[] arr, int left, int right)
        {
            int p = arr[left];
            int i = left, j = right;
            do
            {
                do { i++; } while (i < j && arr[i] <= p);
                do { j--; } while (arr[j] > p);
                if (i < j)
                {
                    Swap(ref arr[i], ref arr[j]);
                }
            } while (i < j);
            Swap(ref arr[left], ref arr[j]);
            return j;
        }

        public void Merging(int[] arr, int l, int m, int r)
        {
            int[] result = new int[r + 1];
            int i = l, j = m + 1, k = l;
            while (i <= m && j <= r)
            {
                result[k++] = (arr[i] < arr[j]) ? arr[i++] : arr[j++];
            }
            while (i <= m) result[k++] = arr[i++];
            while (j <= r) result[k++] = arr[j++];
            for (int n = l; n <= r; n++)
                arr[n] = result[n];
        }
        public string MergeSort(int[] arr, int left, int right)
        {
            int mid = 0;
            if (left < right)
            {
                mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merging(arr, left, mid, right);
            }
            return Display(arr);
        }
        public string CountSort(int[] arr)
        {
            int max = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
                if (max < arr[i]) max = arr[i];
            int[] hashTable = new int[max + 1];
            for (int i = 0; i < arr.Length; i++)
                hashTable[arr[i]]++;
            for (int i = 0, j = 0; i < hashTable.Length; i++)
                if (hashTable[i] > 0)
                    arr[j++] = i;
            return Display(arr);
        }
        public string BucketSort()
        {
            return "";
        }
        public string RadixSort(int[] arr)
        {
            int max = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
                if (max < arr[i]) max = arr[i];
            RadixNode[] hashTable = new RadixNode[10];
            int j = 1;
            while (max > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    int d = (arr[i] / j) % 10;
                    RadixNode t = new RadixNode(arr[i], hashTable[d]);
                    hashTable[d] = (hashTable[d] != null) ? hashTable[d] : t;
                }
                j *= 10;
                max /= 10;
                for (int i = 0, k = 0; i < hashTable.Length; i++)
                {
                    while (hashTable[i] != null)
                    {
                        arr[k++] = hashTable[i].data;
                        hashTable[i] = hashTable[i].next;
                    }
                }
            }
            return Display(arr);
        }
        public string ShellSort(int[] arr)
        {
            int gap = arr.Length / 2;
            while (gap > 0)
            {
                for (int i = 0, j = i + gap; j < arr.Length; i++, j++)
                {
                    int m = i, n = j;
                    while (m >= 0 && arr[m] > arr[n])
                    {
                        Swap(ref arr[m], ref arr[n]);
                        n = m; m = m - gap;
                    }
                }
                gap /= 2;
            }
            return Display(arr);
        }
    }
}