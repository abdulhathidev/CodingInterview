using System;

namespace CodingInterview.TreesAndGraphs
{
    /*
             (1)---(3)
              |   / |
              | /   |
             (4)---(2)
               \   /
                (5)
               /   \
             (6)   (7)
    */
    public class DepthFirstSearch
    {
        int[][] adjacencyMatrix = new int[][]{
            new int[] {0,1,1,1,0,0,0},
            new int[] {1,0,1,0,0,0,0},
            new int[] {1,1,0,1,1,0,0},
            new int[] {1,0,1,0,1,0,0},
            new int[] {0,0,1,1,0,1,1},
            new int[] {0,0,0,0,1,0,0},
            new int[] {0,0,0,0,1,0,0},
        };
        bool[] visited = new bool[7];
        Queue<int> queue = new Queue<int>();
        public DepthFirstSearch()
        {
            Console.Write("4.1. Depth first search visited node's "); DFS(0);
            Console.WriteLine();
        }

        public void DFS(int v)
        {
            if (!visited[v])
            {
                Console.Write("{0} ", v + 1);
                visited[v] = true;
                for (int i = 0; i < adjacencyMatrix.Length; i++)
                {
                    if (adjacencyMatrix[v][i] == 1 && !visited[i])
                        DFS(i);
                }
            }
        }
    }
}