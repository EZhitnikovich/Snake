namespace Snake.Model.Cell
{
    internal class Cell
    {
        internal Cell(CellType cellType)
        {
            CellType = cellType;
        }

        public CellType CellType { get; set; }
        public bool IsSnake => CellType.Equals(CellType.Snake);
        public bool IsAir => CellType.Equals(CellType.Air);
        public bool IsApple => CellType.Equals(CellType.Apple);
    }
}