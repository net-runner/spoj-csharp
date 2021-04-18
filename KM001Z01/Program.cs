using System;

namespace KM001Z01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            string type = input[0];
            int W = int.Parse(input[1]);
            int H;
            string ConCat = "";
            if (W >= 3 && W <= 100)
            {
                if (W % 2 == 0) W++;
                for (var i = 0; i < W; i++)
                {
                    ConCat += "*";
                }
                Console.WriteLine(ConCat);
                ConCat = "";
                if (type == "A")
                {
                    H = int.Parse(input[2]);
                    if (H >= 3 && H <= 100)
                    {
                        if (H % 2 == 0) H++;
                        H -= 2;
                        for (var i = 1; i <= H; i++)
                        {
                            for (var j = 1; j <= W; j++)
                            {
                                if (i == H - MathF.Ceiling(H / 2))
                                {
                                    ConCat += "*";
                                    continue;
                                }
                                if (j == 1 || j == W || j == W - MathF.Ceiling(W / 2))
                                {
                                    ConCat += "*";
                                    continue;
                                }
                                ConCat += ".";
                                continue;
                            }
                            Console.WriteLine(ConCat);
                            ConCat = "";
                        }
                    }
                }
                else
                {
                    for (var i = 0; i < (W - 2); i++)
                    {
                        for (var j = 0; j < W; j++)
                        {
                            if (j == i + 1)
                            {
                                ConCat += "*";
                                continue;
                            }
                            ConCat += ".";
                            continue;
                        }
                    }
                    Console.WriteLine(ConCat);
                    ConCat = "";
                }
                for (var i = 0; i < W; i++)
                {
                    ConCat += "*";
                }
                Console.WriteLine(ConCat);
            }
        }
    }
}

