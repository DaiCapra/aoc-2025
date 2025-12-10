using Range = aoc_2025.Common.Range;

namespace aoc_2025.Task5;

public class Inventory
{
    public List<Range> ranges = new();
    public List<ulong> ids = new();
}

public static class Parser
{
    public static Inventory Parse(string filepath)
    {
        var inventory = new Inventory();

        var text = File.ReadAllLines(filepath).ToList();
        var separatorIndex = text.IndexOf(string.Empty);

        var ranges = text[0..separatorIndex];
        var ids = text[(separatorIndex + 1)..];

        inventory.ranges = ranges.Select(line =>
        {
            var tokens = line.Split('-');
            return new Range(ulong.Parse(tokens[0]), ulong.Parse(tokens[1]));
        }).ToList();

        inventory.ids = ids
            .Select(ulong.Parse)
            .ToList();

        return inventory;
    }
}