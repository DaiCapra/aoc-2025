using aoc_2025.Task2;

namespace aoc_2025_tests.Task2;

public class Tests
{
    [Test]
    public void Example1()
    {
        var ranges = Parser.Parse("Task2/test-input.txt");
        var count = Solver.Sum(ranges);
        Assert.That(count, Is.EqualTo(1227775554));
    }

    [Test]
    public void Example2()
    {
        var ranges = Parser.Parse("Task2/test-input.txt");
        var count = Solver.Sum(ranges, false);
        Assert.That(count, Is.EqualTo(4174379265));
    }


    [Test]
    public void Part1Invalids()
    {
        Assert.That(Solver.IsValid(11), Is.False);
        Assert.That(Solver.IsValid(22), Is.False);
        Assert.That(Solver.IsValid(99), Is.False);
        Assert.That(Solver.IsValid(1010), Is.False);
        Assert.That(Solver.IsValid(1188511885), Is.False);
        Assert.That(Solver.IsValid(222222), Is.False);
        Assert.That(Solver.IsValid(446446), Is.False);
        Assert.That(Solver.IsValid(38593859), Is.False);
    }

    [Test]
    public void Part2Invalids()
    {
        Assert.That(Solver.IsValid(11, false), Is.False);
        Assert.That(Solver.IsValid(22, false), Is.False);
        Assert.That(Solver.IsValid(111, false), Is.False);
        Assert.That(Solver.IsValid(999, false), Is.False);
        Assert.That(Solver.IsValid(824824824, false), Is.False);
    }

    [Test]
    public void Part1Valids()
    {
        Assert.That(Solver.IsValid(824824821), Is.True);
        Assert.That(Solver.IsValid(824824827), Is.True);
        Assert.That(Solver.IsValid(2121212118), Is.True);
        Assert.That(Solver.IsValid(2121212124), Is.True);
    }
}