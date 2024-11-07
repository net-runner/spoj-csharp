using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        // Wczytaj dane wejściowe
        string[] input = Console.ReadLine().Split();
        int x = int.Parse(input[0]);
        int y = int.Parse(input[1]);

        // Generuj napis
        StringBuilder sb = new StringBuilder();
        for (int i = x; i <= y; i++)
        {
            if (i % 6 == 0)
                sb.Append("ab");
            else if (i % 2 == 0 && i % 3 != 0)
                sb.Append("a");
            else if (i % 3 == 0 && i % 2 != 0)
                sb.Append("b");
        }

        // Wyświetl wynik
        Console.WriteLine(sb.ToString());
    }
}