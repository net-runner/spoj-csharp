using System;

namespace HS12MBR
{
    class Program
    {
        public class Prostokont
        {
            public int[] a = new int[4];

            public int x { get => a[0]; set => a[0] = value; }
            public int y { get => a[1]; set => a[1] = value; }

            public int xx { get => a[2]; set => a[2] = value; }
            public int yy { get => a[3]; set => a[3] = value; }
            public Prostokont(int x, int y, int xx, int yy)
            {
                a[0] = x;
                a[1] = y;
                a[2] = xx;
                a[3] = yy;
            }
        }
        public interface IFigura
        {
            Prostokont GetBoundingRectangle();
        }
        public class Punkt : IFigura
        {
            public int x;
            public int y;
            public Punkt(int X, int Y)
            {
                x = X;
                y = Y;
            }

            public Prostokont GetBoundingRectangle()
            {
                return new Prostokont(x, y, x, y);
            }
        }
        public class Kolo : IFigura
        {
            public int x;
            public int y;
            public int r;
            public Kolo(int X, int Y, int R)
            {
                x = X;
                y = Y;
                r = R;
            }

            public Prostokont GetBoundingRectangle()
            {
                return new Prostokont((x - r), (y - r), (x + r), (y + r));
            }
        }

        public class Linia : IFigura
        {
            public int x;
            public int y;

            public int xx;
            public int yy;
            public Linia(int X, int Y, int XX, int YY)
            {
                x = X;
                y = Y;
                xx = XX;
                yy = YY;
            }

            public Prostokont GetBoundingRectangle()
            {
                return new Prostokont((x < xx ? x : xx), (y < yy ? y : yy), (xx > x ? xx : x), (yy > y ? yy : y));
            }
        }
        static void Main(string[] args)
        {
            int tests = int.Parse(Console.ReadLine());
            for (int i = 0; i < tests; i++)
            {

                Prostokont nextProsto = new Prostokont(0, 0, 0, 0);
                Prostokont prosto = new Prostokont(0, 0, 0, 0);
                int objectsAmmount = int.Parse(Console.ReadLine());
                for (int j = 0; j < objectsAmmount; j++)
                {
                    string[] input = Console.ReadLine().Split(" ");
                    switch (input[0])
                    {
                        case "p":
                            prosto = new Punkt(int.Parse(input[1]), int.Parse(input[2])).GetBoundingRectangle();
                            break;
                        case "l":
                            prosto = new Linia(int.Parse(input[1]), int.Parse(input[2]), int.Parse(input[3]), int.Parse(input[4])).GetBoundingRectangle();
                            break;
                        case "c":
                            prosto = new Kolo(int.Parse(input[1]), int.Parse(input[2]), int.Parse(input[3])).GetBoundingRectangle();
                            break;
                    }
                    if (j == 0) nextProsto = prosto;
                    else
                    {
                        if (nextProsto.x > prosto.x) nextProsto.x = prosto.x;
                        if (nextProsto.xx < prosto.xx) nextProsto.xx = prosto.xx;
                        if (nextProsto.y > prosto.y) nextProsto.y = prosto.y;
                        if (nextProsto.yy < prosto.yy) nextProsto.yy = prosto.yy;
                    }
                }
                Console.WriteLine($"{nextProsto.x} {nextProsto.y} {nextProsto.xx} {nextProsto.yy}");
                if (i + 1 != tests) Console.ReadLine();
            }
        }
    }
}
