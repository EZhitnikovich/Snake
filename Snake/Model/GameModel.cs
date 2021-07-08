using System;
using System.Collections.Generic;
using System.Linq;
using Snake.Model.Cell;

namespace Snake.Model
{
    public class GameModel
    {
        private int _height;
        private int _width;
        public Cell.Cell[,] Grid { get; }
        private List<Point> _snake;
        private Direction _direction;
        private int apples;
        private Point _applePoint;

        public int SnakeLength;
        public bool IsAlive { get; private set; }
        
        public GameModel(int height, int width)
        {
            _height = height;
            _width = width;
            Grid = new Cell.Cell[height, width];
            
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Grid[i, j] = new Cell.Cell(CellType.Air);
                }
            }

            _direction = Direction.Right;
            
            _snake = new List<Point>();
            _applePoint = new Point(0,0);
            SnakeLength = 0;
            IsAlive = true;

            apples = 0;
            
            UpdateGrid();
        }

        public void UpdateSnakePosition(Direction direction)
        {
            _direction = direction;
            Point point = _snake.Last();
            
            switch (_direction)
            {
                case Direction.Down: point = point + new Point(1, 0); break;
                case Direction.Up: point = point + new Point(-1, 0); break;
                case Direction.Left: point = point + new Point(0, -1); break;
                case Direction.Right: point = point + new Point(0, 1); break;
            }

            int y = point.Y;
            int x = point.X;

            if (y < 0 || y > _width - 1 || x < 0 || x > _height - 1)
            {
                IsAlive = false;
                return;
            }
            
            if (Grid[x, y].CellType.Equals(CellType.Apple))
            {
                _snake.Add(point);
                SnakeLength++;
                apples = 0;
            }
            else if (Grid[x, y].CellType.Equals(CellType.Air))
            {
                _snake.RemoveAt(0);
                _snake.Add(point);
            }
            else
            {
                IsAlive = false;
            }
            
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            if (SnakeLength == 0)
            {
                int x = _width / 2;
                int y = _height / 2;
                _snake.Add(new Point(x,y));
                SnakeLength++;
            }

            if (apples == 0)
            {
                Random random = new Random();
                while (apples == 0)
                {
                    int x = random.Next(0, _width - 1);
                    int y = random.Next(0, _height - 1);
                    if (Grid[x, y].CellType.Equals(CellType.Air))
                    {
                        _applePoint = new Point(x, y);
                        Grid[x, y].CellType = CellType.Apple;
                        apples = 1;
                    }
                }
            }
            
            ClearGrid();
            
            foreach (var point in _snake)
            {
                Grid[point.X, point.Y].CellType = CellType.Snake;
            }

            Grid[_applePoint.X, _applePoint.Y].CellType = CellType.Apple;
        }

        private void ClearGrid()
        {
            foreach (var cell in Grid)
            {
                cell.CellType = CellType.Air;
            }
        }
    }
}