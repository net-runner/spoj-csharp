using System;
using System.Collections.Generic;

namespace MORSE
{
    class Program
    {
        static Dictionary<string, char> table = new Dictionary<string, char>();
        static string input;
        static Dictionary<int, long> dp = new Dictionary<int, long>();
        static HashSet<string> dict = new HashSet<string>();

        static void init()
        {
            table[".-"] = 'A';
            table["-..."] = 'B';
            table["-.-."] = 'C';
            table["-.."] = 'D';
            table["."] = 'E';
            table["..-."] = 'F';
            table["--."] = 'G';
            table["...."] = 'H';
            table[".."] = 'I';
            table[".---"] = 'J';
            table["-.-"] = 'K';
            table[".-.."] = 'L';
            table["--"] = 'M';
            table["-."] = 'N';
            table["---"] = 'O';
            table[".--."] = 'P';
            table["--.-"] = 'Q';
            table[".-."] = 'R';
            table["..."] = 'S';
            table["-"] = 'T';
            table["..-"] = 'U';
            table["...-"] = 'V';
            table[".--"] = 'W';
            table["-..-"] = 'X';
            table["-.--"] = 'Y';
            table["--.."] = 'Z';
            return;
        }


        static void Main(string[] args)
        {
            //Init the initial morse table
            init();



            int d = int.Parse(Console.ReadLine());

            while (d > 0)
            {
                //Clear data on new dataset
                dp.Clear();
                dict.Clear();

                string morse_code = Console.ReadLine();
                int number_of_phrases = int.Parse(Console.ReadLine());

                //Add phrases to dictionary
                for (var i = 0; i < number_of_phrases; i++)
                {
                    string phrase = Console.ReadLine();
                    dict.Add(phrase);
                }

                int phrases;
                d--;
            }

            return;
        }
    }
}
