using System;

namespace KM001Z01
{
    class Program2
    {
        static void Main(string[] args)
        {
            string[] ACA = new string[] { "*", "." };
            string[] input = Console.ReadLine().Split(" ");
            string type = input[0];
            int W = int.Parse(input[1]);
            int H;
            if (type == "A")
            {
                H = int.Parse(input[2]);
                if (W < 3 || W > 100 || H < 3 || H > 100) type = "X";
                if (H % 2 == 0) H++;
                if (W % 2 == 0) W++;
            }
            else
            {
                H = W;
            }
            if (type != "X")
                for (var i = 1; i <= H; i++)
                {
                    string ConCat = "";
                    for (var j = 1; j <= W; j++)
                    {
                        if (i == 1 || i == H)
                        {
                            ConCat += ACA[0];
                            continue;
                        }
                        if (type == "A")
                        {
                            if (i == H - MathF.Ceiling(H / 2))
                            {
                                ConCat += ACA[0];
                                continue;
                            }
                            if (j == 1 || j == W || j == W - MathF.Ceiling(W / 2))
                            {
                                ConCat += ACA[0];
                                continue;
                            }
                            if (j != 1 && j != W && j != W - MathF.Ceiling(W / 2))
                            {
                                ConCat += ACA[1];
                                continue;
                            }
                        }
                        if (j == i)
                        {
                            ConCat += ACA[0];
                            continue;
                        }
                        ConCat += ACA[1];
                        continue;
                    }
                    Console.WriteLine(ConCat);
                }
        }
    }
}

