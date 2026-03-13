using System;
using System.Collections.Generic;
using System.Text;

namespace PointApp.Model
{
    internal class Point2D : Point
    {
        public int Y { get; set; }

        public Point2D() // : base()
        {
            // Y = 0;
        }

        public Point2D(int x, int y) : base(x)
        {
            Y = y;
        }

        public override string ToString() => $"X={X}, Y={Y}";

        public override void Move5()
        {
            base.Move5();
            Y += 5;       
        }
    }
}
