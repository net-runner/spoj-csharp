using System;
using System.Collections.Generic;

namespace DIGNUM
{
    class Program
    {
        static string[] zero = { " _ ", "| |", "|_|" };
        static string[] one = { "   ", "  |", "  |" };
        static string[] two = { " _ ", " _|", "|_ " };
        static string[] three = { " _ ", " _|", " _|" };
        static string[] four = { "   ", "|_|", "  |" };
        static string[] five = { " _ ", "|_ ", " _|" };
        static string[] six = { " _ ", "|_ ", "|_|" };
        static string[] seven = { " _ ", "  |", "  |" };
        static string[] eight = { " _ ", "|_|", "|_|" };
        static string[] nine = { " _ ", "|_|", "  |" };

        static string[][] numbers = { zero, one, two, three, four, five, six, seven, eight, nine, };

        static List<string[]> compileLine(string line, List<string[]> digiList, int rowIndex)
        {
            if (rowIndex == 0)
            {
                digiList = new List<string[]>();
            }
            string cat = "";
            int iteratorum = 0;
            for (var i = 0; i < line.Length; i++)
            {
                cat += line[i];
                if (cat.Length == 3)
                {
                    if (rowIndex == 0)
                    {
                        digiList.Add(new string[3]);
                    }
                    string[] digit = digiList[iteratorum];
                    digit[rowIndex] = cat;
                    digiList[iteratorum] = digit;
                    cat = "";
                    iteratorum++;
                }
            }
            return digiList;
        }
        static int[] getDigits(List<string[]> digiList)
        {
            int[] numerumArabum = new int[digiList.Count];
            for (var i = 0; i < digiList.Count; i++)
            {
                int iterator = 0;
                foreach (var number in numbers)
                {
                    bool equals = true;
                    for (var j = 0; j < 3; j++)
                    {
                        if (digiList[i][j] != number[j])
                        {
                            equals = false;
                        }
                    }
                    if (equals)
                    {
                        numerumArabum[i] = iterator;
                        break;
                    };
                    iterator++;
                }
            }
            return numerumArabum;
        }
        static void Main(string[] args)
        {
            List<string[]> digiList = new List<string[]>();
            List<string> lines = new List<string>();
            List<int[]> digiLine = new List<int[]>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null || line == "") break;
                lines.Add(line);
            }
            int iterator = 1;
            for (var i = 0; i < lines.Count; i++)
            {
                digiList = compileLine(lines[i], digiList, i % 3);
                if (iterator == 3)
                {
                    digiLine.Add(getDigits(digiList));
                    iterator = 0;
                }
                iterator++;
            }
            for (var i = 0; i < digiLine.Count; i++)
            {
                if (true)
                    foreach (var number in digiLine[i])
                    {
                        Console.Write(number);
                    }
                Console.WriteLine();
            }
        }
    }
}
