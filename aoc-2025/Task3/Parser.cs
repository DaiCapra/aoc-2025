namespace aoc_2025.Task3;

public static class Parser
{
    public static List<string> Parse(string filepath)
    {
        var text = File.ReadAllLines(filepath);
        return text
            .Select(x => x.Trim())
            .ToList();
    }
}