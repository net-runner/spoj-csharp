using System;
using System.Numerics;

namespace PTEST
{
    class Program
    {
        // SIMPLPRBLM
        static BigInteger getPairs(BigInteger S, BigInteger[] nums)
        {
            BigInteger ergo_sum = 0;
            for (var i = 0; i < nums.Length; i++) ergo_sum += rec(S, nums, i);
            return ergo_sum;
        }
        static BigInteger rec(BigInteger S, BigInteger[] nums, int index)
        {
            BigInteger ergo_sum = 0;
            BigInteger pairer = nums[index];
            if (pairer == S) return ergo_sum;
            for (var i = index + 1; i < nums.Length; i++) if (pairer + nums[i] == S) ergo_sum++;
            return ergo_sum;
        }
        static int Main(string[] args)
        {
            BigInteger t = BigInteger.Parse(Console.ReadLine());
            BigInteger case_counter = 1;
            while (t > 0)
            {
                string[] first_line = Console.ReadLine().Split(" ");
                if (first_line == null) break;
                string[] second_line = Console.ReadLine().Split(" ");
                if (second_line == null) break;
                BigInteger s = BigInteger.Parse(first_line[1]);
                BigInteger[] nums = new BigInteger[second_line.Length];
                for (var i = 0; i < BigInteger.Parse(first_line[0]); i++) nums[i] = BigInteger.Parse(second_line[i]);
                Console.WriteLine("Case " + case_counter + ": " + getPairs(s, nums));
                case_counter++;
                t--;
            }
            return 0;
        }

        // JSUMDUZE
        static void Main4(string[] args)
        {
            BigInteger isuma = 0;
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                string line = Console.ReadLine();
                if (line == null || line == "") break;
                string[] aline = line.Split(" ");
                for (var i = 0; i < 2; i++) isuma += BigInteger.Parse(aline[i]);
                Console.WriteLine(isuma);
                t--;
                isuma = 0;
            }
        }

        //SMPSUM

        public static void Main6(string[] args)
        {
            string[] first_line = Console.ReadLine().Split(" ");
            int sum = 0;
            for (var i = int.Parse(first_line[0]); i <= int.Parse(first_line[1]); i++)
            {
                sum += i * i;
            }
            Console.WriteLine(sum);
        }


        // JULKA

        static void Main5(string[] args)
        {
            int t = 10;
            BigInteger both = 0;
            BigInteger kmore = 0;
            BigInteger o1 = 0;
            BigInteger o2 = 0;
            while (t > 0)
            {

                string first_line = Console.ReadLine();
                if (first_line == null) break;
                string second_line = Console.ReadLine();
                if (second_line == null) break;
                both = BigInteger.Parse(first_line);
                kmore = BigInteger.Parse(second_line);
                o2 = (both - kmore) / 2;
                o1 = o2 + kmore;
                Console.WriteLine(o1);
                Console.WriteLine(o2);
                t--;
            }
        }
        static void Main2(string[] args)
        {
            long sum = 0;
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null || line == "") break;
                long isuma = 0;
                string[] aline = line.Split(" ");
                for (var i = 0; i < aline.Length; i++) isuma += int.Parse(aline[i]);
                Console.WriteLine(isuma);
                sum += isuma;
            }
            Console.WriteLine(sum);
        }
        static void Main3(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine(a + b);
        }
    }
}
