namespace aoc_2025.Task2;

public static class Solver
{
    public static bool IsValid(ulong value, bool onlyConsiderTwoBuckets = true)
    {
        var digits = value.ToString();
        int numberOfDigits = digits.Length;

        var visited = new HashSet<int>();
        for (int i = 1; i <= numberOfDigits; i++)
        {
            if (onlyConsiderTwoBuckets && i != 2)
            {
                continue;
            }

            var bucketSize = (int)Math.Ceiling((double)numberOfDigits / i);
            if (!visited.Add(bucketSize))
            {
                // Don't re-check the same bucket size
                continue;
            }

            var buckets = digits.Chunk(bucketSize)
                .Select(chunk => new string(chunk))
                .ToArray();

            if (buckets.Length < 2)
            {
                continue;
            }

            var uniform = buckets.All(t => t == buckets[0]);
            if (uniform)
            {
                return false;
            }
        }

        return true;
    }


    public static ulong Sum(List<Range> ranges, bool onlyConsiderTwoBuckets = true)
    {
        ulong count = 0;

        foreach (var range in ranges)
        {
            var set = FindInvalidIds(range, onlyConsiderTwoBuckets);
            foreach (var invalid in set)
            {
                count += invalid;
            }
        }

        return count;
    }

    private static HashSet<ulong> FindInvalidIds(Range range, bool onlyConsiderTwoBuckets = true)
    {
        var set = new HashSet<ulong>();

        for (ulong i = range.min; i <= range.max; i++)
        {
            if (!IsValid(i, onlyConsiderTwoBuckets))
            {
                set.Add(i);
            }
        }

        return set;
    }
}