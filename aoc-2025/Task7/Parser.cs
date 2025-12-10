using aoc_2025.Common;

namespace aoc_2025.Task7;

public static class Parser
{
    public static Grid Parse(string filepath)
    {
        var lines = File.ReadAllLines(filepath)
            .Select(x => x.Trim())
            .Where(t => !string.IsNullOrWhiteSpace(t))
            .ToList();
        lines.Reverse();

        var grid = new Grid();

        var width = lines[0].Length;
        var height = lines.Count;

        grid.cells = new Cell[width, height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var cell = new Cell();
                cell.type = lines[y][x] switch
                {
                    '.' => Type.None,
                    'S' => Type.Start,
                    '^' => Type.Splitter,
                    _ => cell.type
                };

                grid.cells[x, y] = cell;
                if (cell.type is Type.Start)
                {
                    grid.start = new(x, y);
                }
            }
        }

        return grid;
    }
}