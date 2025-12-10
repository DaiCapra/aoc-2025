namespace aoc_2025.Common;

public interface INode<T> where T : Node<T>
{
    T? Parent { get; set; }
    List<T> Children { get; set; }
}

public abstract class Node<T> : INode<T> where T : Node<T>
{
    public T? Parent { get; set; }
    public List<T> Children { get; set; } = new();

    public void AddChild(T node)
    {
        node.Parent = (T)this;
        Children.Add(node);
    }

    public void InsertChild(int index, T node)
    {
        node.Parent = (T)this;
        Children.Insert(index, node);
    }
}