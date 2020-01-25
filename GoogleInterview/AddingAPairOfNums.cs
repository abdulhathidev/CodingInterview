using System;

namespace CodingInterview.GoogleInterview
{
    public class AddingAPairOfNums
    {
        public AddingAPairOfNums()
        {
            int sum = 8;
            int t = Math.Abs(-10);
            int[] n = new int[] { -10, 1, 2, 4, 4, 18, 6 };
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < n.Length; i++)
            {
                if (min > n[i])
                    min = n[i];
                if (max < n[i])
                    max = n[i];
            }
            int[] hashTable = new int[max + 1];

            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] >= 0)
                    hashTable[n[i]]++;
            }
            for (int i = 0; i < hashTable.Length; i++)
            {
                if (hashTable[i] > 0)
                {
                    int val = sum - i;
                    if (val >= 0 && hashTable[val] > 0)
                    {
                        hashTable[i]--; hashTable[val]--;
                        Console.Write("({0}, {1}), ", i, val);
                    }
                }
            }
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] < 0)
                {
                    int val = Math.Abs(n[i] - sum);
                    if (val >= 0 && hashTable[val] > 0)
                    {
                        Console.Write("({0}, {1}), ", n[i], val);
                        hashTable[val]--;
                    }
                }
            }
        }
    }
}