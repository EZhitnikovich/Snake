using Snake.Enums;

namespace Snake.Models
{
    public class Cell
    {
        public Point Point { get; private set; }
        public CellType CellType { get; set; }
        
        public Cell(Point point)
        {
            Point = point;
        }

        public Cell(int x, int y)
        {
            Point = new Point(x, y);
        }

        public bool IsFruit => CellType.Equals(CellType.Fruit);
        public bool IsSnake => CellType.Equals(CellType.Snake);
        public bool IsAir => CellType.Equals(CellType.Air);
    }
}