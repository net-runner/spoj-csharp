using System;
using System.Collections.Generic;

public sealed class Graph
{
    private readonly List<int>[] adjacencyList;

    public Graph(int vertexCount, int[,] edges)
    {
        adjacencyList = new List<int>[vertexCount];
        for (int i = 0; i < vertexCount; i++)
        {
            adjacencyList[i] = new List<int>();
        }

        for (int i = 0; i < edges.GetLength(0); i++)
        {
            int u = edges[i, 0] - 1;
            int v = edges[i, 1] - 1;
            adjacencyList[u].Add(v);
            adjacencyList[v].Add(u);
        }
    }

    public int GetLeafNode()
    {
        for (int i = 0; i < adjacencyList.Length; i++)
        {
            if (adjacencyList[i].Count == 1)
                return i;
        }
        return 0;
    }

    public Tuple<int, int> FindFurthestVertex(int startVertex)
    {
        bool[] visited = new bool[adjacencyList.Length];
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(startVertex);
        visited[startVertex] = true;

        int farthestVertex = startVertex;
        int distance = -1;

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            distance++;

            for (int i = 0; i < levelSize; i++)
            {
                int node = queue.Dequeue();
                farthestVertex = node;

                foreach (int neighbor in adjacencyList[node])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        return Tuple.Create(farthestVertex, distance);
    }
}

public static class PT07Z
{
    public static int Solve(int nodeCount, int[,] edges)
    {
        if (nodeCount == 1)
            return 0;

        var graph = new Graph(nodeCount, edges);

        var firstVertex = graph.GetLeafNode();
        var farthestVertex = graph.FindFurthestVertex(firstVertex);
        int longestPathLength = graph.FindFurthestVertex(farthestVertex.Item1).Item2;

        return longestPathLength;
    }
}

public static class Program
{
    private static void Main()
    {
        int nodeCount = int.Parse(Console.ReadLine());
        int edgeCount = nodeCount - 1;

        int[,] edges = new int[edgeCount, 2];
        for (int i = 0; i < edgeCount; i++)
        {
            string[] edge = Console.ReadLine().Split();
            edges[i, 0] = int.Parse(edge[0]);
            edges[i, 1] = int.Parse(edge[1]);
        }

        Console.WriteLine(PT07Z.Solve(nodeCount, edges));
    }
}
