using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Security.Permissions;
using System.Text.RegularExpressions;

namespace AoC2024
{
    public class Exo04
    {
        string text = Utils.ReadFile("E:\\Projets\\AdventOfCode\\AoC2024\\Exo2024_04.txt");
        Dictionary<Vector2, char> grid = new Dictionary<Vector2, char>();

        int xmasCount = 0;

        public void Launch()
        {
            string[] textSplitted = text.Split(Environment.NewLine);
            grid = CreateGrid(textSplitted);

            // pour chaque X, parcourir dans toutes les directions sur distance de 4
            // stop si pas de correspondance à XMAS

            foreach (Vector2 pos in grid.Keys)
            {
                CheckAllDirectionFromPosition(pos, "XMAS");
            }

            Console.WriteLine(xmasCount);
        }

        private void CheckAllDirectionFromPosition(Vector2 origin, string searchedString)
        {
            List<Vector2> directionsToCheck = new List<Vector2>()
            {
                new Vector2(1, 0),
                new Vector2(1, -1),
                new Vector2(0, -1),
                new Vector2(-1, -1),
                new Vector2(-1, 0),
                new Vector2(-1, 1),
                new Vector2(0, 1),
                new Vector2(1, 1)
            };

            if (grid[origin] == searchedString[0])
            {
                foreach (Vector2 direction in directionsToCheck)
                {
                    for (int i = 1; i < searchedString.Length; i++)
                    {
                        Vector2 posToCheck = origin + direction * i;

                        if (grid.ContainsKey(posToCheck))
                        {
                            if (GetCharInPosition(posToCheck) == searchedString[i])
                            {
                                if (i == searchedString.Length - 1)
                                    xmasCount++;
                            }
                            else
                                break;
                        }
                    }
                }
            }
        }

        private char GetCharInPosition(Vector2 position) => grid[position];

        private Dictionary<Vector2, char> CreateGrid(string[] textSplitted)
        {
            Dictionary<Vector2, char> dico = new Dictionary<Vector2, char>();
            for (int i = 0; i < textSplitted.Length; i++)
            {
                for (int y = 0; y < textSplitted[i].Length; y++)
                {
                    char c = textSplitted[i][y];
                    Vector2 pos = new Vector2(y, i);

                    dico.Add(pos, c);
                }
            }

            return dico;
        }
    }
}