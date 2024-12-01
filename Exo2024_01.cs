Console.WriteLine("hello");

namespace AoC2024_Exo01
{
    public class Program
    {
        public static void Main()
        {
            string text = Utils.ReadFile("E:\\Projets\\AdventOfCode\\AoC2024\\Exo2024_01.txt");
            string[] textSplitted = text.Split(Environment.NewLine);
        }
    }
}
