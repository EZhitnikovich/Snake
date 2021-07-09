using System;
using System.Collections.Generic;
using System.Linq;
using Snake.Model.Cell;

namespace Snake.Model
{
    public class GameModel
    {
        public Grid Grid { get; }
        private List<Point> _snake;
        private Direction _direction;
        private int apples;

        public bool IsAlive { get; private set; }
        
        public GameModel(Grid grid)
        {
            Grid = grid;
            
            _direction = Direction.Right;

            _snake = new List<Point>();
            _snake.Add(new Point(Grid.Height/2, Grid.Width/2));
            IsAlive = true;

            apples = 0;
            
            UpdateGrid();
        }

        public void UpdateSnakePosition(Direction direction)
        {
            _direction = direction;
            var head = _snake.Last();
            
            switch (_direction)
            {
                case Direction.Down: head = head + new Point(1, 0); break;
                case Direction.Up: head = head + new Point(-1, 0); break;
                case Direction.Left: head = head + new Point(0, -1); break;
                case Direction.Right: head = head + new Point(0, 1); break;
            }

            var y = head.Y;
            var x = head.X;

            if (y < 0 || y > Grid.Width - 1 || x < 0 || x > Grid.Height - 1)
            {
                IsAlive = false;
                return;
            }
            
            if (Grid[x, y].Equals(CellType.Apple))
            {
                _snake.Add(head);
                apples = 0;
            }
            else if (Grid[x, y].Equals(CellType.Air))
            {
                _snake.RemoveAt(0);
                _snake.Add(head);
            }
            else
            {
                IsAlive = false;
            }
            
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            var applePoint = SelectApplePosition();
            
            Grid.UpdateSnakePosition(_snake);
            Grid.UpdateApplePosition(applePoint);
        }

        private Point SelectApplePosition()
        {
            var applePoint = new Point(0, 0);
            
            if (apples == 0)
            {
                Random random = new Random();
                while (apples == 0)
                {
                    int x = random.Next(0, Grid.Width - 1);
                    int y = random.Next(0, Grid.Height - 1);
                    if (Grid[x, y].Equals(CellType.Air))
                    {
                        applePoint = new Point(x, y);
                        apples = 1;
                    }
                }
            }

            return applePoint;
        }
    }
}