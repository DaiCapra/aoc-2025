namespace aoc_2025.Task2;

public static class Solver
{
    public static bool IsValid(ulong value, bool onlyConsiderTwo = true)
    {
        var digits = value.ToString();
        int numberOfDigits = digits.Length;

        bool isEven = numberOfDigits % 2 == 0;
        if (!isEven)
        {
            return true;
        }

        var bucketSize = numberOfDigits / 2;
        var buckets = digits.Chunk(bucketSize)
            .Select(chunk => new string(chunk))
            .ToArray();

        if (onlyConsiderTwo && buckets[0] == buckets[1])
        {
            // Part 1 
            return false;
        }

        return true;
    }

    public static ulong Sum(List<Range> ranges)
    {
        ulong count = 0;

        foreach (var range in ranges)
        {
            var set = Solver.FindInvalidIds(range);
            foreach (var invalid in set)
            {
                count += invalid;
            }
        }

        return count;
    }

    public static HashSet<ulong> FindInvalidIds(Range range)
    {
        var set = new HashSet<ulong>();

        for (ulong i = range.min; i <= range.max; i++)
        {
            if (!IsValid(i))
            {
                set.Add(i);
            }
        }

        return set;
    }
}