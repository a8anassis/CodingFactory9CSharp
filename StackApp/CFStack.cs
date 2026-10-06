namespace StackApp;

internal class CFStack
{
    private const int DefaultCapacity = 100;
    private readonly int[] _items;
    private int _top = -1;

    public CFStack() : this(DefaultCapacity) { }

    public CFStack(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be positive.");
        _items = new int[capacity];
    }

    // Expression-bodied properties for getters for Count, Capacity, IsEmpty, and IsFull
    public int Count => _top + 1;
    public int Capacity => _items.Length;
    public bool IsEmpty => _top == -1;
    public bool IsFull => _top == _items.Length - 1;

    public void Push(int num)
    {
        if (IsFull)
            throw new StackIsFullException("Stack Full");

        _items[++_top] = num;
    }

    public int Pop()
    {
        if (IsEmpty)
            throw new StackIsEmptyException("Stack Empty");

        return _items[_top--];
    }

    public int GetItemAt(int index)
    {
        if (index < 0 || index > _top)
            throw new ArgumentOutOfRangeException("Index is out of range.");
        return _items[index];
    }
}
