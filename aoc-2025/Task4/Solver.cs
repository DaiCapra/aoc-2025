using aoc_2025.Common;

namespace aoc_2025.Task4;

public static class Solver
{
    private const int MaxAdjacent = 4;
    private static readonly Vector2Int[] Directions;

    static Solver()
    {
        Directions =
        [
            Vector2Int.Up,
            Vector2Int.Right,
            Vector2Int.Down,
            Vector2Int.Left,
            Vector2Int.Up + Vector2Int.Left,
            Vector2Int.Up + Vector2Int.Right,
            Vector2Int.Down + Vector2Int.Left,
            Vector2Int.Down + Vector2Int.Right
        ];
    }

    public static int GetPaperRollCount(Cell[,] grid, bool remove = false)
    {
        int count = 0;

        while (true)
        {
            var toRemove = new List<Vector2Int>();

            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    var position = new Vector2Int(x, y);
                    var type = GetType(grid, position);
                    if (type is not Type.Roll)
                    {
                        continue;
                    }

                    int rolls = Directions.Select(direction => position + direction)
                        .Where(offset => IsInsideBounds(grid, offset))
                        .Count(offset => GetType(grid, offset) is Type.Roll);

                    if (rolls < MaxAdjacent)
                    {
                        count++;
                        toRemove.Add(position);
                    }
                }
            }

            if (!remove)
            {
                break;
            }

            foreach (var position in toRemove)
            {
                grid[position.x, position.y].type = Type.None;
            }

            if (toRemove.IsEmpty())
            {
                break;
            }
        }

        return count;
    }

    private static Type GetType(Cell[,] grid, Vector2Int position)
    {
        return grid[position.x, position.y].type;
    }

    private static bool IsInsideBounds(Cell[,] grid, Vector2Int position)
    {
        var width = grid.GetLength(0);
        var height = grid.GetLength(1);

        return position.x >= 0 && position.x < width && position.y >= 0 && position.y < height;
    }
}