using System;

namespace CodingInterview.LeetCode.LinkedList
{
    public class LinkedList
    {
        public LinkedList()
        {
            // ListNode head = new ListNode(5), t = head;
            // for (int i = 4; i > 0; i--)
            // {
            //     t.next = new ListNode(i);
            //     t = t.next;
            // }
            // ListNode head = new ListNode(1); head.next = new ListNode(2);
            // head.next.next = new ListNode(3); head.next.next.next = new ListNode(4);
            // head.next.next.next.next = new ListNode(5);

            // ListNode head1 = new ListNode(3); head1.next = new ListNode(5);
            ListNode head1 = new ListNode(1); head1.next = new ListNode(2);
            head1.next.next = new ListNode(3);

            //Console.WriteLine("{0} Reverse {1}", Display(head), Display(ReverseLinkedList(head)));
            Console.WriteLine("{0} Reverse {1}", Display(head1), Display(ReverseBetween(head1, 2, 3)));
            //Reverse(head);
        }

        public ListNode ReverseLinkedList(ListNode head)
        {
            //      5 -> 4 -> 3 -> 2 -> 1 -> NULL
            // r    p    q
            //      r    p    q
            if (head == null || head.next == null)
                return head;
            ListNode p = null, r = null;
            while (head != null)
            {
                p = head;
                head = head.next;
                p.next = r;
                r = p;
            }
            return r;
        }
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (head == null || head.next == null || n <= m)
                return head;
            ListNode p = head, q = null, r = null, t = null; int i = 0;
            while (p != null)
            {
                i++;
                if (i >= m && i <= n)
                {
                    q = p;
                    p = p.next;
                    q.next = r;
                    r = q;
                }
                else
                {
                    FillReverse(ref head, ref r, ref t);
                    if (t == null)
                    {
                        t = head;
                        p = p.next;
                    }
                    else
                    {
                        t.next = p;
                        p = p.next;
                    }
                }
            }
            FillReverse(ref head, ref r, ref t);
            return t == null ? r : head;
        }

        private static void FillReverse(ref ListNode head, ref ListNode r, ref ListNode t)
        {
            if (r != null)
            {
                while (r != null)
                {
                    if (t == null) { head = new ListNode(r.val); t = head; }
                    else
                    {
                        t.next = new ListNode(r.val);
                        t = t.next;
                    }
                    r = r.next;
                }
            }
        }

        public void Reverse(ListNode pointer)
        {
            ListNode tmp, reverse = null;
            while (pointer != null)
            {
                tmp = pointer;
                pointer = pointer.next;
                tmp.next = reverse;
                reverse = tmp;
            }
            Display(reverse);
        }
        public string Display(ListNode node)
        {
            string nodeList = string.Empty;
            while (node != null)
            {
                nodeList += node.val + "->";
                node = node.next;
            }
            return nodeList + "null";
        }
    }
}