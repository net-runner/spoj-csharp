using System.Text;

public class GraphConverter
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            string graphType = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<(string, int?)>> graph = new Dictionary<string, List<(string, int?)>>();

            for (int j = 0; j < n; j++)
            {
                string[] edge = Console.ReadLine().Split();
                string source = edge[0];
                string target = edge[1];
                int? weight = null;
                if (edge.Length > 2)
                {
                    weight = int.Parse(edge[2]);
                }

                if (!graph.ContainsKey(source))
                {
                    graph[source] = new List<(string, int?)>();
                }
                graph[source].Add((target, weight));
            }

            Console.WriteLine(ConvertToGraphviz(graphType, graph));
        }
    }

    private static string ConvertToGraphviz(string graphType, Dictionary<string, List<(string, int?)>> graph)
    {
        StringBuilder sb = new StringBuilder();
        bool isGraph = graphType == "g" || graphType == "gw";

        if (isGraph)
        {
            sb.AppendLine("graph {");
        }
        else
        {
            sb.AppendLine("digraph {");
        }

        foreach (var node in graph)
        {
            foreach (var neighbor in node.Value)
            {
                string line;
                if (isGraph)
                {
                    line = $"{node.Key} -- {neighbor.Item1}";
                }
                else
                {
                    line = $"{node.Key} -> {neighbor.Item1}";
                }

                if (graphType == "gw" || graphType == "dw")
                {
                    line += $" [label = {neighbor.Item2}]";
                }
                line += ";";
                sb.AppendLine(line);
            }
        }

        sb.AppendLine("}");
        return sb.ToString();
    }
}