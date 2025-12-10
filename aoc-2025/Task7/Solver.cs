using aoc_2025.Common;

namespace aoc_2025.Task7;

public class BeamNode(Vector2Int position) : Node<BeamNode>
{
    public Vector2Int position = position;
}

public static class Solver
{
    public static int Split(Grid grid, bool ignoreVisited = true)
    {
        int count = ignoreVisited ? 0 : 1;
        var beams = new List<Vector2Int>();
        AddBeam(grid, beams, grid.start + Vector2Int.Down, ignoreVisited);

        while (!beams.IsEmpty())
        {
            var beam = beams.Pop(0);
            Console.Write($"Beams: {beams.Count}, Y: {beam.y}\r");
            var next = beam + Vector2Int.Down;
            if (next.y <= 0)
            {
                continue;
            }

            var cell = grid.cells[next.x, next.y];
            if (cell.type is Type.Splitter)
            {
                AddBeam(grid, beams, next + Vector2Int.Left, ignoreVisited);
                AddBeam(grid, beams, next + Vector2Int.Right, ignoreVisited);
                count++;
            }
            else if (cell.type is Type.None)
            {
                AddBeam(grid, beams, next, ignoreVisited);
            }

            
        }

        return count;
    }
    
    private static void AddBeam(Grid grid, List<Vector2Int> beams, Vector2Int position, bool ignoreVisited = true)
    {
        var cell = grid.cells[position.x, position.y];

        if (ignoreVisited)
        {
            if (cell.type is Type.Beam)
            {
                return;
            }

            grid.cells[position.x, position.y].type = Type.Beam;
        }


        beams.Add(position);
    }

    public static void Print(Grid grid)
    {
        for (int y = grid.Height - 1; y >= 0; y--)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                var cell = grid.cells[x, y];
                char c = cell.type switch
                {
                    Type.None => '.',
                    Type.Start => 'S',
                    Type.Splitter => '^',
                    Type.Beam => '|',
                    _ => '?'
                };
                Console.Write(c);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}