using aoc_2025.Task4;

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
        var grid = Parser.Parse("input.txt");
        var count = Solver.GetPaperRollCount(grid, remove: true);

        Console.WriteLine($"Rolls: {count}");
    }
}