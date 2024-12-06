using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
            string[] textSplitted = text.Split(Environment.NewLine);
            string[] tmpRules = textSplitted.TakeWhile(c => c.Length != 0).ToArray();
            string[] tmpPages = GetTmpRules(textSplitted);
            List<OrderingRule> rules = GetAllRules(tmpRules);
            List<Pages> pages = GetAllPages(tmpPages);

            foreach (OrderingRule rule in rules)
            {
                Console.WriteLine($"Rule: {rule.concernedPage} - {rule.beforePage}");
            }
            foreach (Pages page in pages)
            {
                foreach (int nb in page.pages)
                {
                    Console.WriteLine($"Pages: {nb}");
                }
                Console.WriteLine($"---------------");
            }
        }

        public string[] GetTmpRules(string[] text)
        {
            List<string> tmp = new List<string>();
            for (int i = text.Length - 1; i >= 0; i--)
            {
                if (text[i].Contains(","))
                    tmp.Add(text[i]);
            }

            return tmp.ToArray();
        }

        public List<Pages> GetAllPages(string[] pages)
        {
            List<Pages> finalPages = new List<Pages>();

            foreach (string s in pages)
            {
                Pages tmp = new Pages(s);

                finalPages.Add(tmp);
            }

            return finalPages;
        }

        public List<OrderingRule> GetAllRules(string[] rules)
        {
            List<OrderingRule> finalUpdates = new List<OrderingRule>();

            foreach (string s in rules)
            {
                int concernedPage = Int32.Parse(s.Split("|")[0]);
                int beforePage = Int32.Parse(s.Split("|")[1]);

                OrderingRule tmp = new OrderingRule(concernedPage, beforePage);
                finalUpdates.Add(tmp);
            }

            return finalUpdates;
        }
    }

    public class Pages
    {
        public List<int> pages = new List<int>();

        public Pages(string pages)
        {
            this.pages = SplitPages(pages);
        }

        public List<int> SplitPages(string pages)
        {
            string[] tmpPages = pages.Split(",");
            List<int> tmp = new List<int>();

            foreach (string s in tmpPages)
                tmp.Add(Int32.Parse(s));

            return tmp;
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