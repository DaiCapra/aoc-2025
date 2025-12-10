namespace aoc_2025.Common;

public class Range(ulong min, ulong max)
{
    public ulong max = max;
    public ulong min = min;

    public bool Contains(ulong value)
    {
        return value >= min && value <= max;
    }

    public ulong Size()
    {
        return max - min + 1;
    }

    public bool OverlapsWith(Range other)
    {
        return min <= other.max && other.min <= max;
    }

    public void Merge(Range other)
    {
        min = Math.Min(min, other.min);
        max = Math.Max(max, other.max);
    }

    public override string ToString()
    {
        return $"[{min}, {max}]";
    }
}