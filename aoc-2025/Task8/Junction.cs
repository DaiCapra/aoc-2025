using aoc_2025.Common;

namespace aoc_2025.Task8;

public class Edge
{
    public Junction first = null!;
    public Junction second = null!;
    public long distance;

    public override string ToString()
    {
        return $"{first.position} <-> {second.position} | {distance}";
    }
}

public class Junction(Vector3Int position)
{
    public Vector3Int position = position;
    public long circuitId = 0;
    public bool HasCircuit => circuitId > 0;

    public override string ToString()
    {
        return $"{position} | {circuitId}";
    }
}