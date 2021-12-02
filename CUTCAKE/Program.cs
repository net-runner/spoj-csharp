using System;

namespace CUTCAKE
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal n = decimal.Parse(Console.ReadLine());
            for (decimal i = 0; i < n; i++) Console.WriteLine(Math.Ceiling((-1 + (Math.Sqrt(1 - (4 * (2 - double.Parse(Console.ReadLine()) * 2))))) / 2));
        }
    }
}
