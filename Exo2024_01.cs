using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC2024_Exo01
{
    public class Exo01
    {
        public void Launch()
        {
            string text = Utils.ReadFile("E:\\Projets\\AdventOfCode\\AoC2024\\Exo2024_01.txt");
            string[] textSplitted = text.Split(Environment.NewLine);
            List<int> leftIds = new List<int>();
            List<int> rightIds = new List<int>();

            foreach (string line in textSplitted)
            {
                string[] values = line.Split("   ");
                leftIds.Add(Int32.Parse(values[0]));
                rightIds.Add(Int32.Parse(values[1]));
            }

            // PART ONE
            //Console.Write($"{GetAddedDistancesFromLists(leftIds.Order().ToList(), rightIds.Order().ToList())}");

            // PART TWO
            Console.Write($"{GetSumOfMultipliedOccurencesFromLists(leftIds, rightIds)}");
        }

        public static int GetSumOfMultipliedOccurencesFromLists(List<int> left, List<int> right)
        {
            Assert.IsTrue(left.Count == right.Count, "The lists don't have the same amount of elements");

            int total = 0;

            foreach (int value in left)
            {
                total += value * GetAmountOfOccurenceInList(value, right);
            }

            return total;
        }

        public static int GetAmountOfOccurenceInList(int searchValue, List<int> list)
        {
            int total = 0;

            foreach (int value in list)
            {
                if (value == searchValue)
                    total++;
            }

            return total;
        }

        public static int GetAddedDistancesFromLists(List<int> left, List<int> right)
        {
            Assert.IsTrue(left.Count == right.Count, "The lists don't have the same amount of elements");

            int total = 0;

            for (int i = 0; i < left.Count; i++)
            {
                total += Math.Abs(left[i] - right[i]);
            }

            return total;
        }
    }
}
