using System;
using System.Collections.Generic;
using System.Text;

namespace PocoApp
{
    /// <summary>
    /// Defines a Course with auto-implemented properties for Id, Title and Description.
    /// Το CLR δημιουργεί αυτόματα private backing fields
    /// </summary>
    internal class Course
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public override string ToString() => 
            $"Id={Id}, Title={Title}, Description={Description}";
        

        public override bool Equals(object? obj)
        {
            return obj is Course course &&
                   Id == course.Id &&
                   Title == course.Title &&
                   Description == course.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, Description);
        }
    }
}
