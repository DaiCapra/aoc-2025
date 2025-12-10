using aoc_2025.Task5;

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
        var inventory = Parser.Parse("input.txt");
        var sum = Solver.RangeSum(inventory.ranges);
        Console.WriteLine(sum);
    }
}