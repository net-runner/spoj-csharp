using System;
using System.Collections.Generic;

namespace SBANK
{
    class Program
    {
        static string s = "";
        static int howManyAccounts = 0;
        static Dictionary<string, int> aa;
        static void Main(string[] args)
        {
            int tests = int.Parse(Console.ReadLine());
            int counter = 0;
            SortedDictionary<string, int>[] w = new SortedDictionary<string, int>[tests];
            while (counter < tests)
            {
                howManyAccounts = int.Parse(Console.ReadLine());
                aa = new Dictionary<string, int>();
                for (var i = 0; i < howManyAccounts; i++)
                {
                    s = Console.ReadLine();
                    if (!aa.TryAdd(s, 1)) aa[s]++;
                }
                w[counter] = new SortedDictionary<string, int>(aa);
                if (counter + 1 != tests)
                    Console.ReadLine();
                counter++;
            }
            for (var i = 0; i < tests; i++)
            {
                foreach (var account in w[i]) Console.WriteLine(account.Key + account.Value);
                if (i + 1 != tests)
                    Console.WriteLine();
            }
        }
    }
}
