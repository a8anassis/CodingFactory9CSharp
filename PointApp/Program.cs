using PointApp.Model;

namespace PointApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new(15);
            Point p2 = new Point2D(15, 18);
            Point p3 = new Point3D(15, 18, 20);

            DoMove5(p1);
            DoMove5(p2);
            DoMove5(p3);

            DoPrint(p1);
            DoPrint(p2);
            DoPrint(p3);
        }


        public static void DoMove5(Point p)
        {
            p.Move5();
        }

        public static void DoPrint(Point p)
        {
            Console.WriteLine(p.ToString());
        }

    }
}
