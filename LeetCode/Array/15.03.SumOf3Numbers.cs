using System;
using System.Collections.Generic;

namespace CodingInterview.LeetCode.Array
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    public class SumOf3Numbers
    {
        public SumOf3Numbers()
        {
            //Console.WriteLine("{0}", IsPalindrome(0));
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(4);

            ListNode l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);
            MergeTwoLists(l1, l2);
        }
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode r = null, t = null;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    ReadNode(ref l1, ref r, ref t);
                }
                else
                {
                    ReadNode(ref l2, ref r, ref t);
                }
            }
            while (l1 != null)
            {
                ReadNode(ref l1, ref r, ref t);
            }
            while (l2 != null)
            {
                ReadNode(ref l2, ref r, ref t);
            }
            return r;
        }

        private static void ReadNode(ref ListNode l2, ref ListNode r, ref ListNode t)
        {
            if (r == null && t == null)
            {
                r = new ListNode(l2.val);
                t = r;
            }
            else
            {
                t.next = new ListNode(l2.val);
                t = t.next;
            }
            l2 = l2.next;
        }

        public bool IsPalindrome(int x)
        {
            if (x >= -9 && x <= 9)
                return false;
            int t = x, r = 0;
            while (t / 10 > 0)
            {
                r += t % 10;
                t /= 10;
                if (t > 0)
                    r *= 10;
            }
            r += t % 10;
            return r == x;
        }
        public bool IsPalindrome1(int x)
        {

            int orig = x;
            if (x < 0) return false;
            else
            {
                int rev = 0;
                while (x != 0)
                {
                    int pop = x % 10;
                    x /= 10;
                    rev = rev * 10 + pop;
                }
                return (orig == rev);
            }
        }
        public void SumOf3NumbersToGetZeroinArray()
        {
            IList<IList<int>> list = new List<IList<int>>();
            int[] input = new int[] { -1, 0, 1, 2, -1, -4 };
            int min = int.MaxValue, max = int.MinValue;
            bool zeorAvailable = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 0) zeorAvailable = true;
                min = input[i] < min ? input[i] : min;
                max = input[i] > max ? input[i] : max;
            }
            int minLength = 10, maxLength = 10;
            while (-(min) / 10 > 0)
                minLength *= 10;
            while (max / 10 > 0)
                maxLength *= 10;

            int[] hashTable = new int[minLength + maxLength];

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < 0)
                    hashTable[-input[i]]++;
                else if (input[i] == 0)
                    hashTable[input[i]]++;
                else
                    hashTable[minLength + input[i]]++;
            }

            for (int i = minLength; i > 0; i--)
            {
                if (hashTable[i] > 0)
                {
                    int j = i;
                    while (hashTable[maxLength + j] > 0)
                    {
                        if (-i + j == 0 && zeorAvailable)
                        {
                            list.Add(new List<int>()
                        {
                            -i,j,0
                        });
                        }
                        else
                        {
                            if (hashTable[(-i + j) + maxLength] > 0)
                                list.Add(new List<int>() { -i, j, (-i + j) });
                        }
                        j--;
                    }
                }
            }
        }
    }
}