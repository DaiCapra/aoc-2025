namespace aoc_2025.Common;

public struct Vector3Int(int x, int y, int z)
{
    public int x = x;
    public int y = y;
    public int z = z;

    public long DistanceSquared(Vector3Int other)
    {
        long dx = other.x - x;
        long dy = other.y - y;
        long dz = other.z - z;
        return dx * dx + dy * dy + dz * dz;
    }

    public override string ToString()
    {
        return $"({x}, {y}, {z})";
    }
}