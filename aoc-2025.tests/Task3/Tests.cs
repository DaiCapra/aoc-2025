using aoc_2025.Task3;

namespace aoc_2025_tests.Task3;

public class Tests
{
    [Test]
    public void Example1()
    {
        var joltages = Parser.Parse("Task3/test-input.txt");
        Assert.That(joltages.Sum(t => Solver.GetJoltage(t)), Is.EqualTo(357));
    }

    [Test]
    public void Example2()
    {
        var joltages = Parser.Parse("Task3/test-input.txt");
        Assert.That(joltages.Sum(t => Solver.GetJoltage(t, numberOfDigits: 12)), Is.EqualTo(3121910778619));
    }

    [Test]
    public void Joltage1()
    {
        Assert.That(Solver.GetJoltage("987654321111111"), Is.EqualTo(98));
        Assert.That(Solver.GetJoltage("811111111111119"), Is.EqualTo(89));
        Assert.That(Solver.GetJoltage("234234234234278"), Is.EqualTo(78));
        Assert.That(Solver.GetJoltage("818181911112111"), Is.EqualTo(92));
    }

    [Test]
    public void Joltage2()
    {
        Assert.That(Solver.GetJoltage("987654321111111", numberOfDigits: 12), Is.EqualTo(987654321111));
        Assert.That(Solver.GetJoltage("811111111111119", numberOfDigits: 12), Is.EqualTo(811111111119));
        Assert.That(Solver.GetJoltage("234234234234278", numberOfDigits: 12), Is.EqualTo(434234234278));
        Assert.That(Solver.GetJoltage("818181911112111", numberOfDigits: 12), Is.EqualTo(888911112111));
    }
}