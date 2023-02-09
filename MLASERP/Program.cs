using System;
using System.Collections.Generic;

namespace MLASERP
{
    class Program
    {
        enum Direction
        {
            N,
            S,
            W,
            E,
            START,
        }
        class PlotTile
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int cost { get; set; }
            public int distance { get; set; }

            public int cost_distance => this.cost + this.distance;

            public PlotTile? Parent { get; set; }

            public void SetDistance(int targetX, int targetY)
            {
                this.distance = Math.Abs(targetX - this.X) + Math.Abs(targetY - this.Y);
            }

            public string getID()
            {
                return this.X + "." + this.Y;
            }
            public Direction direction { get; set; } = Direction.START;

            public int mirror_count { get; set; } = 0;
        }

        static void TileAdd(int x, int y, string[] plot, PlotTile currentTile, List<PlotTile> possibleTiles, Direction direction, PlotTile end)
        {
            char plotChar = plot[y][x];
            if (plotChar != '*')
            {
                int costModificator = 0;
                int mirror = 0;
                if (direction != currentTile.direction && currentTile.direction != Direction.START)
                {
                    mirror = 1;
                }
                var tile = new PlotTile { X = x, Y = y, Parent = currentTile, cost = currentTile.cost + 1 + costModificator, direction = direction, mirror_count = currentTile.mirror_count + mirror };
                tile.SetDistance(end.X, end.Y);
                possibleTiles.Add(tile);
            }
        }
        static List<PlotTile> GetWalkableTiles(string[] plot, int maxX, int maxY, PlotTile currentTile, PlotTile end)
        {
            var possibleTiles = new List<PlotTile>();
            int incX = currentTile.X + 1;
            int incY = currentTile.Y + 1;
            int decX = currentTile.X - 1;
            int decY = currentTile.Y - 1;


            if (incX < maxX)
            {
                Direction direction = Direction.E;
                TileAdd(incX, currentTile.Y, plot, currentTile, possibleTiles, direction, end);
            }
            if (decX >= 0)
            {
                Direction direction = Direction.W;
                TileAdd(decX, currentTile.Y, plot, currentTile, possibleTiles, direction, end);
            }
            if (incY < maxY)
            {
                Direction direction = Direction.N;
                TileAdd(currentTile.X, incY, plot, currentTile, possibleTiles, direction, end);
            }
            if (decY >= 0)
            {
                Direction direction = Direction.S;
                TileAdd(currentTile.X, decY, plot, currentTile, possibleTiles, direction, end);
            }
            return possibleTiles;
        }

        static void PrintPath(PlotTile endTile)
        {
            Console.WriteLine("Pos: X: " + endTile.X + ", Y: " + endTile.Y + " MI: " + endTile.mirror_count);
            if (endTile.Parent != null)
            {
                PrintPath(endTile.Parent);
            }

        }

        static void Main(string[] args)
        {
            //God i love COWS with LAZERS
            var paramLine = Console.ReadLine();

            if (paramLine == null)
            {
                return;
            }
            string[] par = paramLine.Split(" ");

            //Get the pasture dimensions
            int w = int.Parse(par[0]);
            int h = int.Parse(par[1]);

            if (w == 0 || h == 0)
            {
                return;
            }
            if (w > 100 || h > 100)
            {
                return;
            }

            string[] plot = new string[h];

            int flag = 0;
            PlotTile start = new PlotTile();
            PlotTile end = new PlotTile();

            //Get the plot
            for (int i = 0; i < h; i++)
            {
                var plotline = Console.ReadLine();
                if (plotline == null)
                {
                    return;
                }
                plot[i] = plotline;

                //Find and set cow positions
                for (int j = 0; j < plotline.Length; j++)
                {
                    char ch = plotline[j];
                    if (ch == 'C')
                    {
                        if (flag == 0)
                        {
                            start.X = j;
                            start.Y = i;
                            flag++;
                        }
                        else
                        {
                            end.X = j;
                            end.Y = i;
                        }
                    }
                }
            }
            start.SetDistance(end.X, end.Y);


            List<PlotTile> activeTiles = new List<PlotTile>();
            PriorityQueue<PlotTile, int> queue = new PriorityQueue<PlotTile, int>();
            HashSet<string> visitedTiles = new HashSet<string>();

            queue.Enqueue(start, start.mirror_count);

            while (queue.Count > 0)
            {
                var currentTile = queue.Dequeue();


                if (currentTile.X == end.X && currentTile.Y == end.Y)
                {
                    Console.WriteLine(currentTile.mirror_count);
                    // PrintPath(currentTile);
                    return;
                }

                if (visitedTiles.Contains(currentTile.getID()))
                    continue;
                else
                    visitedTiles.Add(currentTile.getID());



                var walkableTiles = GetWalkableTiles(plot, w, h, currentTile, end);

                for (int i = 0; i < walkableTiles.Count(); i++)
                {

                    var tile = walkableTiles[i];
                    if (!visitedTiles.Contains(tile.getID()))
                    {
                        queue.Enqueue(tile, tile.mirror_count);
                    };


                }
            }
        }
    }
}
