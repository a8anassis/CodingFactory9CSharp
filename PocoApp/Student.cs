using System; 
using System.Collections.Generic;
using System.Text;

namespace PocoApp
{
    internal class Student
    {
        private readonly int _id;
        private readonly string? _firstname;
        private readonly string? _lastname;

        public int Id { get { return _id; }  }
        public string? Firstname { get { return _firstname; }  }
        public string? Lastname { get { return _lastname; } }
    }
}
