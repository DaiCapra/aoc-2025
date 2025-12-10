using System.Diagnostics;
using aoc_2025.Task8;

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
        var junctions = Parser.Parse("input.txt");
        // var junctions = Parser.Parse("input-test.txt");

        var sw = new Stopwatch();
        sw.Start();

        var result = Solver.Solve(junctions, iterations: int.MaxValue);
        Console.WriteLine(result.extension);

        sw.Stop();

        Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");
        Console.WriteLine();
    }
}