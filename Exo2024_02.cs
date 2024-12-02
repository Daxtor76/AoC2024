using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace AoC2024_Exo02
{
    public class Exo02
    {
        public void Launch()
        {
            string text = Utils.ReadFile("E:\\Projets\\AdventOfCode\\AoC2024\\Exo2024_02.txt");
            string[] textSplitted = text.Split(Environment.NewLine);
            Queue<Report> reports = new Queue<Report>();
            int safeReportsCount = 0;

            foreach (string line in textSplitted)
            {
                Report report = new Report();
                string[] levels = line.Split(" ");

                foreach (string level in levels)
                    report.levels.Add(Int32.Parse(level));

                reports.Enqueue(report);
            }

            // PART ONE
            foreach (Report report in reports)
            {
                if (report.IsSafe())
                    safeReportsCount++;
            }

            Console.WriteLine(safeReportsCount);
        }
    }

    public class Report
    {
        public List<int> levels = new List<int>();

        public bool IsSafe()
        {
            Assert.IsTrue(levels.Count > 1, $"Not enough levels");

            if (IsIncreasing(levels[0], levels[1]) && IsDifferenceInRange(levels[0], levels[1]))
            {
                for (int i = 1; i < levels.Count - 1; i++)
                {
                    if (!IsIncreasing(levels[i], levels[i + 1]) || !IsDifferenceInRange(levels[i], levels[i + 1]))
                        return false;
                }
                return true;
            }
            else if (IsDecreasing(levels[0], levels[1]) && IsDifferenceInRange(levels[0], levels[1]))
            {
                for (int i = 1; i < levels.Count - 1; i++)
                {
                    if (!IsDecreasing(levels[i], levels[i + 1]) || !IsDifferenceInRange(levels[i], levels[i + 1]))
                        return false;
                }
                return true;
            }
            else
                return false;
        }

        bool IsDifferenceInRange(int a, int b) => Math.Abs(a - b) >= 1 && Math.Abs(a - b) <= 3;

        bool IsIncreasing(int a, int b) => a < b;

        bool IsDecreasing(int a, int b) => a > b;
    }
}
