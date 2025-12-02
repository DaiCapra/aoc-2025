namespace aoc_2025.Task2;

public static class Parser
{
    public static List<Range> Parse(string filepath)
    {
        var list = new List<Range>();

        var text = File.ReadAllText(filepath);

        var ids = text
            .Split(",")
            .Select(x => x.Trim())
            .ToList();

        foreach (var id in ids)
        {
            var range = CreateRange(id);
            list.Add(range);
        }

        return list;
    }

    public static Range CreateRange(string range)
    {
        var tokens = range.Split('-');
        var min = ulong.Parse(tokens[0]);
        var max = ulong.Parse(tokens[1]);

        return new(min, max);
    }
}