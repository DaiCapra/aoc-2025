namespace aoc_2025.Task1;

public class Password(int initial = 50)
{
    private const int Modulo = 100;
    public int passedZeroCount;
    public int position = initial;
    public int stoppedAtZeroCount;
    public int TotalCount => stoppedAtZeroCount + passedZeroCount;

    public void Apply(List<int> instructions)
    {
        foreach (var instruction in instructions)
        {
            Rotate(instruction);
        }
    }

    public void Rotate(int steps)
    {
        var count = Math.Abs(steps);
        var direction = Math.Sign(steps);

        for (int i = 0; i < count; i++)
        {
            position += direction;
            WrapPosition();

            if (position is 0 or Modulo)
            {
                bool isLastStep = i == count - 1;
                if (isLastStep)
                {
                    stoppedAtZeroCount++;
                }
                else
                {
                    passedZeroCount++;
                }
            }
        }
    }

    private void WrapPosition()
    {
        position = position switch
        {
            >= Modulo => 0,
            < 0 => Modulo - 1,
            _ => position
        };
    }
}