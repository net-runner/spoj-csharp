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

            StringBuilder sb = new StringBuilder();
            bool isGraph = graphType[0] == 'g';

            if (isGraph)
            {
                sb.AppendLine("graph {");
            }
            else
            {
                sb.AppendLine("digraph {");
            }


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

                if (isGraph)
                {
                    sb.Append($"{source} -- {target}");
                }
                else
                {
                    sb.Append($"{source} -> {target}");
                }

                if (weight != null)
                {
                    sb.Append($" [label = {weight}]");
                }
                sb.AppendLine(";");
            }


            sb.AppendLine("}");
            Console.WriteLine(sb.ToString());
        }
    }
}