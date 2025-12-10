using aoc_2025.Task8;
namespace aoc_2025_tests.Task8;

public class Tests
{
    [Test]
    public void Example1()
    {
    	var junctions = Parser.Parse("Task8/test-input.txt");
	    var sum = Solver.Solve(junctions);
	    Assert.That(sum, Is.EqualTo(40));
    }

    [Test]
    public void Example2()
    {
	    var junctions = Parser.Parse("Task8/test-input.txt");
	    var sum = Solver.Solve(junctions, iterations:10000);
    }
}
