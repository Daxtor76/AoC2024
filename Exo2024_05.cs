using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Security.Permissions;
using System.Text.RegularExpressions;

namespace AoC2024
{
    public class Exo05
    {
        string text = Utils.ReadFile("E:\\Projets\\AdventOfCode\\AoC2024\\Exo2024_05.txt");

        public void Launch()
        {
            string[] textSplitted = text.Split(" ");
            string[] rules = textSplitted[0].Split(Environment.NewLine);
            List<OrderingRule> updates = GetAllUpdates(textSplitted[1]);

            
        }

        public List<OrderingRule> GetAllUpdates(string entry)
        {
            string[] updates = entry.Split(Environment.NewLine);
            List<OrderingRule> finalUpdates = new List<OrderingRule>();

            foreach (string s in updates)
            {
                int concernedPage = Int32.Parse(s.Split("|")[0]);
                int beforePage = Int32.Parse(s.Split("|")[1]);

                OrderingRule tmp = new OrderingRule(concernedPage, beforePage);
                finalUpdates.Add(tmp);
            }

            return finalUpdates;
        }
    }

    public class OrderingRule
    {
        public int concernedPage;
        public int beforePage;

        public OrderingRule(int concernedPage, int beforePage)
        {
            this.concernedPage = concernedPage;
            this.beforePage = beforePage;
        }
    }
}