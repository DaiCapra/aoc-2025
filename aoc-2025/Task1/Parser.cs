namespace aoc_2025.Task1;

public static class Parser
{
    public static List<int> Parse(string filepath)
    {
        var lines = File.ReadAllLines(filepath);
        return Parse(lines);
    }

    private static List<int> Parse(IEnumerable<string> text)
    {
        var list = new List<int>();

        foreach (var item in text)
        {
            var dir = item[0] == 'R' ? 1 : -1;
            var steps = int.Parse(item[1..]);

            list.Add(steps * dir);
        }

        return list;
    }
}