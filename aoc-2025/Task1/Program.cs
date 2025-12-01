namespace aoc_2025.Task1;

public class Program
{
    public static void Main()
    {
        var program = new Program();
        program.Run();
    }

    private void Run()
    {
        var instructions = new Parser().Parse("Task1/input.txt");

        var password = new Password();
        password.Apply(instructions);

        Console.WriteLine(password.count);
    }
}