using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AoC2024
{
    public class Exo03
    {
        public void Launch()
        {
            string text = Utils.ReadFile("C:\\Formation\\AoC2024\\Exo2024_03.txt");
            string[] textSplitted = UseRegex(text).ToArray();

            // trouver: mul(x,y)

            // PART ONE
            foreach (string s in textSplitted)
            {
                Console.WriteLine(s);
            }
        }

        public List<string> UseRegex(string input)
        {
            List<string> result = new List<string>();
            Regex regex = new Regex("mul\\([0-9]+,[0-9]+\\)", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(input);

            foreach(Match match in matches)
                result.Add(match.Value);

            return result;
        }
    }
}