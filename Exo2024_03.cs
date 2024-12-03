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
            int result = 0;

            // mul(XXX,YYY)

            // PART ONE
            /*string[] textSplitted = FindMuls(text).ToArray();
            foreach (string s in textSplitted)
            {
                result += GetExpressionResult(s);
            }
            Console.WriteLine(result);*/

            // PART TWO
            string[] textSplitted = FindInstructions(text).ToArray();
            bool canGetValue = true;
            foreach (string s in textSplitted)
            {
                switch(s)
                {
                    case "do()":
                        canGetValue = true;
                        break;
                    case "don't()":
                        canGetValue = false;
                        break;
                    default:
                        if (canGetValue)
                            result += GetExpressionResult(s);
                        else
                            break;
                        break;
                }
            }
            Console.WriteLine(result);
        }

        public int GetExpressionResult(string expression)
        {
            string[] splittedExpression = expression.Split(['(', ',', ')']);
            int a = Int32.Parse(splittedExpression[1]);
            int b = Int32.Parse(splittedExpression[2]);

            return a * b;
        }

        public List<string> FindInstructions(string input)
        {
            List<string> result = new List<string>();
            Regex regex = new Regex("don't\\(\\)|mul\\([0-9]+,[0-9]+\\)|do\\(\\)", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(input);

            foreach(Match match in matches)
                result.Add(match.Value);

            return result;
        }

        public List<string> FindMuls(string input)
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