using System;

namespace KM002Z01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), int.Parse);
            if (parameters[0] < 0 || parameters[1] < 0)
                Console.WriteLine("ujemny argument");
            else
            {
                if (parameters[1] >= parameters[0])
                {
                    decimal h = 0, v = 0, l = parameters[1], r = parameters[0];
                    h = (decimal)(Math.Sqrt((double)(l * l - r * r)));
                    v = (decimal)((r * r) * (decimal)Math.PI * h * 1 / 3);
                    Console.WriteLine(Math.Floor(v) + " " + Math.Ceiling(v));
                }
                else Console.WriteLine("obiekt nie istnieje");
            }
        }
    }
}
