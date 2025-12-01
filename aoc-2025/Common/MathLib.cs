namespace aoc_2025.Common;

public static class MathLib
{
    // https://stackoverflow.com/a/1082938
    public static int Mod(int x, int m)
    {
        int r = x % m;
        return r < 0 ? r + m : r;
    }
}