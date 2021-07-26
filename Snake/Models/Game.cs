using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Snake.Enums;

namespace Snake.Models
{
    public class Game
    {
        public Grid Grid { get; }
        private List<Point> _snake;
        public bool IsAlive { get; private set; } = true;
        private Point _applePosition;
        
        public Game(Grid grid)
        {
            Grid = grid;
            _applePosition = new Point(Grid.Height/3, Grid.Height/3);
            _snake = new List<Point>() {new(Grid.Height / 2, grid.Width / 2)};
        }

        public void Move(Direction direction)
        {
            if(IsAlive == false)
                return;
            
            var head = _snake.Last();
            
            switch (direction)
            {
                case Direction.Down: head = head + new Point(0, 1); break;
                case Direction.Up: head = head + new Point(0, -1); break;
                case Direction.Left: head = head + new Point(-1, 0); break;
                case Direction.Right: head = head + new Point(1, 0); break;
            }

            var y = head.Y;
            var x = head.X;

            if (y < 0 || y > Grid.Width - 1 || x < 0 || x > Grid.Height - 1)
            {
                IsAlive = false;
                return;
            }
            
            if (head == _applePosition)
            {
                _snake.Add(head);
                GenerateFruitPosition();
            }
            else if (Grid[x, y].Equals(CellType.Air))
            {
                _snake.RemoveAt(0);
                _snake.Add(head);
            }

            using (var fs = new FileStream("a.txt", FileMode.Append))
            {
                fs.Write(Encoding.Default.GetBytes($"{head.X}, {head.Y} | {_applePosition.X}, {_applePosition.Y}\n"));
            }
        }

        public void UpdateFruitPosition()
        {
            Grid.UpdateFruitPosition(_applePosition);
        }

        public void UpdateSnakePosition()
        {
            Grid.UpdateSnakePosition(_snake);
        }

        private void GenerateFruitPosition()
        {
            var rand = new Random();
            
            _applePosition = new Point(rand.Next(0, Grid.Width), rand.Next(0, Grid.Height));
        }
    }
}