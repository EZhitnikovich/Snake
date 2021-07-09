using System;
using Snake.Model;
using Snake.Model.Cell;

namespace Snake.Controller
{
    public class GameController
    {
        private GameModel _gameModel;
        public Grid Grid;
        public bool IsAlive => _gameModel.IsAlive;
        
        public GameController(int height, int width)
        {
            Grid = new Grid(height, width);
            _gameModel = new GameModel(Grid);
        }

        public void Move(string direction)
        {
            Direction snakeDirection;

            switch (direction.ToLower())
            {
                case "up": snakeDirection = Direction.Up; break;
                case "down": snakeDirection = Direction.Down; break;
                case "left": snakeDirection = Direction.Left; break;
                case "right": snakeDirection = Direction.Right; break;
                default: throw new ArgumentException("Wrong direction", nameof(direction));
            }

            _gameModel.UpdateSnakePosition(snakeDirection);
        }
    }
}