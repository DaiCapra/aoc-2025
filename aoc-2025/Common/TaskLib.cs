namespace aoc_2025.Common;

public static class TaskLib
{
    public static async Task<T2[]> WhenAll<T1, T2>(this List<T1> list, Func<T1, T2> action)
    {
        var tasks = list
            .Select(element => Task.Run(() => action.Invoke(element)))
            .ToList();

        return await Task.WhenAll(tasks);
    }
}