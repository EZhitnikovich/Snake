namespace Snake.Model
{
    public class Point
    {
        public Point(int x, int y)
        {
            Y = y;
            X = x;
        }

        public int X { get; }
        public int Y { get; }

        public static Point operator +(Point p1, Point p2)
        {
            return new(p1.X + p2.X, p1.Y + p2.Y);
        }
    }
}