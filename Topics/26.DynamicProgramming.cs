using System;
using System.Collections.Generic;

namespace CodingInterview.Topics
{
    public class WeightedGraph
    {
        public int Vertext { get; set; }
        public int Weight { get; set; }
        public WeightedGraph(int vertext)
        {
            this.Vertext = vertext;
        }
        public WeightedGraph(int vertext, int weight)
        {
            this.Vertext = vertext;
            this.Weight = weight;
        }
    }
    public class Cost<T>
    {
        public T Vertext;
        public int CostValue;
        public T Destination;
        public Cost(T vertext, int costVal, T destination)
        {
            this.Vertext = vertext;
            this.CostValue = costVal;
            this.Destination = destination;
        }
    }
    public class MultiStageGraph<I, T>
    {
        public Dictionary<I, HashSet<T>> AdjacencyList { get; } = new Dictionary<I, HashSet<T>>();
        public MultiStageGraph() { }
        public MultiStageGraph(IEnumerable<I> vertices, IEnumerable<Tuple<I, T>> edges)
        {
            foreach (var vertext in vertices)
            {
                AddVertex(vertext);
            }
            foreach (var edge in edges)
            {
                AddEdges(edge);
            }
        }
        private void AddVertex(I vertext)
        {
            AdjacencyList[vertext] = new HashSet<T>();
        }
        private void AddEdges(Tuple<I, T> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                //AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }
    }
    public class DynamicProgramming
    {
        public DynamicProgramming()
        {
            Console.WriteLine("26. Dynamic Programming & Memoization ");
            Console.WriteLine("01. Fibonaci Tabular Method Fib(5) : {0}", FibTabularMethod(8));
            MultiStageGraph();
        }

        public int FibTabularMethod(int n)
        {
            if (n <= 1)
                return n;
            int[] F = new int[n + 1];
            F[0] = 0; F[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                F[i] = F[i - 2] + F[i - 1];
            }
            return F[n];
        }

        public void MultiStageGraph()
        {
            // var vertices = new WeightedGraph[] {
            //     new WeightedGraph(1),
            //     new WeightedGraph(2),
            //     new WeightedGraph(3),
            //     new WeightedGraph(4),
            //     new WeightedGraph(5),
            //     new WeightedGraph(6),
            //     new WeightedGraph(7),
            //     new WeightedGraph(8),
            // };

            var vertices = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };


            var edges = new Tuple<int, WeightedGraph>[]
            {
                new Tuple<int, WeightedGraph>(1,new WeightedGraph(2,2)),
                new Tuple<int, WeightedGraph>(1,new WeightedGraph(3,1)),
                new Tuple<int, WeightedGraph>(1,new WeightedGraph(4,3)),
                new Tuple<int, WeightedGraph>(2,new WeightedGraph(5,2)),
                new Tuple<int, WeightedGraph>(2,new WeightedGraph(6,3)),
                new Tuple<int, WeightedGraph>(3,new WeightedGraph(5,6)),
                new Tuple<int, WeightedGraph>(3,new WeightedGraph(6,7)),
                new Tuple<int, WeightedGraph>(4,new WeightedGraph(5,6)),
                new Tuple<int, WeightedGraph>(4,new WeightedGraph(6,8)),
                new Tuple<int, WeightedGraph>(4,new WeightedGraph(7,9)),
                new Tuple<int, WeightedGraph>(5,new WeightedGraph(8,6)),
                new Tuple<int, WeightedGraph>(6,new WeightedGraph(8,4)),
                new Tuple<int, WeightedGraph>(7,new WeightedGraph(8,5)),
            };

            MultiStageGraph<int, WeightedGraph> graph = new MultiStageGraph<int, WeightedGraph>(vertices, edges);
            int n = 8;
            Cost<int>[] costArray = new Cost<int>[n + 1];
            costArray[n] = new Cost<int>(n, 0, n);
            while (n > 0)
            {
                if (graph.AdjacencyList.ContainsKey(n))
                {
                    foreach (var neighbor in graph.AdjacencyList[n])
                    {
                        var prevCost = costArray[neighbor.Vertext].CostValue;
                        if (costArray[n] == null || costArray[n].CostValue > neighbor.Weight + prevCost)
                            costArray[n] = new Cost<int>(n, neighbor.Weight + prevCost, neighbor.Vertext);
                    }
                }
                n--;
            }

            int i = 1;
            Console.Write("Shortest Path : {0}", i);
            while (i > 0)
            {
                if (i == costArray[i].Destination)
                    break;
                Console.Write(" --> {0}", costArray[i].Destination);
                i = costArray[i].Destination;
            }
            Console.WriteLine();
        }
    }
}