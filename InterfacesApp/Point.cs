using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesApp
{
    internal class Point : AbstractPoint, IMoveable
    {
        public override string ToString() => $"X={X}";
    }
}
