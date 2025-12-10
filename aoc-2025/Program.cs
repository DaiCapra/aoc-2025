using aoc_2025.Task7;

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
        var count = Solver.Split(grid, ignoreVisited: false);
        Console.WriteLine(count);
    }
}