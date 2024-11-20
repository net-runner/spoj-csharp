public class Graph
{
    private int vertexCount;
    private List<int>[] adjacencyList;

    public Graph(int v)
    {
        vertexCount = v;
        adjacencyList = new List<int>[vertexCount];
        for (int i = 0; i < vertexCount; i++)
        {
            adjacencyList[i] = new List<int>();
        }
    }

    public void AddEdge(int v, int w)
    {
        adjacencyList[v - 1].Add(w - 1);
    }

    private void DFSUtil(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write($"{v + 1} ");

        foreach (int neighbor in adjacencyList[v])
        {
            if (!visited[neighbor])
            {
                DFSUtil(neighbor, visited);
            }
        }
    }

    public void DFS(int v)
    {
        bool[] visited = new bool[vertexCount];
        for (int i = 0; i < vertexCount; i++)
        {
            visited[i] = false;
        }
        DFSUtil(v, visited);
    }

    public void BFS(int v)
    {
        bool[] visited = new bool[vertexCount];
        for (int i = 0; i < vertexCount; i++)
        {
            visited[i] = false;
        }
        Queue<int> queue = new Queue<int>();

        visited[v] = true;
        queue.Enqueue(v);

        while (queue.Count > 0)
        {
            v = queue.Dequeue();
            Console.Write($"{v + 1} ");
            foreach (int neighbor in adjacencyList[v])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
    }

    public static void Main()
    {
        int graphs = int.Parse(Console.ReadLine());

        for (int graphCount = 1; graphCount <= graphs; graphCount++)
        {
            int graphSize = int.Parse(Console.ReadLine());
            Graph graph = new Graph(graphSize);

            for (int j = 1; j <= graphSize; j++)
            {
                string[] input = Console.ReadLine().Split();
                int vertex = int.Parse(input[0]);
                int neighbors = int.Parse(input[1]);

                for (int k = 0; k < neighbors; k++)
                {
                    int neighbor = int.Parse(input[k + 2]);
                    graph.AddEdge(vertex, neighbor);
                }
            }

            Console.WriteLine($"graph {graphCount}");

            while (true)
            {
                string[] query = Console.ReadLine().Split();
                int vertex = int.Parse(query[0]);
                int searchType = int.Parse(query[1]);

                if (vertex == 0 && searchType == 0)
                {
                    break;
                }

                int vertexIndex = vertex - 1;
                if (searchType == 0)
                {
                    graph.DFS(vertexIndex);
                    Console.WriteLine();
                    continue;
                }

                graph.BFS(vertexIndex);
                Console.WriteLine();
            }

        }
    }
}