using System;

namespace CodingInterview.CTCI
{
    public class SortingAndSearching
    {
        public SortingAndSearching()
        {
            var arrA = new int[] { 5, 6, 9, -1, -1, -1 };
            var arrB = new int[] { 1, 4, 7 };
            Console.WriteLine("10.1. Merge room space availabe array A with B : {0}",
            Display(MergeRoomSpaceArray(arrA, arrB)));
            Console.WriteLine("10.2. Match Anagagram by sorting : 1 {0}, 2 {1}",
            SortAnagram("medical"), SortAnagram("decimal"));
            var arr = new int[] { 15, 16, 20, 25, 1, 3, 4, 5, 7, 10, 14 };
            int key = 5;
            Console.WriteLine("10.3. Finde element {0} in rotated sorted array : {1}", key,
            FindElementInRotatedSortedArray(arr, key, 0, arr.Length - 1));
        }

        public string Display(int[] arr)
        {
            string result = "";
            foreach (var item in arr)
            {
                result += item + " ";
            }
            return result;
        }
        public int[] MergeRoomSpaceArray(int[] arrA, int[] arrB)
        {
            int indexB = arrB.Length - 1;
            int indexA = arrA.Length - 1 - arrB.Length;
            int indexMerged = arrA.Length - 1;

            while (indexB >= 0)
            {
                if (indexA >= 0 && arrA[indexA] > arrB[indexB])
                {
                    arrA[indexMerged--] = arrA[indexA--];
                }
                else
                {
                    arrA[indexMerged--] = arrB[indexB--];
                }
            }

            return arrA;
        }
        public int UpperToLowerChar(char c)
        {
            return c >= 65 && c <= 90 ? c - 32 : c - 0;
        }
        public string SortAnagram(string str)
        {
            int[] hashTable = new int[26];
            for (int i = 0; i < str.Length; i++)
            {
                int c = UpperToLowerChar(str[i]) - 97;
                hashTable[c]++;
            }
            string result = "";
            for (int i = 0; i < hashTable.Length; i++)
            {
                while (hashTable[i] > 0)
                {
                    result += (char)(i + 97);
                    hashTable[i]--;
                }
            }
            return result;
        }
        public int FindElementInRotatedSortedArray(int[] arr, int key, int l, int r)
        {
            int mid = (l + r) / 2;
            if (l > r) return -1;
            if (arr[mid] == key)
                return mid;
            if (arr[l] <= arr[mid - 1])
            {
                if (arr[l] <= key && arr[mid] >= key)
                    return FindElementInRotatedSortedArray(arr, key, l, mid - 1);
                else
                    return FindElementInRotatedSortedArray(arr, key, mid + 1, r);
            }
            else
            {
                if (arr[mid] <= key && arr[r] >= key)
                    return FindElementInRotatedSortedArray(arr, key, mid + 1, r);
                else
                    return FindElementInRotatedSortedArray(arr, key, l, mid - 1);
            }
        }
    }
}