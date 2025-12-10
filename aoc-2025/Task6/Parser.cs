using System.ComponentModel;
using aoc_2025.Common;

namespace aoc_2025.Task6;

public static class Parser
{
    public static List<Column> CephalopodParse(string filepath)
    {
        var columns = Parse(filepath);

        var list = new List<Column>();
        foreach (var column in columns)
        {
            var cephalopodColumn = new Column { @operator = column.@operator };
            list.Add(cephalopodColumn);

            var term = "";
            for (int i = 0; i < column.terms[0].Length; i++)
            {
                for (int j = 0; j < column.terms.Count; j++)
                {
                    term += column.terms[j][i];
                }

                cephalopodColumn.terms.Add(term);
                term = "";
            }
        }

        list.Reverse();
        return list;
    }

    public static List<Column> Parse(string filepath)
    {
        var rows = File.ReadAllLines(filepath).ToList();
        var operators = rows[^1].Split(null as char[], StringSplitOptions.RemoveEmptyEntries);
        rows.RemoveAt(rows.Count - 1);


        var columns = new Column[operators.Length];
        for (int i = 0; i < columns.Length; i++)
        {
            columns[i] = new()
            {
                @operator = operators[i]
            };
        }

        int index = 0;
        var numbers = new string[rows.Count];

        var length = rows[0].Length;
        for (int i = 0; i < length; i++)
        {
            var tokens = new string[rows.Count];
            for (int j = 0; j < rows.Count; j++)
            {
                tokens[j] = rows[j][i].ToString();
            }

            if (tokens.All(string.IsNullOrWhiteSpace))
            {
                AddTerms();
                continue;
            }

            for (int j = 0; j < rows.Count; j++)
            {
                numbers[j] += tokens[j];
            }

            if (i == length - 1)
            {
                AddTerms();
            }
        }

        return columns.ToList();

        void AddTerms()
        {
            var c = columns[index++];
            for (int j = 0; j < rows.Count; j++)
            {
                c.terms.Add(numbers[j]);
                numbers[j] = "";
            }
        }
    }
}