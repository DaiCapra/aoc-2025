using aoc_2025.Task2;

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
        var ranges = Parser.Parse("input.txt");
        var count = Solver.Sum(ranges, true);
        Console.WriteLine(count);
    }
}