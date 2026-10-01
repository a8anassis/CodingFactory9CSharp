using System;
using System.Collections.Generic;
using System.Text;

namespace OperatorOverloading
{
    internal class Point : IComparable<Point>, IEquatable<Point>
    {
        public int X { get; set; }

        public Point()
        {

        }

        public Point(int x)
        {
            X = x;
        }

        public static Point operator +(Point p1, Point p2)
        {
            ArgumentNullException.ThrowIfNull(p1);
            ArgumentNullException.ThrowIfNull(p2);
            return new Point(p1.X + p2.X);
        }

        public static Point operator -(Point p1, Point p2)
        {
            ArgumentNullException.ThrowIfNull(p1);
            ArgumentNullException.ThrowIfNull(p2);
            return new Point(p1.X - p2.X);
        }


        public int CompareTo(Point? other)
        {
            if (other is null) return 1;
            return X.CompareTo(other.X);
        }

        // Equality: Equals, GetHashCode and == / != must stay consistent.
        public bool Equals(Point? other) => other is not null && X == other.X;

        public override bool Equals(object? obj) => Equals(obj as Point);

        public override int GetHashCode() => HashCode.Combine(X);

        public override string ToString() => $"Point({X})";

        public static bool operator ==(Point? p1, Point? p2)
        {
            if (ReferenceEquals(p1, p2)) return true;
            if (p1 is null || p2 is null) return false;
            return p1.X == p2.X;
        }

        public static bool operator !=(Point? p1, Point? p2) => !(p1 == p2);

        // Comparison operators (null sorts before any non-null Point)
        public static bool operator <(Point? p1, Point? p2) => Compare(p1, p2) < 0;

        public static bool operator >(Point? p1, Point? p2) => Compare(p1, p2) > 0;

        public static bool operator <=(Point? p1, Point? p2) => Compare(p1, p2) <= 0;

        public static bool operator >=(Point? p1, Point? p2) => Compare(p1, p2) >= 0;

        private static int Compare(Point? p1, Point? p2)
        {
            if (ReferenceEquals(p1, p2)) return 0;
            if (p1 is null) return -1;
            return p1.CompareTo(p2);
        }
    }
}
