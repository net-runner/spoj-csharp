using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, string> parent = new Dictionary<string, string>();
    static Dictionary<string, int> rank = new Dictionary<string, int>();

    static string Find(string ip)
    {
        if (parent[ip] != ip)
            parent[ip] = Find(parent[ip]);
        return parent[ip];
    }

    static void Union(string ip1, string ip2)
    {
        string root1 = Find(ip1);
        string root2 = Find(ip2);

        if (root1 != root2)
        {
            if (rank[root1] > rank[root2])
                parent[root2] = root1;
            else if (rank[root1] < rank[root2])
                parent[root1] = root2;
            else
            {
                parent[root2] = root1;
                rank[root1]++;
            }
        }
    }

    static void Main()
    {
        string line;
        while ((line = Console.ReadLine()) != null)
        {
            string[] parts = line.Split(' ');
            if (parts.Length < 3) continue;

            string command = parts[0];
            string ip1 = parts[1];
            string ip2 = parts[2];

            if (!parent.ContainsKey(ip1))
            {
                parent[ip1] = ip1;
                rank[ip1] = 0;
            }
            if (!parent.ContainsKey(ip2))
            {
                parent[ip2] = ip2;
                rank[ip2] = 0;
            }

            if (command == "B")
            {
                Union(ip1, ip2);
            }
            else if (command == "T")
            {
                Console.WriteLine(Find(ip1) == Find(ip2) ? "T" : "N");
            }
        }
    }
}
