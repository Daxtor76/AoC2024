using System.Diagnostics;
using System.Numerics;

namespace AoC2024
{
    public class Exo06
    {
        string text = Utils.ReadFile("E:\\Projets\\AdventOfCode\\AoC2024\\Exo2024_06.txt");
        Dictionary<Vector2, Case> grid = new Dictionary<Vector2, Case>();
        List<Vector2> orderedDirections = new List<Vector2>()
        {
            new Vector2(0, -1),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(-1, 0)
        };
        Vector2 guardPos = new Vector2(0, 0);
        int currentDirection = 0;

        public void Launch()
        {
            string[] textSplitted = text.Split(Environment.NewLine);

            grid = CreateGrid(textSplitted);
            guardPos = GetInitialGuardPos();

            do
            {
                if (IsCaseExisting(guardPos + orderedDirections[currentDirection]))
                {
                    if (grid[guardPos + orderedDirections[currentDirection]].isObstacle)
                    {
                        currentDirection = (currentDirection + 1) % (orderedDirections.Count);
                    }
                    else
                    {
                        grid[guardPos].value = '.';
                        guardPos += orderedDirections[currentDirection];
                        grid[guardPos].value = '^';
                        grid[guardPos].isGuardPath = true;
                    }
                }
            }
            while (IsCaseExisting(guardPos + orderedDirections[currentDirection]));

            Console.WriteLine(GetPathCaseAmount());
        }

        private int GetPathCaseAmount() => grid.Values.Where(c => c.isGuardPath).Count();
        private Case GetCase(Vector2 position) => grid[position];
        private bool IsCaseExisting(Vector2 position) => grid.ContainsKey(position);
        private bool IsCaseExisting(Case c) => grid.ContainsValue(c);

        private Dictionary<Vector2, Case> CreateGrid(string[] textSplitted)
        {
            Dictionary<Vector2, Case> dico = new Dictionary<Vector2, Case>();
            for (int i = 0; i < textSplitted.Length; i++)
            {
                for (int y = 0; y < textSplitted[i].Length; y++)
                {
                    char c = textSplitted[i][y];
                    bool isGuardPath = c == '^';
                    bool isObstacle = c == '#';
                    Vector2 pos = new Vector2(y, i);
                    Case ca = new Case(isGuardPath, isObstacle, c);

                    dico.Add(pos, ca);
                }
            }

            return dico;
        }

        private Vector2 GetInitialGuardPos()
        {
            foreach (KeyValuePair<Vector2, Case> kvp in grid)
            {
                if (kvp.Value.value == '^')
                {
                    return kvp.Key;
                }
            }
            return new Vector2(-1, -1);
        }
    }

    public class Case
    {
        public bool isGuardPath = false;
        public bool isObstacle = false;
        public char value = ' ';

        public Case(bool isGuardPath, bool isObstacle, char value)
        {
            this.isGuardPath = isGuardPath;
            this.isObstacle = isObstacle;
            this.value = value;
        }
    }
}