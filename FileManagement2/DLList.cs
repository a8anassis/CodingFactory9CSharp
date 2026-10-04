namespace FileManagement2;

internal class DLList<T>
{
    private readonly LinkedList<ListNode<T>> _list = new();

    public bool IsEmpty => _list.Count == 0;

    public void InsertFirst(T t) => _list.AddFirst(new ListNode<T> { Value = t, Count = 1 });

    public void InsertLast(T t) => _list.AddLast(new ListNode<T> { Value = t, Count = 1 });

    public ListNode<T>? FindNode(T t)
    {
        foreach (var node in _list)
        {
            /* Είναι ο τρόπος να συγκρίνουμε δύο τιμές για ισότητα σε generic κώδικα, όπου δεν ξέρουμε τι είναι το T.
             * Χρησιμοποιούμε το EqualityComparer<T>.Default.Equals για να συγκρίνουμε τις τιμές.
             *
             * if (node.Value == t)          // error CS0019: το == δεν ορίζεται για αδέσμευτο T
             * if (node.Value.Equals(t))     // compile-άρει, αλλά έχει δύο προβλήματα
             *
             * Το == δεν δουλεύει γιατί ο compiler δεν ξέρει αν το T έχει operator ==. Το .Equals() έχει δύο προβλήματα:
             *
             * Αν το node.Value είναι null, πετάει NullReferenceException.
             * Για value types (π.χ. int, structs) καλεί το object.Equals(object), άρα κάνει boxing σε κάθε σύγκριση.
             * το EqualityComparer<T>.Default
             *
             *   Το Default είναι ένα έτοιμο, cached αντικείμενο που επιλέγει την καλύτερη στρατηγική για το συγκεκριμένο T:
             *
             *   Αν το T υλοποιεί IEquatable<T> (όπως int, string, records), καλεί το Equals(T). Δεν γίνεται boxing.
             *   Αλλιώς, πέφτει στο object.Equals(object).
             *   Χειρίζεται σωστά τα null: δύο null είναι ίσα, ένα null με μη-null όχι, χωρίς exception.
             */
            if (EqualityComparer<T>.Default.Equals(node.Value, t))
                return node;
        }
        return null;
    }

    public void IncreaseCount(T t)
    {
        var node = FindNode(t);
        if (node is not null) node.Count++;
    }

    // Increment if present, otherwise append — single scan
    public void UpSert(T t)    // works like upsert: if exists, increment count; else, insert new node
    {
        var node = FindNode(t);
        if (node is null) InsertLast(t);
        else node.Count++;
    }

    public int TotalCount() => _list.Sum(n => n.Count);

    //public void SortByCount() => Reorder(_list.OrderByDescending(n => n.Count).ToList());

    public void SortByCount() => Reorder(_list.OrderByDescending(n => n.Count).ToList());
    public void SortByValueAsc() => Reorder(_list.OrderBy(n => n.Value).ToList());

    private void Reorder(List<ListNode<T>> sorted)
    {
        _list.Clear();
        foreach (var node in sorted)
            _list.AddLast(node);
    }

    public void Traverse()
    {
        if (IsEmpty)
        {
            Console.WriteLine("List is empty");
            return;
        }

        int total = TotalCount();
        foreach (var node in _list)
            Console.WriteLine($"Value: {node.Value} - Frequency: {node.Count / (double)total:P2}");
    }
}