using System;
using System.Collections.Generic;

namespace HFLOOR
{
    class Program
    {
        static List<char[]> floor = new List<char[]>();
        static char currentChar;
        static int RoomCounter = 0;
        static decimal HandleLines(int width, int height)
        {
            string line;
            floor = new List<char[]>();
            decimal RoomCounter = 0, Peop = 0;
            for (var i = 0; i < height; i++)
            {
                line = Console.ReadLine();
                floor.Add(line.ToCharArray());
                for (var j = 0; j < width; j++)
                    if (line[j] == '*') Peop++;
            }
            if (Peop == 0) return 0;
            if (height <= 2 || width <= 2) return 0;
            RoomCounter = CalculateRooms(width, height);
            return Math.Round(Peop / RoomCounter, 2);
        }
        static decimal CalculateRooms(int width, int height)
        {
            RoomCounter = 0;
            for (var i = 1; i < floor.Count - 1; i++)
            {
                for (var j = 1; j < width - 1; j++)
                {
                    if (floor[i][j] != '#' && floor[i][j] != 'X')
                    {
                        Rekurentorum(j, i, RoomCounter, width, height);
                        RoomCounter++;
                    }
                }
            }
            if (RoomCounter == 0) return 1;
            return RoomCounter;
        }
        static void Rekurentorum(int x, int y, int RoomCounter, int width, int height)
        {
            currentChar = floor[y][x];
            if (currentChar != '#' && currentChar != 'X')
            {
                floor[y][x] = 'X';
                if (y + 1 < height) Rekurentorum(x, y + 1, RoomCounter, width, height);
                if (y - 1 > 0) Rekurentorum(x, y - 1, RoomCounter, width, height);
                if (x - 1 > 0) Rekurentorum(x - 1, y, RoomCounter, width, height);
                if (x + 1 < width) Rekurentorum(x + 1, y, RoomCounter, width, height);
            }
        }
        static void Main(string[] args)
        {
            int Tests = int.Parse(Console.ReadLine());
            if (Tests <= 10)
                while (Tests > 0)
                {
                    int[] parameters = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), int.Parse);
                    if (parameters[0] <= 100 && parameters[1] <= 100) Console.WriteLine(HandleLines(parameters[1], parameters[0]).ToString("0.00"));
                    Tests--;
                }
        }
    }
}
