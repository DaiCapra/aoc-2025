using aoc_2025.Common;

namespace aoc_2025.Task7;

public class Grid
{
    public Cell[,] cells = new Cell[0, 0];
    public Vector2Int start;
    public int Width => cells.GetLength(0);
    public int Height => cells.GetLength(1);
}