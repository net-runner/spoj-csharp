using System;

namespace FCTRL3
{
    class Program
    {
        static void Main(string[] args)
        {
            int Num;
            int OutputN = 1;
            for (int i = 0; i < int.Parse(Console.ReadLine()); i++)
            {
                Num = int.Parse(Console.ReadLine());
                if (Num <= 1) Console.WriteLine("0 1");
                else
                {
                    for (int j = 1; j <= Num; j++) OutputN *= j;
                    if (OutputN > 9) Console.WriteLine(OutputN.ToString().Substring(0, 1) + " " + OutputN.ToString().Substring(1, 1));
                    else Console.WriteLine("0" + " " + OutputN.ToString());
                    OutputN = 1;
                }
            }
        }
    }
}
