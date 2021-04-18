using System;

namespace SMPSEQ
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string s_string = Console.ReadLine();
            int[] s = Array.ConvertAll<string, int>(s_string.Split(" "), int.Parse);
            int m = int.Parse(Console.ReadLine());
            string q_string = Console.ReadLine();
            int[] q = Array.ConvertAll<string, int>(q_string.Split(" "), int.Parse);
            double q_sum = 0;
            double s_sum = 0;
            for (var i = 0; i < m; i++) q_sum += q[i];
            for (var i = 0; i < n; i++) s_sum += s[i];
            if (q_sum / m < s_sum / n) Console.Write(s_string);
            else Console.Write(q_string);
        }
    }
}
