using System;
using System.Collections.Generic;
using System.Text;

namespace FileManagement2
{
    internal class ListNode<T>
    {
        public required T Value { get; init; }
        public int Count { get; set; }
    }
}
