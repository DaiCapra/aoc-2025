namespace aoc_2025.Task8;

public class Circuit
{
    public readonly List<Junction> junctions = new();
    public long id;

    public void Add(Junction junction)
    {
        if (junctions.Contains(junction))
        {
            return;
        }

        junction.circuitId = id;
        junctions.Add(junction);
    }

    public void Remove(Junction junction)
    {
        junction.circuitId = 0;
        junctions.Remove(junction);
    }

    public int Size()
    {
        return junctions.Count;
    }

    public override string ToString()
    {
        return $"Id: {id}, Count: {junctions.Count}";
    }
}