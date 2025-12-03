namespace aoc_2025.Common;

public static class ListExtensions
{
    public static bool IsEmpty<T>(this IList<T> list)
    {
        return list.Count == 0;
    }

    public static T Pop<T>(this IList<T> list, int index = -1)
    {
        if (index == -1)
        {
            index = list.Count - 1;
        }

        var item = list[index];
        list.RemoveAt(index);

        return item;
    }
}