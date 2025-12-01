namespace aoc_2025.Task1;

public class Parser
{
    public List<Instruction> Parse(string filepath)
    {
        var lines = File.ReadAllLines(filepath);
        return Parse(lines);
    }

    private List<Instruction> Parse(IEnumerable<string> text)
    {
        var list = new List<Instruction>();

        foreach (var item in text)
        {
            var dir = item[0] == 'R' ? 1 : -1;
            var steps = int.Parse(item[1..]);

            var instruction = new Instruction
            {
                text = item,
                steps = steps * dir
            };

            list.Add(instruction);
        }

        return list;
    }
}