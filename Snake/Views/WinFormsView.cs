using System.Drawing;
using System.Windows.Forms;
using Snake.Enums;
using Snake.Interfaces;
using Snake.Models;

namespace Snake.Views
{
    public class WinFormsView: IView
    {
        private Graphics _graphics;
        private readonly int _size;
        private readonly Color _fruitColor;
        private readonly Color _snakeColor;
        private readonly Color _airColor;

        public WinFormsView(Graphics graphics, int size, Color fruitColor, Color snakeColor, Color airColor)
        {
            _graphics = graphics;
            _size = size;
            _fruitColor = fruitColor;
            _snakeColor = snakeColor;
            _airColor = airColor;
        }

        public void Update(Grid grid)
        {
            for (int i = 0; i < grid.Height; i++)
            {
                for (int j = 0; j < grid.Width; j++)
                {
                    var brush = new SolidBrush(_airColor);
                    
                    if (grid[i, j] == CellType.Fruit)
                    {
                        brush.Color = _fruitColor;
                    }
                    if (grid[i, j] == CellType.Snake)
                    {
                        brush.Color = _snakeColor;
                    }
                    
                    _graphics.FillRectangle(brush, j * _size, i * _size, _size, _size);
                }
            }
        }

        public void Inform(string message)
        {
            _graphics.DrawString(message, new Font(new FontFamily("Arial"), 100), new SolidBrush(Color.Black), 0, 0);
        }
    }
}