using System.Collections.Generic;
using System.Linq;
using Snake.Enums;

namespace Snake.Models
{
    public class Grid
    {
        private Cell[,] _cells;
        
        public int Width { get; }
        public int Height { get; }

        private Point _applePosition;
        
        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            _cells = new Cell[height, width];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    _cells[i, j] = new Cell(i, j);
                }
            }
        }

        public void UpdateSnakePosition(IEnumerable<Point> snakePoints)
        {
            foreach (var cell in _cells)
            {
                if (cell.IsSnake)
                {
                    cell.CellType = CellType.Air;
                }
            }

            foreach (var snakePoint in snakePoints)
            {
                _cells[snakePoint.X, snakePoint.Y].CellType = CellType.Snake;
            }
        }

        public void UpdateFruitPosition(Point apple)
        {
            if (_applePosition is null)
            {
                _applePosition = apple;
            }

            _cells[_applePosition.X, _applePosition.Y].CellType = CellType.Air;
            _cells[apple.X, apple.Y].CellType = CellType.Fruit;

            _applePosition = apple;
        }

        public CellType this[Point point] => _cells[point.Y, point.X].CellType;
        public CellType this[int x, int y] => _cells[y, x].CellType;
    }
}