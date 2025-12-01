using aoc_2025.Task1;

namespace aoc_2025_tests.Task1;

public class Tests
{
    [Test]
    public void Example()
    {
        var instructions = new Parser().Parse("Task1/input.txt");

        var password = new Password();
        password.Apply(instructions);

        Assert.That(password.count, Is.EqualTo(3));
    }
}