using System;

namespace CodingInterview.Topics
{
    public class Array
    {
        int[] root = new int[8];
        int[] sortedArray = new int[9] { 2, 4, 5, 6, 8, 10, 12, 13, 14 };
        int[] sortedArray1 = new int[9] { 2, 4, 5, 6, 8, 10, 12, 13, 14 };
        int[] array1 = new int[] { 2, 4, 5, 6, 8, 10 };
        int[] array2 = new int[] { 10, 12, 13, 14 };
        int[] pairArray = new int[] { 2, 3, 5, 6, 8, 0, 7, 1, 4, 4, 4 };
        int[] pairSrtedArray = new int[] { 0, 1, 2, 3, 4, 4, 4, 5, 6, 7, 8 };
        public Array()
        {
            Console.WriteLine("14. Array ---------------------------");
            Create();
            Console.WriteLine("01. Display array : {0}", Display(root));
            Console.WriteLine("02. Delete array : {0}", Delete(3));
            Console.WriteLine("03. Linear Search : {0}", LinearSearch(10));
            Console.WriteLine("04. Binary Search Iterative : {0}", BinarySearch_Iterative(sortedArray, 10));
            Console.WriteLine("05. Binary Search Recursive : {0}", BinarySearch_Recursive(sortedArray, 14, 0, sortedArray.Length - 1));
            Console.WriteLine("06. Reverse : {0}", ReverseArray(sortedArray));
            Console.WriteLine("07. IsSorted : {0}", IsSorted(sortedArray1));
            Console.WriteLine("08. Merge Two Array : {0}", MergeArray(array1, array2));
            Console.WriteLine("09. Union two Array : {0}", UnionArray(array1, array2));
            Console.WriteLine("10. Intersect two Array : {0}", IntersectArray(array1, array2));
            Console.WriteLine("11. Find pari of elements wih sum of {0}"); FindPairOfElementsWithSum(pairArray, 8);
            Console.WriteLine("11. Find pari of elements in sorted Array "); FindPairOfElemInSortedArray(pairSrtedArray, 8);
        }
        public void Create()
        {
            var r = new Random();
            for (int i = 0; i < 8; i++)
            {
                int val = i + 5;
                root[i] = val;
            }
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
        public string Delete(int index)
        {
            if (index > root.Length - 1)
                return "Index not found";
            for (int i = index; i < root.Length; i++)
            {
                root[i] = (i + 1) < root.Length ? root[i + 1] : 0;
            }
            return Display(root);
        }
        public string LinearSearch(int val)
        {
            for (int i = 0; i < root.Length; i++)
            {
                if (root[i] == val)
                    return "Value " + val + " found at index " + i;
            }
            return "Value " + val + " not found at any index";
        }
        public string BinarySearch_Iterative(int[] arr, int val)
        {
            int left = 0, right = arr.Length - 1, mid = 0;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (arr[mid] == val)
                    return "Value " + val + " found at index " + mid;
                else if (val < arr[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return "Value " + val + " not found at any index";
        }
        public string BinarySearch_Recursive(int[] arr, int val, int left, int right)
        {
            if (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == val)
                    return "Value " + val + " found at index " + mid;
                else if (val < arr[mid])
                    return BinarySearch_Recursive(arr, val, left, mid - 1);
                else
                    return BinarySearch_Recursive(arr, val, mid + 1, right);
            }
            return "Value " + val + " not found at any index";
        }
        public string ReverseArray(int[] arr)
        {
            for (int i = 0, j = arr.Length - 1; i <= j; i++, j--)
            {
                Swap(ref arr[i], ref arr[j]);
            }
            return Display(arr);
        }
        public string IsSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                    return "This array is not sorted";
            }
            return "This array is sorted";
        }
        public string MergeArray(int[] arr1, int[] arr2)
        {
            int[] arr3 = new int[arr1.Length + arr2.Length];
            int i = 0, j = 0, k = 0;
            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] < arr2[j])
                    arr3[k++] = arr1[i++];
                else
                    arr3[k++] = arr2[j++];
            }
            while (i < arr1.Length)
                arr3[k++] = arr1[i++];
            while (j < arr2.Length)
                arr3[k++] = arr2[j++];
            return Display(arr3);
        }
        public string UnionArray(int[] arr1, int[] arr2)
        {
            int i = 0, j = 0, k = 0;
            int[] arr3 = new int[arr1.Length + arr2.Length];
            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] == arr2[j])
                {
                    arr3[k++] = arr1[i++]; j++;
                }
                else if (arr1[i] < arr2[j])
                    arr3[k++] = arr1[i++];
                else
                    arr3[k++] = arr2[j++];
            }
            while (i < arr1.Length) arr3[k++] = arr1[i++];
            while (j < arr2.Length) arr3[k++] = arr2[j++];
            return Display(arr3);
        }
        public string IntersectArray(int[] arr1, int[] arr2)
        {
            int i = 0, j = 0, k = 0;
            int[] arr3 = new int[arr1.Length + arr2.Length];
            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] == arr2[j])
                {
                    arr3[k++] = arr1[i++]; j++;
                }
                else if (arr1[i] < arr2[j])
                    i++;
                else j++;
            }
            return Display(arr3);
        }
        public void FindPairOfElementsWithSum(int[] arr, int sum)
        {
            int max = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
                max = max < arr[i] ? arr[i] : max;
            int[] hashTable = new int[max + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                hashTable[arr[i]]++;
            }
            for (int i = 0; i < hashTable.Length; i++)
            {
                if (hashTable[i] > 0 && hashTable[sum - i] > 0)
                {
                    hashTable[i]--; hashTable[sum - i]--;
                    Console.Write("Pair ({0},{1})", i, sum - i);
                }
            }
            Console.WriteLine();
        }
        public void FindPairOfElemInSortedArray(int[] arr, int sum)
        {
            int i = 0, j = arr.Length - 1;
            while (i < j)
            {
                int s = arr[i] + arr[j];
                if (s == sum)
                    Console.Write("Pair ({0},{1}), ", arr[i++], arr[j--]);
                else if (s > sum)
                {
                    i++; j--;
                }
                else
                    i++;
            }
            Console.WriteLine();
        }
    }
}