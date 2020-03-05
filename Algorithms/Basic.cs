using System;

namespace CodingInterview.Algorithms
{
    public class Basic
    {
        public Basic()
        {
            Console.WriteLine("Binary Search Index {0}", BinarySearch(5, new int[] { 1, 2, 3, 4, 5, 6 }));
            Mystry("abdulhathi");
        }
        public int BinarySearch(int key, int[] a)
        {
            int lo = 0;
            int hi = a.Length - 1;
            while (lo < hi)
            {
                int mid = (lo + hi) / 2;
                if (key > a[mid]) lo = mid + 1;
                else if (key < a[mid]) hi = mid - 1;
                else if (key == a[mid]) return mid;
            }
            return -1;
        }
        public string Mystry(string s)
        {
            int n = s.Length;
            if (n <= 1) return s;
            string a = s.Substring(0, n / 2);
            string b = s.Substring(n / 2, n);
            return Mystry(b) + Mystry(a);
        }
    }
}
