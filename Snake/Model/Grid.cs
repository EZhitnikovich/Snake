using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Snake.Model.Cell;

namespace Snake.Model
{
    public class Grid
    {
        private Cell.Cell[,] _cells;
        public int Height { get; }
        public int Width { get; }
        private IEnumerable<Point> _snakePosition;
        private Point _applePosition;

        public Grid(int height, int width)
        {
            Height = height;
            Width = width;
            _cells = new Cell.Cell[height, width];
            _snakePosition = new List<Point>();
            _applePosition = new Point(0,0);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    _cells[i, j] = new Cell.Cell(CellType.Air);
                }
            }
        }

        public CellType this[int x, int y]
        {
            get
            {
                if (x > Height - 1 || x < 0 || y > Width - 1 || y < 0)
                {
                    throw new IndexOutOfRangeException($"Max height {Height - 1}, Max width {Width - 1}; Min 0");
                }

                return _cells[x, y].CellType;
            }
        }

        public void UpdateSnakePosition(IEnumerable<Point> snake)
        {
            foreach (var point in _snakePosition)
            {
                _cells[point.X, point.Y].CellType = CellType.Air;
            }

            var snakePosition = snake.ToList();
            
            foreach (var point in snakePosition)
            {
                _cells[point.X, point.Y].CellType = CellType.Snake;
            }

            _snakePosition = snakePosition;
        }

        public void UpdateApplePosition(Point apple)
        {
            if(apple == _applePosition)
                return;

            _cells[_applePosition.X, _applePosition.Y].CellType = CellType.Air;
            _cells[apple.X, apple.Y].CellType = CellType.Apple;
        }
    }
}