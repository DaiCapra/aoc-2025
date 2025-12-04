namespace aoc_2025.Task4;

public static class Parser
{
    public static Cell[,] Parse(string filepath)
    {
        var text = File.ReadAllLines(filepath)
            .Select(x => x.Trim())
            .Where(t => !string.IsNullOrWhiteSpace(t))
            .ToList();

        var width = text[0].Length;
        var height = text.Count;

        var grid = new Cell[width, height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var cell = new Cell();
                cell.type = text[y][x] switch
                {
                    '.' => Type.None,
                    '@' => Type.Roll,
                    _ => cell.type
                };

                grid[x, y] = cell;
            }
        }

        return grid;
    }
}