using Godot;

namespace UsefulCode
{
    public struct Point2
    {
        public int X { get; }
        public int Y { get; }

        public Point2(int x, int y)
        {
            X = x;
            Y = y;
        }
		
        public Point2(Point2 p)
        {
            X = p.X;
            Y = p.Y;
        }
		
        public override string ToString()
        {
            return "Point2(" + X + ", " + Y + ")";
        }

        public static Point2 operator +(Point2 p1, Point2 p2)
        {
            return new Point2(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static Point2 operator -(Point2 p1, Point2 p2)
        {
            return new Point2(p1.X - p2.X, p1.Y - p2.Y);
        }
        public static Point2 operator *(Point2 p1, int v)
        {
            return new Point2(p1.X * v, p1.Y * v);
        }
		public static Point2 operator /(Point2 p1, int v)
        {
            return new Point2(p1.X / v, p1.Y / v);
        }
    }
}
