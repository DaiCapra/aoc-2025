using aoc_2025.Common;

namespace aoc_2025.Task1;

public class Password(int initial = 50)
{
    public int position = initial;
    public int count;

    private const int Modulo = 100;

    public void Apply(List<Instruction> instructions)
    {
        foreach (var instruction in instructions)
        {
            position = MathLib.Mod(position + instruction.steps, Modulo);
            if (position == 0)
            {
                count++;
            }
        }
    }
}