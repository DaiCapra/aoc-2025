using aoc_2025.Task5;

namespace aoc_2025_tests.Task5;

public class Tests
{
    [Test]
    public void Example1()
    {
        var inventory = Parser.Parse("Task5/test-input.txt");
        Assert.That(Solver.Sum(inventory), Is.EqualTo(3));
    }

    [Test]
    public void Example2()
    {
        var inventory = Parser.Parse("Task5/test-input.txt");
        var sum =  Solver.RangeSum(inventory.ranges);
        Assert.That(sum, Is.EqualTo(14));
    }
}