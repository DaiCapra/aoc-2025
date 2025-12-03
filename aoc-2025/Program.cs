using System.Diagnostics;
using aoc_2025.Task3;

namespace aoc_2025;

public class Program
{
    public static void Main()
    {
        var program = new Program();
        program.Run();
    }

    private void Run()
    {
        var joltages = Parser.Parse("input.txt");
        var i = joltages.Sum(t => Solver.GetJoltage(t, numberOfDigits: 12));
        Console.WriteLine(i);
    }
}