namespace Snake.Model.Cell
{
    public class Cell
    {
        public Cell(CellType cellType)
        {
            CellType = cellType;
        }

        public CellType CellType { get; set; }
        public bool IsSnake => CellType.Equals(CellType.Snake);
        public bool IsAir => CellType.Equals(CellType.Air);
        public bool IsApple => CellType.Equals(CellType.Apple);
    }
}