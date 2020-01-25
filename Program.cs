using System;

namespace CodingInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            #region General Topics
            Console.WriteLine();
            Console.WriteLine("General Topics : ");
            Console.WriteLine("-------------------------------------");
            new Topics.HeadAndTailRecursion();
            new Topics.StaticVsGlobalVarRecursion();
            new Topics.TreeRecursion();
            new Topics.IndirectRecursion();
            new Topics.NestedRecursion();
            new Topics.SumOfNNaturalNum();
            //new Topics.BitManipulation();
            #endregion

            //CrackingTheCodingInterview();
        }

        private static void CrackingTheCodingInterview()
        {
            #region 1. Arrays and Strings
            Console.WriteLine();
            Console.WriteLine("Cracking The Coding Interview : ");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1. Arrays and Strings");
            Console.WriteLine("--------------------------------");
            new CodingInterview.ArrayAndString.IsUnique();
            new CodingInterview.ArrayAndString.CheckPermutation();
            new CodingInterview.ArrayAndString.URLify();
            new CodingInterview.ArrayAndString.PalindromePermutation();
            new CodingInterview.ArrayAndString.StringCompression();
            new CodingInterview.ArrayAndString.StringRotation();
            new CodingInterview.ArrayAndString.RotateMatrix();
            #endregion

            #region 2. Linked lists
            Console.WriteLine();
            Console.WriteLine("2. Linked lists");
            Console.WriteLine("--------------------------------");
            new CodingInterview.LinkedLists.RemoveDups();
            new CodingInterview.LinkedLists.ReturnKthToLast();
            new CodingInterview.LinkedLists.DeleteMiddleNode();
            new CodingInterview.LinkedLists.Partition();
            new CodingInterview.LinkedLists.SumLists();
            new CodingInterview.LinkedLists.Palindrome();
            new CodingInterview.LinkedLists.Intersection();
            new CodingInterview.LinkedLists.Loop();
            //new CodingInterview.SortedMerge();
            #endregion

            #region 3. Stacks and Queues
            Console.WriteLine();
            Console.WriteLine("3. Stacks and Queues");
            Console.WriteLine("--------------------------------");
            new CodingInterview.StacksAndQueues.SortStack();
            new CodingInterview.StacksAndQueues.StackMin();
            #endregion

            #region 4. Trees and Graphs
            Console.WriteLine();
            Console.WriteLine("4. Trees and Graphs");
            Console.WriteLine("--------------------------------");
            //new CodingInterview.TreesAndGraphs.QueueTest();
            new CodingInterview.TreesAndGraphs.DepthFirstSearch();
            new CodingInterview.TreesAndGraphs.MinimalTree();
            new CodingInterview.TreesAndGraphs.CheckBSTBalance();
            new CodingInterview.TreesAndGraphs.ValidateBST();
            new CodingInterview.TreesAndGraphs.FirstCommonAncestor();
            //LeetCode
            //new LeetCode.RelativeSortedArray();
            #endregion

            #region Google Interview
            Console.WriteLine();
            Console.WriteLine("Google Interview");
            Console.WriteLine("--------------------------------");
            new GoogleInterview.AddingAPairOfNums();
            new GoogleInterview.ReciprocalEdges();
            Console.WriteLine();
            #endregion
        }

        public static string DisplayChar(char[] input)
        {
            string result = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                result += input[i];
            }
            return result;
        }
    }
}
