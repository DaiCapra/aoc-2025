using aoc_2025.Common;

namespace aoc_2025.Task3;

public static class Solver
{
    public static long GetJoltage(string bank, int numberOfDigits = 2)
    {
        var digits = bank
            .Select(c => int.Parse(c.ToString()))
            .ToList();

        var result = new List<int>();
        while (!digits.IsEmpty())
        {
            var remaining = digits.Count;
            var current = digits.Pop(0);

            var index = Math.Min(result.Count, numberOfDigits - remaining);
            var start = Math.Max(index, 0);

            for (int i = start; i < result.Count; i++)
            {
                if (current > result[i])
                {
                    result.RemoveRange(i, result.Count - i);
                    break;
                }
            }

            if (result.Count < numberOfDigits)
            {
                result.Add(current);
            }
        }

        return ParseJoltage(result);
    }

    private static long ParseJoltage(List<int> result)
    {
        var v = string.Join("", result);
        if (long.TryParse(v, out var joltage))
        {
            return joltage;
        }

        return 0;
    }
}