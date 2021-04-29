using System;
using System.Collections.Generic;
using System.Numerics;

namespace SBANK
{
    class Program
    {
        public class Amogus
        {
            public int ammount = 1;
            public string key = "";

            public Amogus(string k)
            {
                this.key = k;
            }
        }
        static string s = "";
        static int howManyAccounts = 0;
        static Dictionary<BigInteger, Amogus> aa;
        static SortedDictionary<BigInteger, Amogus> bb;
        public static BigInteger ToBigInteger(string value)
        {
            BigInteger result = 0;
            for (int i = 0; i < value.Length; i++)
            {
                result = result * 10 + (value[i] - '0');
            }
            return result;
        }
        static void Main(string[] args)
        {
            int tests = int.Parse(Console.ReadLine());
            int counter = 0;
            while (counter < tests)
            {
                howManyAccounts = int.Parse(Console.ReadLine());
                aa = new Dictionary<BigInteger, Amogus>();
                for (var i = 0; i < howManyAccounts; i++)
                {
                    s = Console.ReadLine();
                    BigInteger ss = ToBigInteger(s);
                    if (!aa.TryAdd(ss, new Amogus(s))) aa[ss].ammount++;
                }
                bb = new SortedDictionary<BigInteger, Amogus>(aa);
                foreach (var account in bb) Console.WriteLine(account.Value.key + account.Value.ammount);
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
