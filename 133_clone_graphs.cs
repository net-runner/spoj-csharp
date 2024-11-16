public class Solution
{

    private Dictionary<Node, Node> graph = new Dictionary<Node, Node>();

    public Node CloneGraph(Node node)
    {

        if (node == null) return null;

        if (graph.ContainsKey(node))
        {
            return graph[node];
        }

        graph[node] = new Node(node.val);

        foreach (Node neighbouringNode in node.neighbors)
        {
            graph[node].neighbors.Add(CloneGraph(neighbouringNode));
        }

        return graph[node];
    }
}