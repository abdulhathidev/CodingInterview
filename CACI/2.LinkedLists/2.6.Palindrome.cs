using System;
using System.Collections;
using System.Collections.Generic;

namespace CodingInterview.LinkedLists
{
    public class Palindrome
    {
        public Palindrome()
        {
            string p = "no lemon, no melonn";
            Node<char> root = LinkedList.BuildNode<char>(RemoveOtherChars(p.ToCharArray()));
            Console.WriteLine("2.6. {0} is valid palindrome : {1}", p, CheckIsAPalindrome(root));
        }
        public bool CheckIsAPalindrome(Node<char> node)
        {
            Node<char> p = node, t = node;
            Stack<char> st = new Stack<char>();
            while (p != null)
            {
                st.Push(t.data);
                p = p.next;
                if (p != null)
                    t = t.next;
                else if (p != null && p.next == null)
                    t = t.next;
                if (p != null)
                    p = p.next;
            }
            while (t != null)
            {
                if (t.data != st.Pop())
                    return false;
                t = t.next;
            }
            return true;
        }
        public void ToggleUpperToLower(ref char c)
        {
            if (c >= 65 && c <= 90)
                c = (char)(c + 32);
        }
        public char[] RemoveOtherChars(char[] str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
            {
                ToggleUpperToLower(ref str[i]);
                result += (str[i] >= 97 && str[i] <= 122) ? str[i].ToString() : "";
            }
            return result.ToCharArray();
        }
    }
}