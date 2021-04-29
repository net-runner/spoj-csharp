using System;
using System.Collections.Generic;

namespace RKS
{
    class Program
    {
        public class Amogus
        {
            public int key { get; set; }
            public int ammount { get; set; }
            public int first { get; set; }
            public Amogus(int k, int f)
            {
                this.key = k;
                this.ammount = 1;
                this.first = f;
            }
        }
        static void Main(string[] args)
        {
            int[] parameters = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), int.Parse);
            List<Amogus> a = new List<Amogus>();
            int[] numbers = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), int.Parse);
            for (var i = 0; i < parameters[0]; i++)
            {
                int indexorum = a.FindIndex(e => e.key == numbers[i]);
                if (indexorum >= 0) a[indexorum].ammount++;
                else a.Add(new Amogus(numbers[i], i));
            }
            a.Sort((x, y) =>
            {
                int comp = y.ammount.CompareTo(x.ammount);
                if (comp != 0) return comp;
                else return x.first.CompareTo(y.first);
            }
            );
            foreach (var amogus in a) for (var i = 0; i < amogus.ammount; i++) Console.Write(amogus.key + " ");
        }
    }
}
