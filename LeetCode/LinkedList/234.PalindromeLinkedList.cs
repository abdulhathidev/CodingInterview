using System;
using System.Collections;
using System.Collections.Generic;

namespace CodingInterview.LeetCode.LinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    public class PalindromeLinkedList
    {
        public PalindromeLinkedList()
        {
            // ListNode head = new ListNode(1);
            // head.next = new ListNode(2);
            // head.next.next = new ListNode(3);
            // head.next.next.next = new ListNode(3);
            // head.next.next.next.next = new ListNode(4);
            // head.next.next.next.next.next = new ListNode(4);
            // head.next.next.next.next.next.next = new ListNode(5);
            // DeleteDuplicates1(head);

            // Console.WriteLine();
            // ListNode head1 = new ListNode(1);
            // head1.next = new ListNode(1);
            // head1.next.next = new ListNode(1);
            // head1.next.next.next = new ListNode(2);
            // head1.next.next.next.next = new ListNode(3);
            // DeleteDuplicates1(head1);

            // ListNode head2 = new ListNode(1);
            // head2.next = new ListNode(2);
            // head2.next.next = new ListNode(2);
            // head2.next.next.next = new ListNode(2);
            // DeleteDuplicates1(head2);
            //[-2147483648,2147483647,2]
            //RotateRight(head, 2);

            // ListNode head = new ListNode(0);
            // head.next = new ListNode(1);
            // head.next.next = new ListNode(2);
            // RotateRight(head, 4);

            // ListNode head = new ListNode(1);
            // head.next = new ListNode(2);
            // RotateRight(head, 2);

            // ListNode head = new ListNode(1);
            // RotateRight(head, 1);

            //head.next.next = new ListNode(2);
            //Console.WriteLine("This is valid Palindrome : {0}", IsPalindrome(head));
            // Console.WriteLine("Remove the nTh node {0}", RemoveNthFromEnd(head, 2));
            //Console.WriteLine("Kth Roatation"); RotateRight(head, 2);

            ListNode head = new ListNode(1);
            head.next = new ListNode(4);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(2);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(2);
            Display(Partition1(head, 3));
            //ListNode head = null;
            Console.WriteLine();
            ListNode head2 = new ListNode(1);
            head2.next = new ListNode(2);

            Display(Partition1(head2, 3));

            Console.WriteLine();
            ListNode head1 = new ListNode(6);
            head1.next = new ListNode(4);
            head1.next.next = new ListNode(3);
            head1.next.next.next = new ListNode(1);
            head1.next.next.next.next = new ListNode(2);
            head1.next.next.next.next.next = new ListNode(5);
            head1.next.next.next.next.next.next = new ListNode(2);
            Display(Partition1(head1, 3));

            Console.WriteLine();
            ListNode head3 = new ListNode(1);
            head3.next = new ListNode(2);
            Display(Partition1(head3, 0));

            ListNode head4 = new ListNode(3);
            head4.next = new ListNode(3);
            head4.next.next = new ListNode(1);
            head4.next.next.next = new ListNode(2);
            head4.next.next.next.next = new ListNode(4);

            Display(Partition1(head4, 3));
        }

        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
                return true;
            else if (head.next != null && head.next.next == null)
                return head.val == head.next.val;
            Stack<int> stack = new Stack<int>();
            ListNode p = head, q = head;
            while (q != null)
            {
                stack.Push(p.val);
                if (q.next != null)
                {
                    q = q.next.next;
                    p = p.next;
                }
                else
                {
                    q = q.next;
                }
            }
            while (p != null)
            {
                if (p.val != stack.Pop())
                    return false;
                p = p.next;
            }
            return true;
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            int count = 0;
            ListNode p = head, q = head;
            while (p != null)
            {
                count++;
                p = p.next;
                if (p != null)
                {
                    count++;
                    p = p.next;
                }
            }
            int last = count - n;
            if (last == 0)
                return head.next;
            while (q != null)
            {
                last--;
                if (last <= 0 && q.next != null)
                {
                    q.next = q.next.next;
                    break;
                }
                q = q.next;
            }
            return head;
        }

        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null)
                return head;
            ListNode current = head, kthNode = null;
            int count = 1;
            //calculating the count;
            while (current.next != null)
            {
                count++;
                current = current.next;
            }
            //Create loop on the last node to head node
            int kthIndex = count >= k ? (count - k) : count - (k % count);
            if (kthIndex > 0)
            {
                current.next = head;
                while (kthIndex >= 0)
                {
                    if (kthIndex == 0 && current.next != null && kthNode.next != null)
                    {
                        head = current.next;
                        kthNode.next.next = null;
                        break;
                    }
                    kthIndex--;
                    kthNode = current;
                    current = current.next;
                }
            }
            return head;
        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode p = head, q = null, t = null, r = null;
            while (p != null)
            {
                if (t != null && q != null)
                {
                    Console.WriteLine("t : {0}, q : {1}, p : {2}", t.val, q.val, p.val);
                }
                t = q;
                q = p;
                p = p.next;
            }
            return r;
        }

        public ListNode DeleteDuplicates1(ListNode head)
        {
            if (head != null && head.next != null && head.val == head.next.val)
            {
                int headVal = head.val;
                while (head != null && head.val == headVal)
                    head = head.next;
            }
            ListNode p = head, t = null, q = null, result = null;
            while (p != null)
            {
                if (p.next != null && p.val == p.next.val)
                {
                    p.next = p.next.next;
                }
                else
                {
                    if (t == null || t.val != p.val)
                    {
                        Console.WriteLine(p.val);
                        if (result == null)
                        {
                            result = new ListNode(p.val);
                            q = result;
                        }
                        else
                        {
                            q.next = new ListNode(p.val);
                            q = q.next;
                        }
                    }
                }
                t = p;
                p = p.next;
            }
            return result;
        }

        public ListNode Partition(ListNode head, int x)
        {
            //1. find the samllest node and fill in q.
            //2. remove the samlles node from head.
            //3. Set the last node of q as head.
            //4. Return the q node.
            if (head == null || head.next == null || head.val == head.next.val)
                return head;
            ListNode p = head, q = null, t = head;
            while (p != null)
            {
                if (p.val < x && p != head)
                {
                    if (t.val > p.val)
                    {
                        ListNode temp = t;
                        t = new ListNode(p.val);
                        t.next = temp;
                    }
                    else if (t.val <= p.val)
                    {
                        ListNode temp = t.next;
                        t.next = new ListNode(p.val);
                        t.next.next = temp;
                        t = t.next;
                    }
                    // if (q.val >= p.val)
                    // {
                    q.next = p.next;
                    p = q;
                    // }
                }
                q = p;
                p = p.next;
            }
            return head;
        }

        public ListNode Partition1(ListNode head, int x)
        {
            if (head == null || head.next == null)
                return head;
            ListNode p = head, q = null, t = null, result = null;
            while (p != null)
            {
                if (p.val >= x)
                {
                    if (result == null)
                    {
                        result = new ListNode(p.val);
                        t = result;
                    }
                    else
                    {
                        t.next = new ListNode(p.val);
                        t = t.next;
                    }
                    if (p == head)
                        head = head.next;
                    else
                    {
                        q.next = p.next;
                        p = q;
                    }
                }
                q = p;
                p = p.next;
            }
            if (q != null) q.next = result;
            return head != null ? head : result;
        }
        public void Display(ListNode node)
        {
           
            while (node != null)
            {
                Console.Write(node.val + "->");
                node = node.next;
            }
            Console.WriteLine("null");
        }
    }
}