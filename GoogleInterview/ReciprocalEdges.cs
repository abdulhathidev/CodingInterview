using System;

namespace CodingInterview.GoogleInterview
{
    public class Edge
    {
        public string FromId;
        public string ToId;
    }
    public class Node
    {
        public Node previous;
        public string data;
        public Node next;
        public Node(string data)
        {
            this.data = data;
        }
    }
    public class ReciprocalEdges
    {
        //{A, W}, {W, D},{D, FH},{FH,A},{A, D},{D,A},{D,W}
        public ReciprocalEdges()
        {
            Edge[] edges = new Edge[]{
                new Edge() { FromId = "A", ToId = "W" },
                new Edge() { FromId = "W", ToId = "D" },
                new Edge() { FromId = "D", ToId = "FH" },
                new Edge() { FromId = "FH", ToId = "A" },
                new Edge() { FromId = "A", ToId = "D" },
                new Edge() { FromId = "D", ToId = "A" },
                new Edge() { FromId = "D", ToId = "W" }
            };
            ReciprocalEdgesCount(edges);
        }

        public void ReciprocalEdgesCount(Edge[] edges)
        {
            Node root = null, p = null, t = null;
            int count = 0;
            for (int i = 0; i < edges.Length; i++)
            {
                Node q = null;
                while (t != null)
                {
                    if (t.data == edges[i].FromId && q != null && q.data == edges[i].ToId)
                    {
                        count++;
                    }
                    q = t;
                    t = t.next;
                }
                if (root == null)
                {
                    root = new Node(edges[i].FromId);
                    p = root;
                    t = root;
                }
                if (p.next == null)
                    p.next = new Node(edges[i].ToId);
                p = p.next;
                t = root;
            }
            Console.WriteLine();
            Console.WriteLine(count);
        }
    }
}