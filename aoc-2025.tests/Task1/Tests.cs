using aoc_2025.Task1;

namespace aoc_2025_tests.Task1;

public class Tests
{
    [Test]
    public void Example()
    {
        var instructions = Parser.Parse("Task1/test-input.txt");

        var password = new Password();
        password.Apply(instructions);

        Assert.That(password.stoppedAtZeroCount, Is.EqualTo(3));
        Assert.That(password.passedZeroCount, Is.EqualTo(3));
    }

    [Test]
    public void OneRevolutionAndPartial()
    {
        var password = new Password();
        password.Rotate(175);

        Assert.That(password.position, Is.EqualTo(25));
        Assert.That(password.passedZeroCount, Is.EqualTo(2));
        Assert.That(password.stoppedAtZeroCount, Is.EqualTo(0));
    }

    [Test]
    public void PartialPass()
    {
        var password = new Password();
        password.Rotate(75);

        Assert.That(password.position, Is.EqualTo(25));
        Assert.That(password.passedZeroCount, Is.EqualTo(1));
        Assert.That(password.stoppedAtZeroCount, Is.EqualTo(0));
    }

    [Test]
    public void R1000()
    {
        var password = new Password();
        password.Rotate(1000);

        Assert.That(password.passedZeroCount, Is.EqualTo(10));
        Assert.That(password.stoppedAtZeroCount, Is.EqualTo(0));
    }

    [Test]
    public void StartAndStopAtZero()
    {
        var password = new Password(0);
        password.Rotate(100);

        Assert.That(password.passedZeroCount, Is.EqualTo(0));
        Assert.That(password.stoppedAtZeroCount, Is.EqualTo(1));

        password = new Password(0);
        password.Rotate(1000);

        Assert.That(password.passedZeroCount, Is.EqualTo(9));
        Assert.That(password.stoppedAtZeroCount, Is.EqualTo(1));
    }

    [Test]
    public void StopAtZeroAndLeave()
    {
        var password = new Password();
        password.Rotate(50);
        password.Rotate(-50);

        Assert.That(password.TotalCount, Is.EqualTo(1));
    }

    [Test]
    public void Test()
    {
        var password = new Password();
        password.Rotate(-75);
        Assert.That(password.passedZeroCount, Is.EqualTo(1));
        Assert.That(password.stoppedAtZeroCount, Is.EqualTo(0));
        
        password = new(0);
        password.Rotate(275);
        Assert.That(password.passedZeroCount, Is.EqualTo(2));
        Assert.That(password.stoppedAtZeroCount, Is.EqualTo(0));
        
        
        password = new(0);
        password.Rotate(275);
        Assert.That(password.passedZeroCount, Is.EqualTo(2));
        Assert.That(password.stoppedAtZeroCount, Is.EqualTo(0));
        
        password = new(25);
        password.Rotate(75);
        Assert.That(password.passedZeroCount, Is.EqualTo(0));
        Assert.That(password.stoppedAtZeroCount, Is.EqualTo(1));
        
        password = new(95);
        password.Rotate(10);
        Assert.That(password.passedZeroCount, Is.EqualTo(1));
        Assert.That(password.stoppedAtZeroCount, Is.EqualTo(0));
    }
}