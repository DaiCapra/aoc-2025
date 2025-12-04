namespace aoc_2025.Common;

public struct Vector2Int(int x, int y)
{
    public int x = x;
    public int y = y;

    public static Vector2Int Up => new(0, 1);
    public static Vector2Int Right => new(1, 0);
    public static Vector2Int Down => new(0, -1);
    public static Vector2Int Left => new(-1, 0);

    public static Vector2Int operator +(Vector2Int a, Vector2Int b)
    {
        return new(a.x + b.x, a.y + b.y);
    }

    public override string ToString()
    {
        return $"[{x}, {y}]";
    }
}