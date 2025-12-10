using System.Text;
using aoc_2025.Common;

namespace aoc_2025.Task7;

public class Result
{
    public long count;
    public long timelines;
}

public static class Solver
{
    public static Result Split(Grid grid)
    {
        var result = new Result();

        var visited = new Dictionary<Vector2Int, long>();

        for (int y = grid.Height - 1; y >= 1; y--)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                var position = new Vector2Int(x, y);
                var below = position + Vector2Int.Down;

                var visits = visited.GetValueOrDefault(position);

                var cell = grid.Get(position);
                var type = cell.type;
                if (type is Type.Start)
                {
                    visited[below] = 1;
                }

                if (type is Type.None && visits > 0)
                {
                    var typeBelow = grid.Get(below).type;
                    if (typeBelow is Type.None)
                    {
                        Visit(visited, below, visits);
                    }
                    else
                    {
                        Visit(visited, below + Vector2Int.Left, visits);
                        Visit(visited, below + Vector2Int.Right, visits);
                        result.count++;
                    }
                }
            }
        }

        for (int x = 0; x < grid.Width; x++)
        {
            var pos = new Vector2Int(x, 0);
            if (visited.TryGetValue(pos, out var v))
            {
                result.timelines += v;
            }
        }

        return result;
    }


    private static void Visit(Dictionary<Vector2Int, long> visited, Vector2Int position, long numberOfVisits)
    {
        visited[position] = visited.GetValueOrDefault(position) + numberOfVisits;
    }
}