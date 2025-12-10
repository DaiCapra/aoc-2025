namespace aoc_2025.Task6;

public class Group
{
    public readonly List<Column> columns = new();
}

public class Column
{
    public readonly List<string> terms = new();
    public string @operator = string.Empty;

    public override string ToString()
    {
        return $"{string.Join(", ", terms)} ({@operator})";
    }
}