namespace Snake.Model.Cell
{
    internal class Cell
    {
        internal Cell(CellType cellType)
        {
            CellType = cellType;
        }

        public CellType CellType { get; set; }
    }
}