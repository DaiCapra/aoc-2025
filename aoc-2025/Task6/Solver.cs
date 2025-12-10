namespace aoc_2025.Task6;

public static class Solver
{
    public static long Sum(List<Column> columns)
    {
        long total = 0;

        foreach (var column in columns)
        {
            var sum = Sum(column);
            total += sum;
        }

        return total;
    }

    private static long Sum(Column column)
    {
        var terms = column.terms
            .Select(t => t.Trim())
            .Select(int.Parse)
            .ToArray();

        if (column.@operator == "*")
        {
            return terms.Aggregate(1L, (a, b) => a * b);
        }

        if (column.@operator == "+")
        {
            return terms.Sum();
        }

        return 0;
    }

    public static long CephalopodSum(List<Column> columns)
    {
        long total = 0;

        foreach (var column in columns)
        {
            total += Sum(column);
        }

        return total;
    }
}