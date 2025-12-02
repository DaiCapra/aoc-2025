using aoc_2025.Common;

namespace aoc_2025.Task1;

public class Password(int initial = 50)
{
    public int position = initial;
    public int stoppedAtZeroCount;
    public int passedZeroCount;
    public int TotalCount => stoppedAtZeroCount + passedZeroCount;

    private const int Modulo = 100;

    public void Apply(List<Instruction> instructions)
    {
        foreach (var instruction in instructions)
        {
            Rotate(instruction.steps);
        }
    }

    public void Rotate(int steps)
    {
        var a = position + steps;
        bool didPassZero = a is < 0 or >= Modulo;

        position = MathLib.Mod(a, Modulo);
    }
}