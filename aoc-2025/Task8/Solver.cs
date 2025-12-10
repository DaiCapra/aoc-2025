using aoc_2025.Common;

namespace aoc_2025.Task8;

public static class Solver
{
    private static void Merge(Circuit c1, Circuit c2)
    {
        foreach (var junction in c2.junctions)
        {
            c1.Add(junction);
        }

        c2.junctions.Clear();
    }

    public static long Solve(List<Junction> junctions, int iterations = 10)
    {
        var edges = GetCombinations(junctions);
        var sortedEdges = edges
            .OrderBy(e => e.distance)
            .ToList();

        var map = new Dictionary<long, Circuit>();
        long identity = 0;
        for (int i = 0; i < iterations; i++)
        {
            if (sortedEdges.IsEmpty())
            {
                break;
            }

            var edge = sortedEdges.Pop(0);
            Console.WriteLine($"{i + 1}: {edge}");

            var j1 = edge.first;
            var j2 = edge.second;
            var isSameCircuit = j1.HasCircuit && j1.circuitId == j2.circuitId;
            if (isSameCircuit)
            {
                continue;
            }
            
            var id = GetBestId(j1.circuitId, j2.circuitId, ref identity);
            if (!map.TryGetValue(id, out var circuit))
            {
                circuit = new() { id = id };
                map[id] = circuit;
            }

            if (!j1.HasCircuit)
            {
                circuit.Add(j1);
            }

            if (!j2.HasCircuit)
            {
                circuit.Add(j2);
            }

            if (j1.circuitId != j2.circuitId)
            {
                FindLargestCircuit(map, j1, j2, out Circuit min, out Circuit max);
                Merge(max, min);
                map.Remove(min.id);
            }
        }

        var circuits = map.Values
            .OrderByDescending(t => t.junctions.Count)
            .ToList();

        var largest = circuits.Take(3);
        var total = largest
            .Select(c => c.junctions.Count)
            .Aggregate(1L, (a, b) => a * b);

        return total;
    }

    private static void FindLargestCircuit(
        Dictionary<long, Circuit> map,
        Junction j1,
        Junction j2,
        out Circuit min,
        out Circuit max
    )
    {
        var c1 = map[j1.circuitId];
        var c2 = map[j2.circuitId];
        if (c1.Size() >= c2.Size())
        {
            max = c1;
            min = c2;
        }
        else
        {
            max = c2;
            min = c1;
        }
    }


    private static long GetBestId(long j1, long j2, ref long circuitIdentity)
    {
        if (j1 != 0 && j2 != 0)
        {
            return Math.Min(j1, j2);
        }

        if (j1 == 0 && j2 == 0)
        {
            return ++circuitIdentity;
        }

        return Math.Max(j1, j2);
    }

    private static List<Edge> GetCombinations(List<Junction> junctions)
    {
        var edges = new List<Edge>();

        for (int i = 0; i < junctions.Count; i++)
        {
            var j1 = junctions[i];

            // Avoid duplicates.
            for (int j = i + 1; j < junctions.Count; j++)
            {
                var j2 = junctions[j];
                var distance = j1.position.DistanceSquared(j2.position);
                edges.Add(new() { first = j1, second = j2, distance = distance });
            }
        }

        return edges;
    }
}