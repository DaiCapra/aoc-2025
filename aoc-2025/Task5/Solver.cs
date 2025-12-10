using aoc_2025.Common;
using Range = aoc_2025.Common.Range;

namespace aoc_2025.Task5;

public static class Solver
{
    public static ulong RangeSum(List<Range> ranges)
    {
        var distinct = FindDistinct(ranges);

        return distinct.Aggregate<Range, ulong>(0, (current, range) => current + range.Size());
    }

    public static int Sum(Inventory inventory)
    {
        return inventory.ids.Count(id => inventory.ranges.Any(range => range.Contains(id)));
    }

    private static List<Range> FindDistinct(List<Range> ranges)
    {
        var list = new List<Range>();

        var stack = new List<Range>(ranges);
        while (!stack.IsEmpty())
        {
            var range = stack.Pop(0);

            bool didChange;
            do
            {
                didChange = false;
                var others = new List<Range>(stack);
                while (!others.IsEmpty())
                {
                    var other = others.Pop(0);
                    if (range.OverlapsWith(other))
                    {
                        range.Merge(other);
                        stack.Remove(other);
                        didChange = true;
                    }
                }
            } while (didChange);

            list.Add(range);
        }

        return list;
    }
}