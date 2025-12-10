using aoc_2025.Task7;

namespace aoc_2025_tests.Task7;

public class Tests
{
    [Test]
    public void Example1()
    {
        var grid = Parser.Parse("Task7/test-input.txt");
        var count = Solver.Split(grid, ignoreVisited: true);
        Assert.That(count, Is.EqualTo(21));
    }

    [Test]
    public void Example2()
    {
        var grid = Parser.Parse("Task7/test-input.txt");
        var count = Solver.Split(grid, ignoreVisited: false);
        Assert.That(count, Is.EqualTo(40));
    }
}