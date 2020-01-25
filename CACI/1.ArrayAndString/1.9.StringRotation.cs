using System;

namespace CodingInterview.ArrayAndString
{
    public class StringRotation
    {
        public StringRotation()
        {
            Console.WriteLine("1.9. heck substring : {0}", IsSubstring("abdul", "dulabh"));
        }

        public bool IsSubstring(string s1, string s2)
        {
            if (s1.Length > 0 && s2.Length > 0)
            {
                return (s1 + s1).Contains(s2);
            }
            return false;
        }
    }
}