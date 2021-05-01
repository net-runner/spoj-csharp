using System;

namespace SBANK
{
    class Program
    {
        static string s = "";
        static string[] x;
        static int howManyAccounts = 0;
        static void Main(string[] args)
        {
            int tests = int.Parse(Console.ReadLine());
            int counter = 0;
            while (counter < tests)
            {
                howManyAccounts = int.Parse(Console.ReadLine());
                x = new string[howManyAccounts];
                for (var i = 0; i < howManyAccounts; i++)
                {
                    s = Console.ReadLine();
                    x[i] = s;
                }
                Array.Sort(x, (x, y) => string.CompareOrdinal(x, y));
                int iterum = 1;
                for (var i = 1; i < howManyAccounts; i++)
                {
                    if (string.CompareOrdinal(x[i], x[i - 1]) == 0)
                    {
                        iterum++;
                        if (i + 1 == howManyAccounts) Console.WriteLine(x[i] + iterum);
                    }
                    else
                    {
                        Console.WriteLine(x[i - 1] + iterum);
                        iterum = 1;
                        if (i + 1 == howManyAccounts) Console.WriteLine(x[i] + iterum);
                    }
                }
                if (counter + 1 != tests)
                {
                    Console.ReadLine();
                    Console.WriteLine();
                }
                counter++;
            }
        }
    }
}
