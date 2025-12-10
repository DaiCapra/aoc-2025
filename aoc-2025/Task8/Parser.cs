using aoc_2025.Common;

namespace aoc_2025.Task8;

public static class Parser
{
    public static List<Junction> Parse(string filepath)
    {
        var list = new List<Junction>();

        var lines = File.ReadAllLines(filepath);

        foreach (var line in lines)
        {
            var tokens = line.Split(',');
            var x = int.Parse(tokens[0]);
            var y = int.Parse(tokens[1]);
            var z = int.Parse(tokens[2]);

            var v = new Vector3Int(x, y, z);
            var junction = new Junction(v);
            list.Add(junction);
        }

        return list;
    }
}