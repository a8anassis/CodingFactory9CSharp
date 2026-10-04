using System.Collections;

namespace SingleLinkedList;

public class SLList<T> : IEnumerable<T>
{
    private Node? _head;

    public int Count { get; private set; }
    public bool IsEmpty => _head is null;

    public void InsertFirst(T t)
    {
        // 1. Δημιουργούμε τον κόμβο και ρυθμίζουμε τις τιμές του
        var tmp = new Node
        {
            Value = t,
            Next = _head
        };

        // 2. Ρυθμίζουμε τον head
        _head = tmp;
        Count++;
    }

    public void InsertLast(T t)
    {
        if (_head is null)
        {
            InsertFirst(t);
            return;
        }

        // 1. Δημιουργούμε τον κόμβο και ρυθμίζουμε τις τιμές του
        var tmp = new Node
        {
            Value = t,
            Next = null
        };

        // 2. Βρίσκουμε τον τελευταίο κόμβο ξεκινώντας από τον head, O(n)
        Node last = _head;
        while (last.Next is not null)
            last = last.Next;

        // 3. Συνδέουμε τον νέο κόμβο στο τέλος
        last.Next = tmp;
        Count++;
    }

    public T RemoveFirst()
    {
        if (_head is null)
            throw new InvalidOperationException("List is empty.");

        T value = _head.Value;
        _head = _head.Next;

        Count--;
        return value;
    }

    public T RemoveLast()
    {
        if (_head is null)
            throw new InvalidOperationException("List is empty.");

        // Ένα μόνο στοιχείο
        if (_head.Next is null)
            return RemoveFirst();

        // Βρίσκουμε τον προτελευταίο κόμβο, O(n)
        Node prev = _head;
        while (prev.Next!.Next is not null)
            prev = prev.Next;

        T value = prev.Next.Value;
        prev.Next = null;

        Count--;
        return value;
    }

    /* Το yield return παράγει αυτόματα τον IEnumerator<T> και δίνει την επόμενη τιμή
     * στο foreach.
     * Η κλήση του GetEnumerator() δεν εκτελεί το loop. 
     * Απλά επιστρέφει τον κέρσορα. 
     * Το loop τρέχει κομμάτι-κομμάτι, ένα βήμα σε κάθε MoveNext() που κάνει η foreach.
     * ο μηχανισμός που κάνει τη λίστα να δουλεύει με foreach χρειάζεται ένα μόνο πράγμα
     * μια μέθοδο GetEnumerator()
     */

    public IEnumerator<T> GetEnumerator()
    {
        for (var current = _head; current is not null; current = current.Next)
            yield return current.Value;
    }

    /*
     * Το interface IEnumerable<T> είναι το συμβόλαιο όπου στην .ΝΕΤ1 δεν είχε Generics
     * και για αυτό χρειάζεται και η παρακάτω γραμμή, αν θέλουμε το : IEnumerable<T> στην επικεφαλίδα της κλάσης.
     */
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private sealed class Node
    {
        // Στον generic κώδικα το default είναι η προεπιλεγμένη τιμή ενός τύπου
        public T Value { get; set; } = default!;
        public Node? Next { get; set; }
    }
}