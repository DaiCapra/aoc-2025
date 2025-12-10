using aoc_2025.Task6;

namespace aoc_2025_tests.Task6;

public class Tests
{
    [Test]
    public void Example1()
    {
        var columns = Parser.Parse("Task6/test-input.txt");
        var sum = Solver.Sum(columns);
        Assert.That(sum, Is.EqualTo(4277556));
    }

    [Test]
    public void Example2()
    {
        var columns = Parser.CephalopodParse("Task6/test-input.txt");
        var sum = Solver.CephalopodSum(columns);
        Assert.That(sum, Is.EqualTo(3263827));
    }
}