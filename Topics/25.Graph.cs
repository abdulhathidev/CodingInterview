using System;
using System.Collections.Generic;

namespace CodingInterview.Topics
{
    public class GraphNode
    {
        public string data;
        public GraphNode next;
        public bool visited;
        public GraphNode(string data)
        {
            this.data = data;
        }
        public GraphNode(string data, bool visited)
        {
            this.data = data;
            this.visited = visited;
        }
    }
    public class Edge
    {
        public string FromId;
        public string ToId;
    }

    public class Graph<T>
    {
        public Graph() { }
        public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
        {
            foreach (var vertex in vertices)
            {
                AddVertext(vertex);
            }
            foreach (var edge in edges)
            {
                AddEdge(edge);
            }
        }
        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

        public void AddVertext(T vertex)
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }
        public void AddEdge(Tuple<T, T> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }
    }
    public class GraphAlgo
    {
        /*                        0  1  2  3  4  5  6
                (0)---(1)      0| 0  1  1  1  0  0  0
                 | \   |       1| 1  0  1  0  0  0  0
                 |  \  |       2| 1  1  0  1  1  0  0  
                 |   \ |       3| 1  0  1  0  1  0  0
                (3)---(2)      4| 0  0  1  1  0  1  1  
                  \   /        5| 0  0  0  0  1  0  0
                   (4)         6| 0  0  0  0  1  0  0
                  /  \
                (5)   (6)
                ▼
        */
        int[][] adjacencyMatrix = new int[][]
        {
            new int[]{ 0, 1, 1, 1, 0, 0, 0 },
            new int[]{ 1, 0, 1, 0, 0, 0, 0 },
            new int[]{ 1, 1, 0, 1, 1, 0, 0 },
            new int[]{ 1, 0, 1, 0, 1, 0, 0 },
            new int[]{ 0, 0, 1, 1, 0, 1, 1 },
            new int[]{ 0, 0, 0, 0, 1, 0, 0 },
            new int[]{ 0, 0, 0, 0, 1, 0, 0 },
        };
        Edge[] edges = new Edge[]{
                new Edge() { FromId = "A", ToId = "W" },
                new Edge() { FromId = "W", ToId = "D" },
                new Edge() { FromId = "D", ToId = "FH" },
                new Edge() { FromId = "FH", ToId = "A" },
                new Edge() { FromId = "A", ToId = "D" },
                new Edge() { FromId = "D", ToId = "A" },
                new Edge() { FromId = "D", ToId = "W" }
            };

        public GraphAlgo()
        {
            Console.WriteLine("24. Graph -------------------------");
            var vertices = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var edges = new[] { Tuple.Create(1, 2), Tuple.Create(1, 3), Tuple.Create(2, 4), Tuple.Create(3, 5),
            Tuple.Create(3, 6), Tuple.Create(4,7), Tuple.Create(5,7),Tuple.Create(5,8),Tuple.Create(5,6),
            Tuple.Create(8,9),Tuple.Create(9,10) };
            var graph = new Graph<int>(vertices, edges);
            DFS(graph, 1);
            Console.WriteLine();
            BFS(graph, 1);
            Console.WriteLine();

            var vertices1 = new string[] { "A", "W", "D", "FH" };
            var edges1 = new[] { Tuple.Create("A","W"), Tuple.Create("W","D"), Tuple.Create("D","FH"),
            Tuple.Create("FH","A"),Tuple.Create("A","D"),Tuple.Create("D","A"), Tuple.Create("D","W")};
            var graph1 = new Graph<string>(vertices1, edges1);
            BFS(graph1, "A");
        }

        public HashSet<T> DFS<T>(Graph<T> graph, T start)
        {
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var stack = new Stack<T>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();
                if (visited.Contains(vertex))
                    continue;
                visited.Add(vertex);
                Console.WriteLine("visited {0}", Convert.ToString(vertex));
                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
                }
            }

            return visited;
        }

        public HashSet<T> BFS<T>(Graph<T> graph, T start)
        {
            var visited = new HashSet<T>();
            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                if (visited.Contains(vertex))
                    continue;
                visited.Add(vertex);
                //Console.WriteLine("visited {0}", vertex);
                Console.Write("neightbor of parent {0} -> ", vertex);
                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    Console.Write(neighbor + " ");
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
                }
                Console.WriteLine();
            }
            return visited;
        }

        public void BreadthFirstSearch(Edge[] edges)
        {

        }
        public void DepthFirstSearch()
        {

        }
    }
}