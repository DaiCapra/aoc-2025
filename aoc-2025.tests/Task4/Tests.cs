using aoc_2025.Task4;

namespace aoc_2025_tests.Task4;

public class Tests
{
    [Test]
    public void Example1()
    {
        var grid = Parser.Parse("Task4/test-input.txt");
        Assert.That(Solver.GetPaperRollCount(grid), Is.EqualTo(13));
    }

    [Test]
    public void Example2()
    {
        var grid = Parser.Parse("Task4/test-input.txt");
        Assert.That(Solver.GetPaperRollCount(grid, remove: true), Is.EqualTo(43));
    }
}