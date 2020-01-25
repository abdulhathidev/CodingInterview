using System;

namespace CodingInterview.LinkedLists
{
    public class SumLists
    {
        public SumLists()
        {
            var result = SumOfReversedLinkedListValue(LinkedList.l1(), LinkedList.l2());
            Console.WriteLine("2.5.({0}) + ({1}) = ({2})", LinkedList.Display(LinkedList.l1()),
            LinkedList.Display(LinkedList.l2()), LinkedList.Display(result));
        }
        public Node<int> SumOfReversedLinkedListValue(Node<int> l1, Node<int> l2)
        {
            int m = 1, sum = 0; Node<int> result = null, p = null;
            while (l1 != null && l2 != null)
            {
                sum += (l1.data * m) + (l2.data * m);
                l1 = l1.next; l2 = l2.next;
                m = m * 10;
            }
            while (l1 != null)
            {
                sum += l1.data * m;
                l1 = l1.next;
                m = m * 10;
            }
            while (l2 != null)
            {
                sum += l2.data * m;
                l2 = l2.next;
                m = m * 10;
            }
            while (sum > 0)
            {
                var n = new Node<int>(sum % 10);
                if (result == null)
                {
                    result = n;
                    p = result;
                }
                else
                {
                    p.next = n;
                    p = p.next;
                }
                sum = sum / 10;
            }
            return result;
        }
    }
}