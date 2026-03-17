using System;
using System.Collections.Generic;
using System.Text;

namespace FileManagement
{
    internal class DLList<T>
    {
        private LinkedList<ListNode<T>> _list = new();

        public void InsertFirst(T t)
        {
            ListNode<T> node = new() { Value = t, Count = 1 };
            _list.AddFirst(node);
        }

        public void InsertLast(T t)
        {
            ListNode<T> node = new() { Value = t, Count = 1 };
            _list.AddLast(node);
        }

        public void Traverse(int totalChars)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
                return;
            }

            _list.ToList().ForEach(node => Console.WriteLine($"Value: {node.Value} - Frequency: " +
                $"{(node.Count / (double)totalChars):P2}"));
        }

        public ListNode<T>? FindNode(T t)
        {
            foreach (ListNode<T> node in _list)
            {
                if (node.Value != null && node.Value.Equals(t))
                {
                    return node;
                }
            }

            return null;
        }


        public void IncreaseCount(T t)
        {
            ListNode<T>? node = FindNode(t);
            if (node is null) return;
            node.Count++;
        }

        public void SortByCount()
        {
            _list = new LinkedList<ListNode<T>>(_list.OrderByDescending(n => n.Count));
        }


        public bool IsEmpty()
        {
            return _list.Count == 0;
        }

    }
}
