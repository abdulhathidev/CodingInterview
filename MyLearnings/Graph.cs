using System;
using System.Collections.Generic;

namespace CodingInterview.MyLearnings
{
    public class GraphNode<T>
    {
        public GraphNode<T> adjacent;
        public T data;
        public GraphNode(T data)
        {
            this.data = data;
        }
    }
    /*   Un Directed Graph
            (2)---(3)   
           / |   / | 
        (1)  |  /  |
           \ | /   |
            (4)---(5)
    */
    public class Graph
    {
        int[][] adjacencyMatrix = new int[5][]
        {
            new int[] {0,1,0,1,0},
            new int[] {1,0,1,1,0},
            new int[] {0,1,0,1,1},
            new int[] {1,1,1,0,1},
            new int[] {0,0,1,1,0},
        };
        Dictionary<int, GraphNode<int>> adjList = new Dictionary<int, GraphNode<int>>();
        GraphNode<int>[] adjacencyList = new GraphNode<int>[5]
        {
            new GraphNode<int>(1) { adjacent = new GraphNode<int>(2) { adjacent = new GraphNode<int>(4) } },
            new GraphNode<int>(2) { adjacent = new GraphNode<int>(1) { adjacent = new GraphNode<int>(3) { adjacent = new GraphNode<int>(4) } } },
            new GraphNode<int>(3) { adjacent = new GraphNode<int>(2) { adjacent = new GraphNode<int>(4) { adjacent = new GraphNode<int>(5) } } },
            new GraphNode<int>(4) { adjacent = new GraphNode<int>(1) { adjacent = new GraphNode<int>(2) { adjacent = new GraphNode<int>(3) { adjacent = new GraphNode<int>(5) } } } },
            new GraphNode<int>(5) { adjacent = new GraphNode<int>(3) { adjacent = new GraphNode<int>(4) } }
        };
        bool[] graphNodeVisited = new bool[5];
        public Graph()
        {
            Console.WriteLine("Graph");
            Console.WriteLine("--------------------------------");
            Console.Write("Read Adjacency Matrix        : "); ReadAdjacencyMatrix(adjacencyMatrix);
            Console.Write("Read Adjacency List          : "); ReadAdjacencyList(adjacencyList);
            Console.Write("Breadth First Search (BFS)   : "); BuildAdjacencyList(); BFS(adjList[1]); Console.WriteLine();
            Console.Write("Depth First Search (DFS)     : "); graphNodeVisited = new bool[5]; DFS(2); Console.WriteLine();
            Console.WriteLine();
        }
        public void ReadAdjacencyMatrix(int[][] adjMatrix)
        {
            for (int i = 0; i < adjacencyMatrix.Length; i++)
                for (int j = 0; j < adjacencyMatrix[i].Length; j++)
                    if (adjacencyMatrix[i][j] == 1)
                        Console.Write("({0},{1}), ", i + 1, j + 1);
            Console.WriteLine();
        }
        public void ReadAdjacencyList(GraphNode<int>[] adjList)
        {
            for (int i = 0; i < adjList.Length; i++)
            {
                GraphNode<int> t = adjList[i];
                Console.Write("[");
                while (t != null)
                {
                    Console.Write(t.data + "->");
                    t = t.adjacent;
                }
                Console.Write("], ");
            }
            Console.WriteLine();
        }

        public void BuildAdjacencyList()
        {
            adjList.Add(1, new GraphNode<int>(1) { adjacent = new GraphNode<int>(2) { adjacent = new GraphNode<int>(4) } });
            adjList.Add(2, new GraphNode<int>(2) { adjacent = new GraphNode<int>(1) { adjacent = new GraphNode<int>(3) { adjacent = new GraphNode<int>(4) } } });
            adjList.Add(3, new GraphNode<int>(3) { adjacent = new GraphNode<int>(2) { adjacent = new GraphNode<int>(4) { adjacent = new GraphNode<int>(5) } } });
            adjList.Add(4, new GraphNode<int>(4) { adjacent = new GraphNode<int>(1) { adjacent = new GraphNode<int>(2) { adjacent = new GraphNode<int>(3) { adjacent = new GraphNode<int>(5) } } } });
            adjList.Add(5, new GraphNode<int>(5) { adjacent = new GraphNode<int>(3) { adjacent = new GraphNode<int>(4) } });
        }
        public void BFS(GraphNode<int> root)
        {
            Queue<GraphNode<int>> queue = new Queue<GraphNode<int>>();
            queue.Enqueue(root);
            graphNodeVisited[root.data - 1] = true;
            Console.Write("({0}) -> ", root.data);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                while (currentNode != null)
                {
                    if (graphNodeVisited[currentNode.data - 1] == false)
                    {
                        graphNodeVisited[currentNode.data - 1] = true;
                        Console.Write("({0}) -> ", currentNode.data);
                        queue.Enqueue(adjList[currentNode.data]);
                    }
                    currentNode = currentNode.adjacent;
                }
            }
        }
        public void DFS(int startNode)
        {
            if (graphNodeVisited[startNode - 1] == false)
            {
                Console.Write("{0} -> ", startNode);
                graphNodeVisited[startNode - 1] = true;
                var adjacent = adjList[startNode].adjacent;
                while (adjacent != null)
                {
                    if (graphNodeVisited[adjacent.data - 1] == false)
                        DFS(adjacent.data);
                    adjacent = adjacent.adjacent;
                }
            }
        }
    }
}